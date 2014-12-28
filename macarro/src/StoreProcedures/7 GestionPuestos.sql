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
	@_plaID[int],
	@_plaFila[int],
	@_plaColumna[int]

AS
	BEGIN
		UPDATE	PLAYA
		SET	PLA_fila = ISNULL(@_plaFila,PLA_fila),
			PLA_columna = ISNULL(@_plaColumna,PLA_columna)
		WHERE	PLA_id = ISNULL(@_plaID,PLA_id);
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
	@_invEstado [int],
	@_invDescripcion [nvarchar](100),
	@_invPlaya [int]

AS
	BEGIN
		INSERT INTO INVENTARIO(INV_id,INV_tipo,INV_precio,FK_estado,INV_descripcion,FK_playa) 
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
		DECLARE @estado int;
		DECLARE @descripcion nvarchar(100);
		SET @playa = 1;
		SET @cantidad = 1;
		SET @estado=(SELECT EST_id FROM Estado 
					WHERE EST_nombre = 'Disponible' AND EST_pertenece='Inventario');
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
	@_invEstado [int],
	@_invDescripcion [nvarchar](100)
	

AS
	BEGIN
	DECLARE @Estado int;
	DECLARE @Columna int;
	DECLARE @Fila int;
	DECLARE @InvTipo nvarchar(100);
	DECLARE @InvIDNuevo int;
	DECLARE @EstadoRequerido int;
	DECLARE @estadoAsignado int;

	SET @estadoAsignado = (SELECT EST_id FROM Estado 
						   WHERE EST_nombre = 'Asignado' AND EST_pertenece='Inventario');
	
	SET @EstadoRequerido = (SELECT EST_id FROM Estado 
							WHERE EST_nombre = 'Disponible' AND EST_pertenece='Inventario');	
	SET @Estado=(Select FK_estado from INVENTARIO WHERE INV_id = @_invId);

	IF @Estado = @estadoAsignado
	BEGIN
		SET @Columna = (Select PUE_columna from PUESTO WHERE FK_inventario = @_invId);
		SET @Fila = (Select PUE_fila from PUESTO WHERE FK_inventario = @_invId);
		SET @InvTipo = (SELECT INV_tipo from INVENTARIO WHERE INV_id = @_invId);
		SET @InvIDNuevo = (SELECT TOP(1) INV_id FROM INVENTARIO 
							WHERE FK_estado=@EstadoRequerido AND INV_tipo=@InvTipo);

		UPDATE	PUESTO
		SET		FK_inventario = ISNULL(@InvIDNuevo,FK_inventario)
		WHERE	FK_inventario = ISNULL(@_invId,FK_inventario);

		UPDATE	INVENTARIO
		SET		FK_estado = ISNULL(@Estado,FK_estado)
		WHERE	INV_id = ISNULL(@InvIDNuevo,INV_id);
	
	END;
			
		UPDATE	INVENTARIO
		SET	INV_precio = ISNULL(@_invPrecio,INV_precio),
			FK_estado = ISNULL(@_invEstado,FK_estado),
			INV_descripcion = ISNULL(@_invDescripcion,INV_descripcion)
		WHERE	INV_id = ISNULL(@_invId,INV_id)
		AND	INV_tipo = ISNULL(@_invTipo,INV_tipo);		

	END
GO

-----PROCEDIMIENTO CONSULTAR INVENTARIO---------------------------
CREATE PROCEDURE Procedure_consultarInventario
	@_invId [int],
	@_invTipo[nvarchar](100),
	@_invEstado[int]

AS
	BEGIN
		SELECT	INV.INV_id AS ID,
				INV.INV_tipo AS TIPO,
				INV.INV_precio AS PRECIO,
				INV.FK_estado AS ESTADOID,
				INV.INV_descripcion AS DESCRIPCION,
				EST.EST_nombre AS ESTADO
		FROM	INVENTARIO INV,ESTADO EST
		WHERE	INV.INV_id = ISNULL(@_invId,INV.INV_id)
		AND		INV.INV_tipo = ISNULL(@_invTipo,INV.INV_tipo)
		AND		INV.INV_descripcion != 'Eliminado'
		AND		INV.FK_estado = ISNULL(@_invEstado,INV.FK_estado)
		AND		INV.FK_estado = EST.EST_id;
	END
GO

----PROCEDIMIENTO ELIMINAR INVENTARIO---------------
CREATE PROCEDURE Procedure_EliminarInventario
	@_invId[int]	

AS
	BEGIN
	DECLARE @Estado int;
	DECLARE @Columna int;
	DECLARE @Fila int;
	DECLARE @InvTipo nvarchar(100);
	DECLARE @InvIDNuevo int;
	DECLARE @EstadoRequerido int;
	DECLARE @estadoAsignado int;
	DECLARE @estadoBloqueado int;

	SET @estadoAsignado = (SELECT EST_id FROM Estado 
						   WHERE EST_nombre = 'Asignado' AND EST_pertenece='Inventario');
	
	SET @EstadoRequerido = (SELECT EST_id FROM Estado 
							WHERE EST_nombre = 'Disponible' AND EST_pertenece='Inventario');	

	SET @estadoBloqueado = (SELECT EST_id FROM Estado 
							WHERE EST_nombre = 'Bloqueado' AND EST_pertenece='Inventario');	

	SET @Estado=(Select FK_estado from INVENTARIO WHERE INV_id = @_invId);

	IF @Estado = @estadoAsignado
	BEGIN
		SET @Columna = (Select PUE_columna from PUESTO WHERE FK_inventario = @_invId);
		SET @Fila = (Select PUE_fila from PUESTO WHERE FK_inventario = @_invId);
		SET @InvTipo = (SELECT INV_tipo from INVENTARIO WHERE INV_id = @_invId);
		SET @InvIDNuevo = (SELECT TOP(1) INV_id FROM INVENTARIO 
							WHERE FK_estado=@EstadoRequerido AND INV_tipo=@InvTipo);

		UPDATE	PUESTO
		SET		FK_inventario = ISNULL(@InvIDNuevo,FK_inventario)
		WHERE	FK_inventario = ISNULL(@_invId,FK_inventario);

		UPDATE	INVENTARIO
		SET		FK_estado = ISNULL(@Estado,FK_estado)
		WHERE	INV_id = ISNULL(@InvIDNuevo,INV_id);
	
	END;
		
	UPDATE	INVENTARIO
	SET		FK_estado = ISNULL(@estadoBloqueado,FK_estado),
			INV_descripcion = ISNULL('Eliminado',INV_descripcion)
	WHERE	INV_id = ISNULL(@_invId,INV_id);

	END
GO

----PROCEDIMIENTO PARA CONSULTAR ESTADOS INVENTARIO-------------------
CREATE PROCEDURE Procedure_consultarInventarioEstados	

AS
	BEGIN
		SELECT	EST_id AS VALOR, 
				EST_nombre AS TITULO  
		FROM	ESTADO 
		WHERE	EST_pertenece='Inventario' 
		AND		EST_nombre != 'Asignado';

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
	@_pueEstado[int],
	@_puePrecio[float],
	@_pueInventario[int],
	@_puePlaya [int]

AS
	BEGIN
		INSERT INTO PUESTO(PUE_fila,PUE_columna,PUE_descripcion,FK_estado,PUE_precio,FK_inventario,FK_playa) 
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

		DECLARE @playaFila int;
		DECLARE @playaColumna int;

		SET @playaFila = (SELECT PLA_fila FROM PLAYA);

		SET @playaColumna = (SELECT PLA_columna FROM PLAYA);

		SELECT	DISTINCT PU.PUE_fila AS FILA, 
			PU.PUE_columna AS COLUMNA,
			PU.PUE_descripcion as DESCRIPCION,
			PU.PUE_precio AS PRECIO 
		FROM	PUESTO PU,ESTADO ES
		WHERE	PU.PUE_fila = ISNULL(@_pueFila,PU.PUE_fila)
		AND	PU.PUE_columna = ISNULL(@_pueColumna,PU.PUE_columna)		
		AND PU.PUE_columna <= @playaColumna
		AND PU.PUE_fila <= @playaFila
		AND	PU.FK_estado = ES.EST_id
		AND ES.EST_nombre = ISNULL(@_pueEstado,ES.EST_nombre);
	END
GO

-----PROCEDIMIENTO ACTUALIZAR PUESTO-----------------
CREATE PROCEDURE Procedure_actualizarPuesto
	@_pueFila[int],
	@_pueColumna[int],
	@_puePrecio[float],
	@_pueEstado[varchar](100),
	@_pueDescripcion[nvarchar](100)
	

AS
	BEGIN
		DECLARE @ESTADO_ID int;

		SET @ESTADO_ID = (SELECT EST_id FROM ESTADO WHERE EST_nombre = @_pueEstado);
		
		UPDATE	PUESTO
		SET		PUE_precio = ISNULL(@_puePrecio,PUE_precio),
				FK_estado = ISNULL(@ESTADO_ID,FK_estado),
				PUE_descripcion = ISNULL(@_pueDescripcion,PUE_descripcion)
		WHERE	PUE_fila = ISNULL(@_pueFila,PUE_fila)
		AND		PUE_columna = ISNULL(@_pueColumna,PUE_columna);		

	END
GO

---------PROCEDIMIENTO QUE ASIGNA INVENTARIO AL PUESTO QUE SE GENERA-----------
CREATE PROCEDURE Procedure_AsignarInventario
	@_pueFila[int],
	@_pueColumna[int],
	@_puePrecio[float],
	@_pueDescripcion[nvarchar](100),
	@_tipo[nvarchar](100),
	@_cantidad[int]
	
AS
	BEGIN
		DECLARE @Playa int;
		DECLARE @Inventario int;
		DECLARE @EstadoBuscar int;
		DECLARE @EstadoAsignar int;	
		DECLARE @CantidadAgregada int;	
		DECLARE @EstadoPuesto int;

		SET @Playa = 1;
		SET @EstadoBuscar = (SELECT EST_id FROM Estado 
							WHERE EST_nombre = 'Disponible' AND EST_pertenece='Inventario');
		SET @EstadoAsignar = (SELECT EST_id FROM Estado 
						   WHERE EST_nombre = 'Asignado' AND EST_pertenece='Inventario');
		SET @CantidadAgregada = 1;
		SET @EstadoPuesto = (SELECT EST_id FROM ESTADO 
							WHERE EST_nombre='Activado' AND EST_pertenece = 'general' OR EST_pertenece = 'Puesto');

		WHILE	@CantidadAgregada <= @_cantidad
		BEGIN
				SET @Inventario =(select TOP(1) INV_id from inventario where FK_estado=@EstadoBuscar AND INV_tipo = @_tipo);
				EXEC Procedure_insertarPuesto @_pueFila,@_pueColumna,@_pueDescripcion,@EstadoPuesto,@_puePrecio,@Inventario,@Playa; 			
				EXEC Procedure_actualizarInventario @Inventario,null,null,@EstadoAsignar,null;
				SET @CantidadAgregada = @CantidadAgregada + 1;
		END;
	END
GO

---------------PROCEDIMIENTO AGREGAR PUESTO POR UBICACION-------------
CREATE PROCEDURE Procedure_agregarPuestoUbicacion
	@_pueFila[int],
	@_pueColumna[int],
	@_puePrecio[float],
	@_pueDescripcion[nvarchar](100)
	
AS
	BEGIN
		DECLARE @CantidadSillas int;
		DECLARE @CantidadMesa int;
		DECLARE @CantidadSombrilla int;
		DECLARE @PuestoExiste int;
		DECLARE @EstadoPuestoExiste int;
		DECLARE @EstadoPuestoCambio int;
		DECLARE @EstadoDesactivado int;
		DECLARE @EstadoDisponibleINV int;

		SET @EstadoDisponibleINV = (SELECT EST_id FROM Estado 
							WHERE EST_nombre = 'Disponible' AND EST_pertenece='Inventario');

		SET @EstadoDesactivado = (SELECT EST_id FROM ESTADO 
							WHERE EST_nombre='Desactivado' AND EST_pertenece = 'general' OR EST_pertenece = 'Puesto');

		SET @EstadoPuestoCambio = (SELECT EST_id FROM ESTADO 
							WHERE EST_nombre='Activado' AND EST_pertenece = 'general' OR EST_pertenece = 'Puesto');

		SET @PuestoExiste = (select COUNT(*) from (
								SELECT DISTINCT PUE_fila,PUE_columna 
								FROM PUESTO 
								WHERE PUE_fila = @_pueFila AND PUE_columna =@_pueColumna) as tabla);

		--PUESTO EXISTE----
		IF @PuestoExiste != 0
		BEGIN
			
			SET @EstadoPuestoExiste = (select tabla.FK_estado from (
											SELECT DISTINCT PUE_fila,PUE_columna,FK_estado 
											FROM PUESTO 
											WHERE PUE_fila = @_pueFila AND PUE_columna =@_pueColumna) as tabla);
			IF @EstadoPuestoExiste = @EstadoDesactivado
			BEGIN
				EXEC Procedure_actualizarPuesto @_pueFila,@_pueColumna,@_puePrecio,'Activado',@_pueDescripcion;
			END;

			IF @EstadoPuestoExiste = @EstadoPuestoCambio
			BEGIN
				PRINT 'EL PUESTO YA EXISTE';
			END;
			
		END;--END IF PUESTO EXISTE

		---PUESTO NO EXISTE----
		IF @PuestoExiste = 0
		BEGIN
			SET @CantidadSillas = (select COUNT(*) from INVENTARIO where INV_tipo='SILLA' AND FK_estado=@EstadoDisponibleINV);
			SET @CantidadMesa = (select COUNT(*) from INVENTARIO where INV_tipo='MESA' AND FK_estado=@EstadoDisponibleINV);
			SET @CantidadSombrilla = (select COUNT(*) from INVENTARIO where INV_tipo='SOMBRILLA' AND FK_estado=@EstadoDisponibleINV);

			----EVALUA QUE EXISTA INVENTARIO SUFICIENTE PARA CREAR EL PUESTO---------
			IF @CantidadSillas >= 2 AND @CantidadMesa >= 1 AND @CantidadSombrilla >= 1
			BEGIN
				----SE AGREGAN LAS SILLAS AL PUESTO------------
				EXEC Procedure_AsignarInventario @_pueFila,@_pueColumna,@_puePrecio,@_pueDescripcion,'SILLA',2;

				----SE AGREGA LA MESA AL PUESTO------------
				EXEC Procedure_AsignarInventario @_pueFila,@_pueColumna,@_puePrecio,@_pueDescripcion,'MESA',1;

				----SE AGREGA LA SOMBRILLA AL PUESTO------------
				EXEC Procedure_AsignarInventario @_pueFila,@_pueColumna,@_puePrecio,@_pueDescripcion,'SOMBRILLA',1;

			END;--END IF INVENTARIO SUFICIENTE

			---EN CASO QUE EL INVENTARIO NO SEA SUFICIENTE PARA CREAR EL PUESTO--------
			IF @CantidadSillas < 2 OR @CantidadMesa < 1 OR @CantidadSombrilla < 1
			BEGIN
				PRINT CONCAT('FALTA DE INVENTARIO - SILLAS: ', @CantidadSillas,', MESAS: ',@CantidadMesa,
				', SOMBRILLAS: ',@CantidadSombrilla);
			END;
		END;--END IF PUESTO NO EXISTE
		
	END
GO

---PROCEDIMIENTO PARA AGREGAR PUESTOS DE UNA FILA---------
CREATE PROCEDURE Procedure_agregarPuestoFila
	@_pueFila[int],
	@_puePrecio[float],
	@_pueDescripcion[nvarchar](100)
AS
	BEGIN
		DECLARE @columnaPlaya int;
		DECLARE @columnaInicio int;

		SET @columnaPlaya = (select PLA_columna from PLAYA);
		SET @columnaInicio = 1;

		WHILE	@columnaInicio <= @columnaPlaya
		BEGIN
			EXEC Procedure_agregarPuestoUbicacion @_pueFila,@columnaInicio,@_puePrecio,@_pueDescripcion;
			SET @columnaInicio = @columnaInicio + 1;
		END;
	END
GO

---PROCEDIMIENTO PARA AGREGAR PUESTOS DE UNA COLUMNA---------
CREATE PROCEDURE Procedure_agregarPuestoColumna
	@_pueColumna[int],
	@_puePrecio[float],
	@_pueDescripcion[nvarchar](100)
	

AS
	BEGIN
		DECLARE @filaPlaya int;
		DECLARE @filaInicio int;

		SET @filaPlaya = (select PLA_fila from PLAYA);
		SET @filaInicio = 1;

		WHILE	@filaInicio <= @filaPlaya
		BEGIN
			EXEC Procedure_agregarPuestoUbicacion @filaInicio,@_pueColumna,@_puePrecio,@_pueDescripcion;
			SET @filaInicio = @filaInicio + 1;
		END;
	END
GO

----PROCEDIMIENTO PARA AGREGAR TODOS LOS PUESTOS DE LA PLAYA----
CREATE PROCEDURE Procedure_agregarPuestoTodos
	@_puePrecio[float],
	@_pueDescripcion[nvarchar](100)
	
AS
	BEGIN
		DECLARE @filaPlaya int;
		DECLARE @columnaPlaya int;
		DECLARE @filaInicio int;
		DECLARE @colimnaInicio int;

		SET @filaPlaya = (select PLA_fila from PLAYA);
		SET @columnaPlaya = (select PLA_columna from PLAYA);
		SET @filaInicio = 1;
		SET @colimnaInicio = 1;

		WHILE	@filaInicio <= @filaPlaya
		BEGIN
			WHILE	@colimnaInicio <= @columnaPlaya
			BEGIN
				EXEC Procedure_agregarPuestoUbicacion @filaInicio,@colimnaInicio,@_puePrecio,@_pueDescripcion;
				SET @colimnaInicio = @colimnaInicio + 1;
			END;

			SET @colimnaInicio = 1;
			SET @filaInicio = @filaInicio + 1;
		END;
	END
GO


----PROCEDIMIENTO PARA AGREGAR PUESTOS-------------------
CREATE PROCEDURE Procedure_agregarPuesto
	@_pueFila[int],
	@_pueColumna[int],
	@_puePrecio[float],
	@_pueDescripcion[nvarchar](100),
	@_accion[int]
	
AS
	BEGIN
		
		IF @_accion = 0
		BEGIN
			EXEC Procedure_agregarPuestoTodos @_puePrecio,@_pueDescripcion;
		END;
		
		IF @_accion = 1
		BEGIN
			EXEC Procedure_agregarPuestoFila @_pueFila,@_puePrecio,@_pueDescripcion;
		END;
		
		IF @_accion = 2
		BEGIN
			EXEC Procedure_agregarPuestoColumna @_pueColumna,@_puePrecio,@_pueDescripcion;
		END;
		
		IF @_accion = 3
		BEGIN
			EXEC Procedure_agregarPuestoUbicacion @_pueFila,@_pueColumna,@_puePrecio,@_pueDescripcion;
		END;	
		
	END
GO

-------------INSERTS----------------------------
EXEC Procedure_insertarPlaya 10,10


------ AGREGAR UNO O MAS INVENTARIO EN UNA SOLA EJECUCION------------------------
-------tipo: sombrilla, precio: 12.50, cantidad a insertar: 10
EXEC Procedure_agregarInventario 'SILLA',200,60;
EXEC Procedure_agregarInventario 'MESA',200,60;
EXEC Procedure_agregarInventario 'SOMBRILLA',200,60;

------AGREGAR LOS PUESTOS
EXEC Procedure_agregarPuestoFila 1,100,'vista al mar';
EXEC Procedure_agregarPuestoFila 2,100,'vista al mar con poca visibilidad';


commit transaction;
go