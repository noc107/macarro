/* 
DESARROLLO DEL SOFTWARE
INTEGRANTES:    BASTIDAS, YINDRI
				BUCHERENICK, YOLYMAR 
                CARRERA, ROXANA 
                                  
PROFESOR:       CARLO MAGURNO
*/

/*--------------------------------------------------------------------------------------- 
                                        PROCEDURE
-----------------------------------------------------------------------------------------*/ 
use MACARRO
go
begin transaction;
go

/*--------------------------------------INSERTAR LUGAR--------------------------*/
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
@tipoDocIdentidad [varchar] (100),
@primerNombre [varchar] (100),
@segundoNombre [varchar](100),
@primerApellido [varchar] (100),
@segundoApellido [varchar] (100),
@fechaNacimiento [date],
@Fk_lugar [int],

@correo [varchar] (100),
@contrasena [varchar] (100),
@tipo [varchar] (100), 
@estado [varchar] (100),
@fechaIngreso [date],
@fechaEgreso [date],
@preguntaSeguridad [varchar] (100),
@respuestaSeguridad [varchar] (100),
@fkPersona [varchar] (100)

AS
BEGIN
	INSERT INTO [dbo].[PERSONA] (PER_docIdentidad,PER_tipoDocIdentidad,PER_primerNombre,
PER_segundoNombre,PER_primerApellido,PER_segundoApellido,PER_fechaNacimiento,FK_lugar) VALUES
(@docIdentidad,@tipoDocIdentidad,@primerNombre,@segundoNombre,@primerApellido,@segundoApellido,@fechaNacimiento,@Fk_lugar)

	INSERT INTO [dbo].[USUARIO] (USU_correo,USU_contrasena,USU_tipo,USU_estado,USU_fechaIngreso,USU_fechaEgreso,
CLI_preguntaSeguridad,CLI_respuestaSeguridad,FK_persona) VALUES (@correo,@contrasena,@tipo,@estado,@fechaIngreso,
@fechaEgreso,@preguntaSeguridad,@respuestaSeguridad,@fkPersona)
END;
go

/*--------------------------------------CONSULTAR PERSONA CLIENTE--------------------------*/
CREATE PROCEDURE [dbo].[Procedure_consultarCliente]
@correo [varchar] (100)

AS
BEGIN

	SELECT PER_docIdentidad, PER_tipoDocIdentidad, PER_primerNombre, PER_segundoNombre, PER_primerApellido,
		   PER_segundoApellido, PER_fechaNacimiento,USU_correo, CLI_preguntaSeguridad, CLI_respuestaSeguridad, LD.LUG_id, LD.LUG_nombre, LC.LUG_id, LC.LUG_nombre,
		    LE.LUG_id, LE.LUG_nombre, LP.LUG_id, LP.LUG_nombre
	FROM PERSONA AS P, USUARIO AS U, LUGAR AS LD, LUGAR AS LC,LUGAR AS LE,LUGAR AS LP
	WHERE (USU_correo = @correo  AND FK_persona = PER_docIdentidad) AND  (P.FK_lugar = LD.LUG_id) AND (LD.FK_lugar = LC.LUG_id) AND (LC.FK_lugar =  LE.LUG_id)
		AND (LE.FK_lugar = LP.LUG_id) 

END;

/*--------------------------------------DESACTIVAR Y ACTIVAR CUENTA--------------------------------*/
CREATE PROCEDURE [dbo].[Procedure_activarDesactivarUSUARIO]
@correo [varchar] (50),
@estado [varchar] (20)
AS
BEGIN

     UPDATE USUARIO 
     SET USU_estado = @estado
     WHERE USU_correo = @correo
END;

/*-------------------------------------CONSULTAR PREGUNTA SEGURIDAD-------------------------------------*/
CREATE PROCEDURE [dbo].[Procedure_consultarPreguntaSeguridad]
@correo [varchar] (50)

AS
BEGIN
	SELECT CLI_preguntaSeguridad, CLI_respuestaSeguridad 
	FROM USUARIO 
	WHERE USU_correo = @correo
END;

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
'Perez', 'Ortega', '02/12/1987', 7, 'rubenalej@gmail.com', 'Ruben123.',
'Cliente', 'Activado', null, null, '¿Cuál es la ciudad de nacimiento su madre?', 
'Caracas', '18293923';

EXEC Procedure_insertarClienteEmpleado '17293840', 'Cedula', 'Manuel', 'Jose', 
'Sanchez', 'Hurtado', '03/01/1988', 8, 'manueljos@hotmail.com', 'Manu123.',
'Cliente', 'Activado', null, null, '¿Cuál es el nombre del colegio donde estudio?', 
'colegio San Agustín', '17293840';

EXEC Procedure_insertarClienteEmpleado '7283928', 'Cedula', 'Mariana', 'Carolina', 
'Marcano', 'Sosa', '12/12/1967', 9, 'marianacarol@gmail.com', 'Mari123.', 
'Cliente', 'Activado', null, null, '¿Cuál es la profesión de su abuela materna?', 
'Licenciada', '7283928';

EXEC Procedure_insertarClienteEmpleado '20238394', 'Cedula', 'Leyda', null, 'Castro', 
'Centeno', '11/08/1994', 10, 'leydacenteno@gmail.com', 'Leyda123.', 'Cliente', 
'Activado', null, null, '¿Cuál era su caricatura favorita en su infancia?', 'Vaca y Pollito', 
'20238394';

EXEC Procedure_insertarClienteEmpleado '17282930', 'Cedula', 'Juan', 'Manuel', 
'Rodriguez', 'Serrano', '10/18/1980', 11, 'juanmanuel@gmail.com', 'Juan123.', 
'Cliente', 'Activado', null, null, '¿Cuál es el segundo nombre de su padre?', 
'Manuel', '17282930';

EXEC Procedure_insertarClienteEmpleado '092583247', 'Pasaporte', 'Yolymar', 'Alejandra', 
'Bucherenick', 'Ortuno', '08/29/1991', 12, 'ybucherenick@gmail.com', 
'Yoly123.', 'Cliente', 'Activado', null, null, '¿Cuál es el nombre de su abuelo paterno?', 
'Enrique', '092583247';

commit transaction;
go