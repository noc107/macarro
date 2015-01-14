/*----------------------------STORED_PROCEDURES-----------------------*/
use MACARRO
go
begin transaction;
go
---Insertar Item-----
CREATE PROCEDURE Procedure_insertarItem
	   @_itemId         [int]           ,
	   @_itemNombre      [nvarchar] (100)
	  
AS

 BEGIN
	   INSERT INTO ITEM(ITE_id,ITE_nombre,FK_estado)
	   VALUES(@_itemId, @_itemNombre,1) 
 END

GO


------------Busqueda por nombre------------------------------------------

CREATE PROCEDURE Procedure_buscarItemNombre
(
	@_itemNombre varchar (50)
)
AS
SELECT ITE_id AS Codigo, ITE_nombre AS Nombre, ITE_INV_cantidad AS Cantidad
FROM ITEM, ITEM_INVENTARIO
WHERE (ITE_nombre LIKE concat(@_itemNombre,'%')) AND (FK_item = ITE_id);
go


--------------Busqueda por codigo-----------------------------------------------------

CREATE PROCEDURE Procedure_buscarItemCodigo
(
	@_itemId varchar (50)
)
AS
SELECT ITE_id AS Codigo, ITE_nombre AS Nombre, ITE_INV_cantidad AS Cantidad
FROM ITEM, ITEM_INVENTARIO
WHERE (ITE_id = @_itemId) AND (FK_item = ITE_id);

go

--------------------------------------------NUEVOOOOOO-------------------------------------

CREATE PROCEDURE Procedure_verProveedor
	   @_itemId			[int]   
AS

 BEGIN	
		DECLARE @_verItemId	 int
		DECLARE @_itemInventarioid int
						
		SELECT @_verItemId	 = ITE_id FROM ITEM WHERE ITE_id = @_itemId;
		SELECT @_itemInventarioid = ITE_INV_id from ITEM_INVENTARIO  where FK_item=@_verItemId;

		select PRO_razonSocial
		from PROVEEDOR  where PRO_id = (select FK_proveedor from ITEM_PROV where FK_item = @_itemId);
 END

GO

----------------------------------Arreglado-----



--------------------------------

CREATE PROCEDURE Procedure_modificarItemMostrado
	   @_itemId 				[int]				      ,
	   @_itemNombre 			[nvarchar]    (100)       ,
	   @_itemCantidad			[int]				      ,
	   @_itemDescripcion		[nvarchar]    (100)       ,
	   @_razonProveedor			[nvarchar]	  (100)		  ,
	   @_itemPrecioCompra		[float]					  ,
	   @_itemPrecioVenta		[float]	,
	   @_itemEstado             [nvarchar] (20)				  
        
AS

 BEGIN

		declare @_idEstado int;
		set @_idEstado = (select EST_id from estado where EST_nombre = @_itemEstado);
		
		Update ITEM set ITE_nombre = @_itemNombre, FK_estado = @_idEstado  where ITE_id=@_itemId ;

		Update ITEM_INVENTARIO set   ITE_INV_precioVenta = @_itemPrecioVenta ,
									 ITE_INV_descripcion = @_itemDescripcion,
									 ITE_INV_cantidad    = @_itemCantidad
							   where FK_item             = @_itemId ;

		Insert into ACTUALIZACION (ACT_id,
								  ACT_cantidad,
								  ACT_fecha,
								  FK_itemInventario)
							   values  ((select max(ACT_id)+1 from ACTUALIZACION),
										@_itemCantidad,
									    (Getdate()),
										(select ITE_INV_id from ITEM_INVENTARIO where FK_item = @_itemId )
										);
									
		Update PROV_INVENTARIO set   PRO_INV_precioCompra = @_itemPrecioCompra,
									 FK_actualizacion     = (select max(ACT_id) from ACTUALIZACION),
									 FK_proveedor		  = (select PRO_id from PROVEEDOR where PRO_razonSocial= @_razonProveedor)
							   where FK_item_inventario   = (select ITE_INV_id from ITEM_INVENTARIO where FK_item = @_itemId );

		Update ITEM_PROV	   set	 FK_proveedor		  = (select PRO_id from PROVEEDOR where PRO_razonSocial= @_razonProveedor)
							   where FK_item = @_itemId ;
 END

GO

-----------Modificar Item --------------

CREATE PROCEDURE Procedure_modificarItem
	   @_itemId           [int]           ,
	   @_itemNombre       [nvarchar] (100) 
AS

 UPDATE ITEM 
 SET 
	ITE_id			 = @_itemId,
	ITE_nombre       = @_itemNombre
 WHERE
	  ITE_id     = @_itemId ;
GO

-----------Consultar Item----------------

CREATE PROCEDURE Procedure_consultaritem

	@_itemId		[int]

AS

  BEGIN
	   SELECT ITE_nombre
	   FROM ITEM
	   WHERE  ITE_id = @_itemId

  END

GO


--------Eliminar Item-----------------

CREATE PROCEDURE Procedure_eliminarItem

	@_itemId		[int]

AS

  BEGIN
	   
	   UPDATE ITEM SET FK_estado = 2 where ITE_id = @_itemId;

  END

GO


----------------------

CREATE PROCEDURE Procedure_GridviewCarga
	  
AS

 BEGIN
		select Distinct (ITE_id) AS Codigo, ITE_nombre AS Nombre , ITE_INV_cantidad AS Cantidad, EST_nombre as Estado  from ITEM,ITEM_INVENTARIO, ESTADO where EST_id = FK_estado and FK_item = ITE_id ;


 END

GO

------------------------------Cambiar atributo, este procedure ya existe-----------
CREATE PROCEDURE Procedure_verItemInventario
	   @_itemId			[int]   
AS

 BEGIN	
		DECLARE @_verItemId int
						
		SELECT @_verItemId = ITE_id FROM ITEM WHERE ITE_id = @_itemId;

		select ITE_INV_cantidad,ITE_INV_descripcion,ITE_INV_precioVenta 
		from ITEM_INVENTARIO  where FK_item=@_verItemId;
 END

GO

---Insertar Item_Inventario-----

CREATE PROCEDURE Procedure_insertarInventarioItem
	   @_inventarioItemId				[int]           ,
	   @_itemPrecioVenta			[float]         ,
	   @_itemDescripcion		[nvarchar] (100),
	   @_itemCantidad		    [int]           ,
	   @_inventarioItemCantidadMinima	[int]           ,
	   @_itemId			[int]           
AS

 BEGIN
	   INSERT INTO ITEM_INVENTARIO(ITE_INV_id,ITE_INV_precioVenta,ITE_INV_descripcion,ITE_INV_cantidad,ITE_INV_cantidadMin,FK_item)
	   VALUES(@_inventarioItemId,@_itemPrecioVenta,@_itemDescripcion,@_itemCantidad,@_inventarioItemCantidadMinima,@_itemId) 
 END

GO
-----------Modificar Item_Inventario --------------

CREATE PROCEDURE Procedure_modificarItemInventario
	   @_inventarioItemId				[int]           ,
	   @_itemPrecioVenta			[float]         ,
	   @_itemDescripcion		[nvarchar] (100),
	   @_itemCantidad		    [int]           ,
	   @_inventarioItemCantidadMinima	[int]           ,
	   @_itemId			[int]           	          
AS

 UPDATE ITEM_INVENTARIO 
 SET 
	ITE_INV_precioVenta    = @_itemPrecioVenta	,
	ITE_INV_descripcion	 = @_itemDescripcion,
	ITE_INV_cantidad = @_itemCantidad,
	ITE_INV_cantidadMin = @_inventarioItemCantidadMinima
	 
 WHERE
	  ITE_INV_id     = @_inventarioItemId ;
GO

-----------Consultar Item_Inventario----------------

CREATE PROCEDURE Procedure_consultaItemInventario

	   @_inventarioItemId				[int]                

AS

  BEGIN
	   SELECT ITE_INV_precioVenta,ITE_INV_descripcion,ITE_INV_cantidad,ITE_INV_cantidadMin
	   FROM ITEM_INVENTARIO
	   WHERE  ITE_INV_id = @_inventarioItemId

  END

GO


--------Eliminar Item_Inventario-----------------

CREATE PROCEDURE Procedure_eliminarItemInventario

	   @_inventarioItemId				[int]           

AS

  BEGIN
	   DELETE 
	   FROM ITEM_INVENTARIO
	   WHERE  ITE_INV_id = @_inventarioItemId

  END

GO



----------------------------------------

---Insertar Actualizacion-----

CREATE PROCEDURE Procedure_insertarActualizacion
	   @_actualizacionId				[int]           ,
	   @_actualizacionFecha				[date]          ,
	   @_actualizacionCantidad			[int]			,
	   @_inventarioItemId	[int]           	   

AS

 BEGIN
	   INSERT INTO ACTUALIZACION(ACT_id,ACT_fecha,ACT_cantidad,FK_itemInventario)
	   VALUES(@_actualizacionId,@_actualizacionFecha,@_actualizacionCantidad,@_inventarioItemId) 
 END

GO
-----------Modificar Actualizacion --------------

CREATE PROCEDURE Procedure_modificarActualizacion
	   @_actualizacionId				[int]           ,
	   @_actualizacionFecha				[date]          ,
	   @_actualizacionCantidad			[int]			,
	   @_inventarioItemId	[int]           
AS

 UPDATE ACTUALIZACION 
 SET 
	ACT_fecha   = @_actualizacionFecha,
	ACT_cantidad	 = @_actualizacionCantidad
	 
 WHERE
	  ACT_id     = @_actualizacionId ;
GO

-----------Consultar Actualizacion----------------

CREATE PROCEDURE Procedure_consultaActualizacion

	   @_actualizacionId				[int]            

AS

  BEGIN
	   SELECT ACT_fecha,ACT_cantidad
	   FROM ACTUALIZACION
	   WHERE  ACT_id = @_actualizacionId

  END

GO


--------Eliminar Actualizacion-----------------

CREATE PROCEDURE Procedure_eliminarActualizacion

	   @_actualizacionId				[int]      

AS

  BEGIN
	   DELETE 
	   FROM ACTUALIZACION
	   WHERE  ACT_id = @_actualizacionId

  END

GO




CREATE PROCEDURE Procedure_guardarItem
	   @_itemNombre			[nvarchar]    (100)       ,
	   @_itemCantidad		[int]				      ,
	   @_inventarioItemCantidadMinima	[int]				      ,
	   @_itemDescripcion		[nvarchar]    (100)       ,
	   @_razonProveedor		[nvarchar]	  (100)		  ,
	   @_itemPrecioCompra	[float]					  ,
	   @_itemPrecioVenta		[float]					  ,
	   @_guardarItemFechaCompra		[datetime]				        
        
AS

 BEGIN
		insert into ITEM (ITE_id,ITE_nombre,FK_estado) values ((select max(ITE_id) from ITEM)+1,@_itemNombre,1);

		insert into ITEM_INVENTARIO(ITE_INV_id,
									ITE_INV_precioVenta,
									ITE_INV_descripcion,
									ITE_INV_cantidad,
									ITE_INV_cantidadMin,
									FK_item) 
							values ((select max(ITE_INV_id) from ITEM_INVENTARIO)+1,
									@_itemPrecioVenta,
									@_itemDescripcion,
									@_itemCantidad,
									@_inventarioItemCantidadMinima,
									(select max(ITE_id) from ITEM));

		insert into PROV_INVENTARIO(PRO_INV_cantidad,
									PRO_INV_fechaCombra,
									PRO_INV_id,
									PRO_INV_precioCompra,
									FK_proveedor,
									FK_item_inventario,
									FK_actualizacion) 
							values (@_itemCantidad,
									@_guardarItemFechaCompra,
									(select max(PRO_INV_id)+1 from PROV_INVENTARIO),		
									@_itemPrecioCompra,
									(select PRO_id from PROVEEDOR where PRO_razonSocial= @_razonProveedor),
									(select ITE_INV_id from ITEM_INVENTARIO where FK_item= (select max(ITE_id) from ITEM)),
									null);
		insert into ITEM_PROV	    (FK_item,
									FK_proveedor)
							values((select max(ITE_id) from ITEM),
								   (select PRO_id from PROVEEDOR where PRO_razonSocial= @_razonProveedor));

 END

GO
----------------------

CREATE PROCEDURE Procedure_verItemNombre
	   @_itemId			[int]   
        
AS

 BEGIN
		select ITE_nombre from Item where ITE_id=@_itemId;

 END

GO



----------------------

CREATE PROCEDURE Procedure_verProveedorInventario
	   @_itemId			[int]   
AS

 BEGIN	
		DECLARE @_verItemId int
		DECLARE @_itemInventarioid int
						
		SELECT @_verItemId = ITE_id FROM ITEM WHERE ITE_id = @_itemId;
		SELECT @_itemInventarioid = ITE_INV_id from ITEM_INVENTARIO  where FK_item=@_verItemId;

		select PRO_INV_fechaCombra,PRO_INV_precioCompra
		from PROV_INVENTARIO  where FK_item_inventario = @_itemInventarioid;
 END

GO

--------------------

CREATE PROCEDURE Procedure_verItemCantidad
	   @_itemId			[int]   
        
AS

 BEGIN
		DECLARE @_verItemId int
		DECLARE @_itemInventarioid int
		DECLARE @_itemFecha Datetime

		SELECT @_verItemId = ITE_id FROM ITEM WHERE ITE_id = @_itemId;
		SELECT @_itemInventarioid = ITE_INV_id from ITEM_INVENTARIO  where FK_item=@_itemId;
		SELECT @_itemFecha = max(ACT_fecha) from ACTUALIZACION  where FK_itemInventario = @_itemInventarioid;


		select ACT_cantidad, ACT_fecha
		from ACTUALIZACION  where FK_itemInventario = @_itemInventarioid;
 END

GO







-------------------CONSULTAR PROVEEDOR DATOS ESPECIFICOS---------------------

CREATE PROCEDURE Procedure_proveedorInfo
AS
   BEGIN
      SELECT PRO_id, PRO_razonSocial
	  FROM PROVEEDOR, ESTADO
	WHERE FK_estado = EST_id
	and EST_nombre = 'Activado';
	  
	END
GO

--------------------------------
	
/*-----------------------------------INSERTS-----------------------------------------*/

/*---------------------------------ITEM---------------------------------------------*/

INSERT INTO ITEM VALUES (1,'Lechuga',1);
go
INSERT INTO ITEM VALUES (2,'Pan Bimbo',1);
go
INSERT INTO ITEM VALUES (3,'Pepinillos',1);
go
INSERT INTO ITEM VALUES (4,'Soda',1);
go
INSERT INTO ITEM VALUES (5,'Pera',1);
go
INSERT INTO ITEM VALUES (6,'Remolacha',1);
go
INSERT INTO ITEM VALUES (7,'Harina',1);
go
INSERT INTO ITEM VALUES (8,'Salsa de soya',1);
go
INSERT INTO ITEM VALUES (9,'Suero',1);
go
INSERT INTO ITEM VALUES (10,'Nata',1);
go
INSERT INTO ITEM VALUES (11,'Salsa de tomate',1);
go
INSERT INTO ITEM VALUES (12,'Pimenton',1);
go
INSERT INTO ITEM VALUES (13,'Lentejas',1);
go
INSERT INTO ITEM VALUES (14,'Caraotas',1);
go
INSERT INTO ITEM VALUES (15,'Frescolita',1);
go
INSERT INTO ITEM VALUES (16,'Pasta',1);
go
INSERT INTO ITEM VALUES (17,'Harina de trigo',1);
go
INSERT INTO ITEM VALUES (18,'Pepsi',1);
go
INSERT INTO ITEM VALUES (19,'Mayonesa',1);
go
INSERT INTO ITEM VALUES (20,'Mostaza',1);
go
INSERT INTO ITEM VALUES (21,'Pollo',1);
go
INSERT INTO ITEM VALUES (22,'Huevo',1);
go
INSERT INTO ITEM VALUES (23,'Garbanzos',1);
go
INSERT INTO ITEM VALUES (24,'Chistorras',1);
go
INSERT INTO ITEM VALUES (25,'Salchichas',2);
go





/*---------------------------------ITEM_INVENTARIO---------------------------------------------*/

INSERT INTO ITEM_INVENTARIO VALUES (1,135, 'Lechuga', 32, 13,1);
go
INSERT INTO ITEM_INVENTARIO VALUES (2,130, 'Pan Bimbo', 44, 17,2);
go
INSERT INTO ITEM_INVENTARIO VALUES (3,120, 'Pepinillos', 32, 11,3);
go
INSERT INTO ITEM_INVENTARIO VALUES (4,115, 'Soda', 48, 20,4);
go
INSERT INTO ITEM_INVENTARIO VALUES (5,105, 'Pera', 33, 22,5);
go
INSERT INTO ITEM_INVENTARIO VALUES (6,130, 'Remolacha', 57, 28,6);
go
INSERT INTO ITEM_INVENTARIO VALUES (7,125, 'Harina', 22, 10,7);
go
INSERT INTO ITEM_INVENTARIO VALUES (8,135, 'Salsa de soya', 33, 30,8);
go
INSERT INTO ITEM_INVENTARIO VALUES (9,145, 'Suero', 38, 33,9);
go
INSERT INTO ITEM_INVENTARIO VALUES (10,155, 'Nata', 12, 10,10);
go
INSERT INTO ITEM_INVENTARIO VALUES (11,135, 'Salsa de tomate', 40, 37,11);
go
INSERT INTO ITEM_INVENTARIO VALUES (12,130, 'Pimenton', 40, 40,12);
go
INSERT INTO ITEM_INVENTARIO VALUES (13,120, 'Lentejas', 49, 45,13);
go
INSERT INTO ITEM_INVENTARIO VALUES (14,105, 'Caraotas', 112, 49,14);
go
INSERT INTO ITEM_INVENTARIO VALUES (15,115, 'Frescolita', 100, 50,15);
go
INSERT INTO ITEM_INVENTARIO VALUES (16,130, 'Pasta', 99, 58,16);
go
INSERT INTO ITEM_INVENTARIO VALUES (17,135, 'Harina de trigo', 67, 52,17);
go
INSERT INTO ITEM_INVENTARIO VALUES (18,145, 'Pepsi', 106, 100,18);
go
INSERT INTO ITEM_INVENTARIO VALUES (19,125, 'Mayonesa', 123, 103,19);
go
INSERT INTO ITEM_INVENTARIO VALUES (20,135, 'Mostaza', 156, 108,20);
go
INSERT INTO ITEM_INVENTARIO VALUES (21,135, 'Pollo', 187, 109,21);
go
INSERT INTO ITEM_INVENTARIO VALUES (22,135, 'Huevo', 90, 78,22);
go
INSERT INTO ITEM_INVENTARIO VALUES (23,135, 'Garbanzos', 80, 73,23);
go
INSERT INTO ITEM_INVENTARIO VALUES (24,135, 'Chistorras', 70, 69,24);
go
INSERT INTO ITEM_INVENTARIO VALUES (25,135, 'Salchichas', 97, 87,25);
go


/*---------------------------------ACTUALIZACION---------------------------------------------*/


INSERT INTO ACTUALIZACION VALUES (1,'02/07/14',100,1);
go
INSERT INTO ACTUALIZACION VALUES (2,'02/07/14',100,2);
go
INSERT INTO ACTUALIZACION VALUES (3,'02/07/14',100,3);
go
INSERT INTO ACTUALIZACION VALUES (4,'02/07/14',100,4);
go
INSERT INTO ACTUALIZACION VALUES (5,'02/07/14',100,5);
go
INSERT INTO ACTUALIZACION VALUES (6,'02/07/14',100,6);
go
INSERT INTO ACTUALIZACION VALUES (7,'02/07/14',100,7);
go
INSERT INTO ACTUALIZACION VALUES (8,'02/07/14',100,8);
go
INSERT INTO ACTUALIZACION VALUES (9,'02/07/14',100,9);
go
INSERT INTO ACTUALIZACION VALUES (10,'02/07/14',100,10);
go
INSERT INTO ACTUALIZACION VALUES (11,'02/07/14',100,11);
go
INSERT INTO ACTUALIZACION VALUES (12,'02/07/14',100,12);
go
INSERT INTO ACTUALIZACION VALUES (13,'02/07/14',100,13);
go
INSERT INTO ACTUALIZACION VALUES (14,'02/07/14',100,14);
go
INSERT INTO ACTUALIZACION VALUES (15,'02/07/14',100,15);
go
INSERT INTO ACTUALIZACION VALUES (16,'02/07/14',100,16);
go
INSERT INTO ACTUALIZACION VALUES (17,'02/07/14',100,17);
go
INSERT INTO ACTUALIZACION VALUES (18,'02/07/14',100,18);
go
INSERT INTO ACTUALIZACION VALUES (19,'02/07/14',100,19);
go
INSERT INTO ACTUALIZACION VALUES (20,'02/07/14',100,20);
go
INSERT INTO ACTUALIZACION VALUES (21,'02/07/14',100,21);
go
INSERT INTO ACTUALIZACION VALUES (22,'02/07/14',100,22);
go
INSERT INTO ACTUALIZACION VALUES (23,'02/07/14',100,23);
go
INSERT INTO ACTUALIZACION VALUES (24,'02/07/14',100,24);
go
INSERT INTO ACTUALIZACION VALUES (25,'02/07/14',100,25);
go

INSERT INTO ACTUALIZACION VALUES (26,'02/15/14',70,1);
go
INSERT INTO ACTUALIZACION VALUES (27,'02/15/14',60,2);
go
INSERT INTO ACTUALIZACION VALUES (28,'02/15/14',30,3);
go
INSERT INTO ACTUALIZACION VALUES (29,'02/15/14',70,4);
go
INSERT INTO ACTUALIZACION VALUES (30,'02/15/14',55,5);
go
INSERT INTO ACTUALIZACION VALUES (31,'02/15/14',36,6);
go
INSERT INTO ACTUALIZACION VALUES (32,'02/15/14',18,7);
go
INSERT INTO ACTUALIZACION VALUES (33,'02/15/14',19,8);
go
INSERT INTO ACTUALIZACION VALUES (34,'02/15/14',27,9);
go
INSERT INTO ACTUALIZACION VALUES (35,'02/15/14',96,10);
go
INSERT INTO ACTUALIZACION VALUES (36,'02/15/14',63,11);
go
INSERT INTO ACTUALIZACION VALUES (37,'02/15/14',80,12);
go
INSERT INTO ACTUALIZACION VALUES (38,'02/15/14',14,13);
go
INSERT INTO ACTUALIZACION VALUES (39,'02/15/14',19,14);
go
INSERT INTO ACTUALIZACION VALUES (40,'02/15/14',59,15);
go
INSERT INTO ACTUALIZACION VALUES (41,'02/15/14',87,16);
go
INSERT INTO ACTUALIZACION VALUES (42,'02/15/14',45,17);
go
INSERT INTO ACTUALIZACION VALUES (43,'02/15/14',26,18);
go
INSERT INTO ACTUALIZACION VALUES (44,'02/15/14',21,19);
go
INSERT INTO ACTUALIZACION VALUES (45,'02/15/14',99,20);
go
INSERT INTO ACTUALIZACION VALUES (46,'02/15/14',78,21);
go
INSERT INTO ACTUALIZACION VALUES (47,'02/15/14',89,22);
go
INSERT INTO ACTUALIZACION VALUES (48,'02/15/14',42,23);
go
INSERT INTO ACTUALIZACION VALUES (49,'02/15/14',31,24);
go
INSERT INTO ACTUALIZACION VALUES (50,'02/15/14',47,25);
go

INSERT INTO ACTUALIZACION VALUES (51,'02/22/14',40,1);
go
INSERT INTO ACTUALIZACION VALUES (52,'02/22/14',20,2);
go
INSERT INTO ACTUALIZACION VALUES (53,'02/22/14',20,3);
go
INSERT INTO ACTUALIZACION VALUES (54,'02/22/14',60,4);
go
INSERT INTO ACTUALIZACION VALUES (55,'02/22/14',45,5);
go
INSERT INTO ACTUALIZACION VALUES (56,'02/22/14',26,6);
go
INSERT INTO ACTUALIZACION VALUES (57,'02/22/14',12,7);
go
INSERT INTO ACTUALIZACION VALUES (58,'02/22/14',14,8);
go
INSERT INTO ACTUALIZACION VALUES (59,'02/22/14',17,9);
go
INSERT INTO ACTUALIZACION VALUES (60,'02/22/14',86,10);
go
INSERT INTO ACTUALIZACION VALUES (61,'02/22/14',53,11);
go
INSERT INTO ACTUALIZACION VALUES (62,'02/22/14',40,12);
go
INSERT INTO ACTUALIZACION VALUES (63,'02/22/14',11,13);
go
INSERT INTO ACTUALIZACION VALUES (64,'02/22/14',12,14);
go
INSERT INTO ACTUALIZACION VALUES (65,'02/22/14',52,15);
go
INSERT INTO ACTUALIZACION VALUES (66,'02/22/14',67,16);
go
INSERT INTO ACTUALIZACION VALUES (67,'02/22/14',35,17);
go
INSERT INTO ACTUALIZACION VALUES (68,'02/22/14',24,18);
go
INSERT INTO ACTUALIZACION VALUES (69,'02/22/14',20,19);
go
INSERT INTO ACTUALIZACION VALUES (70,'02/22/14',82,20);
go
INSERT INTO ACTUALIZACION VALUES (71,'02/22/14',58,21);
go
INSERT INTO ACTUALIZACION VALUES (72,'02/22/14',65,22);
go
INSERT INTO ACTUALIZACION VALUES (73,'02/22/14',36,23);
go
INSERT INTO ACTUALIZACION VALUES (74,'02/22/14',23,24);
go
INSERT INTO ACTUALIZACION VALUES (75,'02/22/14',30,25);
go


/*---------------------------------PROV_INVENTARIO---------------------------------------------*/

INSERT INTO PROV_INVENTARIO VALUES (1,'02/07/14',32,99,1,1,1);
go
INSERT INTO PROV_INVENTARIO VALUES (2,'02/07/14',44,120,2,2,1);
go
INSERT INTO PROV_INVENTARIO VALUES (3,'02/07/14',32,150,3,3,1);
go
INSERT INTO PROV_INVENTARIO VALUES (4,'02/07/14',48,200,4,4,1);
go
INSERT INTO PROV_INVENTARIO VALUES (5,'02/07/14',33,300,5,5,1);
go
INSERT INTO PROV_INVENTARIO VALUES (6,'02/07/14',57,100,6,6,2);
go
INSERT INTO PROV_INVENTARIO VALUES (7,'02/07/14',22,22,7,7,2);
go
INSERT INTO PROV_INVENTARIO VALUES (8,'02/07/14',33,17,8,8,2);
go
INSERT INTO PROV_INVENTARIO VALUES (9,'02/07/14',38,56,9,9,2);
go
INSERT INTO PROV_INVENTARIO VALUES (10,'02/07/14',12,76,10,10,2);
go
INSERT INTO PROV_INVENTARIO VALUES (11,'02/07/14',40,115,11,11,4);
go
INSERT INTO PROV_INVENTARIO VALUES (12,'02/07/14',40,80,12,12,4);
go
INSERT INTO PROV_INVENTARIO VALUES (13,'02/07/14',49,23,13,13,4);
go
INSERT INTO PROV_INVENTARIO VALUES (14,'02/07/14',112,45,14,14,4);
go
INSERT INTO PROV_INVENTARIO VALUES (15,'02/07/14',100,80,15,15,4);
go
INSERT INTO PROV_INVENTARIO VALUES (16,'02/07/14',99,87,16,16,5);
go
INSERT INTO PROV_INVENTARIO VALUES (17,'02/07/14',67,56,17,17,5);
go
INSERT INTO PROV_INVENTARIO VALUES (18,'02/07/14',106,34,18,18,5);
go
INSERT INTO PROV_INVENTARIO VALUES (19,'02/07/14',123,78,19,19,5);
go
INSERT INTO PROV_INVENTARIO VALUES (20,'02/07/14',156,80,20,20,5);
go
INSERT INTO PROV_INVENTARIO VALUES (21,'02/07/14',187,76,21,21,3);
go
INSERT INTO PROV_INVENTARIO VALUES (22,'02/07/14',90,12,22,22,3);
go
INSERT INTO PROV_INVENTARIO VALUES (23,'02/07/14',80,23,23,23,3);
go
INSERT INTO PROV_INVENTARIO VALUES (24,'02/07/14',70,54,24,24,3);
go
INSERT INTO PROV_INVENTARIO VALUES (25,'02/07/14',97,67,25,25,3);
go


-----------------INSERTS ITEM_PROV (requiere datos de tablas Proveedor e Item)---------------------------------------------------------

INSERT INTO ITEM_PROV VALUES (1,1);
go
INSERT INTO ITEM_PROV VALUES (2,1);
go
INSERT INTO ITEM_PROV VALUES (3,1);
go
INSERT INTO ITEM_PROV VALUES (4,1);
go
INSERT INTO ITEM_PROV VALUES (5,1);
go
INSERT INTO ITEM_PROV VALUES (6,2);
go
INSERT INTO ITEM_PROV VALUES (7,2); 
go
INSERT INTO ITEM_PROV VALUES (8,2);
go
INSERT INTO ITEM_PROV VALUES (9,2);
go
INSERT INTO ITEM_PROV VALUES (10,2);
go
INSERT INTO ITEM_PROV VALUES (11,3);
go
INSERT INTO ITEM_PROV VALUES (12,3);
go
INSERT INTO ITEM_PROV VALUES (13,3);
go
INSERT INTO ITEM_PROV VALUES (14,3);
go
INSERT INTO ITEM_PROV VALUES (15,3);
go
INSERT INTO ITEM_PROV VALUES (16,4);
go
INSERT INTO ITEM_PROV VALUES (17,4);
go
INSERT INTO ITEM_PROV VALUES (18,4);
go
INSERT INTO ITEM_PROV VALUES (19,4);
go
INSERT INTO ITEM_PROV VALUES (20,4);
go
INSERT INTO ITEM_PROV VALUES (21,5);
go
INSERT INTO ITEM_PROV VALUES (22,5);
go
INSERT INTO ITEM_PROV VALUES (23,5);
go
INSERT INTO ITEM_PROV VALUES (24,5);
go
INSERT INTO ITEM_PROV VALUES (25,5);
go


commit transaction;
go



