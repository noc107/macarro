use MACARRO
GO
begin transaction;
go


------------------------------------  PRODEDURES  ----------------------------------------------------
-----------------------PROCEDIMIENTO PARA AGREGAR PLATO AL MENU---------------------------------------
CREATE PROCEDURE Procedure_agregarPlato
	          
		@_plaNombre      [nvarchar] (100),
		@_plaPrecio      [float]         ,
		@_plaDescripcion [nvarchar] (100),
		@_seccionNombre  [nvarchar] (100),
		@_seccionId		 [int]
	
	   
	AS

	BEGIN

		INSERT INTO PLATO(PLA_id,PLA_nombre,PLA_precio,PLA_descripcion,FK_estado, FK_seccion)		
		VALUES(NEXT VALUE FOR SEQ_PLATO, @_plaNombre, @_plaPrecio,@_plaDescripcion, 19, @_seccionId) 
	END
GO

-----------------------PROCEDIMIENTO PARA CONSULTAR PLATO---------------------------------------
CREATE PROCEDURE Procedure_consultarPlato

	@_plaId		[int]

	AS

	BEGIN
		SELECT PLA_id, PLA_nombre,PLA_precio,PLA_descripcion 
		FROM PLATO
		WHERE  PLA_id = @_plaId
	END
GO

-----------------------PROCEDIMIENTO PARA CONSULTAR TODOS LOS PLATOS---------------------------------------
CREATE PROCEDURE Procedure_consultarTodosLosPlatos	

	AS

	BEGIN
		SELECT pla_id, pla_nombre, pla_precio, pla_descripcion, sec_nombre
		FROM PLATO, SECCION
		WHERE FK_seccion = SEC_id
	END
GO

-----------------------PROCEDIMIENTO PARA CONSULTAR TODAS LAS SECCIONES---------------------------------------
CREATE PROCEDURE Procedure_consultarTodasLasSecciones	

	AS

	BEGIN
		SELECT * FROM SECCION
	END
GO

-----------------------PROCEDIMIENTO PARA OBTENER ID DE SECCION DADO SU NOMBRE---------------------------------------
CREATE PROCEDURE Procedure_obtenerIdSeccion	

	@_secNombre [nvarchar] (50)

	AS

	BEGIN
		SELECT sec_id
		FROM seccion
		WHERE sec_nombre = @_secNombre
	END
GO

--------------------------PROCEDIMIENTO PARA MODIFICAR PLATO----------------------------------------
CREATE PROCEDURE Procedure_modificarPlato

	@_plaId          [int]           ,
	@_plaNombre      [nvarchar] (50) ,
	@_plaPrecio      [float]         ,
	@_plaDescripcion [nvarchar] (100),
	@_plaEstado      [int],
	@_fkSeccion      [int]             

	AS

	UPDATE PLATO 

	SET 	
		PLA_nombre       = @_plaNombre,	
		PLA_precio       = @_plaPrecio,
		PLA_descripcion  = @_plaDescripcion,
		FK_estado        = @_plaEstado,
		FK_seccion       = @_fkSeccion  
	WHERE
		PLA_id     = @_plaId
GO

----------------------------PROCEDIMIENTO PARA ACTIVAR O DESACTIVAR PLATOS-------------------------
CREATE PROCEDURE Procedure_activarDesactivarPlato
	   @_plaId          [int]          ,
	   @_plaEstado      [int]
AS
	UPDATE PLATO 
	SET
	   FK_estado       = @_plaEstado       
	WHERE 
	   PLA_id          = @_plaId ; 
GO

-------------------PROCEDIMIENTO PARA EL INGRESO DE SECCIONES ------------------------------------

CREATE PROCEDURE Procedure_agregarSeccion
	             
	   @_secNombre      [nvarchar] (100),
	   @_secDescripcion [nvarchar] (100)  
AS
 BEGIN
	   INSERT INTO SECCION(SEC_id,SEC_nombre,SEC_descripcion,FK_estado)
	   VALUES( NEXT VALUE FOR SEQ_SECCION,@_secNombre,@_secDescripcion, 19) 
 END

GO

-----------------------PROCEDIMIENTO PARA CONSULTAR SECCION ---------------------------------------

CREATE PROCEDURE Procedure_consultarSeccion

	@_secId		[int]
AS
  BEGIN
	   SELECT SEC_id,SEC_nombre,SEC_descripcion, EST_nombre 
	   FROM SECCION, ESTADO
	   WHERE	FK_estado = EST_id AND
				@_secId = SEC_id
  END

GO

----------------------PROCEDIMIENTO PARA MODIFICAR LA SECCION--------------------------------------

CREATE PROCEDURE Procedure_modificarSeccion
	   @_secId          [int]           ,
	   @_secNombre      [nvarchar] (100),
	   @_secDescripcion [nvarchar] (100)
AS
	UPDATE SECCION 
	SET 
	   SEC_nombre      = @_secNombre      ,
	   SEC_descripcion = @_secDescripcion 
	WHERE 
	   SEC_id          = @_secId ; 
GO

-----------------------PROCEDIMIENTO PARA CAMBIAR EL ESTADO DE UNA SECCION---------------------------

CREATE PROCEDURE Procedure_modificarEstadoSeccion
	   @_secId          [int], 
	   @_secEstado      [int]
AS
	UPDATE SECCION 
	SET
	   FK_estado      = @_secEstado      
	WHERE 
	   SEC_id          = @_secId ; 
GO

-----------------------PROCEDIMIENTO PARA CONSULTAR SECCIONES POR DISPONIBLE ---------------------------------------

CREATE PROCEDURE Procedure_consultarSeccionDisponible

	@_secId		[int]
AS
  BEGIN
	   SELECT SEC_id,SEC_nombre,SEC_descripcion, EST_nombre 
	   FROM SECCION, ESTADO
	   WHERE	FK_estado = EST_id AND
				@_secId = SEC_id AND
				EST_nombre = 'Disponible'
  END
  
GO

-----------------------PROCEDIMIENTO PARA CONSULTAR SECCIONES POR NO DISPONIBLE ---------------------------------------

CREATE PROCEDURE Procedure_consultarSeccionNoDisponible

	@_secId		[int]

AS
  BEGIN
	   SELECT SEC_id,SEC_nombre,SEC_descripcion, EST_nombre 
	   FROM SECCION, ESTADO
	   WHERE	FK_estado = EST_id AND
				@_secId = SEC_id AND
				EST_nombre = 'No Disponible'
  END
  
GO

---------------------------------EJECUCION DE PROCEDURES PARA INSERTS----------------------------------------
EXEC Procedure_agregarSeccion 'Internacionales','Las mejores carnes, terneras y platos tanto de cocina internacional como nacional.';
EXEC Procedure_agregarSeccion 'Entradas','Platos de bienvenida para abrir el apetito de nuestros comensales';
EXEC Procedure_agregarSeccion 'Pescados','Los mejores alimentos del mar traidos a tu mesa.';
EXEC Procedure_agregarSeccion 'Bebidas','Bebidas excelentes para todos los gustos y de la mejor calidad';
EXEC Procedure_agregarSeccion 'Postres','Los mejores postres para degustar depués de una buena comida';

--------------------------------Carnes y sus platos--------------------------------------------------------------------------
EXEC Procedure_agregarPlato 'Pasta a la Bologna',100.00,'Típico plato italiano de pasta con salsa de carne de la mejor calidad','Internacionales', 1;
EXEC Procedure_agregarPlato 'Brochetas de Ternera al Horno',80,'Plato simple y de buen sabor para compartir con tus amigos.','Internacionales', 1;
EXEC Procedure_agregarPlato 'Lasaña clásica',120,'Plato italiano típico simple con el mismo sabro de la pasta boloñesa','Internacionales', 1;
EXEC Procedure_agregarPlato 'Pollo al limón',130,'Pechugas de pollo marinadas en una vinagreta de limón con chile de árbol y ajo, y asadas en el asador... o la estufa','Internacionales', 1;
EXEC Procedure_agregarPlato 'Brochetas de pollo agridulce',120,'Brochetas de pollo con vegetales. Puedes marinar la carne durante la noche anterior. Si lo deseas, agrega jitomates cherry y champiñones frescos.','Internacionales', 1;


-----------------------------Entradas y sus platos---------------------------------------------------------------------------

EXEC Procedure_agregarPlato 'Pan al ajillo',60,'Pedazos de pan blanco cubiertos con salsa de ajo,cebollín y mantequilla','Entradas', 2;
EXEC Procedure_agregarPlato 'Huevos con espinaca',80,'Combinando los beneficios del huevo y la espinaca. Este plato surge de la creatividad de nuestros chefs.','Entradas', 2;
EXEC Procedure_agregarPlato 'Ensalada de calabacines y albahaca',90,'Receta australiana que caombinan los beneficios de la albahaca y el calabacin para una buena salud','Entradas', 2;
EXEC Procedure_agregarPlato 'Ensalada de pepino con albahaca',90,'Ensalada hecha de pepinos frescos, albahaca fresca y sésamo tostado ','Entradas', 2;
EXEC Procedure_agregarPlato 'Ensalada de papas con hierbas frescas',100,'Variante de la ensalada de papas con hojas de laurel y cascos de cebolla','Entradas', 2;

------------------------------PESCADOS--------------------------------------------------------
EXEC Procedure_agregarPlato 'Merluza a la plancha con tapenade',200,'Merluza a la plancha acompañada de rúcula y tapenade, una pasta tradicional de la Provenza (Francia) que se prepara machacando aceitunas negras, anchoas, alcaparras y aceite de oliva.','Pescados', 3;
EXEC Procedure_agregarPlato 'Bacalao asado con vinagreta de guindillas',250,'bacalao asado en el horno con patatas y melocotón acompañado de vinagreta de guindillas.','Pescados', 3;
EXEC Procedure_agregarPlato 'Arroz marinero',140,'arroz marinero con rape, almejas, mejillones, gambas y cigalas, una receta tradicional, nutritiva y con sabor a mar.','Pescados', 3;
EXEC Procedure_agregarPlato 'Bocados de merluza con dos salsas',120,'bocados de merluza rebozados acompañados de dos salsas: salsa de pimientos del piquillo y salsa de espinacas.','Pescados', 3;
EXEC Procedure_agregarPlato 'Bonito rebozado con salsa de tomate',130,'Atún y bonito son 2 túnidos deliciosos. La tradición cantábrica sigue apostando por la delicadeza del bonito del norte, mucho más pequeño y suave, en cambio el atún rojo del sur está ahora muy de moda, más grasiento y con un sabor más intenso. Para gustos están los colores.','Pescados', 3;

--------------------------Bebidas---------------------------------------------------------

EXEC Procedure_agregarPlato 'Agua mineral',8,'Agua natural','Bebidas', 4;
EXEC Procedure_agregarPlato 'Refrescos',20,'Refrescos de Coca-Cola, 7Up, Naranja, Frescolita, y Uva','Bebidas', 4;
EXEC Procedure_agregarPlato 'Limonada Frappe',150,'Limonada batida con hielo picado','Bebidas', 4;
EXEC Procedure_agregarPlato 'Jugos Naturales',100,'Jugos naturales de Naranja, Limón, Melón,Piña,Lechoza,Patilla,Parchita y Guayaba','Bebidas', 4;
EXEC Procedure_agregarPlato 'Cervezas',160,'Cervezas Polar, Polar Light, Solera, Solera Light y Regional','Bebidas', 4;

-------------------------POSTRES-------------------------------------------------------------------------------------------

EXEC Procedure_agregarPlato 'Quesillo',80,'Postre típico venezolano similar al flan','Postres', 5;
EXEC Procedure_agregarPlato 'Majarete',100,'Postre típico de nuestro país parecido al flan hecho a base de harina de maíz y leche de coco','Postres', 5;
EXEC Procedure_agregarPlato 'Arroz con leche',110,'Postre típico nacional hecho de arroz cocido con leche y azúcar','Postres', 5;
EXEC Procedure_agregarPlato 'Tortas',60,'Deliciosas tortas de cambur,chocolate,vainilla,tres leches y marquesas de vainilla y chocolate','Postres', 5;
EXEC Procedure_agregarPlato 'Ensalada de Frutas',90,'Deliciosa y excelente combinación de frutas como lechoza,piña,patilla y naranja para el beneficio de tu salud','Postres', 5;

---------------------------FIN DE LAS EJECUCIONES DE LOS INSERTS------------------------------------------------------------------------------------

commit transaction;
go
