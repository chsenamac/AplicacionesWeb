use master
go

if exists(select *  from sysdatabases where name = 'BDAppWeb2022')
begin
	drop database BDAppWeb2022
end
go

create database BDAppWeb2022
go

use BDAppWeb2022
go

-- Tablas
create table Usuario
(
	cedula int not null,
	nombreCompleto varchar(50),
	nombreUsuario varchar(20) primary key
)
go

create table Mensaje
(
	numeroInterno int identity(0, 1),
	fechaGenerado datetime check(convert(date, fechaGenerado) <= convert(date, getdate())),
	asunto varchar(50),
	texto varchar(200),

	usuarioEmisor varchar(20) not null foreign key references Usuario(nombreUsuario),
	usuarioReceptor varchar(20) not null foreign key references Usuario(nombreUsuario),

	primary key(numeroInterno)
)
go

create table TipoMensaje
(
	codigoInterno varchar(3) primary key check(codigoInterno like '[A-Z][A-Z][A-Z]'),
	nombre varchar(20)
)
go

create table Comun
(
	numeroInternoMC int foreign key references Mensaje(numeroInterno),
	codigoInternoTM varchar(3) not null foreign key references TipoMensaje(codigoInterno)

	primary key(numeroInternoMC)
)
go

create table Privado
(
	numeroInternoMP int foreign key references Mensaje(numeroInterno),
	fechaCaducidad datetime,
	
	primary key(numeroInternoMP)
)
go

-- PROCEDIMIENTOS ALMACENADOS

create procedure AltaUsuario
@cedula int,
@nombreCompleto varchar(50),
@nombreUsuario varchar(20)
as
begin
	if exists(select * from Usuario where nombreUsuario = @nombreUsuario)
		return -1
	
	insert Usuario(cedula, nombreCompleto, nombreUsuario) 
	values(@cedula, @nombreCompleto, @nombreUsuario)

	if @@error = 0
		return 1
	else 
		return -2
	
end
go

create procedure ModificarUsuario
@cedula int,
@nombreCompleto varchar(50),
@nombreUsuario varchar(20)
as
begin
	if not exists(select * from Usuario where nombreUsuario = @nombreUsuario)
		return -1
		
	update Usuario
	set cedula = @cedula,
		nombreCompleto = @nombreCompleto
	where nombreUsuario = @nombreUsuario

	if @@error = 0 
		return 1
	else
		return -2
end
go

create procedure EliminarUsuario
@nombreusuario varchar(20)
as
begin
	if not exists(select * from Usuario where nombreUsuario = @nombreUsuario)
		return -1
	
	if exists (select * from Mensaje where usuarioReceptor = @nombreUsuario or usuarioEmisor = @nombreUsuario)
		return -2
	
	delete usuario
	where nombreUsuario = @nombreUsuario
	
	if @@error = 0
		return 1
	else
		return -3
end
go

create procedure BuscarUsuario
@nombreUsuario varchar(20)
as
begin
	select * from Usuario where nombreUsuario = @nombreUsuario
end
go

create procedure ListadoUsuarios
as
begin
	select * from Usuario
end
go

create procedure AltaTipoMensaje
@codigoInterno varchar(3),
@nombre varchar(20)
as
begin
	if exists(select * from TipoMensaje where codigoInterno = @codigoInterno)
		return -1
	
	insert TipoMensaje(codigoInterno, nombre) 
	values(@codigoInterno, @nombre)
	
	if @@error = 0
		return 1
	else 
		return -2
end
go

create procedure ModificarTipoMensaje
@codigoInterno varchar(3),
@nombre varchar(20)
as
begin 
	if not exists(select * from TipoMensaje where codigoInterno = @codigoInterno)
		return -1
	
	update TipoMensaje
	set nombre = @nombre
	where codigoInterno = @codigoInterno
	
	if @@error = 0
		return 1
	else 
		return -2
end
go

create procedure EliminarTipoMensaje
@codigoInterno varchar(3)
as
begin
	if not exists(select * from TipoMensaje where codigoInterno = @codigoInterno)
		return -1
	
	if exists (select * from Comun where codigoInternoTM = @codigoInterno)
		return -2
	
	delete TipoMensaje
	where codigoInterno = @codigoInterno
	
	if @@error = 0
		return 1
	else
		return -3
end
go

create procedure BuscarTipoMensaje
@codigoInterno varchar(3)
as
begin
	select * from TipoMensaje where codigoInterno = @codigoInterno
end
go

create procedure ListadoTipoMensajes
as
begin
	select * from TipoMensaje
end
go

create procedure AgregarMensajeComun
@asunto varchar(50),
@texto varchar(200),
@usuarioEmisor varchar(20),
@usuarioReceptor varchar(20),
@codigoInternoMensaje varchar(3)
as
begin
	declare @numeroInternoGenerado int

	if not exists(select * from Usuario where nombreUsuario = @usuarioEmisor)
		return -1
	
	if not exists(select * from Usuario where nombreUsuario = @usuarioReceptor)
		return -2

	if not exists(select * from TipoMensaje where codigoInterno = @codigoInternoMensaje)
		return -3

	begin transaction
		
		insert Mensaje(fechaGenerado, asunto, texto, usuarioEmisor, usuarioReceptor)
		values(getdate(), @asunto, @texto, @usuarioEmisor, @usuarioReceptor)
		
		if @@error <> 0
		begin
			rollback transaction
			return -4
		end
		
		set @numeroInternoGenerado = @@identity
		insert Comun(numeroInternoMC, codigoInternoTM) values(@numeroInternoGenerado, @codigoInternoMensaje)
		
		if @@error <> 0
		begin
			rollback transaction
			return -4
		end
		 	
	commit transaction

	return @numeroInternoGenerado
end
go

create procedure AgregarMensajePrivado
@asunto varchar(50),
@texto varchar(200),
@usuarioEmisor varchar(20),
@usuarioReceptor varchar(20),
@fechaCaducidad datetime
as
begin
	declare @numeroInternoGenerado int

	if(@fechaCaducidad <= getdate())
		return -1

	if not exists(select * from Usuario where nombreUsuario = @usuarioEmisor)
		return -2
	
	if not exists(select * from Usuario where nombreUsuario = @usuarioReceptor)
		return -3

	insert Mensaje(fechaGenerado, asunto, texto, usuarioEmisor, usuarioReceptor)
	values(getdate(), @asunto, @texto, @usuarioEmisor, @usuarioReceptor)
	
	set @numeroInternoGenerado = @@identity

	insert Privado(numeroInternoMP, fechaCaducidad) values(@numeroInternoGenerado, @fechaCaducidad)
	
	if @@error = 0
		return @numeroInternoGenerado
	else 
		return -4
end
go

create procedure ListadoMensajeComunUsuario
@nombreUsuario varchar(20),
@codigoInternoTM varchar(3),
@enviaRecibe bit
as
begin
	if @enviaRecibe = 0
		select * from Mensaje
		inner join Comun
		on Mensaje.numeroInterno = Comun.numeroInternoMC
		where Mensaje.usuarioEmisor = @nombreUsuario
		and Comun.codigoInternoTM = @codigoInternoTM
	else 
		select * from Mensaje
		inner join Comun
		on Mensaje.numeroInterno = Comun.numeroInternoMC
		where Mensaje.usuarioReceptor = @nombreUsuario	
		and Comun.codigoInternoTM = @codigoInternoTM
	end
go


create procedure ListadoMensajePrivadoUsuario
@nombreUsuario varchar(20),
@enviaRecibe bit
as
begin
	if @enviaRecibe = 0
		select * from Mensaje
		inner join Privado
		on Mensaje.numeroInterno = Privado.numeroInternoMP
		where Mensaje.usuarioEmisor = @nombreUsuario
		and Privado.fechaCaducidad >= dateadd(day,-2,getdate())
	else 
		select * from Mensaje
		inner join Privado
		on Mensaje.numeroInterno = Privado.numeroInternoMP
		where Mensaje.usuarioReceptor = @nombreUsuario
		and Privado.fechaCaducidad >= dateadd(day,-2,getdate())
	end
go

--PRUEBAS
exec AltaUsuario 31899838, 'Christiams Sena Machado', 'csenamac'
exec AltaUsuario 49855585, 'Sofia Sena Altez', 'ssenaalt'
exec AltaUsuario 55597016, 'Agustin Sena Altez', 'asenaalt'
exec AltaUsuario 51586140, 'Candela Hernandez', 'chernandez'
exec AltaUsuario 12345678, 'Jose Sabia', 'JSabia'

exec AltaTipoMensaje 'URG', 'Urgente'
exec AltaTipoMensaje 'EVT', 'Evento'
exec AltaTipoMensaje 'ITC', 'Invitacion'
exec AltaTipoMensaje 'PRB', 'Prueba'

exec AgregarMensajeComun 'Prueba mensaje comun 01', 'Mensaje comun 01', 'csenamac', 'asenaalt', 'URG'
exec AgregarMensajeComun 'Prueba mensaje comun 02', 'Mensaje comun 02', 'csenamac', 'asenaalt', 'URG'
exec AgregarMensajeComun 'Prueba mensaje comun 03', 'Mensaje comun 03', 'csenamac', 'asenaalt', 'ITC'
exec AgregarMensajeComun 'Prueba mensaje comun 04', 'Mensaje comun 04', 'csenamac', 'asenaalt', 'URG'
exec AgregarMensajeComun 'Prueba mensaje comun 05', 'Mensaje comun 05', 'csenamac', 'asenaalt', 'EVT'
exec AgregarMensajeComun 'Prueba mensaje comun 06', 'Mensaje comun 06', 'csenamac', 'asenaalt', 'ITC'
exec AgregarMensajeComun 'Prueba mensaje comun 07', 'Mensaje comun 07', 'csenamac', 'asenaalt', 'URG'
exec AgregarMensajeComun 'Prueba mensaje comun 08', 'Mensaje comun 08', 'csenamac', 'asenaalt', 'EVT'

declare @fechaCaducidad datetime
set @fechaCaducidad = dateadd(day, 2, getdate())

exec AgregarMensajePrivado 'Prueba mensaje privado 001', 'Mensaje privado 001', 'ssenaalt', 'chernandez', @fechaCaducidad
exec AgregarMensajePrivado 'Prueba mensaje privado 002', 'Mensaje privado 002', 'ssenaalt', 'chernandez', @fechaCaducidad
exec AgregarMensajePrivado 'Prueba mensaje privado 003', 'Mensaje privado 003', 'ssenaalt', 'chernandez', @fechaCaducidad
exec AgregarMensajePrivado 'Prueba mensaje privado 004', 'Mensaje privado 004', 'ssenaalt', 'chernandez', @fechaCaducidad