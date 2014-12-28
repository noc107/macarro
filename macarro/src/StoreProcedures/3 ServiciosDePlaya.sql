use MACARRO
go
begin transaction;
go

/*---------------------------------------------------------------- SECUENCIAS -----------------------------------------------------------------------------------*/
CREATE SEQUENCE secuenciaIdServicio
AS 
	int
	START WITH 50
	INCREMENT BY 1;
	go
CREATE SEQUENCE secuenciaIdCategoria
AS 
	int
	START WITH 50
	INCREMENT BY 1;
	go

CREATE SEQUENCE secuenciaIdHorario
AS 
	int
	START WITH 50
	INCREMENT BY 1;
	go

/* ----------------------------------------------------------------INSERT CATEGORIA-------------------------------------------------------------------------------*/
INSERT INTO CATEGORIA (CAT_id, CAT_nombre) VALUES (1, 'Deporte');
INSERT INTO CATEGORIA (CAT_id, CAT_nombre) VALUES (2, 'Recreativo');
INSERT INTO CATEGORIA (CAT_id, CAT_nombre) VALUES (3, 'Familiar');
INSERT INTO CATEGORIA (CAT_id, CAT_nombre) VALUES (4, 'Infantil');

/*-----------------------------------------------------------------ISNSERT SERVICIOS------------------------------------------------------------------------------*/
INSERT INTO SERVICIO (SER_id, SER_nombre, SER_descripcion, SER_cantidadDis, SER_capacidad, SER_costo, SER_retiro, FK_estado, FK_categoria) VALUES (1, 'Tabla de Surf', 'Aférrate y disfruta de las olas del mar', 10, 1, 45, 'Puesto de articulos',1, 1);
INSERT INTO SERVICIO (SER_id, SER_nombre, SER_descripcion, SER_cantidadDis, SER_capacidad, SER_costo, SER_retiro, FK_estado, FK_categoria) VALUES (2, 'Caña de Pesca', 'Practica tus habilidades con la pesca', 15, 1, 30, 'Puesto de articulos',1, 1);
INSERT INTO SERVICIO (SER_id, SER_nombre, SER_descripcion, SER_cantidadDis, SER_capacidad, SER_costo, SER_retiro, FK_estado, FK_categoria) VALUES (3, 'Pelota de Voleibol', 'Juega con tus amigos sobre la arena bajo el sol de la playa', 5, 4, 10, 'Puesto de articulos',1, 1);

INSERT INTO SERVICIO (SER_id, SER_nombre, SER_descripcion, SER_cantidadDis, SER_capacidad, SER_costo, SER_retiro, FK_estado, FK_categoria) VALUES (4, 'Moto de Agua', 'Disfruta un paseo por nuestra playa junto a un acompañante y vive la mejor experiencia', 10, 2, 75, 'Muelles',1, 2);
INSERT INTO SERVICIO (SER_id, SER_nombre, SER_descripcion, SER_cantidadDis, SER_capacidad, SER_costo, SER_retiro, FK_estado, FK_categoria) VALUES (5, 'Snorkel', 'Explora nuestras aguas cristalinas', 15, 1, 30, 'Puesto de equipos',1, 2);
INSERT INTO SERVICIO (SER_id, SER_nombre, SER_descripcion, SER_cantidadDis, SER_capacidad, SER_costo, SER_retiro, FK_estado, FK_categoria) VALUES (6, 'Kayak', 'Disfruta del un paseo que te generá mucha adrenalina', 10, 2, 75, 'Puesto de equipos',1,2);

INSERT INTO SERVICIO (SER_id, SER_nombre, SER_descripcion, SER_cantidadDis, SER_capacidad, SER_costo, SER_retiro, FK_estado, FK_categoria) VALUES (7, 'Paseo en Lancha', 'Diviértete en un atractivo paseo en lancha', 5, 4, 75, 'Muelles',1, 3);
INSERT INTO SERVICIO (SER_id, SER_nombre, SER_descripcion, SER_cantidadDis, SER_capacidad, SER_costo, SER_retiro, FK_estado, FK_categoria) VALUES (8, 'Paseo en Barco', 'Diviértete con tu familia y explora el mar', 2, 8, 150, 'Muelles',1, 3);


INSERT INTO SERVICIO (SER_id, SER_nombre, SER_descripcion, SER_cantidadDis, SER_capacidad, SER_costo, SER_retiro, FK_estado, FK_categoria) VALUES (9, 'Kit de arena para niños', 'El mejor Kit para el disfrute de los más pequeños', 25, 3, 20, 'Puesto de articulos',1, 4);
INSERT INTO SERVICIO (SER_id, SER_nombre, SER_descripcion, SER_cantidadDis, SER_capacidad, SER_costo, SER_retiro, FK_estado, FK_categoria) VALUES (10, 'Flotador infantil', 'Deja que los pequeños se bañen en el mar', 25, 1, 10, 'Puesto de articulos',1, 4);

/*-------------------------------------------------------------------INSERT HORARIO-------------------------------------------------------------------------------*/
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (1, Convert(VARCHAR(10),'07:00 am',108), Convert(VARCHAR(10),'11:00 am',108), 1);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (2, Convert(VARCHAR(10),'02:00 pm',108), Convert(VARCHAR(10),'04:00 am',108), 1);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (3, Convert(VARCHAR(10),'07:30 am',108), Convert(VARCHAR(10),'10:30 am',108), 2);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (4, Convert(VARCHAR(10),'01:00 pm',108), Convert(VARCHAR(10),'04:00 pm',108), 2);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (5, Convert(VARCHAR(10),'08:00 am',108), Convert(VARCHAR(10),'04:00 pm',108), 3);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (6, Convert(VARCHAR(10),'07:00 am',108), Convert(VARCHAR(10),'12:00 pm',108), 4);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (7, Convert(VARCHAR(10),'02:00 pm',108), Convert(VARCHAR(10),'04:30 pm',108), 4);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (8, Convert(VARCHAR(10),'08:30 am',108), Convert(VARCHAR(10),'01:00 pm',108), 5);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (9, Convert(VARCHAR(10),'07:00 am',108), Convert(VARCHAR(10),'11:30 am',108), 6);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (10, Convert(VARCHAR(10),'02:30 pm',108), Convert(VARCHAR(10),'05:00 pm',108), 6);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (11, Convert(VARCHAR(10),'08:30 am',108), Convert(VARCHAR(10),'12:30 pm',108), 7);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (12, Convert(VARCHAR(10),'07:30 am',108), Convert(VARCHAR(10),'10:30 am',108), 8);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (13, Convert(VARCHAR(10),'07:00 am',108), Convert(VARCHAR(10),'04:00 pm',108), 9);
INSERT INTO HORARIO (HOR_id, HOR_inicio, HOR_fin, FK_servicio) VALUES (14, Convert(VARCHAR(10),'07:00 am',108), Convert(VARCHAR(10),'04:00 pm',108), 10);
go
/*------------------------------------------------------------------------ACTUALIZAR SERVICIO------------------------------------------------------------------*/

CREATE PROCEDURE Procedure_actualizarServicio
	@_nombreOriginal varchar(100),
	@_nombre varchar(50),
	@_descripcion varchar(100),
	@_cantidad float,
	@_capacidad int,
	@_estado int,
	@_costo float,
	@_lugarRetiro varchar(100),
	@_categoria varchar(100)
AS
begin	
	DECLARE @idCategoria int = 0
	DECLARE @ErrorVar INT;
	DECLARE @RowCountVar INT;


	SELECT @idCategoria = COUNT(*) FROM CATEGORIA WHERE CAT_nombre = @_categoria;
	
	IF(@idCategoria = 0)
	BEGIN
		INSERT CATEGORIA(CAT_id,CAT_nombre) VALUES (NEXT VALUE FOR secuenciaIdCategoria, @_categoria);
		SELECT @idCategoria = CAT_id FROM CATEGORIA WHERE CAT_nombre = @_categoria;
	END
	ELSE
		SELECT @idCategoria = CAT_id FROM CATEGORIA WHERE CAT_nombre = @_categoria;

	UPDATE SERVICIO SET SER_nombre = @_nombre, SER_descripcion = @_descripcion, SER_cantidadDis = @_cantidad, SER_capacidad = @_capacidad, FK_estado = @_estado, SER_costo = @_costo, FK_categoria = @idCategoria
	WHERE SER_id in (Select SER_id From Servicio SerTemp Where SerTemp.SER_nombre = @_nombreOriginal);
	
	SELECT @ErrorVar = @@ERROR
    ,@RowCountVar = @@ROWCOUNT;

	if @ErrorVar <> 0 OR @RowCountVar = 0
		Return 0;

	Return 1;
end;

go

/*-----------------------------------------------------------------------BUSCAR SERVICIO------------------------------------------------------------------------*/

CREATE PROCEDURE Procedure_buscarServicio
	@_busqueda [nvarchar] (100),
	@_estado INT
	
AS
	
	IF(@_estado = 0)
		BEGIN
			SELECT SER_nombre as NombreServicio, SER_descripcion as Descripcion, EST_nombre as Estado
			FROM SERVICIO, ESTADO
			WHERE  (( UPPER(SER_nombre) LIKE UPPER(@_busqueda) + '%') 
				OR ( UPPER(SER_nombre) LIKE '%' + UPPER(@_busqueda))
				OR ( UPPER(SER_nombre) LIKE '%' + UPPER(@_busqueda) + '%') 
				OR( UPPER(SER_descripcion) LIKE UPPER(@_busqueda) + '%') 
				OR ( UPPER(SER_descripcion) LIKE '%' + UPPER(@_busqueda))
				OR ( UPPER(SER_descripcion) LIKE '%' + UPPER(@_busqueda) + '%'))
				AND (EST_id = FK_estado);
		END
	ELSE
		BEGIN
			IF(@_estado = 1)
				BEGIN
					SET @_estado = 1;
				END
			ELSE
				BEGIN
					SET @_estado = 2;
				END	
		
			SELECT SER_nombre as NombreServicio, SER_descripcion as Descripcion
			FROM SERVICIO
			WHERE ( ( UPPER(SER_nombre) LIKE UPPER(@_busqueda) + '%') 
				OR ( UPPER(SER_nombre) LIKE '%' + UPPER(@_busqueda))
				OR ( UPPER(SER_nombre) LIKE '%' + UPPER(@_busqueda) + '%') 
				OR( UPPER(SER_descripcion) LIKE UPPER(@_busqueda) + '%') 
				OR ( UPPER(SER_descripcion) LIKE '%' + UPPER(@_busqueda))
				OR ( UPPER(SER_descripcion) LIKE '%' + UPPER(@_busqueda) + '%')) AND FK_estado = @_estado ;
		
		END;
go


/*------------------------------------------------------------CONSULTAR CATEGORIAS SERVICIOS--------------------------------------------------------------------*/

CREATE PROCEDURE Procedure_consultarCategoriasServicios
AS
	SELECT DISTINCT(CAT_nombre), CAT_id
	FROM CATEGORIA;
	go

/*-----------------------------------------------------------------CONSULTAR HORARIO ELIMINAR--------------------------------------------------------------------*/
/*
CREATE PROCEDURE Procedure_consultarHorarioEliminar
	@_horaIni DATETIME,
	@_horaFin DATETIME,
	@_nombreServicio [nvarchar](100)
AS
BEGIN
	DECLARE @tieneReserva int = 0

	SELECT @tieneReserva = COUNT(RS.FK_reserva) 
	FROM RESERVA_SERVICIO RS 
	WHERE RS.FK_horario in (Select H2.HOR_id FROM HORARIO H2 WHERE convert(char(5), H2.HOR_inicio, 108) =  convert(char(5), @_horaIni, 108) and convert(char(5), H2.HOR_fin, 108) = convert(char(5), @_horaFin, 108) and H2.FK_servicio in (Select SER_id From Servicio Where SER_nombre = @_nombreServicio));

	Return @tieneReserva;

END;
go
*/

/*------------------------------------------------------------------CONSULTAR HORARIO SERVICIO POR ID-------------------------------------------------------------------*/

CREATE PROCEDURE Procedure_consultarHorariosServicioId
	@_idServicio int
AS
	SELECT HOR_id, HOR_inicio, HOR_fin
	FROM HORARIO
	WHERE FK_servicio = @_idServicio;
	go

/*-------------------------------------------------------------CONSULTAR HORARIO SERVICIO POR NOMBRE-------------------------------------------------------------*/

CREATE PROCEDURE Procedure_consultarHorariosServicioNombre
	@_nombreServicio [nvarchar](100)
AS
	SELECT HOR_id, HOR_inicio, HOR_fin
	FROM HORARIO
	WHERE FK_servicio = (Select SER_id From Servicio Where SER_nombre = @_nombreServicio);
	go


/*-----------------------------------------------------------------CONSULTAR SERVICIOS--------------------------------------------------------------------------*/

CREATE PROCEDURE Procedure_consultarServicios
AS
    SELECT SER_nombre as NombreServicio, SER_descripcion as Descripcion, EST_nombre as Estado 
    FROM SERVICIO, ESTADO
    WHERE FK_estado = EST_id;
go


/*---------------------------------------------------------------------ELIMINAR HORARIO--------------------------------------------------------------------------*/

CREATE PROCEDURE Procedure_eliminarHorario
	@_horaIni DATETIME,
	@_horaFin DATETIME,
	@_nombreServicio [nvarchar](100)
AS
BEGIN
	
	DELETE FROM HORARIO 
	WHERE convert(char(5), HOR_inicio, 108) = convert(char(5), @_horaIni, 108) and convert(char(5), HOR_fin, 108) = convert(char(5), @_horaFin, 108) and FK_servicio in (Select SER_id From Servicio Where SER_nombre = @_nombreServicio);

END;
go

/*--------------------------------------------------------------------------ELIMINAR SERVICIO--------------------------------------------------------------------*/

CREATE PROCEDURE Procedure_eliminarServicio

	@_nombreServicio	[nvarchar](100)
AS
	UPDATE SERVICIO
	SET FK_estado = 2
	WHERE  SER_nombre = @_nombreServicio

	IF (@@ERROR = 0)
		return 1;
	ELSE
		return 0;
go


/*-----------------------------------------------------------------------LIMPIAR HORARIO-------------------------------------------------------------------------*/

CREATE PROCEDURE Procedure_limpiarHorario
	@_nombreServicio [nvarchar](100)
AS
begin

	DECLARE @_horario int
	DECLARE @_idServicio int

	SElECT @_idServicio = SER_id FROM SERVICIO WHERE (SER_nombre = @_nombreServicio);

	DELETE FROM HORARIO WHERE FK_servicio = @_idServicio;

	SElECT  SER_id FROM SERVICIO WHERE (SER_nombre = @_nombreServicio);
end;
go

/*--------------------------------------------------------------------OBTENER DATOS DEL SERVICIO-----------------------------------------------------------------*/

CREATE PROCEDURE Procedure_obtenerDatosServicio
	@_nombreServicio [nvarchar](100)
AS
	SELECT SER_id, SER_nombre, SER_descripcion, SER_cantidadDis, SER_capacidad, EST_nombre, SER_costo,
	SER_retiro, CAT_id, CAT_nombre
	FROM SERVICIO, CATEGORIA , ESTADO
	WHERE SER_nombre = UPPER(@_nombreServicio) AND FK_categoria = CAT_id AND EST_id = FK_estado;
go


/*-----------------------------------------------------------------------CUENTA EL SERVICIOS------------------------------------------------------------------------*/

CREATE PROCEDURE Procedure_verificiarServicio
	@nombreServicio varchar(100)
AS
	BEGIN
		SELECT COUNT(*) as cuenta FROM SERVICIO WHERE SER_nombre = @nombreServicio;
	END;

go
