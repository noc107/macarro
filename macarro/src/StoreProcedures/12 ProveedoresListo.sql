use MACARRO
go
begin transaction;
go

-----------------------------------------------------------------------------------
-------------CONSULTAR LUGAR TODOS LOS PAISES-------------------------------------------
----FECHA: 06/12/14 - HORA: 8 PM---------------------------------------------------
CREATE PROCEDURE Procedure_consultarLugarTodosPaises
	@tipoLugar [nvarchar]       (100)
AS
  BEGIN
	   SELECT *
	   FROM LUGAR
	   WHERE LUG_tipo = @tipoLugar;
	  
  END
GO

-----------------------------------------------------------------------------------
-------------CONSULTAR LUGAR ESTADOS DADO UN PAIS-------------------------------------------
----FECHA: 06/12/14 - HORA: 8 PM---------------------------------------------------
CREATE PROCEDURE Procedure_consultarLugarEstadoDadoSuPais
	@idLugar [int]       
AS
  BEGIN
	   SELECT distinct Estado.*
	   FROM LUGAR L, LUGAR LE, (select LE.* from LUGAR L, LUGAR LE where L.LUG_id = LE.FK_lugar and  LE.LUG_tipo = 'Estado' ) as Estado
	   WHERE  L.LUG_id = @idLugar and Estado.FK_lugar = L.LUG_id;
	  
  END
GO


-----------------------------------------------------------------------------------
-------------CONSULTAR LUGAR CIUDAD DADO UN ESTADO-------------------------------------------
----FECHA: 06/12/14 - HORA: 8 PM---------------------------------------------------
CREATE PROCEDURE Procedure_consultarLugarCiudadDadoSuEstado
	@idLugar [int]       
AS
  BEGIN
	   SELECT distinct Ciudad.*
	   FROM LUGAR LE, LUGAR LC, (select LC.* from LUGAR LE, LUGAR LC where LE.LUG_id = LC.FK_lugar and  LC.LUG_tipo = 'Ciudad' ) as Ciudad
	   WHERE  LE.LUG_id = @idLugar and Ciudad.FK_lugar = LE.LUG_id;
	  
  END
GO

-----------------------------------------------------------------------------------
-------------CONSULTAR LUGAR DIRECCION DADA UNA CIUDAD-----------------------------
----FECHA: 06/12/14 - HORA: 8 PM---------------------------------------------------
CREATE PROCEDURE Procedure_consultarLugarDireccionDadaSuCiudad
	@idLugar [int]       
AS
  BEGIN
	   SELECT distinct Direccion.*
	   FROM LUGAR LC, LUGAR LD, (select LD.* from LUGAR LC, LUGAR LD where LC.LUG_id = LD.FK_lugar and  LD.LUG_tipo = 'Direccion' ) as Direccion
	   WHERE  LC.LUG_id = @idLugar and Direccion.FK_lugar = LC.LUG_id;
	  
  END
GO

-----------------------------------------------------------------------------------
-------------CONSULTAR LUGAR: TRAE PAIS, ESTADO, CIUDAD, DIRECCION-----------------
----FECHA: 06/12/14 - HORA: 10 PM---------------------------------------------------
CREATE PROCEDURE Procedure_consultarLugarPaisEstadoCiudadDadaUnaDireccion
	@idLugar [int]       
AS
  BEGIN
	   SELECT distinct Pais.LUG_nombre, Estado.LUG_nombre, Ciudad.LUG_nombre, LD.LUG_nombre
	   FROM LUGAR LD, LUGAR LE, LUGAR LP, LUGAR LC, (select LP.* from LUGAR LP where LP.LUG_tipo = 'País' ) as Pais, 
	   (select LE.* from LUGAR LP, LUGAR LE where LP.LUG_id = LE.FK_lugar and  LE.LUG_tipo = 'Estado' ) as Estado,
	   (select LC.* from LUGAR LE, LUGAR LC where LE.LUG_id = LC.FK_lugar and  LC.LUG_tipo = 'Ciudad' ) as Ciudad
	   WHERE  LD.LUG_id = @idLugar and Pais.LUG_id = LP.LUG_id and Estado.FK_lugar = LP.LUG_id and LE.LUG_id = Estado.LUG_id and Ciudad.FK_lugar = LE.LUG_id 
       and 	  LC.LUG_id = Ciudad.LUG_id and LC.LUG_id = LD.FK_lugar;
	  
  END
GO
----------------------CONSULTA TABLA DE ITEM COMPLETA---------------------------------
---------FECHA: 05/12/14 - HORA: 3 PM----------------------------------------------

CREATE PROCEDURE Procedure_consultarItemCompleto
AS
   BEGIN
      SELECT ITE_id, ITE_nombre
	  FROM ITEM
	  
	END
GO
----------------------CONSULTA GESTIONAR PROVEEDOR---------------------------------
---------FECHA: 03/12/14 - HORA: 2 PM----------------------------------------------

CREATE PROCEDURE Procedure_consultaDeGestionarProveedor
AS
   BEGIN
      SELECT PRO_rif, PRO_razonSocial
	  FROM PROVEEDOR
	  
	END
GO

------------------Procedure_consultarProveedorGeneral------------------------

CREATE PROCEDURE Procedure_consultarProveedorGeneral
	@_proId                   [int]     
AS
  BEGIN
	   SELECT PRO_id, PRO_rif,PRO_razonSocial, PRO_correo,PRO_paginaWeb,PRO_fechaContrato,PRO_telefono,FK_lugar
	   FROM PROVEEDOR
	   WHERE PRO_id = @_proId;
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
-----------------------------------ELIMINAR ITEM ASOCIADO A UN PROVEEDOR----------------
/*SOLO SE ELIMINA EL NOMBRE DEL ITEM A ESE PROVEEDOR MAS NO SE ELIMINA EL ITEM DEFINITIVO*/
----FECHA: 02/12/14 - HORA: 3 PM---------------------------------------------------

CREATE PROCEDURE [dbo].Procedure_eliminarItemDeProveedor
     
	   @_itemid                   [int]
AS

 BEGIN
        DELETE
		FROM ITEM_PROV 
	    WHERE FK_item = @_itemid; 
	   
 END

GO

-------------------------------------------------------------------------------------------
-----------------------------------ELIMINAR PROVEEDOR ASOCIADO A UN ITEM-------------
----FECHA: 04/12/14 - HORA: 6 PM-----------------------------------------------------------

CREATE PROCEDURE [dbo].Procedure_eliminarProveedorDeITEM_PROV
     
	   @_proRif                   [nvarchar]        (50)
AS

 BEGIN
        DELETE
		FROM ITEM_PROV 
	    WHERE FK_proveedor = @_proRif; 
	   
 END

GO

-------------------------------------------------------------------------------------------
-----------------------------------ELIMINAR PROVEEDOR ASOCIADO A UN ITEM-------------
----FECHA: 04/12/14 - HORA: 6 PM-----------------------------------------------------------

CREATE PROCEDURE [dbo].Procedure_eliminarProveedorDePROV_INVENTARIO
     
	   @_proRif                   [nvarchar]         (50)
AS

 BEGIN
        DELETE
		FROM PROV_INVENTARIO
	    WHERE FK_proveedor = @_proRif; 
	   
 END

GO

-------------------------------------------------------------------------------------------
------------------------------ELIMINAR PROVEEDOR-------------------------------------------
----FECHA: 02/12/14 - HORA: 3 PM---------------------------------------------------
CREATE PROCEDURE [dbo].Procedure_eliminarProveedor
       @_proRif                   [nvarchar]        (50)
       
AS

 BEGIN
       Delete 
	   FROM PROVEEDOR 
	   WHERE PRO_rif = @_proRif;
	   
 END

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






------------------INSERTS PROOVEDOR (requiere datos de tabla Lugar)----------------------------------------------------------------

INSERT INTO PROVEEDOR VALUES (1,'J-30298252-9','Polar','polarca@polar.com','www.polar.com.ve','10/09/2014','582122425456',1);
INSERT INTO PROVEEDOR VALUES (2,'J-30167643-2','Pepsico','pepsico@pepsi.com','www.pepsi.com.ve','11/07/2008','582122525349',2);
INSERT INTO PROVEEDOR VALUES (3,'J-30788302-2','Monaca','monaca@gruma.com','www.monaca.com.ve','02/03/2010','582122445609',3);
INSERT INTO PROVEEDOR VALUES (4,'J-30463490-3','Savoy','savoy@nestle.com','www.savoy.com.ve','08/11/2013','582127410267',4);
INSERT INTO PROVEEDOR VALUES (5,'J-89021673-8','Fritz','fritz@gobalftr.com','www.fritz.com.ve','09/12/2012','582123457391',5);





-----------------INSERTS ITEM_PROV (requiere datos de tablas Proveedor e Item)---------------------------------------------------------

INSERT INTO ITEM_PROV VALUES (1,1);
INSERT INTO ITEM_PROV VALUES (2,1);
INSERT INTO ITEM_PROV VALUES (3,1);
INSERT INTO ITEM_PROV VALUES (4,1);
INSERT INTO ITEM_PROV VALUES (5,1);
INSERT INTO ITEM_PROV VALUES (6,2);
INSERT INTO ITEM_PROV VALUES (7,2); 
INSERT INTO ITEM_PROV VALUES (8,2);
INSERT INTO ITEM_PROV VALUES (9,2);
INSERT INTO ITEM_PROV VALUES (10,2);
INSERT INTO ITEM_PROV VALUES (11,3);
INSERT INTO ITEM_PROV VALUES (12,3);
INSERT INTO ITEM_PROV VALUES (13,3);
INSERT INTO ITEM_PROV VALUES (14,3);
INSERT INTO ITEM_PROV VALUES (15,3);
INSERT INTO ITEM_PROV VALUES (16,4);
INSERT INTO ITEM_PROV VALUES (17,4);
INSERT INTO ITEM_PROV VALUES (18,4);
INSERT INTO ITEM_PROV VALUES (19,4);
INSERT INTO ITEM_PROV VALUES (20,4);
INSERT INTO ITEM_PROV VALUES (21,5);
INSERT INTO ITEM_PROV VALUES (22,5);
INSERT INTO ITEM_PROV VALUES (23,5);
INSERT INTO ITEM_PROV VALUES (24,5);
INSERT INTO ITEM_PROV VALUES (25,5);