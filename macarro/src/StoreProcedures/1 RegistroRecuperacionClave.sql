use MACARRO
go
begin transaction;
go
CREATE SEQUENCE PERSONA_SEQ
    START WITH 1
    INCREMENT BY 1;
GO
CREATE SEQUENCE USUARIO_SEQ
    START WITH 1
    INCREMENT BY 1;
GO

--------------------------- CONSULTAR DOCUMENTO DE IDENTIDAD:-----------------------------READY-----
CREATE PROCEDURE [dbo].Procedure_consultarDocIdentificacion
    @docIdentificacion [varchar] (100),
    @tipoDocIdentificacion [varchar] (100)
    --Este tipo debe coincidir con (5,6)
AS
BEGIN
    SELECT p.PER_docIdentidad
    from PERSONA as p, USUARIO as u
    where   @docIdentificacion = p.PER_docIdentidad and 
            @tipoDocIdentificacion = p.FK_estadoTipoDoc and 
            p.PER_id = u.FK_persona and 
            u.FK_estadoTipo = 3;
END;
go
-----------------------------------------------------------------------------------------------------

-------------------------------------- REGISTRAR CLIENTE:-------------------------------------READY--
/*
CREATE PROCEDURE [dbo].[Procedure_RegistrarCliente]
@nombreLugar [varchar] (100),

@docIdentidad [varchar] (100),
@tipoDocIdentidad [varchar] (100),
@primerNombre [varchar] (100),
@segundoNombre [varchar](100),
@primerApellido [varchar] (100),
@segundoApellido [varchar] (100),
@fechaNacimiento [datetime],
@telefono [varchar] (100),
@correo [varchar] (100),
@contrasena [varchar] (100),
@preguntaSeguridad [varchar] (100),
@respuestaSeguridad [varchar] (100)

AS
BEGIN
    DECLARE @tipoDoc int;
    DECLARE @idLugar int;
    DECLARE @tipoLugar varchar (100);
    DECLARE @fkLugar int;
    DECLARE @tipo int;
    DECLARE @estado int;
    DECLARE @fechaIngreso date;
    DECLARE @fechaEgreso date;
    DECLARE @IDpersona int;

    SET @tipoDoc = (select EST_id from ESTADO where EST_nombre = @tipoDocIdentidad and EST_pertenece ='Identificacion');
    SET @idLugar = (select max(LUG_id) from LUGAR) + 1;
    SET @tipoLugar = 'Direccion';
    SET @fkLugar = NULL;
    SET @tipo = (select EST_id from ESTADO where EST_nombre = 'Cliente' and EST_pertenece ='Usuario');
    SET @estado = (select EST_id from ESTADO where EST_nombre = 'Activado' and EST_pertenece ='General');
    SET @fechaIngreso = NULL;
    SET @fechaEgreso = NULL;
    SET @IDpersona = NEXT VALUE FOR PERSONA_SEQ;

    INSERT INTO [dbo].[LUGAR] (LUG_id, LUG_nombre, LUG_tipo, FK_lugar) VALUES (@idLugar, @nombreLugar, @tipoLugar, @fkLugar);

    INSERT INTO [dbo].[PERSONA] (PER_id,PER_docIdentidad,PER_primerNombre,PER_segundoNombre,PER_primerApellido,
                                PER_segundoApellido,PER_fechaNacimiento,PER_telefono,FK_estadoTipoDoc,FK_lugar) VALUES
(@IDpersona,@docIdentidad,@primerNombre,@segundoNombre,@primerApellido,@segundoApellido,@fechaNacimiento,@telefono,@tipoDoc,@idLugar);

    INSERT INTO [dbo].[USUARIO] (USU_correo,USU_contrasena,FK_estadoTipo,FK_estado,USU_fechaIngreso,USU_fechaEgreso,
CLI_preguntaSeguridad,CLI_respuestaSeguridad,FK_persona) VALUES (NEXT VALUE FOR USUARIO_SEQ,@correo,@contrasena,@tipo,@estado,@fechaIngreso,
@fechaEgreso,@preguntaSeguridad,@respuestaSeguridad,@IDpersona);
END;
go
*/
-----------------------------------------------------------------------------------------------------

-------------------------------------- CAMBIAR CONTRASEÑA: -----------------------------------READY--
CREATE PROCEDURE [dbo].Procedure_CambiarContrasena01
       @IDusuario [int],
       @usuario [varchar] (100),
       @nuevaClave [varchar] (100)   
      
AS 
BEGIN 
     
UPDATE USUARIO
   SET USU_contrasena = @nuevaClave
       WHERE USU_correo = @usuario and USU_id = @IDusuario

END;
go
-----------------------------------------------------------------------------------------------------

-------------------------------------- OBTENER RESPUESTA: -----------------------------------READY---
CREATE PROCEDURE [dbo].Procedure_ObtenerRespuesta
    @usuario [varchar] (100)
AS
BEGIN
    DECLARE @tipo int;
    SET @tipo = (select EST_id from ESTADO where EST_nombre = 'Cliente' and EST_pertenece ='Usuario');

    DECLARE @estado int
    SET @estado = (select EST_id from ESTADO where EST_nombre = 'Activado' and EST_pertenece ='General');

    SELECT u.CLI_respuestaSeguridad
    from USUARIO as u
    where @usuario = u.USU_correo and u.FK_estadoTipo = @tipo and u.FK_estado = @estado
END;
go
-----------------------------------------------------------------------------------------------------

-------------------------------------- OBTENER PREGUNTA: --------------------------------------READY-
CREATE PROCEDURE [dbo].Procedure_ObtenerPregunta
    @usuario [varchar] (100)
AS
BEGIN
    DECLARE @tipo int;
    SET @tipo = (select EST_id from ESTADO where EST_nombre = 'Cliente' and EST_pertenece ='Usuario');

    DECLARE @estado int
    SET @estado = (select EST_id from ESTADO where EST_nombre = 'Activado' and EST_pertenece ='General');

    SELECT u.CLI_preguntaSeguridad
    from USUARIO as u
    where @usuario = u.USU_correo and u.FK_estadoTipo = @tipo and u.FK_estado = @estado
END;
go

-----------------------------------------------------------------------------------------------------

-------------------------- VERIFICAR CORREO ELECTRÓNICO: --------------------------------------READY-
CREATE PROCEDURE [dbo].Procedure_VerificarCorreoE01
    @usuario [varchar] (100)
AS
BEGIN
    DECLARE @tipo int;
    SET @tipo = (select EST_id from ESTADO where EST_nombre = 'Cliente' and EST_pertenece ='Usuario');

    DECLARE @estado int
    SET @estado = (select EST_id from ESTADO where EST_nombre = 'Activado' and EST_pertenece ='General');

    SELECT u.USU_correo
    from USUARIO as u
    where @usuario = u.USU_correo and u.FK_estadoTipo = @tipo and u.FK_estado = @estado
END;
go 
-----------------------------------------------------------------------------------------------------

-------------------------- VERIFICAR CORREO ELECTRÓNICO: --------------------------------------READY-
CREATE PROCEDURE [dbo].Procedure_VerificarCorreo01
    @usuario [varchar] (100)
AS
BEGIN
    DECLARE @tipo int;
    SET @tipo = (select EST_id from ESTADO where EST_nombre = 'Cliente' and EST_pertenece ='Usuario');

    DECLARE @estado int
    SET @estado = (select EST_id from ESTADO where EST_nombre = 'Activado' and EST_pertenece ='General');

    SELECT u.USU_correo
    from USUARIO as u
    where @usuario = u.USU_correo and u.FK_estadoTipo = @tipo and u.FK_estado = @estado
END;
go
-----------------------------------------------------------------------------------------------------

-------------------------- VERIFICAR CONSULTAR CLAVE-CLIENTE--------------------------------READY----
CREATE PROCEDURE [dbo].[Procedure_consultarClienteClave]
    @usuario [varchar] (100),
    @clave [varchar] (100)
AS
BEGIN
    DECLARE @tipo int;
    SET @tipo = (select EST_id from ESTADO where EST_nombre = 'Cliente' and EST_pertenece ='Usuario');

    DECLARE @estado int
    SET @estado = (select EST_id from ESTADO where EST_nombre = 'Activado' and EST_pertenece ='General');

    SELECT p.PER_primerNombre, p.PER_primerApellido, p.PER_docIdentidad, u.USU_correo, u.USU_id, p.PER_id
    from PERSONA as p, USUARIO as u
    where @usuario = u.USU_correo and @clave = u.USU_contrasena and p.PER_id = u.FK_persona 
    and u.FK_estadoTipo = @tipo and u.FK_estado = @estado
END;
go
-----------------------------------------------------------------------------------------------------

-------------------------- VERIFICAR CONSULTAR CLAVE-EMPLEADO---------------------------------READY--
CREATE PROCEDURE [dbo].[Procedure_consultarEmpleadoClave]
    @usuario [varchar] (100),
    @clave [varchar] (100)
AS
BEGIN
DECLARE @tipo int;
    SET @tipo = (select EST_id from ESTADO where EST_nombre = 'Cliente' and EST_pertenece ='Usuario');

    DECLARE @estado int
    SET @estado = (select EST_id from ESTADO where EST_nombre = 'Activado' and EST_pertenece ='General');

    SELECT p.PER_primerNombre, p.PER_primerApellido, p.PER_docIdentidad, u.USU_correo,u.USU_id, p.PER_id
    from PERSONA as p, USUARIO as u
    where @usuario = u.USU_correo and @clave = u.USU_contrasena and p.PER_id = u.FK_persona 
    and u.FK_estadoTipo = @tipo and u.FK_estado = @estado
END;
go
-----------------------------------------------------------------------------------------------------


/*--------------------------------------INSERTAR LUGAR------------------------READY--*/
CREATE PROCEDURE [dbo].[Procedure_insertarLugar]
	@idLugar [int],
	@nombreLugar [nvarchar](100),
	@tipoLugar [nvarchar](100),
	@fkLugar [int]
AS
BEGIN
    INSERT INTO [dbo].[LUGAR](LUG_id, LUG_nombre, LUG_tipo, FK_lugar)
    VALUES(@idLugar, @nombreLugar, @tipoLugar, @fkLugar)
END;
go

/*--------------------------------------INSERTAR CLIENTE EMPLEADO--------------------------*/
CREATE PROCEDURE [dbo].[Procedure_insertarClienteEmpleado]
@docIdentidad [varchar] (100),
@estadoTipoDoc [varchar] (100),
@primerNombre [varchar] (100),
@segundoNombre [varchar](100),
@primerApellido [varchar] (100),
@segundoApellido [varchar] (100),
@fechaNacimiento [datetime],
@Fk_lugar [int],
@correo [varchar] (100),
@contrasena [varchar] (100),
@estadoTipo [varchar] (100), 
@Elestado [varchar] (100),
@fechaIngreso [datetime],
@fechaEgreso [datetime],
@preguntaSeguridad [varchar] (100),
@respuestaSeguridad [varchar] (100),
@telefono [varchar] (100)

AS
BEGIN
DECLARE @tipoDoc int;
DECLARE @tipo int;
DECLARE @estado int;
DECLARE @IDpersona int;

SET @IDpersona = NEXT VALUE FOR PERSONA_SEQ;
SET @tipoDoc = (select EST_id from ESTADO where EST_nombre = @estadoTipoDoc and EST_pertenece ='Identificacion');
SET @tipo = (select EST_id from ESTADO where EST_nombre = @estadoTipo and EST_pertenece ='Usuario');
SET @estado = (select EST_id from ESTADO where EST_nombre = @Elestado and EST_pertenece ='General');

    INSERT INTO [dbo].[PERSONA] (PER_id,PER_docIdentidad,PER_primerNombre,
PER_segundoNombre,PER_primerApellido,PER_segundoApellido,PER_fechaNacimiento,PER_telefono,FK_estadoTipoDoc,FK_lugar) VALUES
(@IDpersona,@docIdentidad,@primerNombre,@segundoNombre,@primerApellido,@segundoApellido,@fechaNacimiento,@telefono,@tipoDoc,@Fk_lugar)

    INSERT INTO [dbo].[USUARIO] (USU_id,USU_correo,USU_contrasena,FK_estadoTipo,FK_estado,USU_fechaIngreso,USU_fechaEgreso,
CLI_preguntaSeguridad,CLI_respuestaSeguridad,FK_persona) VALUES (NEXT VALUE FOR USUARIO_SEQ,@correo,@contrasena,@tipo,@estado,@fechaIngreso,
@fechaEgreso,@preguntaSeguridad,@respuestaSeguridad,@IDpersona)
END;
go

/*--------------------------------------CONSULTAR PERSONA CLIENTE--------------------READY---*/
CREATE PROCEDURE [dbo].[Procedure_consultarCliente]
@correo [varchar] (100)

AS
BEGIN
    DECLARE @tipo int;
    SET @tipo = (select EST_id from ESTADO where EST_nombre = 'Cliente' and EST_pertenece ='Usuario');
    
    SELECT PER_docIdentidad, FK_estadoTipoDoc, PER_primerNombre, PER_segundoNombre, PER_primerApellido,
           PER_segundoApellido, PER_fechaNacimiento,USU_correo, CLI_preguntaSeguridad, CLI_respuestaSeguridad, L.LUG_id, L.LUG_nombre, L.LUG_tipo
    FROM PERSONA AS P, USUARIO AS U, LUGAR AS L
    WHERE U.USU_correo = @correo AND U.FK_persona = P.PER_id AND P.FK_lugar = L.LUG_id and U.FK_estadoTipo = @tipo

END;
go
/*--------------------------------------DESACTIVAR Y ACTIVAR CUENTA------------------------READY----*/
CREATE PROCEDURE [dbo].[Procedure_activarDesactivarUSUARIO]
@correo [varchar] (50),
@estado [varchar] (20)
AS
BEGIN

    DECLARE @Elestado int
    SET @Elestado = (select EST_id from ESTADO where EST_nombre = @estado and EST_pertenece ='General');

     UPDATE USUARIO 
     SET FK_estado = @estado
     WHERE USU_correo = @correo
END;
go
/*-------------------------------------CONSULTAR PREGUNTA SEGURIDAD-------------------------------------*/
CREATE PROCEDURE [dbo].[Procedure_consultarPreguntaSeguridad]
@correo [varchar] (50)

AS
BEGIN
	SELECT CLI_preguntaSeguridad, CLI_respuestaSeguridad 
	FROM USUARIO 
	WHERE USU_correo = @correo
END;
go
/*---------------------------------------MODIFICAR CONTRASEÑA-------------------------------------------*/
CREATE PROCEDURE [dbo].[Procedure_cambiarContrasena]
@correo [varchar] (50),
@contrasena [varchar] (50)
AS
BEGIN

     UPDATE USUARIO 
     SET USU_contrasena = @contrasena
     WHERE USU_correo = @correo
END;
go


/*CREATE PROCEDURE [dbo].[Procedure_consultarDireccionContrasena]
@docIdentidad [varchar] (50)

AS
BEGIN

    SELECT USU_contrasena,FK_lugar
    FROM PERSONA AS P, USUARIO AS U
    WHERE PER_docIdentidad = @docIdentidad AND FK_persona = @docIdentidad

END;

go
*/
----------------------------------------------------------------
CREATE PROCEDURE [dbo].[Procedure_consultarDireccion]
@docIdentidad [varchar] (50)

AS
BEGIN

    SELECT p.FK_lugar
    FROM PERSONA AS P, USUARIO AS U
    WHERE p.PER_docIdentidad = @docIdentidad AND u.USU_id = p.PER_id

END;

go
----------------------------------------------------------------
CREATE PROCEDURE [dbo].[Procedure_consultarContrasena]
@correo [varchar] (50)

AS
BEGIN

    SELECT USU_contrasena
    FROM  USUARIO AS U
    WHERE USU_correo = @correo

END;

go
-----------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[Procedure_modificarCliente]
@lugarId [int],
@docIdentidad [varchar] (50),
@primerNombre [varchar] (50),
@segundoNombre [varchar] (50),
@primerApellido [varchar] (50),
@segundoApellido [varchar] (50),
@fechaNacimiento [datetime],
@correo [varchar] (50),
@contrasena [varchar] (50),
@preguntaSeguridad [varchar] (50),
@respuestaSeguridad [varchar] (50),
@lugarp[varchar] (100)


AS
BEGIN

     UPDATE PERSONA 
     SET PER_primerNombre = @primerNombre,
         PER_segundoNombre = @segundoNombre,
         PER_primerApellido = @primerApellido,
         PER_segundoApellido = @segundoApellido,
         PER_fechaNacimiento = @fechaNacimiento
     WHERE PER_docIdentidad = @docIdentidad
           
     UPDATE USUARIO 
     SET USU_contrasena = @contrasena,
           CLI_preguntaSeguridad = @preguntaSeguridad,
           CLI_respuestaSeguridad = @respuestaSeguridad
     WHERE USU_correo = @correo

     UPDATE LUGAR
     SET LUG_nombre = @lugarp
     WHERE LUG_id = @lugarId
END;
go
/*--------------------------------------------------------------------------------------- 
                                        INSERT
-----------------------------------------------------------------------------------------*/ 
/*--------------------------------------------------------------------------------------- 
                                        LUGAR
-----------------------------------------------------------------------------------------*/


EXEC Procedure_insertarLugar 1, 'Venezuela', 'País', NULL;

EXEC Procedure_insertarLugar 2, 'Dtto Capital', 'Estado', 1;

EXEC Procedure_insertarLugar 3, 'Mirada', 'Estado', 2;

EXEC Procedure_insertarLugar 4, 'Caracas', 'Ciudad', 2;

EXEC Procedure_insertarLugar  5, 'Los Teques', 'Ciudad', 3;

EXEC Procedure_insertarLugar  6, 'Guarenas', 'Ciudad', 3;

EXEC Procedure_insertarLugar 7, 'Parroquia Caricuao UD 3, Bloque 6, piso 1, apt 01', 'Direccion', 4;

EXEC Procedure_insertarLugar  8, 'Parroquia San Juan, Bloque 16, piso 4, apt 04', 'Direccion', 4;

EXEC Procedure_insertarLugar 9, 'Parroquia Altagracia, Edif 3, piso 8, apt 07', 'Direccion', 4;

EXEC Procedure_insertarLugar 10, 'Parroquia Candelaria, edif 8, piso 15, apt 05', 'Direccion', 4;

EXEC Procedure_insertarLugar 11, 'Parroquia San pedro, residencia Virgen María, Casa # 3', 'Direccion', 5;

EXEC Procedure_insertarLugar 12, 'Zona industrial de Cloris Urb. Terrazas del Este, Primera Etapa, edif 20, apt 3-2', 
							 'Direccion', 6;

/*--------------------------------------------------------------------------------------- 
                                        PERSONA - USUARIO
-----------------------------------------------------------------------------------------*/ 

EXEC Procedure_insertarClienteEmpleado '18293923', 'Cedula', 'Ruben', 'Alenjadro', 
'Perez', 'Ortega', '02-12-1987', 7, 'rubenalej@gmail.com', '736f907006c60320b8b8a643c21af99b',
'Cliente', 'Activado', null, null, '¿Cuál es la ciudad de nacimiento su madre?', 
'Caracas','0412-369-65-16';
/*clave Ruben123*/


EXEC Procedure_insertarClienteEmpleado '17293840', 'Cedula', 'Manuel', 'Jose', 
'Sanchez', 'Hurtado', '03-01-1988', 8, 'manueljos@hotmail.com', '1a715d422dbc1e399c325e68d667e37a',
'Cliente', 'Activado', null, null, '¿Cuál es el nombre del colegio donde estudio?', 
'colegio San Agustín', '04128547844';
/*clave Manu123*/
EXEC Procedure_insertarClienteEmpleado '7283928', 'Cedula', 'Mariana', 'Carolina', 
'Marcano', 'Sosa', '12-12-1967', 9, 'marianacarol@gmail.com', '17bcc025953711a979d446104dfd46d5', 
'Cliente', 'Activado', null, null, '¿Cuál es la profesión de su abuela materna?', 
'Licenciada', '02127895487';
/*Clave Mari123*/
EXEC Procedure_insertarClienteEmpleado '20238394', 'Cedula', 'Leyda', null, 'Castro', 
'Centeno', '11-08-1994', 10, 'leydacenteno@gmail.com', 'c49600113542f2479f7ca195a8e638a5', 'Cliente', 
'Activado', null, null, '¿Cuál era su caricatura favorita en su infancia?', 'Vaca y Pollito', 
'0219896545';
/*Clave Leyda123*/
EXEC Procedure_insertarClienteEmpleado '17282930', 'Cedula', 'Juan', 'Manuel', 
'Rodriguez', 'Serrano', '10-18-1980', 11, 'juanmanuel@gmail.com', 'a31add0c8535719a165e2fad450c4cf6', 
'Cliente', 'Activado', null, null, '¿Cuál es el segundo nombre de su padre?', 
'Manuel', '0412548965';
/*Clave Juan123*/
EXEC Procedure_insertarClienteEmpleado '092583247', 'Pasaporte', 'Yolymar', 'Alejandra', 
'Bucherenick', 'Ortuno', '08-29-1991', 12, 'ybucherenick@gmail.com', 
'cbf2997a7f96a7a45a556bb083c0698a9', 'Cliente', 'Activado', null, null, '¿Cuál es el nombre de su abuelo paterno?', 
'Enrique', '04167453354';
/*Clave Yoly123*/
commit transaction;
go