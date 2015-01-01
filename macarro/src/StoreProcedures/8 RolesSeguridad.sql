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
CREATE PROCEDURE [dbo].Procedure_ConsultarSecuenciaRol
AS
  BEGIN
	    SELECT current_value FROM sys.sequences WHERE name = 'ROL_SEQ'
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
/**/
CREATE PROCEDURE [dbo].Procedure_ConsultarUsuarioSinRol
       @_rolID                     [int]          
AS
 BEGIN
	SELECT COUNT(*) FROM USUARIO_ROL WHERE FK_rol = @_rolID;
END
GO
/**/
CREATE PROCEDURE Procedure_AccionURL
	@_rolID		[int]
AS
  BEGIN
	   SELECT A.ACC_url
	   FROM ROL R, ACCION A, ROL_ACCION RA
	   WHERE  R.ROL_id = @_rolID AND R.ROL_id = RA.FK_rol AND RA.FK_accion = A.ACC_id AND A.ACC_url IS NOT NULL;
  END
GO
/**/
CREATE PROCEDURE Procedure_AccionIdMenu
	@_rolID		[int]
AS
  BEGIN
	   SELECT A.ACC_id_menu
	   FROM ROL R, ACCION A, ROL_ACCION RA
	   WHERE  R.ROL_id = @_rolID AND R.ROL_id = RA.FK_rol AND RA.FK_accion = A.ACC_id AND A.ACC_id_menu IS NOT NULL
  END
GO
/**/
CREATE PROCEDURE Procedure_consultarRolesEmpleadoAccion
	 @usuario                 [nvarchar]   (50)
AS
	SELECT R.ROL_id,R.ROL_nombre,R.ROL_descripcion
	FROM USUARIO_ROL UR, ROL R, USUARIO U
	WHERE R.ROL_id = UR.FK_rol AND U.USU_correo = @usuario AND UR.FK_usuario = U.USU_id;
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

insert into MENU_MASTER values(1, 1,'Roles y Acciones',NULL,NULL)
insert into MENU_MASTER values(2, 2,'Gestion de Playa',NULL,NULL)
insert into MENU_MASTER values(3, 3,'Usuarios Internos',NULL,NULL)
insert into MENU_MASTER values(4, 4,'Servicios de Playa',NULL,NULL)
insert into MENU_MASTER values(5, 5,'Proveedores',NULL,NULL)
insert into MENU_MASTER values(6, 6,'Reservas',NULL,NULL)
insert into MENU_MASTER values(7, 7,'Estacionamiento',NULL,NULL)
insert into MENU_MASTER values(8, 8,'Menu de Restaurante',NULL,NULL)
insert into MENU_MASTER values(9, 9,'Membresia',NULL,NULL)
insert into MENU_MASTER values(10, 10,'Gestion de Inventario',NULL,NULL)
insert into MENU_MASTER values(11, 11,'Reportes',NULL,NULL)
insert into MENU_MASTER values(12, 12,'Cierre de Caja',NULL,NULL)

	
INSERT INTO MENU_MASTER VALUES(13,101,'Agregar Rol',1,'/Presentacion/Vistas/Web/RolesSeguridad/web_08_agregarRol.aspx');
INSERT INTO MENU_MASTER VALUES(14,102,'Gestionar Roles',1,'/Presentacion/Vistas/Web/RolesSeguridad/web_08_gestionarRoles.aspx');
INSERT INTO MENU_MASTER VALUES(15,106,'Consultar Acciones',1,'/Presentacion/Vistas/Web/RolesSeguridad/web_08_consultarAcciones.aspx');

INSERT INTO MENU_MASTER VALUES(16,107,'Configurar Playa',2,'/Presentacion/Vistas/Web/ConfiguracionPuestosPlaya/web_2_configurarPlaya.aspx');
INSERT INTO MENU_MASTER VALUES(17,108,'Agregar Puestos',2,'/Presentacion/Vistas/Web/ConfiguracionPuestosPlaya/web_2_agregarPuesto.aspx');
INSERT INTO MENU_MASTER VALUES(18,113,'Consultar Puestos',2,'/Presentacion/Vistas/Web/ConfiguracionPuestosPlaya/web_2_consultarPuesto.aspx');
INSERT INTO MENU_MASTER VALUES(19,111,'Agregar Item de Playa',2,'/Presentacion/Vistas/Web/ConfiguracionPuestosPlaya/web_2_agregarItem.aspx');
INSERT INTO MENU_MASTER VALUES(20,112,'Consultar Item de Playa',2,'/Presentacion/Vistas/Web/ConfiguracionPuestosPlaya/web_2_consultarInventario.aspx');

INSERT INTO MENU_MASTER VALUES(21,116,'Agregar Usuario',3,'/Presentacion/Vistas/Web/UsuariosInternos/web_09_agregarUsuario.aspx');
INSERT INTO MENU_MASTER VALUES(22,120,'Gestionar Usuarios',3,'/Presentacion/Vistas/Web/UsuariosInternos/web_09_gestionUsuario.aspx');

INSERT INTO MENU_MASTER VALUES(23,122,'Agregar Servicios',4,'/Presentacion/Vistas/Web/ConfiguracionServiciosPlaya/web_3_agregarServicio.aspx');
INSERT INTO MENU_MASTER VALUES(24,123,'Gestionar Servicios',4,'/Presentacion/Vistas/Web/ConfiguracionServiciosPlaya/web_03_consultaServicio.aspx');

INSERT INTO MENU_MASTER VALUES(25,127,'Agregar Proveedor',5,'/Presentacion/Vistas/Web/Proveedores/web_02_agregarProveedores.aspx');
INSERT INTO MENU_MASTER VALUES(26,131,'Gestionar Proveedores',5,'/Presentacion/Vistas/Web/Proveedores/web_02_gestionarProveedores.aspx');

INSERT INTO MENU_MASTER VALUES(27,132,'Confirmar Reserva',6,'/Presentacion/Vistas/Web/ReservasSombrillasServiciosPlaya/web_07_gestionarReservas.aspx');

INSERT INTO MENU_MASTER VALUES(28,137,'Agregar Estacionamiento',7,'/Presentacion/Vistas/Web/ConfiguracionEstacionamientos/web_5_agregarEstacionamiento.aspx');
INSERT INTO MENU_MASTER VALUES(29,138,'Gestionar Estacionamiento',7,'/Presentacion/Vistas/Web/ConfiguracionEstacionamientos/web_5_gestionarEstacionamiento.aspx');
INSERT INTO MENU_MASTER VALUES(30,139,'Consultar Ticket',7,'/Presentacion/Vistas/Web/ConfiguracionEstacionamientos/web_5_consultarTicket.aspx');

INSERT INTO MENU_MASTER VALUES(31,143,'Agregar Seccion',8,'/Presentacion/Vistas/Web/MenuRestaurante/web_05_agregarSeccion.aspx');
INSERT INTO MENU_MASTER VALUES(32,144,'Agregar Producto',8,'/Presentacion/Vistas/Web/MenuRestaurante/web_05_agregarProducto.aspx');
INSERT INTO MENU_MASTER VALUES(33,150,'Gestionar Seccion',8,'/Presentacion/Vistas/Web/MenuRestaurante/web_05_gestionarSeccion.aspx');
INSERT INTO MENU_MASTER VALUES(34,149,'Gestionar Producto',8,'/Presentacion/Vistas/Web/MenuRestaurante/web_05_gestionarProducto.aspx');

INSERT INTO MENU_MASTER VALUES(35,156,'Gestionar Membresia',9,'/Presentacion/Vistas/Web/GestionVentaMembresia/web_14_buscarMembresia.aspx');
INSERT INTO MENU_MASTER VALUES(36,159,'Precio Membresia',9,'/Presentacion/Vistas/Web/GestionVentaMembresia/web_14_gestionPrecioMembresia.aspx');

INSERT INTO MENU_MASTER VALUES(37,151,'Agregar Item',10,'/Presentacion/Vistas/Web/InventarioRestaurante/web_06_agregarItem.aspx');
INSERT INTO MENU_MASTER VALUES(38,152,'Gestionar Inventario',10,'/Presentacion/Vistas/Web/InventarioRestaurante/web_06_gestionarInventario.aspx');

INSERT INTO MENU_MASTER VALUES(39,160,'Ingresos',11,'/Presentacion/Vistas/Web/ReportesFinancierosExportacion/web_13_ReporteIngresos.aspx');
INSERT INTO MENU_MASTER VALUES(40,161,'Productos',11,'/Presentacion/Vistas/Web/ReportesFinancierosExportacion/web_13_ReporteProductos.aspx');
INSERT INTO MENU_MASTER VALUES(41,162,'Proveedores',11,'/Presentacion/Vistas/Web/ReportesFinancierosExportacion/web_13_ReporteProveedores.aspx');
INSERT INTO MENU_MASTER VALUES(42,163,'Restaurante',11,'/Presentacion/Vistas/Web/ReportesFinancierosExportacion/web_13_ReporteComidaBebida.aspx');
INSERT INTO MENU_MASTER VALUES(43,164,'Usuarios',11,'/Presentacion/Vistas/Web/ReportesFinancierosExportacion/web_13_ReporteUsuarios.aspx');
INSERT INTO MENU_MASTER VALUES(44,165,'Membresia',11,'/Presentacion/Vistas/Web/ReportesFinancierosExportacion/web_13_ReporteMembresias.aspx');
INSERT INTO MENU_MASTER VALUES(45,166,'Roles',11,'/Presentacion/Vistas/Web/ReportesFinancierosExportacion/web_13_ReporteRoles.aspx');

INSERT INTO MENU_MASTER VALUES(46,167,'Agregar Venta',12,'/Presentacion/Vistas/Web/VentaCierreCaja/web_07_agregarVenta.aspx');
INSERT INTO MENU_MASTER VALUES(47,168,'Gestionar Ventas',12,'/Presentacion/Vistas/Web/VentaCierreCaja/web_07_gestionarVenta.aspx');





INSERT INTO ACCION VALUES(1,'Agregar rol','Con esta accion podra agregar un nuevo rol con su descripcion',101,'/Presentacion/Vistas/Web/RolesSeguridad/web_08_agregarRol.aspx');
INSERT INTO ACCION VALUES(2,'Gestionar rol','Con esta accion podra gestionar roles',102,'/Presentacion/Vistas/Web/RolesSeguridad/web_08_gestionarRoles.aspx');
INSERT INTO ACCION VALUES(3,'Consultar rol','Con esta accion podra consultar un rol por nombre',103,'/Presentacion/Vistas/Web/RolesSeguridad/web_08_consultarRol.aspx');
INSERT INTO ACCION VALUES(4,'Modificar rol','Con esta accion podra modificar un rol',104,'/Presentacion/Vistas/Web/RolesSeguridad/web_08_editarRol.aspx');
INSERT INTO ACCION VALUES(5,'Eliminar rol','Con esta accion podra eliminar un rol',105,'NULL');
INSERT INTO ACCION VALUES(6,'Consultar accion','Con esta accion podra consultar las acciones disponibles para asignar a un rol',106,'/Presentacion/Vistas/Web/RolesSeguridad/web_08_consultarAcciones.aspx');

INSERT INTO ACCION VALUES(7,'Configurar la playa','Con esta accion puede configurar la playa con su largo y ancho',107,'/Presentacion/Vistas/Web/ConfiguracionPuestosPlaya/web_2_configurarPlaya.aspx');
INSERT INTO ACCION VALUES(8,'Agregar puesto','Con esta accion podra agregar un nuevo puesto de playa con su descripcion',108,'/Presentacion/Vistas/Web/ConfiguracionPuestosPlaya/web_2_agregarPuesto.aspx');
INSERT INTO ACCION VALUES(9,'Modificar puesto','Con esta accion podra modificar un puesto de playa por fila, columna o ubicación',109,'/Presentacion/Vistas/Web/ConfiguracionPuestosPlaya/web_2_modificarPuesto.aspx');
INSERT INTO ACCION VALUES(10,'Eliminar puesto playa','Con esta accion podra eliminar puesto de playa',110,'NULL');
INSERT INTO ACCION VALUES(11,'Agregar item de playa','Con esta accion podra agregar un item de playa',111,'/Presentacion/Vistas/Web/ConfiguracionPuestosPlaya/web_2_agregarItem.aspx');
INSERT INTO ACCION VALUES(12,'Consultar item de playa','Con esta accion podra consultar el inventario de items de playa',112,'/Presentacion/Vistas/Web/ConfiguracionPuestosPlaya/web_2_consultarInventario.aspx');
INSERT INTO ACCION VALUES(13,'Consultar puesto','Con esta accion podra consultar los puestos de la playa',113,'/Presentacion/Vistas/Web/ConfiguracionPuestosPlaya/web_2_consultarPuesto.aspx');
INSERT INTO ACCION VALUES(14,'Modificar inventario playa','Con esta accion podra modificar el inventario de puestos de playa',114,'/Presentacion/Vistas/Web/ConfiguracionPuestosPlaya/web_2_modificarInventario.aspx');
INSERT INTO ACCION VALUES(15,'Eliminar inventario playa','Con esta accion podra eliminar inventario de playa',115,'NULL');

INSERT INTO ACCION VALUES(16,'Agregar usuario interno','Con esta accion podra agregar un usuario',116,'/Presentacion/Vistas/Web/UsuariosInternos/web_09_agregarUsuario.aspx');

INSERT INTO ACCION VALUES(17,'Consultar usuario interno','Con esta accion podra consultar los usuarios',117,'/Presentacion/Vistas/Web/UsuariosInternos/web_09_consultarUsuario.aspx');
INSERT INTO ACCION VALUES(18,'Modificar usuario interno','Con esta accion podra modificar los usuarios',118,'/Presentacion/Vistas/Web/UsuariosInternos/web_09_modificarUsuario.aspx');
INSERT INTO ACCION VALUES(19,'Eliminar usuario interno','Con esta accion podra eliminar los usuarios',119,'NULL');
INSERT INTO ACCION VALUES(20,'Gestionar usuarios','Con esta accion podra gestionar los usuarios',120,'/Presentacion/Vistas/Web/UsuariosInternos/web_09_gestionUsuario.aspx');
INSERT INTO ACCION VALUES(21,'Modificar datos','Con esta accion podra modificar datos de usuario',121,'/Presentacion/Vistas/Web/UsuariosInternos/web_09_perfil_usuario.aspx');

INSERT INTO ACCION VALUES(22,'Agregar servicio de playa','Con esta accion podra agregar servicios de playa',122,'/Presentacion/Vistas/Web/ConfiguracionServiciosPlaya/web_3_agregarServicio.aspx');
INSERT INTO ACCION VALUES(23,'Gestionar servicio de playa','Con esta accion podra gestionar servicios de playa',123,'/Presentacion/Vistas/Web/ConfiguracionServiciosPlaya/web_03_consultaServicio.aspx');
INSERT INTO ACCION VALUES(24,'Consultar servicio de playa','Con esta accion podra consultar servicios de playa',124,'/Presentacion/Vistas/Web/ConfiguracionServiciosPlaya/web_03_consultaServicioCompleta.aspx');
INSERT INTO ACCION VALUES(25,'Modificar servicio de playa','Con esta accion podra modificar servicios de playa',125,'/Presentacion/Vistas/Web/ConfiguracionServiciosPlaya/web_03_modificarServiciosPlaya.aspx');
INSERT INTO ACCION VALUES(26,'Eliminar servicio de playa','Con esta accion podra eliminar servicios de playa',126,'NULL');

INSERT INTO ACCION VALUES(27,'Agregar proveedor','Con esta accion podra agregar proveedores',127,'/Presentacion/Vistas/Web/Proveedores/web_02_agregarProveedores.aspx');
INSERT INTO ACCION VALUES(28,'Consultar proveedor','Con esta accion podra consultar proveedores',128,'/Presentacion/Vistas/Web/Proveedores/web_02_consultarProveedor.aspx');
INSERT INTO ACCION VALUES(29,'Modificar proveedor','Con esta accion podra modificar proveedores',129,'/Presentacion/Vistas/Web/Proveedores/web_02_modificarProveedor.aspx');
INSERT INTO ACCION VALUES(30,'Eliminar proveedor','Con esta accion podra eliminar proveedores',130,'/Presentacion/Vistas/Web/Proveedores/web_02_eliminarProveedor.aspx');
INSERT INTO ACCION VALUES(31,'Gestionar proveedor','Con esta accion podra gestionar proveedores',131,'/Presentacion/Vistas/Web/Proveedores/web_02_gestionarProveedores.aspx');

INSERT INTO ACCION VALUES(32,'Confirmar reserva','Con esta accion podra confirmar reserva',132,'/Presentacion/Vistas/Web/ReservasSombrillasServiciosPlaya/web_07_confirmacionReserva.aspx');
INSERT INTO ACCION VALUES(33,'Modificar reserva','Con esta accion podra modificar reserva',133,'/Presentacion/Vistas/Web/ReservasSombrillasServiciosPlaya/web_07_editarReserva.aspx');
INSERT INTO ACCION VALUES(34,'Eliminar reserva','Con esta accion podra eliminar reserva',134,'NULL');
INSERT INTO ACCION VALUES(35,'Gestionar reserva','Con esta accion podra gestionar reserva',135,'/Presentacion/Vistas/Web/ReservasSombrillasServiciosPlaya/web_07_gestionarReservas.aspx');
INSERT INTO ACCION VALUES(36,'Listar reserva cliente','Con esta accion podras listar las reservas de un cliente',136,'/Presentacion/Vistas/Web/ReservasSombrillasServiciosPlaya/web_07_listaReservas.aspx');

INSERT INTO ACCION VALUES(37,'Agregar estacionamiento','Con esta accion podra agregar estacionamiento',137,'/Presentacion/Vistas/Web/ConfiguracionEstacionamientos/web_5_agregarEstacionamiento.aspx');
INSERT INTO ACCION VALUES(38,'Gestionar estacionamiento','Con esta accion podra gestionar estacionamiento',138,'/Presentacion/Vistas/Web/ConfiguracionEstacionamientos/web_5_gestionarEstacionamiento.aspx');
INSERT INTO ACCION VALUES(39,'Consultar ticket','Con tick accion podra consultar ticket',139,'/Presentacion/Vistas/Web/ConfiguracionEstacionamientos/web_5_consultarTicket.aspx');
INSERT INTO ACCION VALUES(40,'Detalle ticket','Con tick accion podra detalle ticket',140,'/Presentacion/Vistas/Web/ConfiguracionEstacionamientos/web_5_detalleTicket.aspx');
INSERT INTO ACCION VALUES(41,'Consultar estacionamiento','Con esta accion podra consultar estacionamiento',141,'/Presentacion/Vistas/Web/ConfiguracionEstacionamientos/web_5_consultarEstacionamiento.aspx');
INSERT INTO ACCION VALUES(42,'Editar estacionamiento','Con esta accion podra editar estacionamiento',142,'/Presentacion/Vistas/Web/ConfiguracionEstacionamientos/web_5_editarEstacionamiento.aspx');


INSERT INTO ACCION VALUES(43,'Agregar seccion','Con esta accion podra agregar seccion',143,'/Presentacion/Vistas/Web/MenuRestaurante/web_05_agregarSeccion.aspx');
INSERT INTO ACCION VALUES(44,'Agregar producto','Con esta accion podra agregar producto',144,'/Presentacion/Vistas/Web/MenuRestaurante/web_05_agregarProducto.aspx');
INSERT INTO ACCION VALUES(45,'Modificar seccion','Con esta accion podra modificar seccion',145,'/Presentacion/Vistas/Web/MenuRestaurante/web_05_modificarSeccion.aspx');
INSERT INTO ACCION VALUES(46,'Eliminar seccion','Con esta accion podra eliminar seccion',146,'NULL');
INSERT INTO ACCION VALUES(47,'Modificar producto','Con esta accion podra modificar producto',147,'/Presentacion/Vistas/Web/MenuRestaurante/web_05_modificarProducto.aspx');
INSERT INTO ACCION VALUES(48,'Eliminar producto','Con esta accion podra eliminar producto',148,'NULL');
INSERT INTO ACCION VALUES(49,'Gestionar producto','Con esta accion podra gestionar producto',149,'/Presentacion/Vistas/Web/MenuRestaurante/web_05_gestionarProducto.aspx');
INSERT INTO ACCION VALUES(50,'Gestionar seccion','Con esta accion podra gestionar seccion',150,'/Presentacion/Vistas/Web/MenuRestaurante/web_05_gestionarSeccion.aspx');

INSERT INTO ACCION VALUES(51,'Agregar item de inventario','Con esta accion podra agregar item de inventario',151,'/Presentacion/Vistas/Web/InventarioRestaurante/web_06_agregarItem.aspx');
INSERT INTO ACCION VALUES(52,'Gestionar Inventario','Con esta accion podra gestionar inventario',152,'/Presentacion/Vistas/Web/InventarioRestaurante/web_06_gestionarInventario.aspx');
INSERT INTO ACCION VALUES(53,'Consultar un item de inventario','Con esta accion podra consultar un item de inventario',153,'/Presentacion/Vistas/Web/InventarioRestaurante/web_06_verItem.aspx');
INSERT INTO ACCION VALUES(54,'Modificar un item de inventario','Con esta accion podra modificar un item de inventario',154,'/Presentacion/Vistas/Web/InventarioRestaurante/web_06_modificarItem.aspx');
INSERT INTO ACCION VALUES(55,'Eliminar un item de inventario','Con esta accion podra eliminar un item de inventario',155,'NULL');

INSERT INTO ACCION VALUES(56,'Buscar membresia','Con esta accion podra buscar membresia',156,'/Presentacion/Vistas/Web/GestionVentaMembresia/web_14_buscarMembresia.aspx');
INSERT INTO ACCION VALUES(57,'consultar membresia','Con esta accion podra consultar membresia',157,'/Presentacion/Vistas/Web/GestionVentaMembresia/web_14_consultarMembresia.aspx');
INSERT INTO ACCION VALUES(58,'Modificar membresia','Con esta accion podra modificar membresia',158,'/Presentacion/Vistas/Web/GestionVentaMembresia/web_14_modificarMembresia.aspx');
INSERT INTO ACCION VALUES(59,'Gestion Precio Membresia','Con esta accion podra gestion precio membresia',159,'/Presentacion/Vistas/Web/GestionVentaMembresia/web_14_gestionPrecioMembresia.aspx');

INSERT INTO ACCION VALUES(60,'Reporte de ingresos','Con esta accion podra generar reporte de ingresos',160,'/Presentacion/Vistas/Web/ReportesFinancierosExportacion/web_13_ReporteIngresos.aspx');
INSERT INTO ACCION VALUES(61,'Reporte de productos','Con esta accion podra generar reporte de productos',161,'/Presentacion/Vistas/Web/ReportesFinancierosExportacion/web_13_ReporteProductos.aspx');
INSERT INTO ACCION VALUES(62,'Reporte de proveedores','Con esta accion podra generar reporte de proveedores',162,'/Presentacion/Vistas/Web/ReportesFinancierosExportacion/web_13_ReporteProveedores.aspx');
INSERT INTO ACCION VALUES(63,'Reporte de restaurant','Con esta accion podra generar reporte de restaurant',163,'/Presentacion/Vistas/Web/ReportesFinancierosExportacion/web_13_ReporteComidaBebida.aspx');
INSERT INTO ACCION VALUES(64,'Reporte de usuarios','Con esta accion podra generar reporte de usuarios',164,'/Presentacion/Vistas/Web/ReportesFinancierosExportacion/web_13_ReporteUsuarios.aspx');
INSERT INTO ACCION VALUES(65,'Reporte de membresia','Con esta accion podra generar reporte de membresia',165,'/Presentacion/Vistas/Web/ReportesFinancierosExportacion/web_13_ReporteMembresias.aspx');
INSERT INTO ACCION VALUES(66,'Reporte de Roles','Con esta accion podra generar reporte de roles',166,'/Presentacion/Vistas/Web/ReportesFinancierosExportacion/web_13_ReporteRoles.aspx');

INSERT INTO ACCION VALUES(67,'Agregar una venta','Con esta accion podra agregar una venta',167,'/Presentacion/Vistas/Web/VentaCierreCaja/web_07_agregarVenta.aspx');
INSERT INTO ACCION VALUES(68,'Gestionar venta','Con esta accion podra gestionar venta',168,'/Presentacion/Vistas/Web/VentaCierreCaja/web_07_gestionarVenta.aspx');
INSERT INTO ACCION VALUES(69,'Imprimir factura','Con esta accion podra imprimir factura',169,'/Presentacion/Vistas/Web/VentaCierreCaja/web_07_imprimirFactura.aspx');
INSERT INTO ACCION VALUES(70,'Cerrar Caja Diario','Con esta accion podra cerrar caja diario',170,'/Presentacion/Vistas/Web/VentaCierreCaja/web_07_cerrarCajaDiario.aspx');
INSERT INTO ACCION VALUES(71,'Cerrar Caja Mensual','Con esta accion podra cerrar caja mensual',171,'/Presentacion/Vistas/Web/VentaCierreCaja/web_07_cerrarCajaMensual.aspx');
INSERT INTO ACCION VALUES(72,'Eliminar estacionamiento','Con esta accion podra eliminar estacionamiento',172,'NULL');



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
INSERT INTO ROL_ACCION VALUES(1,53);
INSERT INTO ROL_ACCION VALUES(1,54);
INSERT INTO ROL_ACCION VALUES(1,55);
INSERT INTO ROL_ACCION VALUES(1,56);
INSERT INTO ROL_ACCION VALUES(1,57);
INSERT INTO ROL_ACCION VALUES(1,58);
INSERT INTO ROL_ACCION VALUES(1,59);
INSERT INTO ROL_ACCION VALUES(1,60);
INSERT INTO ROL_ACCION VALUES(1,61);
INSERT INTO ROL_ACCION VALUES(1,62);
INSERT INTO ROL_ACCION VALUES(1,63);
INSERT INTO ROL_ACCION VALUES(1,64);
INSERT INTO ROL_ACCION VALUES(1,65);
INSERT INTO ROL_ACCION VALUES(1,66);
INSERT INTO ROL_ACCION VALUES(1,67);
INSERT INTO ROL_ACCION VALUES(1,68);
INSERT INTO ROL_ACCION VALUES(1,69);
INSERT INTO ROL_ACCION VALUES(1,70);
INSERT INTO ROL_ACCION VALUES(1,71);

INSERT INTO ROL_ACCION VALUES(2,60);
INSERT INTO ROL_ACCION VALUES(2,61);
INSERT INTO ROL_ACCION VALUES(2,62);
INSERT INTO ROL_ACCION VALUES(2,63);
INSERT INTO ROL_ACCION VALUES(2,64);
INSERT INTO ROL_ACCION VALUES(2,65);
INSERT INTO ROL_ACCION VALUES(2,66);
INSERT INTO ROL_ACCION VALUES(2,16);
INSERT INTO ROL_ACCION VALUES(2,17);
INSERT INTO ROL_ACCION VALUES(2,18);
INSERT INTO ROL_ACCION VALUES(2,19);
INSERT INTO ROL_ACCION VALUES(2,20);
INSERT INTO ROL_ACCION VALUES(2,21);
INSERT INTO ROL_ACCION VALUES(2,27);
INSERT INTO ROL_ACCION VALUES(2,28);
INSERT INTO ROL_ACCION VALUES(2,29);
INSERT INTO ROL_ACCION VALUES(2,30);
INSERT INTO ROL_ACCION VALUES(2,31);

INSERT INTO ROL_ACCION VALUES(3,16);
INSERT INTO ROL_ACCION VALUES(3,17);
INSERT INTO ROL_ACCION VALUES(3,18);
INSERT INTO ROL_ACCION VALUES(3,19);
INSERT INTO ROL_ACCION VALUES(3,20);
INSERT INTO ROL_ACCION VALUES(3,21);

INSERT INTO ROL_ACCION VALUES(4,7);
INSERT INTO ROL_ACCION VALUES(4,8);
INSERT INTO ROL_ACCION VALUES(4,9);
INSERT INTO ROL_ACCION VALUES(4,10);
INSERT INTO ROL_ACCION VALUES(4,11);
INSERT INTO ROL_ACCION VALUES(4,12);
INSERT INTO ROL_ACCION VALUES(4,13);
INSERT INTO ROL_ACCION VALUES(4,14);
INSERT INTO ROL_ACCION VALUES(4,15);
INSERT INTO ROL_ACCION VALUES(4,22);
INSERT INTO ROL_ACCION VALUES(4,23);
INSERT INTO ROL_ACCION VALUES(4,24);
INSERT INTO ROL_ACCION VALUES(4,25);
INSERT INTO ROL_ACCION VALUES(4,26);

INSERT INTO ROL_ACCION VALUES(5,27);
INSERT INTO ROL_ACCION VALUES(5,28);
INSERT INTO ROL_ACCION VALUES(5,29);
INSERT INTO ROL_ACCION VALUES(5,30);
INSERT INTO ROL_ACCION VALUES(5,31);

INSERT INTO ROL_ACCION VALUES(6,56);
INSERT INTO ROL_ACCION VALUES(6,57);
INSERT INTO ROL_ACCION VALUES(6,58);
INSERT INTO ROL_ACCION VALUES(6,59);
INSERT INTO ROL_ACCION VALUES(6,32);
INSERT INTO ROL_ACCION VALUES(6,33);
INSERT INTO ROL_ACCION VALUES(6,34);
INSERT INTO ROL_ACCION VALUES(6,35);
INSERT INTO ROL_ACCION VALUES(6,36);

INSERT INTO ROL_ACCION VALUES(7,43);
INSERT INTO ROL_ACCION VALUES(7,44);
INSERT INTO ROL_ACCION VALUES(7,45);
INSERT INTO ROL_ACCION VALUES(7,46);
INSERT INTO ROL_ACCION VALUES(7,47);
INSERT INTO ROL_ACCION VALUES(7,48);
INSERT INTO ROL_ACCION VALUES(7,49);
INSERT INTO ROL_ACCION VALUES(7,50);
INSERT INTO ROL_ACCION VALUES(7,51);
INSERT INTO ROL_ACCION VALUES(7,52);
INSERT INTO ROL_ACCION VALUES(7,53);
INSERT INTO ROL_ACCION VALUES(7,54);
INSERT INTO ROL_ACCION VALUES(7,55);

INSERT INTO ROL_ACCION VALUES(8,51);
INSERT INTO ROL_ACCION VALUES(8,52);
INSERT INTO ROL_ACCION VALUES(8,53);
INSERT INTO ROL_ACCION VALUES(8,54);
INSERT INTO ROL_ACCION VALUES(8,55);

INSERT INTO ROL_ACCION VALUES(9,67);
INSERT INTO ROL_ACCION VALUES(9,68);
INSERT INTO ROL_ACCION VALUES(9,69);
INSERT INTO ROL_ACCION VALUES(9,70);
INSERT INTO ROL_ACCION VALUES(9,71);
INSERT INTO ROL_ACCION VALUES(1,72);
INSERT INTO ROL_ACCION VALUES(4,72);


/*==============================================================*/
/* Table: USUARIO_ROL                                           */
/*==============================================================*/

INSERT INTO USUARIO_ROL VALUES(7,1);
INSERT INTO USUARIO_ROL VALUES(7,2);
INSERT INTO USUARIO_ROL VALUES(8,3);
INSERT INTO USUARIO_ROL VALUES(9,1);
INSERT INTO USUARIO_ROL VALUES(10,4);
INSERT INTO USUARIO_ROL VALUES(11,6);
INSERT INTO USUARIO_ROL VALUES(12,1);

commit transaction;
go