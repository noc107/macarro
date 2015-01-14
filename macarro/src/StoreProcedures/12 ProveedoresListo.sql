use MACARRO
go
begin transaction;
go

----------------------CONSULTA TABLA DE ITEM COMPLETA---------------------------------
---------FECHA: 05/12/14 - HORA: 3 PM----------------------------------------------

CREATE PROCEDURE Procedure_consultarItemCompleto
AS
   BEGIN
      SELECT ITE_id, ITE_nombre
	  FROM ITEM
	  
	END
GO




------------------Procedure_consultarProveedorGeneral------------------------

CREATE PROCEDURE Procedure_consultarProveedorGeneral
	@_proId                   [int]     
AS
  BEGIN
	   SELECT p.PRO_id, p.PRO_rif, p.PRO_razonSocial, p.PRO_correo, p.PRO_paginaWeb, p.PRO_fechaContrato,
	   p.PRO_telefono, p.FK_lugar, e.EST_nombre
	   FROM PROVEEDOR p, ESTADO e
	   WHERE PRO_id = @_proId and p.FK_estado=e.EST_id
  END


go
------------------------------------------------------------------------------------
----------------CONSULTAR PROVEEDOR CON SU LISTA DE ITEMS , SE TRAE NOMBRE E ID DEL ITEM--
----FECHA: 06/12/14 - HORA: 7 PM---------------------------------------------------

CREATE PROCEDURE [dbo].Procedure_consultaProveedorListaItemsIdNombre

	   @_proRif                   [nvarchar]       (50)
      

AS

  BEGIN
	   SELECT distinct Prov.ITE_nombre, Prov.ITE_id
	   FROM PROVEEDOR p, ITEM i, ITEM_PROV ip, (select i.ITE_nombre, i.ITE_id, p.PRO_rif from ITEM i, ITEM_PROV ip, PROVEEDOR p where p.PRO_rif = FK_proveedor and i.ITE_id = FK_item ) as Prov
	   WHERE  p.PRO_rif = @_proRif and Prov.PRO_rif = p.PRO_rif;

  END

GO

------------------------------------------------------------------------------------
----------------CONSULTAR PROVEEDOR CON SU LISTA DE ITEMS---------------------------
----FECHA: 02/12/14 - HORA: 3 PM---------------------------------------------------

CREATE PROCEDURE [dbo].Procedure_consultaProveedorListaItems

	   @_proRif                   [nvarchar]       (50)
      

AS

  BEGIN
	   SELECT distinct Prov.ITE_nombre
	   FROM PROVEEDOR p, ITEM i, ITEM_PROV ip, (select i.ITE_nombre, p.PRO_rif from ITEM i, ITEM_PROV ip, PROVEEDOR p where p.PRO_rif = FK_proveedor and i.ITE_id = FK_item ) as Prov
	   WHERE  p.PRO_rif = @_proRif and Prov.PRO_rif = p.PRO_rif;

  END

GO
-------------------------------------------------------------------------------------------
----------------------------MODIFICAR PROVEEDOR--------------------------------------------
----FECHA: 02/12/14 - HORA: 3 PM---------------------------------------------------
CREATE PROCEDURE Procedure_modificarProveedor
	   @_proRif                   [nvarchar]       (50),  
       @_proRazonSocial           [nvarchar]      (100), 
       @_proCorreo                [nvarchar]       (50),                  
       @_proPaginaWeb             [nvarchar]      (100),
       @_proFechaContrato         [date]               , 
       @_proTelefono              [nvarchar]       (20), 
       @_proFkLugar               [int]                ,
	   @_item_provFkProveedor     [nvarchar]       (50),
	   @_prov_invFkProveedor      [nvarchar]       (50)
AS
	UPDATE PROVEEDOR
	SET 
	        PRO_rif           = @_proRif,
            PRO_razonSocial   = @_proRazonSocial,
            PRO_correo        = @_proCorreo,
            PRO_paginaWeb     = @_proPaginaWeb,
            PRO_fechaContrato = @_proFechaContrato,
            PRO_telefono      = @_proTelefono,
            FK_lugar          = @_proFkLugar
	WHERE 
	        PRO_rif           = @_proRif;

GO

-----------------------------------------------------------------------------------
----------------------------MODIFICAR PROVEEDOR DENTRO DE ITEM_PROV----------------
----FECHA: 04/12/14 - HORA: 4 PM---------------------------------------------------
CREATE PROCEDURE Procedure_modificarProveedorEnItem_Prov
	   @_proRif                   [nvarchar]       (50),  
	   @_item_provFkProveedor     [nvarchar]       (50)
	
AS
	UPDATE ITEM_PROV
	SET 
	      FK_Proveedor = @_item_provFkProveedor
	WHERE 
	      FK_Proveedor   = @_item_provFkProveedor;
		

GO

-----------------------------------------------------------------------------------
----------------------------MODIFICAR PROVEEDOR DENTRO DE PROV_INVENTARIO----------------
----FECHA: 04/12/14 - HORA: 4 PM---------------------------------------------------
CREATE PROCEDURE Procedure_modificarProveedorEnProv_Inventario
	   @_proRif                   [nvarchar]       (50),  
	   @_prov_invFkProveedor      [nvarchar]       (50)
AS
	UPDATE PROV_INVENTARIO
	SET 
	      FK_Proveedor = @_prov_invFkProveedor 
	WHERE 
	      FK_Proveedor   = @_prov_invFkProveedor;
		 
GO



-------------------------------------------------------------------------------------------
 ---------------------------INSERTAR ITEM_PROV---------------------------------------------

CREATE PROCEDURE [dbo].Procedure_InsertarITEM_PROV
       @_item_provFkItem                 [int]            ,
       @_item_provFkProveedor            [int]
	   
AS     
BEGIN 

     INSERT INTO ITEM_PROV
          ( 
              FK_item        ,
              FK_proveedor       
          ) 
     VALUES 
          ( 
            @_item_provFkItem          ,
            @_item_provFkProveedor     
             
          ) 

END 
GO


-----------------------------Procedure_insertarProveedor---------------------

CREATE PROCEDURE [dbo].Procedure_insertarProveedor 
       @_proRif                   [nvarchar]       (50),  
       @_proRazonSocial           [nvarchar]      (100), 
       @_proCorreo                [nvarchar]       (50),                  
       @_proPaginaWeb             [nvarchar]      (100),
       @_proFechaContrato         [date]               , 
       @_proTelefono              [nvarchar]       (20), 
       @_proFkLugar               [int]                             
AS 
BEGIN 

     INSERT INTO PROVEEDOR
          ( 
		    PRO_id			 ,
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
		    (select max(ITE_id) from ITEM)+1,
            @_proRif          ,
            @_proRazonSocial  ,
            @_proCorreo       ,
            @_proPaginaWeb    ,
            @_proFechaContrato,
            @_proTelefono     ,
            @_proFkLugar          
          ) 

END
GO




-----------------------cargar proveedores para gridview--------------------------------

CREATE PROCEDURE Procedure_llenarGVProveedores   
(
	@_paramBusq varchar (100)
)
AS
  BEGIN
	   SELECT p.PRO_id, p.PRO_rif, p.PRO_razonSocial, p.PRO_correo, p.PRO_paginaWeb, p.PRO_fechaContrato,
	   p.PRO_telefono, p.FK_lugar, e.EST_nombre
	   FROM PROVEEDOR p, ESTADO e
	   WHERE p.FK_estado=e.EST_id and (p.PRO_rif like concat('%',@_paramBusq,'%') or p.PRO_razonSocial like concat('%',@_paramBusq,'%'))

  END

  GO

  GO


-------------------------------------------------------------------------------------------
------------------------------ELIMINAR PROVEEDOR-------------------------------------------
----FECHA: 02/12/14 - HORA: 3 PM---------------------------------------------------
CREATE PROCEDURE [dbo].Procedure_eliminarProveedor
       @_proId                   [int]     
       
AS

 BEGIN
       UPDATE PROVEEDOR SET FK_ESTADO=2 WHERE PRO_ID=@_proId
	   
 END

GO



/*---------------------------------------------------------------------*/
CREATE PROCEDURE Procedure_consultarDireccionProveedor
(@idDireccion  [int]) 
AS
SELECT	
		(L4.LUG_tipo +': '+ L4.LUG_nombre + ', ' + L3.LUG_tipo +': '+L3.LUG_nombre + ', ' +L2.LUG_tipo+': '+ L2.LUG_nombre + ', '+L1.LUG_tipo+':'+ L1.LUG_nombre) as Direccion 
FROM	 
		LUGAR as L4, 
		LUGAR as L3, 
		LUGAR as L2, 
		LUGAR as L1
WHERE	 
		L4.LUG_id=@idDireccion AND 
		L3.LUG_id=L4.FK_lugar AND 
		L2.LUG_id=L3.FK_lugar AND 
		L1.LUG_id=L2.FK_lugar;

GO



------------------INSERTS PROOVEDOR (requiere datos de tabla Lugar)----------------------------------------------------------------

INSERT INTO PROVEEDOR VALUES (1,'J-30298252-9','Polar','polarca@polar.com','www.polar.com.ve','10/09/2014','582122425456', 8, 1);
go
INSERT INTO PROVEEDOR VALUES (2,'J-30167643-2','Pepsico','pepsico@pepsi.com','www.pepsi.com.ve','11/07/2008','582122525349', 9, 1);
go
INSERT INTO PROVEEDOR VALUES (3,'J-30788302-2','Monaca','monaca@gruma.com','www.monaca.com.ve','02/03/2010','582122445609', 10, 1);
go
INSERT INTO PROVEEDOR VALUES (4,'J-30463490-3','Savoy','savoy@nestle.com','www.savoy.com.ve','08/11/2013','582127410267', 9, 1);
go
INSERT INTO PROVEEDOR VALUES (5,'J-89021673-8','Fritz','fritz@gobalftr.com','www.fritz.com.ve','09/12/2012','582123457391', 8, 1);
go


commit transaction;
go
