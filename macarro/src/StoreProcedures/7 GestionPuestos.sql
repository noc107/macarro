use MACARRO
go
begin transaction;
go
--------Secuencial de la Tabla Playa--------------

CREATE SEQUENCE secuenciaTablaPlaya
    START WITH 1
    INCREMENT BY 1 ;
GO

--------Secuencial de la Tabla Inventario--------------

CREATE SEQUENCE secuenciaTablaInventario
    START WITH 1
    INCREMENT BY 1 ;
GO


-------------------------------------------------------------------------------------
--------------------------   GESTION DE PLAYA  --------------------------------------
-------------------------------------------------------------------------------------

--------PROCEDIMIENTO INSERTAR PLAYA----------

CREATE PROCEDURE Procedure_insertarPlaya
	@_playaFila [int],
	@_playaColumna [int]

AS
	BEGIN
		INSERT INTO PLAYA(PLA_id,PLA_fila,PLA_columna) 
		VALUES (NEXT VALUE FOR secuenciaTablaPlaya,@_playaFila,@_playaColumna);	
	END 
GO

--------PROCEDIMIENTO ACTUALIZAR PLAYA--------
CREATE PROCEDURE Procedure_actualizarPlaya
	@_puePlaya[int],
	@_pueFila[int],
	@_pue_Columna[int]

AS
	BEGIN
		UPDATE	PLAYA
		SET	PLA_fila = ISNULL(@_pueFila,PLA_fila),
			PLA_columna = ISNULL(@_pue_Columna,PLA_columna)
		WHERE	PLA_id = ISNULL(@_puePlaya,PLA_id);
	END 
GO

-----PROCEDIMIENTO CONSULTAR PLAYA---------------
CREATE PROCEDURE Procedure_consultarPlaya
	@_plaID[int]

AS
	BEGIN
		SELECT	PLA_id AS ID, 
			PLA_fila AS FILAS, 
			PLA_columna AS COLUMNAS 
		FROM	PLAYA
		WHERE	PLA_id = ISNULL(@_plaID,PLA_id);
	END 
GO

-------------------------------------------------------------------------------------
--------------------------GESTION DE INVENTARIO--------------------------------------
-------------------------------------------------------------------------------------

-------PROCEDIMIENTO INSERTAR INVENTARIO---------

CREATE PROCEDURE Procedure_insertarInventario
	@_invTipo [nvarchar](100),
	@_invPrecio [float],
	@_invEstado [nvarchar](100),
	@_invDescripcion [nvarchar](100),
	@_invPlaya [int]

AS
	BEGIN
		INSERT INTO INVENTARIO(INV_id,INV_tipo,INV_precio,INV_estado,INV_descripcion,FK_playa) 
		VALUES (NEXT VALUE FOR secuenciaTablaInventario ,@_invTipo,@_invPrecio,@_invEstado,@_invDescripcion,@_invPlaya);	
	END 
GO

--------PROCEDIMIENTO AGREGAR INVENTARIO EN CANTIDAD----------
CREATE PROCEDURE Procedure_agregarInventario
	@_invTipo [nvarchar](100),
	@_invPrecio [float],
	@_invCantidad [int]

AS
	BEGIN

		DECLARE @playa int;
		DECLARE @cantidad int;
		DECLARE @estado nvarchar(100);
		DECLARE @descripcion nvarchar(100);
		SET @playa = 1;
		SET @cantidad = 1;
		SET @estado = 'Disponible';
		SET @descripcion = 'Perfecto Estado';
		
		WHILE @cantidad <= @_invCantidad
			BEGIN
				EXEC Procedure_insertarInventario @_invTipo,@_invPrecio, @estado,@descripcion,@playa;
				SET @cantidad = @cantidad + 1;
			END;
	
	END
GO


--------PROCEDIMIENTO ACTUALIZAR INVENTARIO EN CANTIDAD O INDIVIDUAL----------
CREATE PROCEDURE Procedure_actualizarInventario
	@_invId [int],
	@_invTipo [nvarchar](100),
	@_invPrecio [float],
	@_invEstado [nvarchar](100),
	@_invDescripcion [nvarchar](100)
	

AS
	BEGIN
		
		UPDATE	INVENTARIO
		SET	INV_precio = ISNULL(@_invPrecio,INV_precio),
			INV_estado = ISNULL(@_invEstado,INV_estado),
			INV_descripcion = ISNULL(@_invDescripcion,INV_descripcion)
		WHERE	INV_id = ISNULL(@_invId,INV_id)
		AND	INV_tipo = ISNULL(@_invTipo,INV_tipo);		

	END
GO

-----PROCEDIMIENTO CONSULTAR INVENTARIO---------------------------
CREATE PROCEDURE Procedure_consultarInventario
	@_invTipo[nvarchar](100),
	@_invEstado[nvarchar](100)

AS
	BEGIN
		SELECT	INV_id AS ID,
				INV_tipo AS TIPO,
				INV_precio AS PRECIO,
				INV_estado AS ESTADO,
				INV_descripcion AS DESCRIPCION
		FROM	INVENTARIO
		WHERE	INV_tipo = ISNULL(@_invTipo,INV_tipo)
		AND		INV_estado = ISNULL(@_invEstado,INV_estado);
	END
GO

-------------------------------------------------------------------------------------
--------------------------   GESTION DE PUESTOS--------------------------------------
-------------------------------------------------------------------------------------

-------PROCEDIMIENTO INSERTAR PUESTO---------

CREATE PROCEDURE Procedure_insertarPuesto
	@_pueFila[int],
	@_pue_Columna[int],
	@_pueDescripcion[nvarchar](100),
	@_pueEstado[nvarchar](100),
	@_puePrecio[float],
	@_pueInventario[int],
	@_puePlaya [int]

AS
	BEGIN
		INSERT INTO PUESTO(PUE_fila,PUE_columna,PUE_descripcion,PUE_estado,PUE_precio,FK_inventario,FK_playa) 
		VALUES (@_pueFila,@_pue_Columna,@_pueDescripcion,@_pueEstado,@_puePrecio,@_pueInventario,@_puePlaya);	
	END 
GO

---------PROCEDIMIENTO CONSULTAR PUESTO-----------
CREATE PROCEDURE Procedure_consultarPuesto
	@_pueFila[int],
	@_pueColumna[int],
	@_pueEstado[nvarchar](100)

AS
	BEGIN
		SELECT	DISTINCT PUE_fila AS FILA, 
			PUE_columna AS COLUMNA,
			PUE_descripcion as DESCRIPCION,
			PUE_precio AS PRECIO 
		FROM	PUESTO
		WHERE	PUE_fila = ISNULL(@_pueFila,PUE_fila)
		AND	PUE_columna = ISNULL(@_pueColumna,PUE_columna)
		AND	PUE_estado = ISNULL(@_pueEstado,PUE_estado);
	END
GO

-----PROCEDIMIENTO ACTUALIZAR PUESTO-----------------
CREATE PROCEDURE Procedure_actualizarPuesto
	@_pueFila[int],
	@_pueColumna[int],
	@_puePrecio[float],
	@_pueEstado[nvarchar](100),
	@_pueDescripcion[nvarchar](100)
	

AS
	BEGIN
		
		UPDATE	PUESTO
		SET		PUE_precio = ISNULL(@_puePrecio,PUE_precio),
				PUE_estado = ISNULL(@_pueEstado,PUE_estado),
				PUE_descripcion = ISNULL(@_pueDescripcion,PUE_descripcion)
		WHERE	PUE_fila = ISNULL(@_pueFila,PUE_fila)
		AND		PUE_columna = ISNULL(@_pueColumna,PUE_columna);		

	END
GO

-------------INSERTS----------------------------
EXEC Procedure_insertarPlaya 10,10


------- AGREGA UNO A UNO EL INVENTARIO ------------------------------------------
EXEC Procedure_insertarInventario 'SILLA',12.25,'Disponible','silla reclinable',1;
EXEC Procedure_insertarInventario 'SILLA',12.25,'Disponible','silla reclinable',1;
EXEC Procedure_insertarInventario 'SILLA',12.25,'Disponible','silla reclinable',1;
EXEC Procedure_insertarInventario 'SILLA',12.25,'Disponible','silla reclinable',1;
EXEC Procedure_insertarInventario 'SILLA',12.25,'Disponible','silla reclinable',1;
EXEC Procedure_insertarInventario 'SILLA',12.25,'Disponible','silla reclinable',1;
EXEC Procedure_insertarInventario 'SILLA',12.25,'Disponible','silla reclinable',1;

------ AGREGAR UNO O MAS INVENTARIO EN UNA SOLA EJECUCION------------------------
-------tipo: sombrilla, precio: 12.50, cantidad a insertar: 10
EXEC Procedure_agregarInventario 'SOMBRILLA',   12.50  ,  10;


EXEC Procedure_insertarPuesto 1, 1 ,'excelente vista al mar', 'Activado',100.00, 1, 1;
EXEC Procedure_insertarPuesto 1, 2 ,'excelente vista al mar', 'Activado',100.00, 2, 1;
EXEC Procedure_insertarPuesto 1, 3 ,'excelente vista al mar', 'Activado',100.00, 3, 1;
EXEC Procedure_insertarPuesto 1, 4 ,'excelente vista al mar', 'Activado',100.00, 4, 1;
EXEC Procedure_insertarPuesto 1, 5 ,'excelente vista al mar', 'Activado',100.00, 5, 1;

commit transaction;
go