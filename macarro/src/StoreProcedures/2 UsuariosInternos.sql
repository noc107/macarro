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

/*CREATE PROCEDURE Procedure_agregarEmpleadoInterfaz
@docIdentidad [varchar] (100),
@tipoDocIdentidad [varchar] (100),
@primerNombre [varchar] (100),
@segundoNombre [varchar](100),
@primerApellido [varchar] (100),
@segundoApellido [varchar] (100),
@fechaNacimiento [varchar] (100),

@idCiudad [int],
@nombreLugar [varchar] (100),

@correo [varchar] (100),
@contrasena [varchar] (100),
@tipo [varchar] (100), 
@estatus [varchar] (100),
@fechaIngreso [varchar] (100),
@fechaEgreso [varchar] (100)

AS
DECLARE 
@idMaxLugar int = 0
BEGIN
    select @idMaxLugar = Max(LUG_id) from lugar;

    set @idMaxLugar = @idMaxLugar + 1;

    INSERT INTO lugar VALUES (@idMaxLugar,@nombreLugar,'Direccion',@idCiudad);

	INSERT INTO [dbo].[PERSONA] (PER_docIdentidad,PER_tipoDocIdentidad,PER_primerNombre,
PER_segundoNombre,PER_primerApellido,PER_segundoApellido,PER_fechaNacimiento,FK_lugar) VALUES
(@docIdentidad,@tipoDocIdentidad,@primerNombre,@segundoNombre,@primerApellido,@segundoApellido,Convert(varchar(100),@fechaNacimiento,110),@idMaxLugar)

	INSERT INTO [dbo].[USUARIO] (USU_correo,USU_contrasena,USU_tipo,USU_estado,USU_fechaIngreso,USU_fechaEgreso,FK_persona) 
	VALUES (@correo,@contrasena,@tipo,@estatus,Convert(varchar(100),@fechaIngreso,110),Convert(varchar(100),@fechaEgreso,110),@docIdentidad)
END;

go*/

/*---------------------------------------------------------------------*/
/*CREATE PROCEDURE Procedure_modificarUsuario

@docIdentidad [varchar] (100),
@primerNombre [varchar] (100),
@segundoNombre [varchar](100),
@primerApellido [varchar] (100),
@segundoApellido [varchar] (100),
@fechaNacimiento [varchar] (100),

@idCiudad [int],
@correo [varchar] (100),
@contrasena [varchar] (100),
@estatus [varchar] (100),
@fechaEgreso [varchar] (100),
@nombreLugar [nvarchar](100)

as
Declare
@idLugarDireccion [int] = 0,
@idMaxLugar [int] = 0
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
	   FK_lugar				 = @idLugarDireccion
	WHERE 
	   PER_docIdentidad      = @docIdentidad; 

UPDATE USUARIO
	SET 
	   USU_contrasena      	 = @contrasena,
	   USU_estado     		 = @estatus,
	   USU_fechaEgreso  	 = Convert(varchar(100),@fechaEgreso,110)   

	WHERE 
	   USU_correo      		 = @correo; 

end;

go*/
/*---------------------------------------------------------------------*/
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
/*CREATE PROCEDURE Procedure_agregarEmpleado
@docIdentidad [varchar] (100),
@tipoDocIdentidad [varchar] (100),
@primerNombre [varchar] (100),
@segundoNombre [varchar](100),
@primerApellido [varchar] (100),
@segundoApellido [varchar] (100),
@fechaNacimiento [varchar] (100),
@fkLugar [int],

@correo [varchar] (100),
@contrasena [varchar] (100),
@tipo [varchar] (100), 
@estatus [varchar] (100),
@fechaIngreso [varchar] (100),
@fechaEgreso [varchar] (100),
@fkPersona [varchar] (100)

AS
BEGIN
	INSERT INTO [dbo].[PERSONA] (PER_docIdentidad,PER_tipoDocIdentidad,PER_primerNombre,
PER_segundoNombre,PER_primerApellido,PER_segundoApellido,PER_fechaNacimiento,FK_lugar) VALUES
(@docIdentidad,@tipoDocIdentidad,@primerNombre,@segundoNombre,@primerApellido,@segundoApellido,Convert(varchar(100),@fechaNacimiento,110),@fkLugar)

	INSERT INTO [dbo].[USUARIO] (USU_correo,USU_contrasena,USU_tipo,USU_estado,USU_fechaIngreso,USU_fechaEgreso,FK_persona) 
	VALUES (@correo,@contrasena,@tipo,@estatus,Convert(varchar(100),@fechaIngreso,110),Convert(varchar(100),@fechaEgreso,110),@fkPersona)
END;

go*/

/*---------------------------------------------------------------------*/
/*CREATE PROCEDURE Procedure_consultarEmpleado 
(
    @busqueda varchar (50),
	@estatus varchar (20)
)           
AS 
SELECT DISTINCT (PER_docIdentidad), PER_tipoDocIdentidad, PER_primerNombre, PER_segundoNombre, PER_primerApellido,
PER_segundoApellido, PER_fechaNacimiento,USU_correo, USU_estado, USU_fechaIngreso, USU_fechaEgreso
FROM PERSONA as P, LUGAR as L, USUARIO as U
WHERE (PER_primerNombre LIKE concat(@busqueda,'%') OR PER_primerApellido LIKE concat(@busqueda,'%') OR USU_estado = @estatus 
OR CONCAT(PER_primerNombre,CONCAT(' ',PER_primerApellido)) LIKE concat(@busqueda,'%')) 
AND USU_tipo = 'Empleado' AND U.FK_persona = P.PER_docIdentidad;

go*/

/*---------------------------------------------------------------------*/
/*CREATE PROCEDURE Procedure_consultarTodosEmpleados
AS 
SELECT DISTINCT(PER_docIdentidad), PER_tipoDocIdentidad, PER_primerNombre, PER_segundoNombre, PER_primerApellido,
PER_segundoApellido, PER_fechaNacimiento,USU_correo, USU_estado, USU_fechaIngreso, USU_fechaEgreso
FROM PERSONA as P, LUGAR as L, USUARIO as U
WHERE USU_tipo = 'Empleado' AND U.FK_persona = P.PER_docIdentidad;

go*/
/*---------------------------------------------------------------------*/
CREATE PROCEDURE Procedure_consultarRolesEmpleado
(
	@usuario varchar (50)
)
AS
SELECT ROL_nombre
FROM USUARIO_ROL AS UR, ROL AS R, USUARIO as U
WHERE R.ROL_id = UR.FK_rol AND U.USU_correo = @usuario;

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
/*---------------------------------------------------------------------*/
/*CREATE PROCEDURE procedure_modificarEstadoUsuario
(@docIdentidad [varchar] (100))
AS
BEGIN
Update USUARIO set USU_estado = 'Desactivado' WHERE FK_persona = @docIdentidad;
END;
go*/

/*---------------------------------------------------------------------*/
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

/*---------------------------------------------------------------------*/
CREATE PROCEDURE Procedure_obtenerDireccion
(@idDireccion  [int])
AS
BEGIN
	   SELECT D.LUG_nombre 
	   FROM LUGAR D
	   WHERE D.LUG_tipo = 'Direccion' and D.LUG_id = @idDireccion;
END;

go 
/*---------------------------------------------------------------------*/
CREATE PROCEDURE Procedure_obtenerRolesUsuario
(@correo [varchar] (100))
AS
BEGIN
		SELECT R.ROL_id, R.ROL_nombre
		FROM USUARIO_ROL UR, ROL R
		WHERE UR.FK_rol = R.ROL_id and UR.FK_usuario = @correo
END;

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
CREATE PROCEDURE Procedure_consultarDireccionConcatenada
(@idDireccion  [int])
AS
BEGIN
	   SELECT P.LUG_nombre + ' - ' +  E.LUG_nombre + ' - ' + C.LUG_nombre + ' - ' + D.LUG_nombre  as Direccion 
	   FROM LUGAR P, LUGAR E, LUGAR C, LUGAR D
	   WHERE D.FK_lugar = C.LUG_id and D.LUG_id = @idDireccion and C.FK_lugar = E.LUG_id and E.FK_lugar = P.LUG_id 
END;

go

/*---------------------------------------------------------------------*/
/*CREATE PROCEDURE Procedure_consultarEmpleadoUnico 
(
    @docIdentidad varchar (50)
)           
AS 
SELECT DISTINCT (PER_docIdentidad), PER_tipoDocIdentidad, PER_primerNombre, PER_segundoNombre, PER_primerApellido,
PER_segundoApellido, PER_fechaNacimiento,P.FK_lugar,USU_correo, USU_estado, USU_fechaIngreso, USU_fechaEgreso, USU_tipo, U.FK_persona
FROM PERSONA as P, LUGAR as L, USUARIO as U
WHERE PER_docIdentidad = @docIdentidad AND USU_tipo = 'Empleado' AND U.FK_persona = P.PER_docIdentidad;

Go*/



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
INSERT INTO PERSONA VALUES (NEXT VALUE FOR PERSONA_SEQ,'20304050','Amanda',null,'Rodriguez','Gomez','04/01/1985','0412-1234567',5,24);
go
INSERT INTO PERSONA VALUES (NEXT VALUE FOR PERSONA_SEQ,'11123456','Alejandro','Daniel','Vieira','Machado','05/06/1983','0414-1234679',5,25);
go
INSERT INTO PERSONA VALUES (NEXT VALUE FOR PERSONA_SEQ,'9876243','Vanessa','Gabriela','Martinez','Lozano','11/11/1987','0416-6789012',5,26);
go
INSERT INTO PERSONA VALUES (NEXT VALUE FOR PERSONA_SEQ,'12333444','Pablo','David','Westphal','Juvinao','08/11/1987','0424-4567890',5,27);
go
INSERT INTO PERSONA VALUES (NEXT VALUE FOR PERSONA_SEQ,'17111940','Andrea','Paola','Gonzales','Crespo','10/18/1980','0426-3579123',5,28);
go
INSERT INTO PERSONA VALUES (NEXT VALUE FOR PERSONA_SEQ,'13141516','Gabriel',null,'Gonzales','Contreras','08/28/1991','0412-1864132',5,29);



go
INSERT INTO USUARIO VALUES (NEXT VALUE FOR USUARIO_SEQ,'amandaRodriguez@gmail.com','Amanda123','01/01/2014',null,null,null,4,1,7);
go
INSERT INTO USUARIO VALUES (NEXT VALUE FOR USUARIO_SEQ,'alejandroVieira@gmail.com','Alejo123','01/01/2014',null,null,null,4,1,8);
go
INSERT INTO USUARIO VALUES (NEXT VALUE FOR USUARIO_SEQ,'vanessaMartinez@gmail.com','Vann123','01/01/2014',null,null,null,4,1,9);
go
INSERT INTO USUARIO VALUES (NEXT VALUE FOR USUARIO_SEQ,'pabloWestphal@gmail.com','Pablo123','01/01/2014',null,null,null,4,1,10);
go
INSERT INTO USUARIO VALUES (NEXT VALUE FOR USUARIO_SEQ,'andreaPaola@gmail.com','Andre123','01/01/2014',null,null,null,4,1,11);
go
INSERT INTO USUARIO VALUES (NEXT VALUE FOR USUARIO_SEQ,'gabrielGonzales@gmail.com','Gabo123','01/01/2014',null,null,null,4,1,12);


commit transaction;
go