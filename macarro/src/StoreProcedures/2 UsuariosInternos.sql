/*--------------------------------------------------------------------------------------- 
                                        MODULO USUARIOS INTERNOS
-----------------------------------------------------------------------------------------*/ 

/*--------------------------------------------------------------------------------------- 
                                        LUGAR
-----------------------------------------------------------------------------------------*/
use MACARRO
go
begin transaction;
go
/*---------------------------------------------------------------------*/


/*---------------------------------------------------------------------*/

/*
DROP PROCEDURE Procedure_verificarCorreo;
DROP PROCEDURE Procedure_verificarDocIdentidad;
DROP PROCEDURE Procedure_eliminarEmpleadoNuevo;
DROP PROCEDURE Procedure_agregarEmpleadoInterfaz;
DROP PROCEDURE Procedure_modificarUsuario;
DROP PROCEDURE Procedure_agregarLugar;
DROP PROCEDURE Procedure_agregarEmpleado;
DROP PROCEDURE Procedure_modificarEstadoUsuario;
DROP PROCEDURE Procedure_llenarCBPais;
DROP PROCEDURE Procedure_llenarCBEstado;
DROP PROCEDURE Procedure_llenarCBCiudad;
DROP PROCEDURE Procedure_agregarRolesUsuario;
DROP PROCEDURE Procedure_eliminarRolesUsuario;
DROP PROCEDURE Procedure_obtenerRolesSinAsignar;
DROP PROCEDURE Procedure_consultarTodosEmpleados;
DROP PROCEDURE Procedure_consultarEmpleadoUnico;
DROP PROCEDURE Procedure_consultarEmpleado;
DROP PROCEDURE Procedure_consultarRolesEmpleado;
DROP PROCEDURE Procedure_obtenerRolesUsuario;
DROP PROCEDURE Procedure_consultarDireccionCompleta;
*/

/*---------------------------------------------------------------------*/




CREATE PROCEDURE Procedure_verificarCorreo
		@correo	[nvarchar](100)  
AS 
BEGIN
		SELECT COUNT(*) as existeCorreo FROM USUARIO WHERE USU_correo = @correo;
END;

GO
/*---------------------------------------------------------------------*/
CREATE PROCEDURE Procedure_verificarDocIdentidad
		@docIdentidad	[nvarchar](100)  
AS 
BEGIN
		SELECT COUNT(*) as existeCedula FROM PERSONA WHERE PER_docIdentidad = @docIdentidad;
END;

go

/*---------------------------------------------------------------------*/
CREATE PROCEDURE Procedure_eliminarEmpleadoNuevo
@correo varchar (100)
AS
DECLARE 
@idPersona varchar (100)
BEGIN
select @idPersona = FK_persona from USUARIO where USU_correo = @correo
delete from USUARIO where USU_correo = @correo;
delete from persona where PER_docIdentidad = @idPersona;

END;

go

/*---------------------------------------------------------------------*/


CREATE PROCEDURE Procedure_agregarEmpleadoInterfaz
@docIdentidad [varchar] (100),
@tipoDocIdentidad [varchar] (100),
@primerNombre [varchar] (100),
@segundoNombre [varchar](100),
@primerApellido [varchar] (100),
@segundoApellido [varchar] (100),
@fechaNacimiento [varchar] (100),
@telefono [varchar] (100), 

@idCiudad [int],
@nombreLugar [varchar] (100),

@correo [varchar] (100),
@contrasena [varchar] (100),

@estatus [varchar] (100),
@fechaIngreso [varchar] (100),
@fechaEgreso [varchar] (100)

AS
DECLARE @idMaxLugar int = 0
DECLARE @idPersona int = 0 
BEGIN
    select @idMaxLugar = Max(LUG_id) from lugar;

    set @idMaxLugar = @idMaxLugar + 1;

    INSERT INTO lugar VALUES (@idMaxLugar,@nombreLugar,'Direccion',@idCiudad);

	set @idPersona = NEXT VALUE FOR PERSONA_SEQ; 
	
	IF (@tipoDocIdentidad='Cedula')
		BEGIN
			INSERT INTO PERSONA (PER_id,PER_docIdentidad,PER_primerNombre,
			PER_segundoNombre,PER_primerApellido,PER_segundoApellido,PER_fechaNacimiento,PER_telefono,FK_estadoTipoDoc,FK_lugar) VALUES
			(@idPersona,@docIdentidad ,@primerNombre,@segundoNombre,@primerApellido,@segundoApellido,@fechaNacimiento,@telefono,5,@idMaxLugar);
        END 
	ELSE 
		BEGIN
			INSERT INTO PERSONA (PER_id,PER_docIdentidad,PER_primerNombre,
			PER_segundoNombre,PER_primerApellido,PER_segundoApellido,PER_fechaNacimiento,PER_telefono,FK_estadoTipoDoc,FK_lugar) VALUES
			(@idPersona,@docIdentidad ,@primerNombre,@segundoNombre,@primerApellido,@segundoApellido,@fechaNacimiento,@telefono,6,@idMaxLugar);
		END
	
			INSERT INTO USUARIO (USU_id,USU_correo,USU_contrasena,USU_fechaIngreso,USU_fechaEgreso,CLI_preguntaSeguridad,CLI_respuestaSeguridad,FK_estadoTipo,FK_estado,FK_persona) 
			VALUES (NEXT VALUE FOR USUARIO_SEQ,@correo,@contrasena,@fechaIngreso,@fechaEgreso,'','',4,1,@idPersona);
	
	
		
	
END;
go


--------------------------------------------------------------------------------------------------------*/
 CREATE PROCEDURE Procedure_modificarUsuario

@docIdentidad [varchar] (100),
@primerNombre [varchar] (100),
@segundoNombre [varchar](100),
@primerApellido [varchar] (100),
@segundoApellido [varchar] (100),
@fechaNacimiento [varchar] (100),
@telefono        [varchar] (100),
@tipoDocIdentidad [varchar] (100),
 
@idCiudad [int],
@correo [varchar] (100),
@contrasena [varchar] (100),
@estatus [varchar] (100),
@fechaEgreso [varchar] (100),
@nombreLugar [varchar](100)

as

Declare @idLugarDireccion [int] = 0
DECLARE @idMaxLugar [int] = 0
DECLARE @idPersona [int] = 0
begin

	select @idLugarDireccion = LUG_id from lugar where LUG_nombre = @nombreLugar and LUG_tipo = 'Direccion' and FK_lugar = @idCiudad;

	if (@idLugarDireccion = 0)
		begin 
			select @idMaxLugar = MAX(LUG_id) from lugar;

			set @idMaxLugar = @idMaxLugar + 1;

			INSERT INTO lugar VALUES (@idMaxLugar,@nombreLugar,'Direccion',@idCiudad);

			set @idLugarDireccion = @idMaxLugar;
		end
	
	SELECT @idPersona=PER_id FROM PERSONA WHERE PER_docIdentidad  = @docIdentidad; 
	
	
    IF (@tipoDocIdentidad='Cedula')   
		BEGIN 
			UPDATE PERSONA
				SET 
				   PER_primerNombre      = @primerNombre,
				   PER_segundoNombre     = @segundoNombre,
				   PER_primerApellido    = @primerApellido,   
				   PER_segundoApellido   = @segundoApellido,
				   PER_fechaNacimiento   = Convert(varchar(100),@fechaNacimiento,110),
				   PER_telefono          = @telefono,
				   FK_estadoTipoDoc      = 5,
				   FK_lugar				 = @idLugarDireccion
				WHERE 
				   PER_docIdentidad      = @docIdentidad;
       	END 
		
	ELSE	
		BEGIN
			UPDATE PERSONA
				SET 
				   PER_primerNombre      = @primerNombre,
				   PER_segundoNombre     = @segundoNombre,
				   PER_primerApellido    = @primerApellido,   
				   PER_segundoApellido   = @segundoApellido,
				   PER_fechaNacimiento   = Convert(varchar(100),@fechaNacimiento,110),
				   PER_telefono          = @telefono,
				   FK_estadoTipoDoc      = 6,
				   FK_lugar				 = @idLugarDireccion
				WHERE 
				   PER_docIdentidad      = @docIdentidad;
		END 
    
    IF (@estatus = '1')
		BEGIN
			UPDATE USUARIO
			SET 
			   USU_contrasena      	 = @contrasena,
			   FK_estadoTipo         = 4,
			   FK_estado     		 = 1,
			   USU_fechaEgreso  	 = ''   

			WHERE 
					USU_correo      	  = @correo 
			   AND  FK_persona            = @idPersona; 
		END
	IF (@estatus = '2')
		BEGIN
			UPDATE USUARIO
			SET 
			   USU_contrasena      	 = @contrasena,
			   FK_estadoTipo         = 4,
			   FK_estado     		 = 2,
			   USU_fechaEgreso  	 = Convert(varchar(100),@fechaEgreso,110)   

			WHERE 
					USU_correo      	  = @correo 
			   AND  FK_persona            = @idPersona; 
		END
		
	ELSE
		BEGIN
			UPDATE USUARIO
			SET 
			   USU_contrasena      	 = @contrasena,
			   FK_estadoTipo         = 4,
			   
			   USU_fechaEgreso  	 = Convert(varchar(100),@fechaEgreso,110)   

			WHERE 
					USU_correo      	  = @correo 
			   AND  FK_persona            = @idPersona;
		END
		
    
 
end;


go 
-----------------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE Procedure_perfilUsuario
@IdPer [int],
@docIdentidad [varchar] (100),
@primerNombre [varchar] (100),
@segundoNombre [varchar](100),
@primerApellido [varchar] (100),
@segundoApellido [varchar] (100),
@fechaNacimiento [varchar] (100),
@telefono        [varchar] (100),

 
@idCiudad [int],
@correo [varchar] (100),
@contrasena [varchar] (100),


@nombreLugar [varchar](100)

as

Declare @idLugarDireccion [int] = 0
DECLARE @idMaxLugar [int] = 0

begin

	select @idLugarDireccion = LUG_id from lugar where LUG_nombre = @nombreLugar and LUG_tipo = 'Direccion' and FK_lugar = @idCiudad;

	if (@idLugarDireccion = 0)
		begin 
			select @idMaxLugar = MAX(LUG_id) from lugar;

			set @idMaxLugar = @idMaxLugar + 1;

			INSERT INTO lugar VALUES (@idMaxLugar,@nombreLugar,'Direccion',@idCiudad);

			set @idLugarDireccion = @idMaxLugar;
		end
	
	
	
	
    
			UPDATE PERSONA
				SET 
				   PER_primerNombre      = @primerNombre,
				   PER_segundoNombre     = @segundoNombre,
				   PER_primerApellido    = @primerApellido,   
				   PER_segundoApellido   = @segundoApellido,
				   PER_fechaNacimiento   = Convert(varchar(100),@fechaNacimiento,110),
				   PER_telefono          = @telefono,
				   PER_docIdentidad      = @docIdentidad, 
				   FK_lugar				 = @idLugarDireccion
				WHERE 
				   PER_id = @IdPer; 
       	
		
	
		
		
    
 
			UPDATE USUARIO
			SET 
			   USU_contrasena      	 = @contrasena,
			   USU_correo      	     = @correo   

			WHERE 
					FK_persona            = @IdPer; 
	
		
		
		
    
 
end;
go
-----------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE Procedure_agregarLugar
	@idLugar [int],
	@nombreLugar [nvarchar](100),
	@tipoLugar [nvarchar](100),
	@fkLugar [int]
AS
BEGIN
    INSERT INTO LUGAR(LUG_id, LUG_nombre, LUG_tipo, FK_lugar)
    VALUES(@idLugar, @nombreLugar, @tipoLugar, @fkLugar)
END;

go 
/*---------------------------------------------------------------------*/

CREATE PROCEDURE Procedure_agregarEmpleado
@docIdentidad [varchar] (100),
@tipoDocIdentidad [varchar] (100),
@primerNombre [varchar] (100),
@segundoNombre [varchar](100),
@primerApellido [varchar] (100),
@segundoApellido [varchar] (100),
@fechaNacimiento [varchar] (100),
@telefono [varchar] (100), 

@fkLugar [int],


@correo [varchar] (100),
@contrasena [varchar] (100),


@fechaIngreso [varchar] (100),
@fechaEgreso [varchar] (100)

AS

DECLARE @idPersona int = 0 
BEGIN
    

	set @idPersona = NEXT VALUE FOR PERSONA_SEQ; 
	
	IF (@tipoDocIdentidad='Cedula')
		BEGIN
			INSERT INTO PERSONA (PER_id,PER_docIdentidad,PER_primerNombre,
			PER_segundoNombre,PER_primerApellido,PER_segundoApellido,PER_fechaNacimiento,PER_telefono,FK_estadoTipoDoc,FK_lugar) VALUES
			(@idPersona,@docIdentidad ,@primerNombre,@segundoNombre,@primerApellido,@segundoApellido,@fechaNacimiento,@telefono,5,@fkLugar);
        END 
	ELSE 
		BEGIN
			INSERT INTO PERSONA (PER_id,PER_docIdentidad,PER_primerNombre,
			PER_segundoNombre,PER_primerApellido,PER_segundoApellido,PER_fechaNacimiento,PER_telefono,FK_estadoTipoDoc,FK_lugar) VALUES
			(@idPersona,@docIdentidad ,@primerNombre,@segundoNombre,@primerApellido,@segundoApellido,@fechaNacimiento,@telefono,6,@fkLugar);
		END
	
	
			INSERT INTO USUARIO (USU_id,USU_correo,USU_contrasena,USU_fechaIngreso,USU_fechaEgreso,CLI_preguntaSeguridad,CLI_respuestaSeguridad,FK_estadoTipo,FK_estado,FK_persona) 
			VALUES (NEXT VALUE FOR USUARIO_SEQ,@correo,@contrasena,@fechaIngreso,@fechaEgreso,'','',4,1,@idPersona);
	
	
		
	
END;
go

/*---------------------------------------------------------------------*/
 CREATE PROCEDURE Procedure_modificarEstadoUsuario
(@docIdentidad [varchar] (100))
AS
DECLARE @idPersona int = 0
DECLARE @estadoActual int = 0
BEGIN

	SELECT @idPersona = PER_id 
	FROM   PERSONA 
	WHERE  PER_docIdentidad=@docIdentidad; 
	
	SELECT @estadoActual = u.FK_estado    
	FROM   PERSONA as p, USUARIO as u 
	WHERE  u.FK_persona=p.PER_id and				
		   p.PER_docIdentidad=@docIdentidad; 
	
	IF (@estadoActual=1)
		BEGIN
			Update USUARIO 
					set FK_estado = 2,
						USU_fechaEgreso = SYSDATETIME()
								
					WHERE FK_persona = @idPersona;
		END
	ELSE
		BEGIN
			Update USUARIO 
					set FK_estado = 1,
					USU_fechaEgreso = null			
					WHERE FK_persona = @idPersona;
		END
END;
go

CREATE PROCEDURE Procedure_llenarCBPais
AS
BEGIN
	   SELECT LUG_id, LUG_nombre
	   FROM LUGAR
	   WHERE LUG_tipo = 'País';
END;

go
/*---------------------------------------------------------------------*/
CREATE PROCEDURE Procedure_llenarCBEstado
(@idPais  [int])
AS
BEGIN
	   SELECT E.LUG_id, E.LUG_nombre 
	   FROM LUGAR E
	   WHERE E.LUG_tipo = 'Estado' and E.FK_lugar = @idPais;
END;

go 

/*---------------------------------------------------------------------*/
CREATE PROCEDURE Procedure_llenarCBCiudad
(@idEstado  [int])
AS
BEGIN
	   SELECT C.LUG_id, C.LUG_nombre 
	   FROM LUGAR C
	   WHERE C.LUG_tipo = 'Ciudad' and C.FK_lugar = @idEstado;
END;

go

CREATE PROCEDURE Procedure_llenarCBEstatusUsuario
AS

SELECT 
		EST_id     as IdEstado, 	
		EST_nombre as Estado
		FROM ESTADO 
		WHERE 
			EST_pertenece = 'General';
go

/*---------------------------------------------------------------------*/

CREATE PROCEDURE Procedure_agregarRolesUsuario
(@correo [varchar] (100),
 @idRol [int])
AS
DECLARE
@verificarRol [int] = 0
BEGIN
        if ((select R.ROL_id
    	from ROL R
    	where R.ROL_id = @idRol and  (@idRol not in (select FK_rol
                          from USUARIO_ROL 
                          where FK_usuario = @correo))) is not null)

		begin 
			set @verificarRol = @idRol;
		end;
	    if (@verificarRol != 0)
		begin 
			INSERT INTO USUARIO_ROL VALUES (@correo,@idRol);
		end;
END;

go

/*---------------------------------------------------------------------*/
CREATE PROCEDURE Procedure_eliminarRolesUsuario
(@correo [varchar] (100),
 @idRol [int])
AS
DECLARE
@verificarRol [int] = 0
BEGIN

	select @verificarRol = UR.FK_rol 
    from USUARIO_ROL UR
    where UR.FK_usuario = @correo and @idRol in (select FK_rol 
                                                from USUARIO_ROL 
                                                where FK_usuario = @correo);

	if (@verificarRol != 0)
		begin 
			DELETE FROM USUARIO_ROL where FK_usuario = @correo and FK_Rol = @idRol;
		end
END;

go
/*---------------------------------------------------------------------*/
CREATE PROCEDURE Procedure_obtenerRolesSinAsignar
(@correo [varchar] (100))
AS
BEGIN
	select distinct ROL_id, ROL_nombre from  ROL
	where ROL_id not in (select FK_rol from USUARIO_ROL where FK_usuario = @correo)
END;

go

/*---------------------------------------------------------------------*/
CREATE PROCEDURE Procedure_consultarTodosEmpleados
AS 
SELECT	P.PER_id as Idpersona,
		E.EST_nombre as NombreDoc,
		P.PER_docIdentidad as DocIdentidad,
		P.PER_primerNombre as Pnombre,
		P.PER_segundoNombre as Snombre,
		P.PER_primerApellido as Papellido,
		P.PER_segundoApellido as Sapellido,
		P.PER_fechaNacimiento as Fnacimiento,
		P.PER_telefono as Telf,
		U.USU_correo as Correo, 
		U.USU_fechaIngreso as Fingreso,
		U.USU_fechaEgreso as Fegreso,
		(L4.LUG_tipo +': '+ L4.LUG_nombre + ', ' + L3.LUG_tipo +': '+L3.LUG_nombre + ', ' +L2.LUG_tipo+': '+ L2.LUG_nombre + ', '+L1.LUG_tipo+':'+ L1.LUG_nombre) as Direccion 
FROM	PERSONA as P,
		USUARIO as U, 
		ESTADO as E, 
		LUGAR as L4, 
		LUGAR as L3, 
		LUGAR as L2, 
		LUGAR as L1
WHERE	U.FK_estadoTipo=4  AND 
		P.PER_id=U.FK_persona AND
		P.FK_estadoTipoDoc=E.EST_id AND 
		L4.LUG_id=P.FK_lugar AND 
		L3.LUG_id=L4.FK_lugar AND 
		L2.LUG_id=L3.FK_lugar AND 
		L1.LUG_id=L2.FK_lugar;
go
/*---------------------------------------------------------------------*/


CREATE PROCEDURE Procedure_consultarEmpleadoUnico 
(
    @IdPer int
)           
AS
SELECT	P.PER_id as Idpersona,
		E.EST_nombre as NombreDoc,
		P.PER_docIdentidad as DocIdentidad,
		P.PER_primerNombre as Pnombre,
		P.PER_segundoNombre as Snombre,
		P.PER_primerApellido as Papellido,
		P.PER_segundoApellido as Sapellido,
		P.PER_fechaNacimiento as Fnacimiento,
		P.PER_telefono as Telf,
		U.USU_correo as Correo,
		EU.EST_nombre as Estatus, 
		U.USU_fechaIngreso as Fingreso,
		U.USU_fechaEgreso as Fegreso,
		(L4.LUG_tipo +': '+ L4.LUG_nombre + ', ' + L3.LUG_tipo +': '+L3.LUG_nombre + ', ' +L2.LUG_tipo+': '+ L2.LUG_nombre + ', '+L1.LUG_tipo+':'+ L1.LUG_nombre) as Direccion,
		P.FK_lugar as FkLugar 
FROM	PERSONA as P,
		USUARIO as U, 
		ESTADO as E, 
		ESTADO as EU,
		LUGAR as L4, 
		LUGAR as L3, 
		LUGAR as L2, 
		LUGAR as L1
WHERE	U.FK_estadoTipo=4  AND 
		P.PER_id=U.FK_persona AND
		P.FK_estadoTipoDoc=E.EST_id AND 
		U.FK_estado = EU.EST_id AND
		L4.LUG_id=P.FK_lugar AND 
		L3.LUG_id=L4.FK_lugar AND 
		L2.LUG_id=L3.FK_lugar AND 
		L1.LUG_id=L2.FK_lugar AND
		P.PER_id=@IdPer;

Go


/*--------------------------------------------------------------*/
CREATE PROCEDURE Procedure_consultarEmpleado 
(
    @busqueda varchar (100)
)           
AS
SELECT	DISTINCT (P.PER_id) as Idpersona,
		P.PER_docIdentidad as DocIdentidad,
		P.PER_primerNombre as Pnombre,
		P.PER_segundoNombre as Snombre,
		P.PER_primerApellido as Papellido,
		P.PER_segundoApellido as Sapellido
FROM	PERSONA as P,
		USUARIO as U 
		
WHERE	U.FK_estadoTipo=4  AND 
        U.FK_estado = 1    AND 
		P.PER_id=U.FK_persona AND
		( UPPER(P.PER_primerNombre) LIKE UPPER(@busqueda) + '%') OR
		( UPPER(P.PER_primerApellido) LIKE UPPER(@busqueda) + '%')
ORDER BY P.PER_primerApellido;
		

Go



/*--------------------------------------------------------------*/

CREATE PROCEDURE Procedure_consultarRolesEmpleado
(@IdPer [int])
AS
SELECT	R.ROL_nombre as NombreRol
FROM    USUARIO_ROL US,
        ROL R,
	USUARIO U

WHERE   R.ROL_id=US.FK_rol     AND
		U.FK_estadoTipo=4      AND
        US.FK_usuario=U.USU_id AND
		U.USU_id=@IdPer;

go

/*---------------------------------------------------------------------*/
CREATE PROCEDURE Procedure_obtenerRolesUsuario
(@IdPer [int])
AS
BEGIN
    SELECT  R.ROL_nombre
    FROM    USUARIO_ROL US,
            ROL R
    WHERE   R.ROL_id=US.FK_rol AND
            US.FK_usuario=@Idper
END;

go

/*---------------------------------------------------------------------*/
CREATE PROCEDURE Procedure_consultarDireccionCompleta
(@idDireccion  [int])
AS
BEGIN


       SELECT C.LUG_id FROM LUGAR C, LUGAR D WHERE C.LUG_id = D.FK_lugar and D.LUG_id = @idDireccion and C.LUG_tipo ='Ciudad'
       union
	   SELECT E.LUG_id FROM LUGAR E, LUGAR C WHERE E.LUG_id = C.FK_lugar and C.LUG_id = 
       (SELECT C.LUG_id FROM LUGAR C, LUGAR D WHERE C.LUG_id = D.FK_lugar and D.LUG_id = @idDireccion) and E.LUG_tipo = 'Estado'
       union
       SELECT P.LUG_id FROM LUGAR P, LUGAR E WHERE P.LUG_id = E.FK_lugar and E.LUG_id =
       (SELECT E.LUG_id FROM LUGAR E, LUGAR C WHERE E.LUG_id = C.FK_lugar and C.LUG_id = 
       (SELECT C.LUG_id FROM LUGAR C, LUGAR D WHERE C.LUG_id = D.FK_lugar and D.LUG_id = @idDireccion)) and P.LUG_tipo = 'País'

END;
go

CREATE PROCEDURE Procedure_obtenerDireccion
(@idDireccion  [int])
AS
BEGIN
	   SELECT D.LUG_nombre 
	   FROM LUGAR D
	   WHERE D.LUG_tipo = 'Direccion' and D.LUG_id = @idDireccion;
END;
go


----------------------------------------------------------------------------------------				
----------------------------EXECUTE DE LUGAR-DIRECCIONES DE PROVEEDOR-------------------

            EXEC Procedure_insertarLugar 
            @idLugar       = 13,
            @nombreLugar  = 'Parroquia Caricuao, Calle A, Local Q, Coche', 
            @tipoLugar     = 'Direccion',
            @fkLugar  =	4;	
			GO

            EXEC Procedure_insertarLugar 
            @idLugar      = 14,
            @nombreLugar = 'Parroquia San Juan, Calle C, Local 34, Santa Rosa de Lima',
            @tipoLugar    = 'Direccion',
            @fkLugar = 4;	
			GO

            EXEC Procedure_insertarLugar 
            @idLugar      = 15,
            @nombreLugar = 'Parroquia Altagracia, Calle Guaicaipuro, Local 76, Bello Monte',
            @tipoLugar    = 'Direccion',
            @fkLugar = 4;	
			GO

            EXEC Procedure_insertarLugar 
            @idLugar      = 16, 
            @nombreLugar = 'Parroquia Candelaria, De Tablitas A Sordo, Parcelas 2-5, Los Ruices',
            @tipoLugar    = 'Direccion',
            @fkLugar = 4;	
			GO

            EXEC Procedure_insertarLugar 
            @idLugar      = 17,
            @nombreLugar = 'Parroquia San Pedro, Avenida Principal de Lomas de Prados del Este, Indialca, Alto Prado',
            @tipoLugar    = 'Direccion',
            @fkLugar = 5;			
			GO





INSERT INTO LUGAR VALUES (18,'Estados Unidos','País',null);
go
INSERT INTO LUGAR VALUES (19,'Florida','Estado',18);
go
INSERT INTO LUGAR VALUES (20,'Georgia','Estado',18);
go
INSERT INTO LUGAR VALUES (21,'Jacksonville','Ciudad',19);
go
INSERT INTO LUGAR VALUES (22,'Miami','Ciudad',19);
go
INSERT INTO LUGAR VALUES (23,'Atlanta','Ciudad',20);
go
INSERT INTO LUGAR VALUES (24,'Eastport Apartments, The 11701 Palm Lake Drive Jacksonville, FL 32218-3985','Direccion',21);
go
INSERT INTO LUGAR VALUES (25,'La Esperanza 3800 University Blvd S Jacksonville, FL 32216-4328','Direccion',21);
go
INSERT INTO LUGAR VALUES (26,'1231 PENNSYLVANIA AV 10','Direccion',22);
go
INSERT INTO LUGAR VALUES (27,'1250 WEST AV 10D','Direccion',22);
go
INSERT INTO LUGAR VALUES (28,'415 Fairburn Rd SW Atlanta, GA 30331-1996','Direccion',23);
go
INSERT INTO LUGAR VALUES (29,'1800 Windridge Dr Sandy Springs, GA 30350-2873','Direccion',23);

/*--------------------------------------------------------------------------------------- 
                                        PERSONA
-----------------------------------------------------------------------------------------*/ 
go
INSERT INTO PERSONA VALUES (NEXT VALUE FOR PERSONA_SEQ,'20304050','Amanda','','Rodriguez','Gomez','04/01/1985','0412-1234567',5,24);
go
INSERT INTO PERSONA VALUES (NEXT VALUE FOR PERSONA_SEQ,'11123456','Alejandro','Daniel','Vieira','Machado','05/06/1983','0414-1234679',5,25);
go
INSERT INTO PERSONA VALUES (NEXT VALUE FOR PERSONA_SEQ,'9876243','Vanessa','Gabriela','Martinez','Lozano','11/11/1987','0416-6789012',5,26);
go
INSERT INTO PERSONA VALUES (NEXT VALUE FOR PERSONA_SEQ,'12333444','Pablo','David','Westphal','Juvinao','08/11/1987','0424-4567890',5,27);
go
INSERT INTO PERSONA VALUES (NEXT VALUE FOR PERSONA_SEQ,'17111940','Andrea','Paola','Gonzales','Crespo','10/18/1980','0426-3579123',5,28);
go
INSERT INTO PERSONA VALUES (NEXT VALUE FOR PERSONA_SEQ,'13141516','Gabriel','','Gonzales','Contreras','08/28/1991','0412-1864132',5,29);


/*
-----------------  Todas las contrasenas son Admin123 -----------------------
*/
go
INSERT INTO USUARIO VALUES (NEXT VALUE FOR USUARIO_SEQ,'amandaRodriguez@gmail.com','21232f297a57a5a743894a0e4a801fc3','01/01/2014','','','',4,1,7);
go
INSERT INTO USUARIO VALUES (NEXT VALUE FOR USUARIO_SEQ,'alejandroVieira@gmail.com','21232f297a57a5a743894a0e4a801fc3','01/01/2014','','','',4,1,8);
go
INSERT INTO USUARIO VALUES (NEXT VALUE FOR USUARIO_SEQ,'vanessaMartinez@gmail.com','21232f297a57a5a743894a0e4a801fc3','01/01/2014','','','',4,1,9);
go
INSERT INTO USUARIO VALUES (NEXT VALUE FOR USUARIO_SEQ,'pabloWestphal@gmail.com','21232f297a57a5a743894a0e4a801fc3','01/01/2014','','','',4,1,10);
go
INSERT INTO USUARIO VALUES (NEXT VALUE FOR USUARIO_SEQ,'andreaPaola@gmail.com','21232f297a57a5a743894a0e4a801fc3','01/01/2014','','','',4,1,11);
go
INSERT INTO USUARIO VALUES (NEXT VALUE FOR USUARIO_SEQ,'gabrielGonzales@gmail.com','21232f297a57a5a743894a0e4a801fc3','01/01/2014','','','',4,1,12);


commit transaction;
go