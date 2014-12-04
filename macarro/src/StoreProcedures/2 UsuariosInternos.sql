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

CREATE PROCEDURE Procedure_consultarEmpleado 
(
    @busqueda varchar (50),
	@estatus varchar (20)
)           
AS 
SELECT PER_docIdentidad, PER_tipoDocIdentidad, PER_primerNombre, PER_segundoNombre, PER_primerApellido,
PER_segundoApellido, PER_fechaNacimiento,USU_correo, USU_estado, USU_fechaIngreso, USU_fechaEgreso
FROM PERSONA as P, LUGAR as L, USUARIO as U
WHERE (PER_primerNombre LIKE concat(@busqueda,'%') OR PER_primerApellido LIKE concat(@busqueda,'%') OR USU_estado = @estatus 
OR CONCAT(PER_primerNombre,CONCAT(' ',PER_primerApellido)) LIKE concat(@busqueda,'%')) 
AND USU_tipo = 'Empleado' AND U.FK_persona = P.PER_docIdentidad;

go

CREATE PROCEDURE Procedure_consultarRolesEmpleado
(
	@usuario varchar (50)
)
AS
SELECT ROL_nombre
FROM USUARIO_ROL AS UR, ROL AS R, USUARIO as U
WHERE R.ROL_id = UR.FK_rol AND U.USU_correo = @usuario;




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

INSERT INTO PERSONA VALUES (20304050,'Cedula','Amanda',null,'Rodriguez','Gomez','04/01/1985',24);
go
INSERT INTO PERSONA VALUES (11123456,'Cedula','Alejandro','Daniel','Vieira','Machado','05/06/1983',23);
go
INSERT INTO PERSONA VALUES (9876243,'Cedula','Vanessa','Gabriela','Martinez','Lozano','11/11/1987',22);
go
INSERT INTO PERSONA VALUES (12333444,'Cedula','Pablo','David','Westphal','Juvinao','08/11/1987',21);
go
INSERT INTO PERSONA VALUES (17111940,'Cedula','Andrea','Paola','Gonzales','Crespo','10/18/1980',20);
go
INSERT INTO PERSONA VALUES (13141516,'Cedula','Gabriel',null,'Gonzales','Contreras','08/28/1991',19);




INSERT INTO USUARIO VALUES ('amandaRodriguez@gmail.com','Amanda123','Empleado','Activado','01/01/2014',null,null,null,20304050);
go
INSERT INTO USUARIO VALUES ('alejandroVieira@gmail.com','Alejo123','Empleado','Activado','01/01/2014',null,null,null,11123456);
go
INSERT INTO USUARIO VALUES ('vanessaMartinez@gmail.com','Vann123','Empleado','Activado','01/01/2014',null,null,null,9876243);
go
INSERT INTO USUARIO VALUES ('pabloWestphal@gmail.com','Pablo123','Empleado','Activado','01/01/2014',null,null,null,12333444);
go
INSERT INTO USUARIO VALUES ('andreaPaola@gmail.com','Andre123','Empleado','Activado','01/01/2014',null,null,null,17111940);
go
INSERT INTO USUARIO VALUES ('gabrielGonzales@gmail.com','Gabo123.','Empleado','Activado','01/01/2014',null,null,null,13141516);


commit transaction;
go