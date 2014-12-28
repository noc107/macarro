use MACARRO
GO
begin transaction;
go


------------------------------------CREACIÓN DE LAS SEQUENCIAS-----------------------------------------------------

---------SEQUENCIA SECCIÓN------------
CREATE SEQUENCE SEQ_SECCION 
 START WITH 1
 INCREMENT BY 1
GO

---------SEQUENCIA PLATO------------
CREATE SEQUENCE SEQ_PLATO 
 START WITH 1
 INCREMENT BY 1
GO

---------------------------------------------FIN DE CREACIÓN DE SEQUENCIAS------------------------------------------

---------------------------------  PRODEDURES  ----------------------------------------------------


-------------------PROCEDIMIENTO PARA EL INGRESO DE SECCIONES ------------------------------------

CREATE PROCEDURE Procedure_agregarSeccion
	             
	   @_secNombre      [nvarchar] (100),
	   @_secDescripcion [nvarchar] (100)
	  
AS

 BEGIN
	   DECLARE 
	   @_secEstado nvarchar(15);
	   SET @_secEstado = 'Activado'; 


	   INSERT INTO SECCION(SEC_id,SEC_nombre,SEC_descripcion,SEC_estado)
	   VALUES( NEXT VALUE FOR SEQ_SECCION,@_secNombre,@_secDescripcion, @_secEstado) 

 END

GO

-----------------------PROCEDIMIENTO PARA CONSULTAR SECCION ---------------------------------------

CREATE PROCEDURE Procedure_consultarSeccion

	@_secId		[int]

AS

  BEGIN
	   SELECT SEC_id,SEC_nombre,SEC_descripcion,SEC_estado 
	   FROM SECCION 
	   WHERE  SEC_id = @_secId

  END
GO

----------------------PROCEDIMIENTO PARA ACTUALIZAR LA SECCION--------------------------------------

CREATE PROCEDURE Procedure_modificarSeccion
	   @_secId          [int]           ,
	   @_secNombre      [nvarchar] (100),
	   @_secDescripcion [nvarchar] (100),
	   @_secEstado      [nvarchar] (15)
AS
	UPDATE SECCION 
	SET 
	   SEC_nombre      = @_secNombre      ,
	   SEC_descripcion = @_secDescripcion ,
	   SEC_estado      = @_secEstado      
	WHERE 
	   SEC_id          = @_secId ; 

GO


-----------------------PROCEDIMIENTO PARA ACTIVAR O DESACTIVAR UNA SECCION---------------------------


CREATE PROCEDURE Procedure_activarDesactivarSeccion
	   @_secId          [int], 
	   @_secEstado      [nvarchar] (15)
AS
	UPDATE SECCION 
	SET
	   SEC_estado      = @_secEstado      
	WHERE 
	   SEC_id          = @_secId ; 

GO




-----------------------PROCEDIMIENTO PARA AGREGAR PLATO AL MENU---------------------------------------



CREATE PROCEDURE Procedure_agregarPlato
	          
	   @_plaNombre      [nvarchar] (100),
	   @_plaPrecio      [float]         ,
	   @_plaDescripcion [nvarchar] (100),
	   @_seccionNombre  [nvarchar] (100)        
	   
AS

 BEGIN
	  
   DECLARE     @_idSeccion int = 0;
   
 
                
		SELECT @_idSeccion=SEC_id
		FROM SECCION
		WHERE SEC_nombre=@_seccionNombre;

	   INSERT INTO PLATO(PLA_id,PLA_nombre,PLA_precio,PLA_descripcion,PLA_estado,FK_seccion)
	   VALUES( NEXT VALUE FOR SEQ_PLATO,@_plaNombre ,@_plaPrecio,@_plaDescripcion,'Activado',@_idSeccion ) 

 END
GO

-----------------------PROCEDIMIENTO PARA CONSULTAR PLATO---------------------------------------

CREATE PROCEDURE Procedure_consultarPlato

	@_plaId		[int]

AS

  BEGIN
	   SELECT PLA_id,PLA_nombre,PLA_precio,PLA_descripcion,PLA_estado,FK_seccion 
	   FROM PLATO
	   WHERE  PLA_id = @_plaId

  END

GO

--------------------------PROCEDIMIENTO PARA MODIFICAR PLATO----------------------------------------


CREATE PROCEDURE Procedure_modificarPlato

  @_plaId          [int]           ,

  @_plaNombre      [nvarchar] (50) ,

  @_plaPrecio      [float]         ,

  @_plaDescripcion [nvarchar] (100),

  @_plaEstado      [nvarchar] (15) ,

  @_fkSeccion      [int]           

   

AS



 UPDATE PLATO 

 SET 

PLA_nombre       = @_plaNombre,

PLA_precio       = @_plaPrecio,

PLA_descripcion  = @_plaDescripcion,

PLA_estado       = @_plaEstado,

    FK_seccion       = @_fkSeccion  

 WHERE

  PLA_id     = @_plaId

GO

--------------------------PROCEDIMIENTO PARA ELIMINAR PLATO----------------------------------------

CREATE PROCEDURE Procedure_EliminarPlato

  @_plaId          [int]           ,

  @_plaEstado      [nvarchar] (15)    

AS



 UPDATE PLATO 

 SET 

PLA_estado  ='Desactivado'     

    

 WHERE

  PLA_id     =@_plaId;


GO
--------------------------PROCEDIMIENTO PARA ELIMINAR SECCION----------------------------------------

CREATE PROCEDURE Procedure_EliminarSeccion

  @_secId          [int]          

AS

UPDATE SECCION

SET 

  SEC_estado	='Desactivado'


WHERE 

  SEC_id          = @_secId ;

UPDATE PLATO 

SET 

PLA_estado  ='Desactivado'     

    

WHERE

  FK_seccion     = @_secId ;   


GO
----------------------------PROCEDIMIENTO PARA ACTIVAR O DESACTIVAR PLATOS-------------------------


CREATE PROCEDURE Procedure_activarDesactivarPlato
	   @_plaId          [int]          ,
	   @_plaEstado      [nvarchar] (15)
AS
	UPDATE PLATO 
	SET
	   PLA_estado       = @_plaEstado       
	WHERE 
	   PLA_id          = @_plaId ; 

GO


CREATE PROCEDURE Procedure_CargaGridviewEliminarSeccion

 

AS



 BEGIN


select Distinct (SEC_id) AS Codigo, SEC_nombre AS Nombre , SEC_descripcion AS descripcion, SEC_estado as estado  from SECCION where SEC_estado = 'Activado';

 END





 go


 CREATE PROCEDURE Procedure_CargaGridviewEliminarPlato

 

AS



 BEGIN


select Distinct (pla_id) as Codigo, PLA_nombre as nombre, PLA_precio as precio, PLA_descripcion  as descripcion, PLA_estado as estado, SEC_nombre as seccion from PLATO, SECCION where PLA_estado='Activado' and FK_seccion=SEC_id;

 END

go


---------------------------PROCEDIMIENTO PARA LLENAR EL COMBO DE SECCIONES----------------------------
CREATE PROCEDURE Procedure_consultarSeccionesPlato

	

AS

  BEGIN
	   SELECT DISTINCT (SEC_nombre), SEC_id
	   FROM SECCION WHERE SEC_estado='Activado'

  END
GO


CREATE PROCEDURE Procedure_consultarSeccionCompleta



AS 



  BEGIN

  SELECT SEC_id as Codigo, SEC_nombre as nombre,SEC_descripcion as descripcion,SEC_estado as estado 

  FROM SECCION; 

 



  END
go


---------------------------------  PROCEDURES FOR INSERT  ------------------------------------------------------

---------------------------------EJECUCION DE PROCEDURES PARA INSERTS----------------------------------------


EXEC Procedure_agregarSeccion 'Internacionales','Las mejores carnes, terneras y platos tanto de cocina internacional como nacional.';
EXEC Procedure_agregarSeccion 'Entradas','Platos de bienvenida para abrir el apetito de nuestros comensales';
EXEC Procedure_agregarSeccion 'Pescados','Los mejores alimentos del mar traidos a tu mesa.';
EXEC Procedure_agregarSeccion 'Bebidas','Bebidas excelentes para todos los gustos y de la mejor calidad';
EXEC Procedure_agregarSeccion 'Postres','Los mejores postres para degustar depués de una buena comida';




--------------------------------Carnes y sus platos--------------------------------------------------------------------------
EXEC Procedure_agregarPlato 'Pasta a la Bologna',100.00,'Típico plato italiano de pasta con salsa de carne de la mejor calidad','Internacionales';
EXEC Procedure_agregarPlato 'Brochetas de Ternera al Horno',80,'Plato simple y de buen sabor para compartir con tus amigos.','Internacionales';
EXEC Procedure_agregarPlato 'Lasaña clásica',120,'Plato italiano típico simple con el mismo sabro de la pasta boloñesa','Internacionales';
EXEC Procedure_agregarPlato 'Pollo al limón',130,'Pechugas de pollo marinadas en una vinagreta de limón con chile de árbol y ajo, y asadas en el asador... o la estufa','Internacionales';
EXEC Procedure_agregarPlato 'Brochetas de pollo agridulce',120,'Brochetas de pollo con vegetales. Puedes marinar la carne durante la noche anterior. Si lo deseas, agrega jitomates cherry y champiñones frescos.','Internacionales';


-----------------------------Entradas y sus platos---------------------------------------------------------------------------

EXEC Procedure_agregarPlato 'Pan al ajillo',60,'Pedazos de pan blanco cubiertos con salsa de ajo,cebollín y mantequilla','Entradas';
EXEC Procedure_agregarPlato 'Huevos con espinaca',80,'Combinando los beneficios del huevo y la espinaca. Este plato surge de la creatividad de nuestros chefs.','Entradas';
EXEC Procedure_agregarPlato 'Ensalada de calabacines y albahaca',90,'Receta australiana que caombinan los beneficios de la albahaca y el calabacin para una buena salud','Entradas';
EXEC Procedure_agregarPlato 'Ensalada de pepino con albahaca',90,'Ensalada hecha de pepinos frescos, albahaca fresca y sésamo tostado ','Entradas';
EXEC Procedure_agregarPlato 'Ensalada de papas con hierbas frescas',100,'Variante de la ensalada de papas con hojas de laurel y cascos de cebolla','Entradas';

------------------------------PESCADOS--------------------------------------------------------
EXEC Procedure_agregarPlato 'Merluza a la plancha con tapenade',200,'Merluza a la plancha acompañada de rúcula y tapenade, una pasta tradicional de la Provenza (Francia) que se prepara machacando aceitunas negras, anchoas, alcaparras y aceite de oliva.','Pescados';
EXEC Procedure_agregarPlato 'Bacalao asado con vinagreta de guindillas',250,'bacalao asado en el horno con patatas y melocotón acompañado de vinagreta de guindillas.','Pescados';
EXEC Procedure_agregarPlato 'Arroz marinero',140,'arroz marinero con rape, almejas, mejillones, gambas y cigalas, una receta tradicional, nutritiva y con sabor a mar.','Pescados';
EXEC Procedure_agregarPlato 'Bocados de merluza con dos salsas',120,'bocados de merluza rebozados acompañados de dos salsas: salsa de pimientos del piquillo y salsa de espinacas.','Pescados';
EXEC Procedure_agregarPlato 'Bonito rebozado con salsa de tomate',130,'Atún y bonito son 2 túnidos deliciosos. La tradición cantábrica sigue apostando por la delicadeza del bonito del norte, mucho más pequeño y suave, en cambio el atún rojo del sur está ahora muy de moda, más grasiento y con un sabor más intenso. Para gustos están los colores.','Pescados';

--------------------------Bebidas---------------------------------------------------------

EXEC Procedure_agregarPlato 'Agua mineral',8,'Agua natural','Bebidas';
EXEC Procedure_agregarPlato 'Refrescos',20,'Refrescos de Coca-Cola, 7Up, Naranja, Frescolita, y Uva','Bebidas';
EXEC Procedure_agregarPlato 'Limonada Frappe',150,'Limonada batida con hielo picado','Bebidas';
EXEC Procedure_agregarPlato 'Jugos Naturales',100,'Jugos naturales de Naranja, Limón, Melón,Piña,Lechoza,Patilla,Parchita y Guayaba','Bebidas';
EXEC Procedure_agregarPlato 'Cervezas',160,'Cervezas Polar, Polar Light, Solera, Solera Light y Regional','Bebidas';

-------------------------POSTRES-------------------------------------------------------------------------------------------

EXEC Procedure_agregarPlato 'Quesillo',80,'Postre típico venezolano similar al flan','Postres';
EXEC Procedure_agregarPlato 'Majarete',100,'Postre típico de nuestro país parecido al flan hecho a base de harina de maíz y leche de coco','Postres';
EXEC Procedure_agregarPlato 'Arroz con leche',110,'Postre típico nacional hecho de arroz cocido con leche y azúcar','Postres';
EXEC Procedure_agregarPlato 'Tortas',60,'Deliciosas tortas de cambur,chocolate,vainilla,tres leches y marquesas de vainilla y chocolate','Postres';
EXEC Procedure_agregarPlato 'Ensalada de Frutas',90,'Deliciosa y excelente combinación de frutas como lechoza,piña,patilla y naranja para el beneficio de tu salud','Postres';

---------------------------FIN DE LAS EJECUCIONES DE LOS INSERTS------------------------------------------------------------------------------------






commit transaction;
go