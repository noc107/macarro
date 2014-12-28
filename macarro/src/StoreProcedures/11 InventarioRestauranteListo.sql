/*----------------------------STORED_PROCEDURES-----------------------*/
use MACARRO
go
begin transaction;
go
---Insertar Item-----
CREATE PROCEDURE Procedure_insertarItem
	   @_itemid         [int]           ,
	   @_itemNombre      [nvarchar] (100)
AS

 BEGIN
	   INSERT INTO ITEM(ITE_id,ITE_nombre)
	   VALUES(@_itemid, @_itemnombre) 
 END

GO


------------Busqueda por nombre------------------------------------------

CREATE PROCEDURE Procedure_buscarItemNombre
(
	@nombreBuscado varchar (50)
)
AS
SELECT ITE_id AS Codigo, ITE_nombre AS Nombre, ITE_INV_cantidad AS Cantidad
FROM ITEM, ITEM_INVENTARIO
WHERE (ITE_nombre LIKE concat(@nombreBuscado,'%')) AND (FK_item = ITE_id);
go


--------------Busqueda por codigo-----------------------------------------------------

CREATE PROCEDURE Procedure_buscarItemCodigo
(
	@idBuscado varchar (50)
)
AS
SELECT ITE_id AS Codigo, ITE_nombre AS Nombre, ITE_INV_cantidad AS Cantidad
FROM ITEM, ITEM_INVENTARIO
WHERE (ITE_id = @idBuscado) AND (FK_item = ITE_id);

go

--------------------------------------------NUEVOOOOOO-------------------------------------

CREATE PROCEDURE Procedure_verProveedor
	   @_verItemId			[int]   
AS

 BEGIN	
		DECLARE @_itemId int
		DECLARE @_itemInventarioid int
						
		SELECT @_itemId = ITE_id FROM ITEM WHERE ITE_id = @_verItemId;
		SELECT @_itemInventarioid = ITE_INV_id from ITEM_INVENTARIO  where FK_item=@_itemId;

		select PRO_razonSocial
		from PROVEEDOR  where PRO_id = (select FK_proveedor from ITEM_PROV where FK_item = @_verItemId);
 END

GO

----------------------------------Arreglado-----



--------------------------------

CREATE PROCEDURE Procedure_modificarItemMostrado
	   @_modificarItemId				[int]				      ,
	   @_modificarItemNombre			[nvarchar]    (100)       ,
	   @_modificarItemCantidad			[int]				      ,
	   @_modificarItemDescripcion		[nvarchar]    (100)       ,
	   @_modificarItemProveedor			[nvarchar]	  (100)		  ,
	   @_modificarItemPrecioCompra		[float]					  ,
	   @_modificarItemPrecioVenta		[float]					  
        
AS

 BEGIN
		Update ITEM set ITE_nombre = @_modificarItemNombre where ITE_id=@_modificarItemId;

		Update ITEM_INVENTARIO set   ITE_INV_precioVenta = @_modificarItemPrecioVenta ,
									 ITE_INV_descripcion = @_modificarItemDescripcion,
									 ITE_INV_cantidad    = @_modificarItemCantidad
							   where FK_item             = @_modificarItemId;

		Insert into ACTUALIZACION (ACT_id,
								  ACT_cantidad,
								  ACT_fecha,
								  FK_itemInventario)
							   values  ((select max(ACT_id)+1 from ACTUALIZACION),
										@_modificarItemCantidad,
									    (Getdate()),
										(select ITE_INV_id from ITEM_INVENTARIO where FK_item = @_modificarItemId)
										);
									
		Update PROV_INVENTARIO set   PRO_INV_precioCompra = @_modificarItemPrecioCompra,
									 FK_actualizacion     = (select max(ACT_id) from ACTUALIZACION),
									 FK_proveedor		  = (select PRO_id from PROVEEDOR where PRO_razonSocial= @_modificarItemProveedor)
							   where FK_item_inventario   = (select ITE_INV_id from ITEM_INVENTARIO where FK_item = @_modificarItemId);

		Update ITEM_PROV	   set	 FK_proveedor		  = (select PRO_id from PROVEEDOR where PRO_razonSocial= @_modificarItemProveedor)
							   where FK_item = @_modificarItemId;
 END

GO

-----------Modificar Item --------------

CREATE PROCEDURE Procedure_modificarItem
	   @_itemid          [int]           ,
	   @_itemnombre      [nvarchar] (100) 
AS

 UPDATE ITEM 
 SET 
	ITE_id			 = @_itemid,
	ITE_nombre       = @_itemnombre
 WHERE
	  ITE_id     = @_itemid ;
GO

-----------Consultar Item----------------

CREATE PROCEDURE Procedure_consultaritem

	@_itemid		[int]

AS

  BEGIN
	   SELECT ITE_nombre
	   FROM ITEM
	   WHERE  ITE_id = @_itemid

  END

GO


--------Eliminar Item-----------------

CREATE PROCEDURE Procedure_eliminarItem

	@_itemid		[int]

AS

  BEGIN
	   
	   Delete from ACTUALIZACION where FK_itemInventario = (select ITE_INV_id from ITEM_INVENTARIO where FK_item = @_itemid);

	   Delete from PROV_INVENTARIO where FK_item_inventario = (select ITE_INV_id from ITEM_INVENTARIO where FK_item = @_itemid);

	   Delete from ITEM_INVENTARIO where FK_item= @_itemid;

	   Delete from ITEM_PROV where FK_item = @_itemid;

	   Delete ITEM  where  ITE_id = @_itemid;

  END

GO


----------------------

CREATE PROCEDURE Procedure_GridviewCarga
	  
AS

 BEGIN
		select Distinct (ITE_id) AS Codigo, ITE_nombre AS Nombre , ITE_INV_cantidad AS Cantidad  from ITEM,ITEM_INVENTARIO ;


 END

GO

------------------------------Cambiar atributo, este procedure ya existe-----------
CREATE PROCEDURE Procedure_verItemInventario
	   @_verItemId			[int]   
AS

 BEGIN	
		DECLARE @_itemId int
						
		SELECT @_itemId = ITE_id FROM ITEM WHERE ITE_id = @_verItemId;

		select ITE_INV_cantidad,ITE_INV_descripcion,ITE_INV_precioVenta 
		from ITEM_INVENTARIO  where FK_item=@_itemId;
 END

GO

---Insertar Item_Inventario-----

CREATE PROCEDURE Procedure_insertarInventarioItem
	   @_inventarioitemid				[int]           ,
	   @_inventarioitemprecioventa		[float]         ,
	   @_inventarioitemdescripcion		[nvarchar] (100),
	   @_inventarioitemcantidad		    [int]           ,
	   @_inventarioitemcantidadminima	[int]           ,
	   @_inventarioitemfkitem			[int]           
AS

 BEGIN
	   INSERT INTO ITEM_INVENTARIO(ITE_INV_id,ITE_INV_precioVenta,ITE_INV_descripcion,ITE_INV_cantidad,ITE_INV_cantidadMin,FK_item)
	   VALUES(@_inventarioitemid,@_inventarioitemprecioventa,@_inventarioitemdescripcion,@_inventarioitemcantidad,@_inventarioitemcantidadminima,@_inventarioitemfkitem) 
 END

GO
-----------Modificar Item_Inventario --------------

CREATE PROCEDURE Procedure_modificarItemInventario
	   @_inventarioitemid				[int]           ,
	   @_inventarioitemprecioventa		[float]         ,
	   @_inventarioitemdescripcion		[nvarchar] (100),
	   @_inventarioitemcantidad		    [int]           ,
	   @_inventarioitemcantidadminima	[int]           ,
	   @_inventarioitemfkitem			[int]           	          
AS

 UPDATE ITEM_INVENTARIO 
 SET 
	ITE_INV_precioVenta    = @_inventarioitemprecioventa,
	ITE_INV_descripcion	 = @_inventarioitemdescripcion,
	ITE_INV_cantidad = @_inventarioitemcantidad,
	ITE_INV_cantidadMin = @_inventarioitemcantidadminima
	 
 WHERE
	  ITE_INV_id     = @_inventarioitemid ;
GO

-----------Consultar Item_Inventario----------------

CREATE PROCEDURE Procedure_consultaItemInventario

	   @_inventarioitemid				[int]                

AS

  BEGIN
	   SELECT ITE_INV_precioVenta,ITE_INV_descripcion,ITE_INV_cantidad,ITE_INV_cantidadMin
	   FROM ITEM_INVENTARIO
	   WHERE  ITE_INV_id = @_inventarioitemid

  END

GO


--------Eliminar Item_Inventario-----------------

CREATE PROCEDURE Procedure_eliminarItemInventario

	   @_inventarioitemid				[int]           

AS

  BEGIN
	   DELETE 
	   FROM ITEM_INVENTARIO
	   WHERE  ITE_INV_id = @_inventarioitemid

  END

GO



----------------------------------------

---Insertar Actualizacion-----

CREATE PROCEDURE Procedure_insertarActualizacion
	   @_actualizacionid				[int]           ,
	   @_actualizacionfecha				[date]          ,
	   @_actualizacioncantidad			[int]			,
	   @_actualizacionfkiteminventario	[int]           	   

AS

 BEGIN
	   INSERT INTO ACTUALIZACION(ACT_id,ACT_fecha,ACT_cantidad,FK_itemInventario)
	   VALUES(@_actualizacionid,@_actualizacionfecha,@_actualizacioncantidad,@_actualizacionfkiteminventario) 
 END

GO
-----------Modificar Actualizacion --------------

CREATE PROCEDURE Procedure_modificarActualizacion
	   @_actualizacionid				[int]           ,
	   @_actualizacionfecha				[date]          ,
	   @_actualizacioncantidad			[int]			,
	   @_actualizacionfkiteminventario	[int]           
AS

 UPDATE ACTUALIZACION 
 SET 
	ACT_fecha   = @_actualizacionfecha,
	ACT_cantidad	 = @_actualizacioncantidad
	 
 WHERE
	  ACT_id     = @_actualizacionid ;
GO

-----------Consultar Actualizacion----------------

CREATE PROCEDURE Procedure_consultaActualizacion

	   @_actualizacionid				[int]            

AS

  BEGIN
	   SELECT ACT_fecha,ACT_cantidad
	   FROM ACTUALIZACION
	   WHERE  ACT_id = @_actualizacionid

  END

GO


--------Eliminar Actualizacion-----------------

CREATE PROCEDURE Procedure_eliminarActualizacion

	   @_actualizacionid				[int]      

AS

  BEGIN
	   DELETE 
	   FROM ACTUALIZACION
	   WHERE  ACT_id = @_actualizacionid

  END

GO



use MACARRO
GO


CREATE PROCEDURE Procedure_guardarItem
	   @_guardarItemNombre			[nvarchar]    (100)       ,
	   @_guardarItemCantidad		[int]				      ,
	   @_guardarItemCantidadMinima	[int]				      ,
	   @_guardarItemDescripcion		[nvarchar]    (100)       ,
	   @_guardarItemProveedor		[nvarchar]	  (100)		  ,
	   @_guardarItemPrecioCompra	[float]					  ,
	   @_guardarItemPrecioVenta		[float]					  ,
	   @_guardarItemFechaCompra		[datetime]				        
        
AS

 BEGIN
		insert into ITEM (ITE_id,ITE_nombre) values ((select max(ITE_id) from ITEM)+1,@_guardarItemNombre);

		insert into ITEM_INVENTARIO(ITE_INV_id,
									ITE_INV_precioVenta,
									ITE_INV_descripcion,
									ITE_INV_cantidad,
									ITE_INV_cantidadMin,
									FK_item) 
							values ((select max(ITE_INV_id) from ITEM_INVENTARIO)+1,
									@_guardarItemPrecioVenta,
									@_guardarItemDescripcion,
									@_guardarItemCantidad,
									@_guardarItemCantidadMinima,
									(select max(ITE_id) from ITEM));

		insert into PROV_INVENTARIO(PRO_INV_cantidad,
									PRO_INV_fechaCombra,
									PRO_INV_id,
									PRO_INV_precioCompra,
									FK_proveedor,
									FK_item_inventario,
									FK_actualizacion) 
							values (@_guardarItemCantidad,
									@_guardarItemFechaCompra,
									(select max(PRO_INV_id)+1 from PROV_INVENTARIO),		
									@_guardarItemPrecioCompra,
									(select PRO_id from PROVEEDOR where PRO_razonSocial= @_guardarItemProveedor),
									(select ITE_INV_id from ITEM_INVENTARIO where FK_item= (select max(ITE_id) from ITEM)),
									null);
		insert into ITEM_PROV	    (FK_item,
									FK_proveedor)
							values((select max(ITE_id) from ITEM),
								   (select PRO_id from PROVEEDOR where PRO_razonSocial= @_guardarItemProveedor));

 END

GO
----------------------

CREATE PROCEDURE Procedure_verItemNombre
	   @_verItemId			[int]   
        
AS

 BEGIN
		select ITE_nombre from Item where ITE_id=@_verItemId;

 END

GO



----------------------

CREATE PROCEDURE Procedure_verProveedorInventario
	   @_verItemId			[int]   
AS

 BEGIN	
		DECLARE @_itemId int
		DECLARE @_itemInventarioid int
						
		SELECT @_itemId = ITE_id FROM ITEM WHERE ITE_id = @_verItemId;
		SELECT @_itemInventarioid = ITE_INV_id from ITEM_INVENTARIO  where FK_item=@_itemId;

		select PRO_INV_fechaCombra,PRO_INV_precioCompra
		from PROV_INVENTARIO  where FK_item_inventario = @_itemInventarioid;
 END

GO

--------------------

CREATE PROCEDURE Procedure_verItemCantidad
	   @_verItemId			[int]   
        
AS

 BEGIN
		DECLARE @_itemId int
		DECLARE @_itemInventarioid int
		DECLARE @_itemFecha Datetime

		SELECT @_itemId = ITE_id FROM ITEM WHERE ITE_id = @_verItemId;
		SELECT @_itemInventarioid = ITE_INV_id from ITEM_INVENTARIO  where FK_item=@_itemId;
		SELECT @_itemFecha = max(ACT_fecha) from ACTUALIZACION  where FK_itemInventario = @_itemInventarioid;


		select ACT_cantidad, ACT_fecha
		from ACTUALIZACION  where FK_itemInventario = @_itemInventarioid;
 END

GO


--------------------------------
	
/*-----------------------------------INSERTS-----------------------------------------*/

/*---------------------------------ITEM---------------------------------------------*/

INSERT INTO ITEM VALUES (1,'Lechuga');
INSERT INTO ITEM VALUES (2,'Pan Bimbo');
INSERT INTO ITEM VALUES (3,'Pepinillos');
INSERT INTO ITEM VALUES (4,'Soda');
INSERT INTO ITEM VALUES (5,'Pera');
INSERT INTO ITEM VALUES (6,'Remolacha');
INSERT INTO ITEM VALUES (7,'Harina');
INSERT INTO ITEM VALUES (8,'Salsa de soya');
INSERT INTO ITEM VALUES (9,'Suero');
INSERT INTO ITEM VALUES (10,'Nata');
INSERT INTO ITEM VALUES (11,'Salsa de tomate');
INSERT INTO ITEM VALUES (12,'Pimenton');
INSERT INTO ITEM VALUES (13,'Lentejas');
INSERT INTO ITEM VALUES (14,'Caraotas');
INSERT INTO ITEM VALUES (15,'Frescolita');
INSERT INTO ITEM VALUES (16,'Pasta');
INSERT INTO ITEM VALUES (17,'Harina de trigo');
INSERT INTO ITEM VALUES (18,'Pepsi');
INSERT INTO ITEM VALUES (19,'Mayonesa');
INSERT INTO ITEM VALUES (20,'Mostaza');
INSERT INTO ITEM VALUES (21,'Pollo');
INSERT INTO ITEM VALUES (22,'Huevo');
INSERT INTO ITEM VALUES (23,'Garbanzos');
INSERT INTO ITEM VALUES (24,'Chistorras');
INSERT INTO ITEM VALUES (25,'Salchichas');





/*---------------------------------ITEM_INVENTARIO---------------------------------------------*/

INSERT INTO ITEM_INVENTARIO VALUES (1,135, 'Lechuga', 32, 13,1);
INSERT INTO ITEM_INVENTARIO VALUES (2,130, 'Pan Bimbo', 44, 17,2);
INSERT INTO ITEM_INVENTARIO VALUES (3,120, 'Pepinillos', 32, 11,3);
INSERT INTO ITEM_INVENTARIO VALUES (4,115, 'Soda', 48, 20,4);
INSERT INTO ITEM_INVENTARIO VALUES (5,105, 'Pera', 33, 22,5);
INSERT INTO ITEM_INVENTARIO VALUES (6,130, 'Remolacha', 57, 28,6);
INSERT INTO ITEM_INVENTARIO VALUES (7,125, 'Harina', 22, 10,7);
INSERT INTO ITEM_INVENTARIO VALUES (8,135, 'Salsa de soya', 33, 30,8);
INSERT INTO ITEM_INVENTARIO VALUES (9,145, 'Suero', 38, 33,9);
INSERT INTO ITEM_INVENTARIO VALUES (10,155, 'Nata', 12, 10,10);
INSERT INTO ITEM_INVENTARIO VALUES (11,135, 'Salsa de tomate', 40, 37,11);
INSERT INTO ITEM_INVENTARIO VALUES (12,130, 'Pimenton', 40, 40,12);
INSERT INTO ITEM_INVENTARIO VALUES (13,120, 'Lentejas', 49, 45,13);
INSERT INTO ITEM_INVENTARIO VALUES (14,105, 'Caraotas', 112, 49,14);
INSERT INTO ITEM_INVENTARIO VALUES (15,115, 'Frescolita', 100, 50,15);
INSERT INTO ITEM_INVENTARIO VALUES (16,130, 'Pasta', 99, 58,16);
INSERT INTO ITEM_INVENTARIO VALUES (17,135, 'Harina de trigo', 67, 52,17);
INSERT INTO ITEM_INVENTARIO VALUES (18,145, 'Pepsi', 106, 100,18);
INSERT INTO ITEM_INVENTARIO VALUES (19,125, 'Mayonesa', 123, 103,19);
INSERT INTO ITEM_INVENTARIO VALUES (20,135, 'Mostaza', 156, 108,20);
INSERT INTO ITEM_INVENTARIO VALUES (21,135, 'Pollo', 187, 109,21);
INSERT INTO ITEM_INVENTARIO VALUES (22,135, 'Huevo', 90, 78,22);
INSERT INTO ITEM_INVENTARIO VALUES (23,135, 'Garbanzos', 80, 73,23);
INSERT INTO ITEM_INVENTARIO VALUES (24,135, 'Chistorras', 70, 69,24);
INSERT INTO ITEM_INVENTARIO VALUES (25,135, 'Salchichas', 97, 87,25);


/*---------------------------------ACTUALIZACION---------------------------------------------*/


INSERT INTO ACTUALIZACION VALUES (1,'02/07/14',100,1);
INSERT INTO ACTUALIZACION VALUES (2,'02/07/14',100,2);
INSERT INTO ACTUALIZACION VALUES (3,'02/07/14',100,3);
INSERT INTO ACTUALIZACION VALUES (4,'02/07/14',100,4);
INSERT INTO ACTUALIZACION VALUES (5,'02/07/14',100,5);
INSERT INTO ACTUALIZACION VALUES (6,'02/07/14',100,6);
INSERT INTO ACTUALIZACION VALUES (7,'02/07/14',100,7);
INSERT INTO ACTUALIZACION VALUES (8,'02/07/14',100,8);
INSERT INTO ACTUALIZACION VALUES (9,'02/07/14',100,9);
INSERT INTO ACTUALIZACION VALUES (10,'02/07/14',100,10);
INSERT INTO ACTUALIZACION VALUES (11,'02/07/14',100,11);
INSERT INTO ACTUALIZACION VALUES (12,'02/07/14',100,12);
INSERT INTO ACTUALIZACION VALUES (13,'02/07/14',100,13);
INSERT INTO ACTUALIZACION VALUES (14,'02/07/14',100,14);
INSERT INTO ACTUALIZACION VALUES (15,'02/07/14',100,15);
INSERT INTO ACTUALIZACION VALUES (16,'02/07/14',100,16);
INSERT INTO ACTUALIZACION VALUES (17,'02/07/14',100,17);
INSERT INTO ACTUALIZACION VALUES (18,'02/07/14',100,18);
INSERT INTO ACTUALIZACION VALUES (19,'02/07/14',100,19);
INSERT INTO ACTUALIZACION VALUES (20,'02/07/14',100,20);
INSERT INTO ACTUALIZACION VALUES (21,'02/07/14',100,21);
INSERT INTO ACTUALIZACION VALUES (22,'02/07/14',100,22);
INSERT INTO ACTUALIZACION VALUES (23,'02/07/14',100,23);
INSERT INTO ACTUALIZACION VALUES (24,'02/07/14',100,24);
INSERT INTO ACTUALIZACION VALUES (25,'02/07/14',100,25);

INSERT INTO ACTUALIZACION VALUES (26,'02/15/14',70,1);
INSERT INTO ACTUALIZACION VALUES (27,'02/15/14',60,2);
INSERT INTO ACTUALIZACION VALUES (28,'02/15/14',30,3);
INSERT INTO ACTUALIZACION VALUES (29,'02/15/14',70,4);
INSERT INTO ACTUALIZACION VALUES (30,'02/15/14',55,5);
INSERT INTO ACTUALIZACION VALUES (31,'02/15/14',36,6);
INSERT INTO ACTUALIZACION VALUES (32,'02/15/14',18,7);
INSERT INTO ACTUALIZACION VALUES (33,'02/15/14',19,8);
INSERT INTO ACTUALIZACION VALUES (34,'02/15/14',27,9);
INSERT INTO ACTUALIZACION VALUES (35,'02/15/14',96,10);
INSERT INTO ACTUALIZACION VALUES (36,'02/15/14',63,11);
INSERT INTO ACTUALIZACION VALUES (37,'02/15/14',80,12);
INSERT INTO ACTUALIZACION VALUES (38,'02/15/14',14,13);
INSERT INTO ACTUALIZACION VALUES (39,'02/15/14',19,14);
INSERT INTO ACTUALIZACION VALUES (40,'02/15/14',59,15);
INSERT INTO ACTUALIZACION VALUES (41,'02/15/14',87,16);
INSERT INTO ACTUALIZACION VALUES (42,'02/15/14',45,17);
INSERT INTO ACTUALIZACION VALUES (43,'02/15/14',26,18);
INSERT INTO ACTUALIZACION VALUES (44,'02/15/14',21,19);
INSERT INTO ACTUALIZACION VALUES (45,'02/15/14',99,20);
INSERT INTO ACTUALIZACION VALUES (46,'02/15/14',78,21);
INSERT INTO ACTUALIZACION VALUES (47,'02/15/14',89,22);
INSERT INTO ACTUALIZACION VALUES (48,'02/15/14',42,23);
INSERT INTO ACTUALIZACION VALUES (49,'02/15/14',31,24);
INSERT INTO ACTUALIZACION VALUES (50,'02/15/14',47,25);

INSERT INTO ACTUALIZACION VALUES (51,'02/22/14',40,1);
INSERT INTO ACTUALIZACION VALUES (52,'02/22/14',20,2);
INSERT INTO ACTUALIZACION VALUES (53,'02/22/14',20,3);
INSERT INTO ACTUALIZACION VALUES (54,'02/22/14',60,4);
INSERT INTO ACTUALIZACION VALUES (55,'02/22/14',45,5);
INSERT INTO ACTUALIZACION VALUES (56,'02/22/14',26,6);
INSERT INTO ACTUALIZACION VALUES (57,'02/22/14',12,7);
INSERT INTO ACTUALIZACION VALUES (58,'02/22/14',14,8);
INSERT INTO ACTUALIZACION VALUES (59,'02/22/14',17,9);
INSERT INTO ACTUALIZACION VALUES (60,'02/22/14',86,10);
INSERT INTO ACTUALIZACION VALUES (61,'02/22/14',53,11);
INSERT INTO ACTUALIZACION VALUES (62,'02/22/14',40,12);
INSERT INTO ACTUALIZACION VALUES (63,'02/22/14',11,13);
INSERT INTO ACTUALIZACION VALUES (64,'02/22/14',12,14);
INSERT INTO ACTUALIZACION VALUES (65,'02/22/14',52,15);
INSERT INTO ACTUALIZACION VALUES (66,'02/22/14',67,16);
INSERT INTO ACTUALIZACION VALUES (67,'02/22/14',35,17);
INSERT INTO ACTUALIZACION VALUES (68,'02/22/14',24,18);
INSERT INTO ACTUALIZACION VALUES (69,'02/22/14',20,19);
INSERT INTO ACTUALIZACION VALUES (70,'02/22/14',82,20);
INSERT INTO ACTUALIZACION VALUES (71,'02/22/14',58,21);
INSERT INTO ACTUALIZACION VALUES (72,'02/22/14',65,22);
INSERT INTO ACTUALIZACION VALUES (73,'02/22/14',36,23);
INSERT INTO ACTUALIZACION VALUES (74,'02/22/14',23,24);
INSERT INTO ACTUALIZACION VALUES (75,'02/22/14',30,25);


/*---------------------------------PROV_INVENTARIO---------------------------------------------*/

INSERT INTO PROV_INVENTARIO VALUES (1,'02/07/14',32,99,1,1,1);
INSERT INTO PROV_INVENTARIO VALUES (2,'02/07/14',44,120,2,2,1);
INSERT INTO PROV_INVENTARIO VALUES (3,'02/07/14',32,150,3,3,1);
INSERT INTO PROV_INVENTARIO VALUES (4,'02/07/14',48,200,4,4,1);
INSERT INTO PROV_INVENTARIO VALUES (5,'02/07/14',33,300,5,5,1);
INSERT INTO PROV_INVENTARIO VALUES (6,'02/07/14',57,100,6,6,2);
INSERT INTO PROV_INVENTARIO VALUES (7,'02/07/14',22,22,7,7,2);
INSERT INTO PROV_INVENTARIO VALUES (8,'02/07/14',33,17,8,8,2);
INSERT INTO PROV_INVENTARIO VALUES (9,'02/07/14',38,56,9,9,2);
INSERT INTO PROV_INVENTARIO VALUES (10,'02/07/14',12,76,10,10,2);
INSERT INTO PROV_INVENTARIO VALUES (11,'02/07/14',40,115,11,11,4);
INSERT INTO PROV_INVENTARIO VALUES (12,'02/07/14',40,80,12,12,4);
INSERT INTO PROV_INVENTARIO VALUES (13,'02/07/14',49,23,13,13,4);
INSERT INTO PROV_INVENTARIO VALUES (14,'02/07/14',112,45,14,14,4);
INSERT INTO PROV_INVENTARIO VALUES (15,'02/07/14',100,80,15,15,4);
INSERT INTO PROV_INVENTARIO VALUES (16,'02/07/14',99,87,16,16,5);
INSERT INTO PROV_INVENTARIO VALUES (17,'02/07/14',67,56,17,17,5);
INSERT INTO PROV_INVENTARIO VALUES (18,'02/07/14',106,34,18,18,5);
INSERT INTO PROV_INVENTARIO VALUES (19,'02/07/14',123,78,19,19,5);
INSERT INTO PROV_INVENTARIO VALUES (20,'02/07/14',156,80,20,20,5);
INSERT INTO PROV_INVENTARIO VALUES (21,'02/07/14',187,76,21,21,3);
INSERT INTO PROV_INVENTARIO VALUES (22,'02/07/14',90,12,22,22,3);
INSERT INTO PROV_INVENTARIO VALUES (23,'02/07/14',80,23,23,23,3);
INSERT INTO PROV_INVENTARIO VALUES (24,'02/07/14',70,54,24,24,3);
INSERT INTO PROV_INVENTARIO VALUES (25,'02/07/14',97,67,25,25,3);

commit transaction;
go