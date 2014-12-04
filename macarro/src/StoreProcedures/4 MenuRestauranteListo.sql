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
	   @_secDescripcion [nvarchar] (100),
	   @_secEstado      [nvarchar] (15)
AS

 BEGIN
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
	          
	   @_plaNombre      [nvarchar] (50) ,
	   @_plaPrecio      [float]         ,
	   @_plaDescripcion [nvarchar] (100),
	   @_plaEstado      [nvarchar] (15) ,
	   @_fkSeccion      [int]           
	   
AS

 BEGIN
	   INSERT INTO PLATO(PLA_id,PLA_nombre,PLA_precio,PLA_descripcion,PLA_estado,FK_seccion)
	   VALUES( NEXT VALUE FOR SEQ_PLATO,@_plaNombre,@_plaPrecio,@_plaDescripcion,@_plaEstado,@_fkSeccion ) 
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
	PLA_nombre       = @_plaNombre     ,
	PLA_precio       = @_plaPrecio     ,
	PLA_descripcion  = @_plaDescripcion,
	PLA_estado       = @_plaEstado     ,
    FK_seccion       = @_fkSeccion  	
 WHERE
	  PLA_id     = @_plaId        AND
	  FK_seccion = @_fkSeccion;
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


---------------------------------  PROCEDURES FOR INSERT  ------------------------------------------------------

---------------------------------EJECUCION DE PROCEDURES PARA INSERTS----------------------------------------


EXEC Procedure_agregarSeccion 'Carnes','Las mejores carnes, terneras y platos tanto de cocina internacional como nacional.','Activado';
EXEC Procedure_agregarSeccion 'Entradas','Platos de bienvenida para abrir el apetito de nuestros comensales','Activado';
EXEC Procedure_agregarSeccion 'Pescados','Los mejores alimentos del mar traidos a tu mesa.','Activado';
EXEC Procedure_agregarSeccion 'Bebidas','Bebidas excelentes para todos los gustos y de la mejor calidad','Activado';
EXEC Procedure_agregarSeccion 'Postres','Los mejores postres para degustar depués de una buena comida','Activado';



--------------------------------Carnes y sus platos--------------------------------------------------------------------------
EXEC Procedure_agregarPlato 'Pasta a la Bologna',100.00,'Típico plato italiano de pasta con salsa de carne de la mejor calidad','Activado',1;
EXEC Procedure_agregarPlato 'Brochetas de Ternera al Horno',80,'Plato simple y de buen sabor para compartir con tus amigos.','Activado',1;
EXEC Procedure_agregarPlato 'Lasaña clásica',120,'Plato italiano típico simple con el mismo sabro de la pasta boloñesa','Activado',1;
EXEC Procedure_agregarPlato 'Pollo al limón',130,'Pechugas de pollo marinadas en una vinagreta de limón con chile de árbol y ajo, y asadas en el asador... o la estufa','Activado',1;
EXEC Procedure_agregarPlato 'Brochetas de pollo agridulce',120,'Brochetas de pollo con vegetales. Puedes marinar la carne durante la noche anterior. Si lo deseas, agrega jitomates cherry y champiñones frescos.','Activado',1;


-----------------------------Entradas y sus platos---------------------------------------------------------------------------

EXEC Procedure_agregarPlato 'Pan al ajillo',60,'Pedazos de pan blanco cubiertos con salsa de ajo,cebollín y mantequilla','Activado',2;
EXEC Procedure_agregarPlato 'Huevos con espinaca',80,'Combinando los beneficios del huevo y la espinaca. Este plato surge de la creatividad de nuestros chefs.','Activado',2;
EXEC Procedure_agregarPlato 'Ensalada de calabacines y albahaca',90,'Receta australiana que caombinan los beneficios de la albahaca y el calabacin para una buena salud','Activado',2;
EXEC Procedure_agregarPlato 'Ensalada de pepino con albahaca',90,'Ensalada hecha de pepinos frescos, albahaca fresca y sésamo tostado ','Activado',2;
EXEC Procedure_agregarPlato 'Ensalada de papas con hierbas frescas',100,'Variante de la ensalada de papas con hojas de laurel y cascos de cebolla','Activado',2;

------------------------------PESCADOS--------------------------------------------------------
EXEC Procedure_agregarPlato 'Merluza a la plancha con tapenade',200,'Merluza a la plancha acompañada de rúcula y tapenade, una pasta tradicional de la Provenza (Francia) que se prepara machacando aceitunas negras, anchoas, alcaparras y aceite de oliva.','Activado',3;
EXEC Procedure_agregarPlato 'Bacalao asado con vinagreta de guindillas',250,'bacalao asado en el horno con patatas y melocotón acompañado de vinagreta de guindillas.','Activado',3;
EXEC Procedure_agregarPlato 'Arroz marinero',140,'arroz marinero con rape, almejas, mejillones, gambas y cigalas, una receta tradicional, nutritiva y con sabor a mar.','Activado',3;
EXEC Procedure_agregarPlato 'Bocados de merluza con dos salsas',120,'bocados de merluza rebozados acompañados de dos salsas: salsa de pimientos del piquillo y salsa de espinacas.','Activado',3;
EXEC Procedure_agregarPlato 'Bonito rebozado con salsa de tomate',130,'Atún y bonito son 2 túnidos deliciosos. La tradición cantábrica sigue apostando por la delicadeza del bonito del norte, mucho más pequeño y suave, en cambio el atún rojo del sur está ahora muy de moda, más grasiento y con un sabor más intenso. Para gustos están los colores.','Activado',3;

--------------------------Bebidas---------------------------------------------------------

EXEC Procedure_agregarPlato 'Agua mineral',8,'Agua natural','Activado',4;
EXEC Procedure_agregarPlato 'Refrescos',20,'Refrescos de Coca-Cola, 7Up, Naranja, Frescolita, y Uva','Activado',4;
EXEC Procedure_agregarPlato 'Limonada Frappe',150,'Limonada batida con hielo picado','Activado',4;
EXEC Procedure_agregarPlato 'Jugos Naturales',100,'Jugos naturales de Naranja, Limón, Melón,Piña,Lechoza,Patilla,Parchita y Guayaba','Activado',4;
EXEC Procedure_agregarPlato 'Cervezas',160,'Cervezas Polar, Polar Light, Solera, Solera Light y Regional','Activado',4;

-------------------------POSTRES-------------------------------------------------------------------------------------------

EXEC Procedure_agregarPlato 'Quesillo',80,'Postre típico venezolano similar al flan','Activado',5
EXEC Procedure_agregarPlato 'Majarete',100,'Postre típico de nuestro país parecido al flan hecho a base de harina de maíz y leche de coco','Activado',5;
EXEC Procedure_agregarPlato 'Arroz con leche',110,'Postre típico nacional hecho de arroz cocido con leche y azúcar','Activado',5;
EXEC Procedure_agregarPlato 'Tortas',60,'Deliciosas tortas de cambur,chocolate,vainilla,tres leches y marquesas de vainilla y chocolate','Activado',5;
EXEC Procedure_agregarPlato 'Ensalada de Frutas',90,'Deliciosa y excelente combinación de frutas como lechoza,piña,patilla y naranja para el beneficio de tu salud','Activado',5;

---------------------------FIN DE LAS EJECUCIONES DE LOS INSERTS------------------------------------------------------------------------------------


--------------------------------------EJECUCIONES DE PRUEBA DE LOS PROCEDURES----------------------------------------------------------------------
EXEC Procedure_modificarSeccion 1,'Internacionales','Platos de marca internacional','Activado';

EXEC Procedure_modificarPlato 3,'Terneras a la broaster', 200,'Ternera bien cocida', 'Activado', 3;

EXEC Procedure_activarDesactivarSeccion 2,'Desactivado';

EXEC Procedure_activarDesactivarPlato 5,'Desactivado';

commit transaction;
go