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
	   DELETE 
	   FROM ITEM
	   WHERE  ITE_id = @_itemid

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
go
------------------------------------------------------------------------
------------------INSERTAR UN PROVEEDOR---------------------------------
CREATE PROCEDURE [dbo].Procedure_insertarProveedor 
       @_proRif                   [nvarchar]       (50),  
       @_proRazonSocial           [nvarchar]      (100), 
       @_proCorreo                [nvarchar]       (50),                  
       @_proPaginaWeb             [nvarchar]      (100),
       @_proFechaContacto         [date]               , 
       @_proTelefono              [nvarchar]       (20), 
       @_proFkLugar               [int]                             
AS 
BEGIN 

     INSERT INTO PROVEEDOR
          ( 
            PRO_rif          ,
            PRO_razonSocial  ,
            PRO_correo       ,
            PRO_paginaWeb    ,
            PRO_fechaContrato,
            PRO_telefono     ,
            FK_lugar             
          ) 
     VALUES 
          ( 
            @_proRif          ,
            @_proRazonSocial  ,
            @_proCorreo       ,
            @_proPaginaWeb    ,
            @_proFechaContacto,
            @_proTelefono     ,
            @_proFkLugar          
          ) 

END 

GO


--------------------------------------------------------------------------------------------

---EXECUTE PROVEEDOR--

            EXEC Procedure_insertarProveedor
			@_proRif           = 'J-30298252-9',
            @_proRazonSocial   = 'Distribuidora La Llanisca C.A',
            @_proCorreo        = 'lallanisca@gmail.com',
            @_proPaginaWeb     =  'www.lallanisca.com',
            @_proFechaContacto =  '01/11/2014',
            @_proTelefono      = '02126811075',
            @_proFkLugar       = 15;
			GO
			
			EXEC Procedure_insertarProveedor
			@_proRif           = 'J-30167643-2',
            @_proRazonSocial   = 'Sacos y Envases Canarven C.A', 
            @_proCorreo        = 'canarvenca@gmail.com', 
            @_proPaginaWeb     =  'www.canarven.com',
            @_proFechaContacto = '02/12/2014',
            @_proTelefono      = '021297529750',
            @_proFkLugar       = 14;
			GO
			
			EXEC Procedure_insertarProveedor
			@_proRif           = 'J-30788302-2',
            @_proRazonSocial   = 'Cordeles y Mecates El Asturcon C.A', 
            @_proCorreo        = 'elasturcon@gmail.com',
            @_proPaginaWeb     =  'www.elasturcon.com',
            @_proFechaContacto = '03/13/2014',
            @_proTelefono      = '02127539710',
            @_proFkLugar       = 15;
			GO
			
			EXEC Procedure_insertarProveedor
			@_proRif           = 'J-30463490-3', 
            @_proRazonSocial   = 'Empresas Polar C.A', 
            @_proCorreo        = 'empresaspolar@gmail.com', 
            @_proPaginaWeb     =  'www.empresaspolar.com',
            @_proFechaContacto = '04/14/2014',
            @_proTelefono      = '02125419032', 
            @_proFkLugar       = 16;
			GO
			
			EXEC Procedure_insertarProveedor
			@_proRif           = 'J-89021673-8', 
            @_proRazonSocial   = 'Pepsico de Venezuela C.A', 
            @_proCorreo        = 'pepsicovenezuela@gmail.com', 
            @_proPaginaWeb     =  'www.pepsicovenezuela.com', 
            @_proFechaContacto = '05/15/2014',
            @_proTelefono      = '02129769283', 
            @_proFkLugar       = 17;
			GO
			
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

INSERT INTO ITEM_INVENTARIO VALUES (1,135, 'Granos y frijoles', 100, 10,1);
INSERT INTO ITEM_INVENTARIO VALUES (2,130, 'Granos y frijoles', 100, 10,2);
INSERT INTO ITEM_INVENTARIO VALUES (3,120, 'Granos y frijoles', 100, 10,3);
INSERT INTO ITEM_INVENTARIO VALUES (4,115, 'Granos y frijoles', 100, 10,4);
INSERT INTO ITEM_INVENTARIO VALUES (5,105, 'Granos y frijoles', 100, 10,5);
INSERT INTO ITEM_INVENTARIO VALUES (6,130, 'Granos y frijoles', 100, 10,6);
INSERT INTO ITEM_INVENTARIO VALUES (7,125, 'Granos y frijoles', 100, 10,7);
INSERT INTO ITEM_INVENTARIO VALUES (8,135, 'Granos y frijoles', 100, 10,8);
INSERT INTO ITEM_INVENTARIO VALUES (9,145, 'Granos y frijoles', 100, 10,9);
INSERT INTO ITEM_INVENTARIO VALUES (10,155, 'Granos y frijoles', 100, 10,10);
INSERT INTO ITEM_INVENTARIO VALUES (11,135, 'Granos y frijoles', 100, 10,11);
INSERT INTO ITEM_INVENTARIO VALUES (12,130, 'Granos y frijoles', 100, 10,12);
INSERT INTO ITEM_INVENTARIO VALUES (13,120, 'Granos y frijoles', 100, 10,13);
INSERT INTO ITEM_INVENTARIO VALUES (14,105, 'Granos y frijoles', 100, 10,14);
INSERT INTO ITEM_INVENTARIO VALUES (15,115, 'Granos y frijoles', 100, 10,15);
INSERT INTO ITEM_INVENTARIO VALUES (16,130, 'Granos y frijoles', 100, 10,16);
INSERT INTO ITEM_INVENTARIO VALUES (17,135, 'Granos y frijoles', 100, 10,17);
INSERT INTO ITEM_INVENTARIO VALUES (18,145, 'Granos y frijoles', 100, 10,18);
INSERT INTO ITEM_INVENTARIO VALUES (19,125, 'Granos y frijoles', 100, 10,19);
INSERT INTO ITEM_INVENTARIO VALUES (20,135, 'Granos y frijoles', 100, 10,20);
INSERT INTO ITEM_INVENTARIO VALUES (21,135, 'Granos y frijoles', 100, 10,21);
INSERT INTO ITEM_INVENTARIO VALUES (22,135, 'Granos y frijoles', 100, 10,22);
INSERT INTO ITEM_INVENTARIO VALUES (23,135, 'Granos y frijoles', 100, 10,23);
INSERT INTO ITEM_INVENTARIO VALUES (24,135, 'Granos y frijoles', 100, 10,24);
INSERT INTO ITEM_INVENTARIO VALUES (25,135, 'Granos y frijoles', 100, 10,25);


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

INSERT INTO PROV_INVENTARIO VALUES (1,'02/07/14',100,80,1,1,'J-30298252-9');
INSERT INTO PROV_INVENTARIO VALUES (2,'02/07/14',100,80,2,2,'J-30298252-9');
INSERT INTO PROV_INVENTARIO VALUES (3,'02/07/14',100,80,3,3,'J-30298252-9');
INSERT INTO PROV_INVENTARIO VALUES (4,'02/07/14',100,80,4,4,'J-30298252-9');
INSERT INTO PROV_INVENTARIO VALUES (5,'02/07/14',100,80,5,5,'J-30298252-9');
INSERT INTO PROV_INVENTARIO VALUES (6,'02/07/14',100,80,6,6,'J-30167643-2');
INSERT INTO PROV_INVENTARIO VALUES (7,'02/07/14',100,80,7,7,'J-30167643-2');
INSERT INTO PROV_INVENTARIO VALUES (8,'02/07/14',100,80,8,8,'J-30167643-2');
INSERT INTO PROV_INVENTARIO VALUES (9,'02/07/14',100,80,9,9,'J-30167643-2');
INSERT INTO PROV_INVENTARIO VALUES (10,'02/07/14',100,80,10,10,'J-30167643-2');
INSERT INTO PROV_INVENTARIO VALUES (11,'02/07/14',100,80,11,11,'J-30463490-3');
INSERT INTO PROV_INVENTARIO VALUES (12,'02/07/14',100,80,12,12,'J-30463490-3');
INSERT INTO PROV_INVENTARIO VALUES (13,'02/07/14',100,80,13,13,'J-30463490-3');
INSERT INTO PROV_INVENTARIO VALUES (14,'02/07/14',100,80,14,14,'J-30463490-3');
INSERT INTO PROV_INVENTARIO VALUES (15,'02/07/14',100,80,15,15,'J-30463490-3');
INSERT INTO PROV_INVENTARIO VALUES (16,'02/07/14',100,80,16,16,'J-89021673-8');
INSERT INTO PROV_INVENTARIO VALUES (17,'02/07/14',100,80,17,17,'J-89021673-8');
INSERT INTO PROV_INVENTARIO VALUES (18,'02/07/14',100,80,18,18,'J-89021673-8');
INSERT INTO PROV_INVENTARIO VALUES (19,'02/07/14',100,80,19,19,'J-89021673-8');
INSERT INTO PROV_INVENTARIO VALUES (20,'02/07/14',100,80,20,20,'J-89021673-8');
INSERT INTO PROV_INVENTARIO VALUES (21,'02/07/14',100,80,21,21,'J-30788302-2');
INSERT INTO PROV_INVENTARIO VALUES (22,'02/07/14',100,80,22,22,'J-30788302-2');
INSERT INTO PROV_INVENTARIO VALUES (23,'02/07/14',100,80,23,23,'J-30788302-2');
INSERT INTO PROV_INVENTARIO VALUES (24,'02/07/14',100,80,24,24,'J-30788302-2');
INSERT INTO PROV_INVENTARIO VALUES (25,'02/07/14',100,80,25,25,'J-30788302-2');

commit transaction;
go