use MACARRO
go
begin transaction;
go
/*==============================================================*/
/* Procedure insert                                             */
/*==============================================================*/

CREATE PROCEDURE [dbo].Procedure_AgregarRol
	   @_rolNombre                 [nvarchar]   (100),
       @_rolDescripcion            [nvarchar]   (100)  
     
AS
 BEGIN
	   INSERT INTO ROL VALUES(NEXT VALUE FOR ROL_SEQ,@_rolNombre,@_rolDescripcion) 
 END
GO
/**/
CREATE PROCEDURE [dbo].Procedure_AgregarRol_Accion
       @_rolID                     [int]             ,
	   @_accionID                  [int]                  
AS
  BEGIN
	   INSERT INTO ROL_ACCION(FK_rol,FK_accion)
	   VALUES(@_rolID,@_accionID) 
  END
GO

/*==============================================================*/
/* Procedure update                                             */
/*==============================================================*/

CREATE PROCEDURE [dbo].Procedure_ModificarRol
	   @_rolID                     [int]             ,
	   @_rolNombre                 [nvarchar]   (100),
       @_rolDescripcion            [nvarchar]   (100)  
     
AS
 BEGIN
	   UPDATE ROL 
		SET 
		   ROL_nombre      = @_rolNombre      ,
		   ROL_descripcion = @_rolDescripcion      
		WHERE 
		   ROL_id          = @_rolID          ;
 END
GO

/*==============================================================*/
/* Procedure delete                                             */
/*==============================================================*/

CREATE PROCEDURE [dbo].Procedure_EliminarRol
       @_rolID                     [int]          
AS
 BEGIN
       Delete USUARIO_ROL WHERE FK_rol = @_rolID;
	   Delete ROL_ACCION WHERE FK_rol = @_rolID;
	   Delete ROL WHERE ROL_id = @_rolID;
 END
GO
/**/
CREATE PROCEDURE [dbo].Procedure_EliminarAccionRol
       @_rolID                     [int]          
AS
 BEGIN
	   Delete ROL_ACCION WHERE FK_rol = @_rolID;
 END
GO

/*==============================================================*/
/* Procedure selects                                            */
/*==============================================================*/
CREATE PROCEDURE Procedure_ConsultarRol
	@_rolID		[int]
AS
  BEGIN
	   SELECT A.ACC_id,A.ACC_nombre,A.ACC_descripcion
	   FROM ROL R, ACCION A, ROL_ACCION RA
	   WHERE  R.ROL_id = @_rolID AND R.ROL_id = RA.FK_rol AND RA.FK_accion = A.ACC_id
  END
GO
/**/
CREATE PROCEDURE Procedure_ConsultarRolGeneral
AS
  BEGIN
	   SELECT *
	   FROM ROL 
  END
GO
/**/
CREATE PROCEDURE Procedure_ConsultarAccionGeneral
AS
  BEGIN
	   SELECT *
	   FROM ACCION 
  END
GO

/*==============================================================*/
/* Secuencia:ROL_SEQ                                            */
/*==============================================================*/

CREATE SEQUENCE ROL_SEQ
    START WITH 1
    INCREMENT BY 1;
GO

/*==============================================================*/
/* Table: ROL                                                 	*/
/*==============================================================*/

INSERT INTO ROL VALUES(NEXT VALUE FOR ROL_SEQ,'Administrador','Encargado de la supervision de la aplicación');
INSERT INTO ROL VALUES(NEXT VALUE FOR ROL_SEQ,'Director general','Realiza los reportes y ordena a los gerentes y supervisores');
INSERT INTO ROL VALUES(NEXT VALUE FOR ROL_SEQ,'Gerente de recursos humanos','Encargado de los empleados internos');
INSERT INTO ROL VALUES(NEXT VALUE FOR ROL_SEQ,'Gerente de la playa','Encargado del inventario de los materiales para la playa y sus servicios');
INSERT INTO ROL VALUES(NEXT VALUE FOR ROL_SEQ,'Supervisor de proveedores','Apoyar en el desarrollo y administración de la red de proveedores');
INSERT INTO ROL VALUES(NEXT VALUE FOR ROL_SEQ,'Gerente de atencion al cliente','Recibir las peticiones de los clientes para las reservaciones y crear membresias');
INSERT INTO ROL VALUES(NEXT VALUE FOR ROL_SEQ,'Gerente del restaurante','Encargado de realizar los platos del restaurante');
INSERT INTO ROL VALUES(NEXT VALUE FOR ROL_SEQ,'Supervisor de inventario','Administra el inventario de los productos para el restaurante');
INSERT INTO ROL VALUES(NEXT VALUE FOR ROL_SEQ,'Tesorero','Administra el flujo de caja');

/*==============================================================*/
/* Table: ACCION                                    			*/
/*==============================================================*/

INSERT INTO ACCION VALUES(1,'Agregar rol','Con esta accion podra agregar un nuevo rol con su descripcion');
INSERT INTO ACCION VALUES(2,'Consultar rol','Con esta accion podra consultar un rol por nombre');
INSERT INTO ACCION VALUES(3,'Modificar rol','Con esta accion podra modificar un rol');
INSERT INTO ACCION VALUES(4,'Eliminar rol','Con esta accion podra eliminar un rol');
INSERT INTO ACCION VALUES(5,'Configurar la playa','Con esta accion puede configurar la playa con su largo y ancho');
INSERT INTO ACCION VALUES(6,'Agregar puesto','Con esta accion podra agregar un nuevo puesto de playa con su descripcion');
INSERT INTO ACCION VALUES(7,'Modificar puesto','Con esta accion podra modificar un puesto de playa por fila, columna o ubicación');
INSERT INTO ACCION VALUES(8,'Agregar item de playa','Con esta accion podra agregar un item de playa');
INSERT INTO ACCION VALUES(9,'Consultar item de playa','Con esta accion podra consultar el inventario de items de playa');
INSERT INTO ACCION VALUES(10,'Agregar usuario interno','Con esta accion podra agregar un nuevo rol con su descripcion');
INSERT INTO ACCION VALUES(11,'Consultar usuario interno','Con esta accion podra consultar un usuario interno por nombre');
INSERT INTO ACCION VALUES(12,'Modificar usuario interno','Con esta accion podra modificar un  usuario interno');
INSERT INTO ACCION VALUES(13,'Eliminar usuario interno','Con esta accion podra eliminar un  usuario interno');
INSERT INTO ACCION VALUES(14,'Agregar servicio de playa','Con esta accion podra agregar un nuevo  servicio de playa con su descripcion');
INSERT INTO ACCION VALUES(15,'Consultar servicio de playa','Con esta accion podra consultar un servicio de playa por nombre');
INSERT INTO ACCION VALUES(16,'Modificar servicio de playa','Con esta accion podra modificar un servicio de playa');
INSERT INTO ACCION VALUES(17,'Eliminar servicio de playa','Con esta accion podra eliminar un  servicio de playa');
INSERT INTO ACCION VALUES(18,'Agregar proveedor','Con esta accion podra agregar un nuevo  servicio de playa con su descripcion');
INSERT INTO ACCION VALUES(19,'Consultar proveedor','Con esta accion podra consultar un servicio de playa por nombre');
INSERT INTO ACCION VALUES(20,'Modificar proveedor','Con esta accion podra modificar un servicio de playa');
INSERT INTO ACCION VALUES(21,'Eliminar proveedor','Con esta accion podra eliminar un  servicio de playa');
INSERT INTO ACCION VALUES(22,'Agregar reserva','Con esta accion podra agregar una nueva  reserva con su descripcion');
INSERT INTO ACCION VALUES(23,'Confirmar reserva','Con esta accion podra Confirmar una reserva');
INSERT INTO ACCION VALUES(24,'Modificar reserva','Con esta accion podra modificar una reserva');
INSERT INTO ACCION VALUES(25,'Eliminar reserva','Con esta accion podra eliminar una reserva');
INSERT INTO ACCION VALUES(26,'Agregar estacionamiento','Con esta accion podra agregar un estacionamiento con su descripcion');
INSERT INTO ACCION VALUES(27,'Gestionar estacionamiento','Con esta accion podra consultar un estacionamiento por nombre o por placa');
INSERT INTO ACCION VALUES(28,'Consultar ticket','Con esta accion podra consultar los tickets por hora, fecha o placa');
INSERT INTO ACCION VALUES(29,'Agregar seccion','Con esta accion podra agregar una seccion con su descripcion');
INSERT INTO ACCION VALUES(30,'Agregar producto','Con esta accion podra agregar un producto con su descripcion');
INSERT INTO ACCION VALUES(31,'Consultar seccion','Con esta accion podra consultar una seccion ');
INSERT INTO ACCION VALUES(32,'Modificar seccion','Con esta accion podra modificar una seccion');
INSERT INTO ACCION VALUES(33,'Eliminar seccion','Con esta accion podra eliminar una seccion');
INSERT INTO ACCION VALUES(34,'Consultar producto','Con esta accion podra consultar un producto');
INSERT INTO ACCION VALUES(35,'Modificar producto','Con esta accion podra modificar un producto');
INSERT INTO ACCION VALUES(36,'Eliminar producto','Con esta accion podra eliminar un producto');
INSERT INTO ACCION VALUES(37,'Buscar y consultar membresia','Con esta accion podra buscar una membresia por numero de carnet o por cedula');
INSERT INTO ACCION VALUES(38,'Modificar membresia','Con esta accion podra modificar una membresia e imprimir un carnet fisico de dicha membresia');
INSERT INTO ACCION VALUES(39,'Agregar item de inventario','Con esta accion podra agregar un item de inventario del restaurante');
INSERT INTO ACCION VALUES(40,'Consultar un item de inventario','Con esta accion podra Confirmar un item de inventario del restaurante');
INSERT INTO ACCION VALUES(41,'Modificar un item de inventario','Con esta accion podra modificar un item de inventario del restaurante');
INSERT INTO ACCION VALUES(42,'Eliminar un item de inventario','Con esta accion podra eliminar un item de inventario del restaurante');
INSERT INTO ACCION VALUES(43,'Reporte de ingresos','Con esta accion podra ver los reportes de ingreso en un intervalo de tiempo');
INSERT INTO ACCION VALUES(44,'Reporte de productos','Con esta accion podra ver los reportes de productos en un intervalo de tiempo');
INSERT INTO ACCION VALUES(45,'Reporte de proveedores ','Con esta accion podra ver los reportes de proveedores en un intervalo de tiempo');
INSERT INTO ACCION VALUES(46,'Reporte de restaurant','Con esta accion podra ver los reportes del resturante en un intervalo de tiempo');
INSERT INTO ACCION VALUES(47,'Reporte de usuarios','Con esta accion podra ver los reportes de usuarios en un intervalo de tiempo');
INSERT INTO ACCION VALUES(48,'Reporte de membresia','Con esta accion podra ver los reportes de membresias en un intervalo de tiempo');
INSERT INTO ACCION VALUES(49,'Agregar una venta','Con esta accion podra agregar una venta');
INSERT INTO ACCION VALUES(50,'Consultar una venta','Con esta accion podra consultar una venta');
INSERT INTO ACCION VALUES(51,'Modificar una venta','Con esta accion podra modificar una venta');
INSERT INTO ACCION VALUES(52,'Imprimir factura','Con esta accion podra imprimir una venta');


/*==============================================================*/
/* Table: ROL_ACCION                                            */
/*==============================================================*/

INSERT INTO ROL_ACCION VALUES(1,1);
INSERT INTO ROL_ACCION VALUES(1,2);
INSERT INTO ROL_ACCION VALUES(1,3);
INSERT INTO ROL_ACCION VALUES(1,4);
INSERT INTO ROL_ACCION VALUES(1,5);
INSERT INTO ROL_ACCION VALUES(1,6);
INSERT INTO ROL_ACCION VALUES(1,7);
INSERT INTO ROL_ACCION VALUES(1,8);
INSERT INTO ROL_ACCION VALUES(1,9);
INSERT INTO ROL_ACCION VALUES(1,10);
INSERT INTO ROL_ACCION VALUES(1,11);
INSERT INTO ROL_ACCION VALUES(1,12);
INSERT INTO ROL_ACCION VALUES(1,13);
INSERT INTO ROL_ACCION VALUES(1,14);
INSERT INTO ROL_ACCION VALUES(1,15);
INSERT INTO ROL_ACCION VALUES(1,16);
INSERT INTO ROL_ACCION VALUES(1,17);
INSERT INTO ROL_ACCION VALUES(1,18);
INSERT INTO ROL_ACCION VALUES(1,19);
INSERT INTO ROL_ACCION VALUES(1,20);
INSERT INTO ROL_ACCION VALUES(1,21);
INSERT INTO ROL_ACCION VALUES(1,22);
INSERT INTO ROL_ACCION VALUES(1,23);
INSERT INTO ROL_ACCION VALUES(1,24);
INSERT INTO ROL_ACCION VALUES(1,25);
INSERT INTO ROL_ACCION VALUES(1,26);
INSERT INTO ROL_ACCION VALUES(1,27);
INSERT INTO ROL_ACCION VALUES(1,28);
INSERT INTO ROL_ACCION VALUES(1,29);
INSERT INTO ROL_ACCION VALUES(1,30);
INSERT INTO ROL_ACCION VALUES(1,31);
INSERT INTO ROL_ACCION VALUES(1,32);
INSERT INTO ROL_ACCION VALUES(1,33);
INSERT INTO ROL_ACCION VALUES(1,34);
INSERT INTO ROL_ACCION VALUES(1,35);
INSERT INTO ROL_ACCION VALUES(1,36);
INSERT INTO ROL_ACCION VALUES(1,37);
INSERT INTO ROL_ACCION VALUES(1,38);
INSERT INTO ROL_ACCION VALUES(1,39);
INSERT INTO ROL_ACCION VALUES(1,40);
INSERT INTO ROL_ACCION VALUES(1,41);
INSERT INTO ROL_ACCION VALUES(1,42);
INSERT INTO ROL_ACCION VALUES(1,43);
INSERT INTO ROL_ACCION VALUES(1,44);
INSERT INTO ROL_ACCION VALUES(1,45);
INSERT INTO ROL_ACCION VALUES(1,46);
INSERT INTO ROL_ACCION VALUES(1,47);
INSERT INTO ROL_ACCION VALUES(1,48);
INSERT INTO ROL_ACCION VALUES(1,49);
INSERT INTO ROL_ACCION VALUES(1,50);
INSERT INTO ROL_ACCION VALUES(1,51);
INSERT INTO ROL_ACCION VALUES(1,52);
INSERT INTO ROL_ACCION VALUES(2,2);
INSERT INTO ROL_ACCION VALUES(2,6);
INSERT INTO ROL_ACCION VALUES(2,9);
INSERT INTO ROL_ACCION VALUES(2,11);
INSERT INTO ROL_ACCION VALUES(2,15);
INSERT INTO ROL_ACCION VALUES(2,19);
INSERT INTO ROL_ACCION VALUES(2,27);
INSERT INTO ROL_ACCION VALUES(2,28);
INSERT INTO ROL_ACCION VALUES(2,31);
INSERT INTO ROL_ACCION VALUES(2,34);
INSERT INTO ROL_ACCION VALUES(2,37);
INSERT INTO ROL_ACCION VALUES(2,40);
INSERT INTO ROL_ACCION VALUES(2,43);
INSERT INTO ROL_ACCION VALUES(2,44);
INSERT INTO ROL_ACCION VALUES(2,45);
INSERT INTO ROL_ACCION VALUES(2,46);
INSERT INTO ROL_ACCION VALUES(2,47);
INSERT INTO ROL_ACCION VALUES(2,48);
INSERT INTO ROL_ACCION VALUES(2,50);
INSERT INTO ROL_ACCION VALUES(3,10);
INSERT INTO ROL_ACCION VALUES(3,11);
INSERT INTO ROL_ACCION VALUES(3,12);
INSERT INTO ROL_ACCION VALUES(3,13);
INSERT INTO ROL_ACCION VALUES(4,5);
INSERT INTO ROL_ACCION VALUES(4,6);
INSERT INTO ROL_ACCION VALUES(4,7);
INSERT INTO ROL_ACCION VALUES(4,8);
INSERT INTO ROL_ACCION VALUES(4,9);
INSERT INTO ROL_ACCION VALUES(4,14);
INSERT INTO ROL_ACCION VALUES(4,15);
INSERT INTO ROL_ACCION VALUES(4,16);
INSERT INTO ROL_ACCION VALUES(4,17);
INSERT INTO ROL_ACCION VALUES(5,18);
INSERT INTO ROL_ACCION VALUES(5,19);
INSERT INTO ROL_ACCION VALUES(5,20);
INSERT INTO ROL_ACCION VALUES(5,21);
INSERT INTO ROL_ACCION VALUES(6,22);
INSERT INTO ROL_ACCION VALUES(6,23);
INSERT INTO ROL_ACCION VALUES(6,24);
INSERT INTO ROL_ACCION VALUES(6,25);
INSERT INTO ROL_ACCION VALUES(6,37);
INSERT INTO ROL_ACCION VALUES(6,38);
INSERT INTO ROL_ACCION VALUES(7,29);
INSERT INTO ROL_ACCION VALUES(7,30);
INSERT INTO ROL_ACCION VALUES(7,31);
INSERT INTO ROL_ACCION VALUES(7,32);
INSERT INTO ROL_ACCION VALUES(7,33);
INSERT INTO ROL_ACCION VALUES(7,34);
INSERT INTO ROL_ACCION VALUES(7,35);
INSERT INTO ROL_ACCION VALUES(7,36);
INSERT INTO ROL_ACCION VALUES(8,39);
INSERT INTO ROL_ACCION VALUES(8,40);
INSERT INTO ROL_ACCION VALUES(8,41);
INSERT INTO ROL_ACCION VALUES(8,42);
INSERT INTO ROL_ACCION VALUES(9,49);
INSERT INTO ROL_ACCION VALUES(9,50);
INSERT INTO ROL_ACCION VALUES(9,51);
INSERT INTO ROL_ACCION VALUES(9,52);


/*==============================================================*/
/* Table: USUARIO_ROL                                           */
/*==============================================================*/

INSERT INTO USUARIO_ROL VALUES('amandaRodriguez@gmail.com',1);
INSERT INTO USUARIO_ROL VALUES('amandaRodriguez@gmail.com',2);
INSERT INTO USUARIO_ROL VALUES('alejandroVieira@gmail.com',3);
INSERT INTO USUARIO_ROL VALUES('vanessaMartinez@gmail.com',1);
INSERT INTO USUARIO_ROL VALUES('pabloWestphal@gmail.com',4);
INSERT INTO USUARIO_ROL VALUES('andreaPaola@gmail.com',6);
INSERT INTO USUARIO_ROL VALUES('gabrielGonzales@gmail.com',1);

commit transaction;
go