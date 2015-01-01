use MACARRO
go
begin transaction;
go

CREATE SEQUENCE RESERVA_SEQ
AS
    INT
    START WITH 50
    INCREMENT BY 1;
GO

CREATE SEQUENCE RESERVA_SERVICIO_SEQ
AS 
	int
	START WITH 50
	INCREMENT BY 1;
GO

CREATE SEQUENCE RESERVA_PUESTO_SEQ
AS 
	int
	START WITH 50
	INCREMENT BY 1;
GO


----------------PROCEDIMIENTO PARA CONSULTAR UNA RESERVA------------FIXED
CREATE PROCEDURE Procedure_consultarReservaUsuarioServicio
	
AS
	BEGIN
		select distinct(PER_id) as Cedula,(PER_primerNombre +' ' +PER_primerApellido) as Nombre 
		from USUARIO U, PERSONA P, RESERVA R, RESERVA_SERVICIO RS,ESTADO E
		where U.FK_persona = P.PER_id
		and R.FK_usuario = U.USU_id
		and RS.FK_reserva = R.RES_id
		and R.FK_estado = E.EST_id
	        and E.EST_pertenece = 'Reserva'
		and E.EST_nombre = 'En espera'
		and U.USU_id IN (	SELECT USU_id
							FROM USUARIO U, ESTADO E
							WHERE U.FK_estado = E.EST_id
							  and E.EST_pertenece = 'General'
						      and E.EST_nombre = 'Activado')	
		group by 
		PER_primerNombre, PER_primerApellido, PER_id

	END
GO


----------------PROCEDIMIENTO PARA CONCULTAR UNA RESERVA DADO UN ID DE PERSONA-------FIXED
---- FALTA TRERSE EL TOTAL DE LA RESERVA

CREATE PROCEDURE Procedure_consultarReservaUsuarioServicioEnEspera
@_perCedula [int]
	
AS
	BEGIN
		select  RES_id as Reserva, RES_fecha as FechaReserva
		from USUARIO U, PERSONA P, RESERVA R, RESERVA_SERVICIO RS, ESTADO E
		where P.PER_id= @_perCedula
		and P.PER_id = U.FK_persona
		and R.FK_usuario = U.USU_id
		and RS.FK_reserva = R.RES_id
		and R.FK_estado = E.EST_id
		and E.EST_pertenece = 'Reserva'
		and E.EST_nombre = 'En espera'
		and U.USU_id IN (	SELECT USU_id
							FROM USUARIO U, ESTADO E
							WHERE U.FK_estado = E.EST_id
							  and E.EST_pertenece = 'General'
						      and E.EST_nombre = 'Activado')	

		GROUP BY RES_fecha, RES_id
		

	END
GO


----------------PROCEDIMIENTO PARA CONSULTAR DETALLE DE RESERVA DE UNA PERSONA----------FIXED
--------NO SE TOCO

CREATE PROCEDURE Procedure_consultarDetalleReserva
@_resId [int] 
	
AS
	BEGIN
		select  SER_nombre as NombreServicio, RES_SER_cantidad as CantidadSolicitada, (RES_SER_cantidad*SER_costo*(cast(cast (DATEPART (hour,RES_SER_horaFin) as char(2)) as int)- cast(cast (DATEPART (hour,RES_SER_horaInicio) as char(2))as int) )) as Costo, RES_fecha as FechaReserva, convert(varchar(8),cast(RES_SER_horaInicio as time),100) as HoraInicio, convert(varchar(8),cast(RES_SER_horaFin as time),100) as HoraFin
		from RESERVA, RESERVA_SERVICIO, SERVICIO, HORARIO 
		where RES_id = @_resId
		and RES_id = FK_reserva 
		and FK_horario = HOR_id
		and FK_servicio = SER_id;
		

	END
GO


--------------------PROCEDIMIENTO PARA CARGAR LOS DATOS EN EL EDITAR UNA RESERVA_SERVICIO--------------FIXED
----- NO SE TOCO
CREATE PROCEDURE Procedure_cargarDetalleReservaServicio
@_resId [int],
@_serId [int]
 
	
AS
	BEGIN
		select  SER_nombre as NombreServicio, RES_SER_cantidad as CantidadSolicitada, (RES_SER_cantidad*SER_costo*(cast(cast (DATEPART (hour,RES_SER_horaFin) as char(2)) as int)- cast(cast (DATEPART (hour,RES_SER_horaInicio) as char(2))as int) )) as Costo, RES_fecha as FechaReserva, convert(varchar(8),cast(RES_SER_horaInicio as time),100) as HoraInicio, convert(varchar(8),cast(RES_SER_horaFin as time),100) as HoraFin
		from RESERVA, RESERVA_SERVICIO, SERVICIO
		where RES_id = @_resId
		and RES_id = FK_reserva 
		and SER_id = @_serId
		

	END
GO




----------------PROCEDIMIENTO PARA CONSULTAR UNA RESERVA DE SERVICIO------------FIXED
------- HAY QUE CALCULAR EL TOTAL DE LA RESERVA
CREATE PROCEDURE Procedure_consultarReserva
	@_perDocIdentidad  [int]
AS
	BEGIN
		SELECT RES_id as Reserva,SER_nombre as Servicio, RES_SER_cantidad as Cantidad, RES_fechA as Fecha, PER_docIdentidad as Cedula, convert(varchar(8),cast(RES_SER_horaInicio as time),100) as HoraInicio, convert(varchar(8),cast(RES_SER_horaFin as time),100) HoraFin
		FROM RESERVA R, RESERVA_SERVICIO RS, HORARIO H, SERVICIO S, PERSONA P, USUARIO U, ESTADO E
		WHERE PER_id = @_perDocIdentidad
		AND PER_id= FK_persona 
		AND U.USU_id = R.FK_usuario
		and RS.FK_reserva = R.RES_id
		and R.FK_estado = E.EST_id
		and E.EST_pertenece = 'Reserva'
		and E.EST_nombre = 'En espera'
		and U.USU_id IN (	SELECT USU_id
							FROM USUARIO U, ESTADO E
							WHERE U.FK_estado = E.EST_id
							  and E.EST_pertenece = 'General'
						      and E.EST_nombre = 'Activado')	

		AND RES_id = FK_reserva 
		AND HOR_id = FK_horario  
		AND SER_id = FK_servicio

	END
GO




--------------PROCEDIMIENTO PARA ACTUALIZAR LA SECCION---------------FIXED
--------- SE QUITA ResTotal 
CREATE PROCEDURE Procedure_modificarReserva
	@_resId [int],
	@_resEstado [varchar] (100),
	@_resFecha [date]
	
AS
	UPDATE RESERVA
	SET 
		RES_fecha  = @_resFecha,
		FK_estado = (SELECT E.EST_id
					 FROM ESTADO E
	                 WHERE E.EST_nombre = @_resEstado and E.EST_pertenece = 'Reserva')
	WHERE
		RES_id     = @_resId;


GO



--------------AGREGAR RESERVA_SERVICIO-------------FIXED
------SE AÑADIO ID DE RESERVA SERVCIO CON SECUENCIA

CREATE PROCEDURE Procedure_insertarReservaServicio
	@_resHoraInicio [datetime],
	@_resHoraFin [datetime],
	@_resSerCantidad [int],
	@_fkReserva [int], 
	@_fkHorario [int]
	

AS
	BEGIN
		INSERT INTO RESERVA_SERVICIO
		VALUES (NEXT VALUE FOR RESERVA_SERVICIO_SEQ,Convert(VARCHAR(8),@_resHoraInicio,108),Convert(VARCHAR(8),@_resHoraFin,108),@_resSerCantidad,@_fkHorario,@_fkReserva)	
	END
GO


------------INSERTAR UNA RESERVA------------------FIXED
CREATE PROCEDURE Procedure_insertarReserva
	@_resId [int],
	@_resFecha [date],
	@_fkUsuario [int],
	@_fkEstado [varchar] (100)

AS
 BEGIN


	INSERT INTO RESERVA
	VALUES(NEXT VALUE FOR RESERVA_SEQ,@_resFecha,@_fkUsuario,(SELECT E.EST_id
															  FROM ESTADO E
															  WHERE E.EST_nombre = @_fkEstado and E.EST_pertenece = 'Reserva'))
 END
 GO





-------------------------PROCEDIMIENTO ME TRAE EL ID DEL SERVICIO DE UNA RESERVA-------------FIXED
------- NO SE TOCO
CREATE PROCEDURE Procedure_traerIdDeServicio
	
	@_serNombre[varchar](100),
	@_resId [int]

AS
	BEGIN
		Select SER_id as Id 
		from SERVICIO S, RESERVA R,RESERVA_SERVICIO RS, HORARIO H
		WHERE R.RES_id= @_resId
		AND RS.FK_reserva = R.RES_id
		AND RS.FK_horario = H.HOR_id
		AND H.FK_servicio = S.SER_id
		AND S.SER_nombre= @_serNombre
		
	END
	GO


----------------------------PROCEDIMIENTO PARA ACTUALIZAR ESTADO DE RESERVA DE EN ESPERA A OTRO----------FIXED

CREATE PROCEDURE Procedure_cambiarStatusReservaServicio

	@_resId  [int],
	@_estadoReserva [varchar] (15)
AS
	BEGIN

		IF @_estadoReserva= 'Confirmado'
		BEGIN 
			UPDATE RESERVA
			SET FK_estado = (SELECT E.EST_id
							 FROM ESTADO E
							 WHERE E.EST_nombre = @_estadoReserva and E.EST_pertenece = 'Reserva')
			WHERE RES_id= @_resId;
		END;
		
		
		IF @_estadoReserva= 'Cancelado'
		BEGIN

			DECLARE @_estado int;

			set @_estado = (SELECT count(FK_reserva) from RESERVA_SERVICIO where FK_reserva= @_resId);
			IF @_estado != 0
			begin

			DELETE FROM RESERVA_SERVICIO WHERE FK_reserva= @_resId;
			DELETE FROM RESERVA WHERE RES_id = @_resId;

			END;



		END;

	END
GO


/*
-----------------------ACTUALIZAR PRECIO DE RESERVA--------------------
---- ESTE PROCEDURE NO VA EL TOTAL NO SE MODIFICA

CREATE PROCEDURE Procedure_cambiarMontoReservaPuesto

AS
	BEGIN
		
		declare @_resId int;
		declare @_montoTotal float;

		set @_resId = (select max(RES_id) from RESERVA);
		
		set @_montoTotal= (select sum(pue.PUE_precio) from PUESTO pue, RESERVA_PUESTO respue where respue.FK_reserva= @_resId AND respue.FK_puestoColumna= pue.PUE_columna AND respue.FK_puestoFila= pue.PUE_fila and respue.FK_playa= pue.FK_playa and respue.FK_inventario= pue.FK_inventario );


			UPDATE RESERVA
			SET RES_total = @_montoTotal
			WHERE RES_id= @_resId;


	END
GO


*/


------TRAER NOMBRES DEL SERVICIO-------FIXED
-----NO SE TOCO

CREATE PROCEDURE Procedure_consultarInformacionServicios

AS
	BEGIN

		select SER_id, SER_nombre 
		from SERVICIO;
	END
GO





---------------INSERTAR RESERVA PUESTO------------------FIXED

CREATE PROCEDURE Procedure_insertarReservaTipoPuesto


@_fechaReserva [varchar] (100),
@_usuId [nvarchar] (100)


AS

	BEGIN

		declare @_resId int;
		set @_resId = NEXT VALUE FOR RESERVA_SEQ

		INSERT INTO RESERVA(RES_id,RES_fecha,FK_usuario, FK_estado) 
		VALUES (@_resId,convert ( varchar(100),@_fechaReserva,110),@_usuId,(SELECT E.EST_id
																			FROM ESTADO E
															                WHERE E.EST_nombre = 'En espera' and E.EST_pertenece = 'Reserva'));
		
	END
GO




----------------BUSCAR PUESTOS OCUPADOS DE LA ULTIMA RESERVA-------------------
-------NO SE TOCO

CREATE PROCEDURE Procedure_buscarOcupados

AS
	BEGIN
		
		declare @_fechaReserva date;
		declare @_ultimoId int;
			set @_ultimoId= (select max(RES_id) from RESERVA);	

			set @_fechaReserva= (select RES_fecha from RESERVA where RES_id= @_ultimoId);
			
			select FK_puestoColumna as Columna, FK_puestoFila as Fila 
			from RESERVA, RESERVA_PUESTO 
			where RES_id= FK_reserva and RES_fecha= @_fechaReserva	

	END
GO




--------------------INSERTAR EN RESERVA_PUESTO---------------------------FIXED

CREATE PROCEDURE Procedure_insertarTablaReservaPuesto
@_resFecha  [datetime] ,
@_fila [int] ,
@_columna [int]


AS
	BEGIN
		declare @_playa int;
		declare @_inventario int;
		declare @_resId int;
		declare @_filaInventario int;

		set @_resId = (Select max(RES_id) from RESERVA);
		set @_playa = (select distinct(FK_playa) from PUESTO where PUE_columna= @_columna and PUE_fila= @_fila);
		
		SELECT 
		distinct(FK_inventario),
		ROW_NUMBER() over (ORDER BY FK_inventario) AS Number
		
		INTO #INVENTARIOS
		FROM PUESTO
		WHERE PUE_columna= @_columna and PUE_fila= @_fila


		DECLARE @MaxRownum INT
		SET @MaxRownum = (SELECT MAX(Number) FROM #INVENTARIOS)


		DECLARE @Iterator INT
		SET @Iterator = (SELECT MIN(Number) FROM #INVENTARIOS)


		WHILE @Iterator <= @MaxRownum
		BEGIN

			SET @_filaInventario = (SELECT FK_inventario
									FROM #INVENTARIOS
									WHERE Number = @Iterator);
    
       	    INSERT INTO RESERVA_PUESTO
			VALUES (NEXT VALUE FOR RESERVA_PUESTO_SEQ,@_resFecha,@_resId, @_fila, @_columna, @_filaInventario, @_playa);	

    
			SET @Iterator = @Iterator + 1
		END

        DROP TABLE #INVENTARIOS

	END
	GO

----------------TRAER PRECIO PUESTO----------------


CREATE PROCEDURE Procedure_traerPrecioPuesto
@_pueColumna [int],
@_pueFila[int]

AS
	BEGIN
	select PUE_precio as Precio from PUESTO where PUE_columna= @_pueColumna and PUE_fila= @_pueFila
	END
GO



--------------TRAER TAMANO PLAYA-----------------------


CREATE PROCEDURE Procedure_traerTamanoPlaya

AS
	BEGIN
	select PLA_columna as Columna, PLA_fila as Fila from PLAYA
	END
GO



-------------------------------------------NUEVOS STORED PROCEDURES ----------------------------------------------------------------


---------------CONSULTAR RESERVAS DE SERVICIO POR ID(CORREO) DE USUARIO ------------------

CREATE PROCEDURE ConsultarReservaPorCorreoUsuario
	@_correo [varchar] (100)

AS
BEGIN

SELECT R.RES_id as IDReserva, RS.RES_SER_horaInicio as Inicio,RS.RES_SER_horaFin Fin, S.SER_nombre Nombre, RS.RES_SER_cantidad Cantidad, S.SER_costo*RS.RES_SER_cantidad AS Total, E.EST_nombre AS Estado
FROM RESERVA_SERVICIO RS, RESERVA R, SERVICIO S, HORARIO H, USUARIO U,ESTADO E
WHERE U.USU_correo = @_correo AND
	  U.USU_id = R.FK_usuario AND
	  R.RES_id = RS.FK_reserva AND
	  RS.FK_horario = H.HOR_id AND
	  H.FK_servicio = S.SER_id AND 
	  R.FK_estado = E.EST_id AND
	  E.EST_pertenece = 'Reserva'
END
GO

---------------ELIMINAR RESERVA DE SERVICIO POR ID DE RESERVA ------------------


CREATE PROCEDURE EliminarReservaPorID
	@_reservaID [int]

AS
BEGIN

DELETE FROM RESERVA_SERVICIO
WHERE FK_reserva = @_reservaID

DELETE FROM RESERVA
WHERE RES_id = @_reservaID

END

GO
---------------CONSULTAR RESERVA DE SERVICIO POR ID DE RESERVA ------------------
CREATE PROCEDURE ConsultarReservaPorIDReserva
	@_reservaID [int]

AS
BEGIN

SELECT R.RES_id as IDReserva, R.RES_fecha as Fecha,S.SER_nombre Nombre, RS.RES_SER_cantidad Cantidad,RS.RES_SER_horaInicio Inicio, RS.RES_SER_horaFin as Fin, S.SER_costo*RS.RES_SER_cantidad AS Total 
FROM RESERVA_SERVICIO RS, RESERVA R, SERVICIO S, HORARIO H
WHERE R.RES_id = @_reservaID AND
	  RS.FK_reserva = R.RES_id AND
	  RS.FK_horario = H.HOR_id AND
	  H.FK_servicio = S.SER_id
END
GO
---------------MODIFICAR RESERVA DE SERVICIO ------------------
CREATE PROCEDURE ModificarReserva
	@_reservaID [int],
	@_nombreServicio [varchar] (100),
	@_cantidad [int], 
	@_horaInicio [varchar] (100),
	@_horaFin [varchar] (100)

AS
BEGIN

UPDATE RESERVA_SERVICIO 
SET RES_SER_cantidad = @_cantidad,
	RES_SER_horaInicio = @_horaInicio,
	RES_SER_horaFin = @_horaFin,
	FK_horario = (SELECT max(H.HOR_id)
				  FROM HORARIO H, SERVICIO S
				  WHERE S.SER_nombre = @_nombreServicio AND
						S.SER_id = H.FK_servicio)			  
WHERE FK_reserva = @_reservaID

END
GO
---------------CONSULTAR SERVICIOS ------------------
CREATE PROCEDURE ConsultarServicios
AS
BEGIN

SELECT DISTINCT(SER_NOMBRE) as Servicio
FROM SERVICIO

END

GO
---------------CONSULTAR Cantidad Disponible de un Servicio ------------------
CREATE PROCEDURE CantidadDisponibleServicio
	@_nombreServicio [varchar] (100),
	@_horaInicio [varchar] (100),
	@_horaFin [varchar] (100)


AS
BEGIN

DECLARE
@_cantidadServicio [int],
@_cantidadReservas [int],
@_cantidad [int]


SET  @_cantidadReservas= (SELECT SUM(RS.RES_SER_cantidad)
						  FROM RESERVA R, RESERVA_SERVICIO RS, SERVICIO S, HORARIO H
                          WHERE S.SER_nombre = @_nombreServicio AND
								S.SER_id = H.FK_servicio AND
								H.HOR_id = RS.FK_horario AND
							   ((CONVERT (DATETIME, @_horaInicio) BETWEEN CONVERT(DATETIME, RS.RES_SER_horaInicio) AND CONVERT(DATETIME, RS.RES_SER_horaFin)) OR
								(CONVERT (DATETIME, @_horaFin) BETWEEN CONVERT(DATETIME, RS.RES_SER_horaInicio) AND CONVERT(DATETIME, RS.RES_SER_horaFin))) AND
								RS.FK_reserva = R.RES_id AND
								R.FK_estado IN (SELECT E.EST_id
												FROM ESTADO E
												WHERE (E.EST_nombre = 'Confirmado' or E.EST_nombre = 'En espera')  and 
													   E.EST_pertenece = 'Reserva'))


SET  @_cantidadServicio= (SELECT S.SER_cantidadDis
						 FROM SERVICIO S
						 WHERE S.SER_nombre = @_nombreServicio)

IF (@_cantidadReservas IS NULL)
BEGIN

SET @_cantidadReservas = 0

END

IF (@_cantidadServicio IS NULL)
BEGIN

SET @_cantidadServicio = 0

END
SET @_cantidad = @_cantidadServicio - @_cantidadReservas

RETURN @_cantidad

END

GO
------------INSERTAR UNA RESERVA------------------
CREATE PROCEDURE InsertarReservaServicio
	@_correo [varchar] (100),
	@_Estado [varchar](100),
	@_nombreServicio[varchar] (100),
	@_resHoraInicio [datetime],
	@_resHoraFin [datetime],
	@_resSerCantidad [int]

AS
 BEGIN

 DECLARE
 @_resId [int]

 SET @_resId = NEXT VALUE FOR RESERVA_SEQ

	INSERT INTO RESERVA
	VALUES(@_resId,CONVERT (DATETIME, GETDATE()),(SELECT USU_id
							   FROM USUARIO
                               WHERE USU_correo = @_correo),
							   (SELECT E.EST_id
								FROM ESTADO E
								WHERE E.EST_nombre = @_Estado and E.EST_pertenece = 'Reserva'))

	INSERT INTO RESERVA_SERVICIO
	VALUES (NEXT VALUE FOR RESERVA_SERVICIO_SEQ,CONVERT (DATETIME, @_resHoraInicio),CONVERT (DATETIME,@_resHoraFin),@_resSerCantidad,
	(SELECT max(H.HOR_id)
	 FROM HORARIO H, SERVICIO S
	 WHERE S.SER_nombre = @_nombreServicio AND
		   S.SER_id = H.FK_servicio),@_resId)	
	

 END
GO


---------------------------INSERTS TABLA RESERVA---------------------------------------------------------

INSERT INTO RESERVA  VALUES (1,'12/20/2014',11111111,10);
INSERT INTO RESERVA  VALUES (2,'6/12/2014',11111112,9);
INSERT INTO RESERVA  VALUES (3,'5/6/2014',11111113,11);
INSERT INTO RESERVA  VALUES (4,'12/22/2014',11111114,10);
INSERT INTO RESERVA  VALUES (5,'7/27/2014',11111115,9);
INSERT INTO RESERVA  VALUES (6,'10/25/2014',11111116,11);
INSERT INTO RESERVA  VALUES (7,'2/4/2014',11111114,10);
INSERT INTO RESERVA  VALUES (8,'3/15/2014',11111113,9);
INSERT INTO RESERVA  VALUES (9,'4/12/2014',11111112,9);
INSERT INTO RESERVA  VALUES (10,'2/4/2014',11111111,11);
INSERT INTO RESERVA  VALUES (11,'4/8/2014',11111112,10);
INSERT INTO RESERVA  VALUES (12,'8/10/2014',11111113,9);
INSERT INTO RESERVA  VALUES (13,'3/3/2014',11111114,9);
INSERT INTO RESERVA  VALUES (14,'9/16/2014',11111115,9);
INSERT INTO RESERVA  VALUES (15,'12/17/2014',11111116,10);
INSERT INTO RESERVA  VALUES (16,'9/23/2014',11111116,9);
INSERT INTO RESERVA  VALUES (17,'6/21/2014',11111115,10);
INSERT INTO RESERVA  VALUES (18,'5/25/2014',11111114,9);
INSERT INTO RESERVA  VALUES (19,'10/7/2014',11111113,9);
INSERT INTO RESERVA  VALUES (20,'2/19/2014',11111112,9);

---------------------------INSERTS TABLA RESERVA PUESTO--------------------------------------------------

INSERT INTO RESERVA_PUESTO  VALUES (1,'12/20/2014',1,1,1,721,1);
INSERT INTO RESERVA_PUESTO  VALUES (2,'12/20/2014',1,1,1,722,1);
INSERT INTO RESERVA_PUESTO  VALUES (3,'12/20/2014',1,1,1,781,1);
INSERT INTO RESERVA_PUESTO  VALUES (4,'12/20/2014',1,1,1,841,1);

INSERT INTO RESERVA_PUESTO  VALUES (5,'6/12/2014',2,1,2,723,1);
INSERT INTO RESERVA_PUESTO  VALUES (6,'6/12/2014',2,1,2,724,1);
INSERT INTO RESERVA_PUESTO  VALUES (7,'6/12/2014',2,1,2,782,1);
INSERT INTO RESERVA_PUESTO  VALUES (8,'6/12/2014',2,1,2,842,1);

INSERT INTO RESERVA_PUESTO  VALUES (9,'5/6/2014',3,1,3,725,1);
INSERT INTO RESERVA_PUESTO  VALUES (10,'5/6/2014',3,1,3,726,1);
INSERT INTO RESERVA_PUESTO  VALUES (11,'5/6/2014',3,1,3,783,1);
INSERT INTO RESERVA_PUESTO  VALUES (12,'5/6/2014',3,1,3,843,1);

INSERT INTO RESERVA_PUESTO  VALUES (13,'12/22/2014',4,1,4,727,1);
INSERT INTO RESERVA_PUESTO  VALUES (14,'12/22/2014',4,1,4,728,1);
INSERT INTO RESERVA_PUESTO  VALUES (15,'12/22/2014',4,1,4,784,1);
INSERT INTO RESERVA_PUESTO  VALUES (16,'12/22/2014',4,1,4,844,1);

INSERT INTO RESERVA_PUESTO  VALUES (17,'7/27/2014',5,1,5,729,1);
INSERT INTO RESERVA_PUESTO  VALUES (18,'7/27/2014',5,1,5,730,1);
INSERT INTO RESERVA_PUESTO  VALUES (19,'7/27/2014',5,1,5,785,1);
INSERT INTO RESERVA_PUESTO  VALUES (20,'7/27/2014',5,1,5,845,1);

INSERT INTO RESERVA_PUESTO  VALUES (21,'10/25/2014',6,1,6,731,1);
INSERT INTO RESERVA_PUESTO  VALUES (22,'10/25/2014',6,1,6,732,1);
INSERT INTO RESERVA_PUESTO  VALUES (23,'10/25/2014',6,1,6,786,1);
INSERT INTO RESERVA_PUESTO  VALUES (24,'10/25/2014',6,1,6,846,1);

INSERT INTO RESERVA_PUESTO  VALUES (25,'2/4/2014',7,1,7,733,1);
INSERT INTO RESERVA_PUESTO  VALUES (26,'2/4/2014',7,1,7,734,1);
INSERT INTO RESERVA_PUESTO  VALUES (27,'2/4/2014',7,1,7,787,1);
INSERT INTO RESERVA_PUESTO  VALUES (28,'2/4/2014',7,1,7,847,1);

INSERT INTO RESERVA_PUESTO  VALUES (29,'3/15/2014',8,1,8,735,1);
INSERT INTO RESERVA_PUESTO  VALUES (30,'3/15/2014',8,1,8,736,1);
INSERT INTO RESERVA_PUESTO  VALUES (31,'3/15/2014',8,1,8,788,1);
INSERT INTO RESERVA_PUESTO  VALUES (32,'3/15/2014',8,1,8,848,1);

INSERT INTO RESERVA_PUESTO  VALUES (33,'4/12/2014',9,1,9,737,1);
INSERT INTO RESERVA_PUESTO  VALUES (34,'4/12/2014',9,1,9,738,1);
INSERT INTO RESERVA_PUESTO  VALUES (35,'4/12/2014',9,1,9,789,1);
INSERT INTO RESERVA_PUESTO  VALUES (36,'4/12/2014',9,1,9,849,1);

INSERT INTO RESERVA_PUESTO  VALUES (37,'2/4/2014',10,1,10,739,1);
INSERT INTO RESERVA_PUESTO  VALUES (38,'2/4/2014',10,1,10,740,1);
INSERT INTO RESERVA_PUESTO  VALUES (39,'2/4/2014',10,1,10,790,1);
INSERT INTO RESERVA_PUESTO  VALUES (40,'2/4/2014',10,1,10,850,1);

---------------------------INSERTS TABLA RESERVA SERVICIO------------------------------------------------

INSERT INTO RESERVA_SERVICIO  VALUES (1,'8:01 am','9:00 am',1,1,11);
INSERT INTO RESERVA_SERVICIO  VALUES (2,'9:01 am','10:00 am',1,3,12);
INSERT INTO RESERVA_SERVICIO  VALUES (3,'10:01 am','11:00 am',1,5,13);
INSERT INTO RESERVA_SERVICIO  VALUES (4,'11:01 am','12:00 am',1,6,14);
INSERT INTO RESERVA_SERVICIO  VALUES (5,'12:01 am','1:00 am',1,8,15);
INSERT INTO RESERVA_SERVICIO  VALUES (6,'8:01 pm','9:00 am',1,9,16);
INSERT INTO RESERVA_SERVICIO  VALUES (7,'9:01 pm','10:00 am',1,11,17);
INSERT INTO RESERVA_SERVICIO  VALUES (8,'7:30 pm','10:00 am',1,12,18);
INSERT INTO RESERVA_SERVICIO  VALUES (9,'3:01 pm','3:00 am',1,13,19);
INSERT INTO RESERVA_SERVICIO  VALUES (10,'2:01 pm','4:00 am',1,10,20);
