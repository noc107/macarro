use MACARRO
go
begin transaction;
go

----------------------CONSULTA GESTIONAR PROVEEDOR---------------------------------
---------FECHA: 03/03/14 - HORA: 2 PM----------------------------------------------

CREATE PROCEDURE Procedure_consultaDeGestionarProveedor
AS
   BEGIN
      SELECT PRO_rif, PRO_razonSocial
	  FROM PROVEEDOR
	  
	END
GO
-----------------------------------------------------------------------------------
-------------CONSULTAR PROVEEDOR GENERAL-------------------------------------------
----FECHA: 02/03/14 - HORA: 3 PM---------------------------------------------------
CREATE PROCEDURE Procedure_consultarProveedorGeneral
AS
  BEGIN
	   SELECT *
	   FROM PROVEEDOR
  END
GO
------------------------------------------------------------------------------------
----------------CONSULTAR PROVEEDOR CON SU LISTA DE ITEMS---------------------------
----FECHA: 02/03/14 - HORA: 3 PM---------------------------------------------------

CREATE PROCEDURE [dbo].Procedure_consultaProveedorListaItems

	   @_proRif                   [nvarchar]       (50)
      

AS

  BEGIN
	   SELECT distinct p.* , Prov.ITE_nombre
	   FROM PROVEEDOR p, ITEM i, ITEM_PROV ip, (select i.ITE_nombre, p.PRO_rif from ITEM i, ITEM_PROV ip, PROVEEDOR p where p.PRO_rif = FK_proveedor and i.ITE_id = Fk_item ) as Prov
	   WHERE  p.PRO_rif = @_proRif and Prov.PRO_rif = p.PRO_rif;

  END

GO
-------------------------------------------------------------------------------------------
----------------------------MODIFICAR PROVEEDOR--------------------------------------------
----FECHA: 02/03/14 - HORA: 3 PM---------------------------------------------------
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

-------------------------------------------------------------------------------------------
-----------------------------------ELIMINAR ITEM ASOCIADO A UN PROVEEDOR----------------
/*SOLO SE ELIMINA EL NOMBRE DEL ITEM A ESE PROVEEDOR MAS NO SE ELIMINA EL ITEM DEFINITIVO*/
----FECHA: 02/03/14 - HORA: 3 PM---------------------------------------------------

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
------------------------------ELIMINAR PROVEEDOR-------------------------------------------
----FECHA: 02/03/14 - HORA: 3 PM---------------------------------------------------
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
       @_item_provFkProveedor            [nvarchar]   (50)
	   
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

	--------------------------------------------------------------------------------
	--------------------EXECUTE PROV_ITEM-----------------------------------------
	
            EXEC Procedure_InsertarITEM_PROV
	        @_item_provFkItem        =                1,
			@_item_provFkProveedor   =   'J-30298252-9';
            GO
			
	        EXEC Procedure_InsertarITEM_PROV
		    @_item_provFkItem        =                2,	
			@_item_provFkProveedor   =   'J-30298252-9';
			GO
          
		    EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                3,
			@_item_provFkProveedor   =   'J-30298252-9';
			GO
           
		    EXEC Procedure_InsertarITEM_PROV
	        @_item_provFkItem        =                4,
			@_item_provFkProveedor   =   'J-30298252-9';
			GO
           
		    EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                5,
			@_item_provFkProveedor   =   'J-30298252-9';
			GO
           
		    EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                6,
			@_item_provFkProveedor   =   'J-30167643-2';
			GO
			
			EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                7,
			@_item_provFkProveedor   =   'J-30167643-2';
			GO
            
			EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                8,
			@_item_provFkProveedor   =   'J-30167643-2';
			GO
            
			EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                9,
			@_item_provFkProveedor   =   'J-30167643-2';
			GO
			
			EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                10,
			@_item_provFkProveedor   =    'J-30167643-2';
			GO
            
			EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                11,
			@_item_provFkProveedor   =    'J-30788302-2';
			GO
            
			EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                12,
			@_item_provFkProveedor   =    'J-30788302-2';
			GO
			
            EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                13,
			@_item_provFkProveedor   =    'J-30788302-2';
			GO
			
            EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                14,
			@_item_provFkProveedor   =    'J-30788302-2';
			GO
            
			EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                15,
			@_item_provFkProveedor   =    'J-30788302-2';
			GO
            
			EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                16,
			@_item_provFkProveedor   =    'J-30463490-3';
			GO
            
			EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                17,
			@_item_provFkProveedor   =    'J-30463490-3';
			GO
           
		    EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                18,
			@_item_provFkProveedor   =    'J-30463490-3';
			GO
            
			EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                19,
			@_item_provFkProveedor   =    'J-30463490-3';
			GO
            
			EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                20,
			@_item_provFkProveedor   =    'J-30463490-3';
			GO
            
			EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                21,
			@_item_provFkProveedor   =    'J-89021673-8';
			GO
            
			EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                22,
			@_item_provFkProveedor   =    'J-89021673-8';
			GO
            
			EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                23,
			@_item_provFkProveedor   =    'J-89021673-8';
			GO
            
			EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                24,
			@_item_provFkProveedor   =    'J-89021673-8';
			GO
            
			EXEC Procedure_InsertarITEM_PROV
			@_item_provFkItem        =                25,
			@_item_provFkProveedor   =    'J-89021673-8';
			GO
commit transaction;
go