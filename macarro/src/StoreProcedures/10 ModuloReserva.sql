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


----------------PROCEDIMIENTO PARA CONSULTAR UNA RESERVA------------
CREATE PROCEDURE Procedure_consultarReservaUsuarioServicio
	
AS
	BEGIN
		select distinct(PER_docIdentidad) as Cedula,(PER_primerNombre +' ' +PER_primerApellido) as Nombre 
		from USUARIO U, PERSONA P, RESERVA R, RESERVA_SERVICIO RS,ESTADO E
		where U.FK_persona = P.PER_docIdentidad
		and R.FK_usuario = U.USU_correo
		and RS.FK_reserva = R.RES_id
		and R.FK_estado = E.EST_id
		and E.EST_pertenece = 'Reserva'
		and E.EST_nombre = 'En espera'
		and U.FK_estado = E.EST_id
		and E.EST_pertenece = 'General'
		and E.EST_nombre = 'Activado'
		group by 
		PER_primerNombre, PER_primerApellido, PER_docIdentidad

	END
GO


----------------PROCEDIMIENTO PARA CONCULTAR UNA RESERVA DADO UN ID DE PERSONA-------

CREATE PROCEDURE Procedure_consultarReservaUsuarioServicioEnEspera
@_perCedula [varchar] (100)
	
AS
	BEGIN
		select  RES_id as Reserva, RES_fecha as FechaReserva
		from USUARIO U, PERSONA P, RESERVA R, RESERVA_SERVICIO RS, ESTADO E
		where P.PER_docIdentidad = @_perCedula
		and P.PER_id = U.FK_persona
		and R.FK_usuario = U.USU_id
		and RS.FK_reserva = R.RES_id
		and R.FK_estado = E.EST_id
		and E.EST_pertenece = 'Reserva'
		and E.EST_nombre = 'En espera'
		and U.FK_estado = E.EST_id
		and E.EST_pertenece = 'General'
		and E.EST_nombre = 'Activado'

		GROUP BY RES_fecha, res_id
		

	END
GO



----------------PROCEDIMIENTO PARA CONSULTAR DETALLE DE RESERVA DE UNA PERSONA----------

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


--------------------PROCEDIMIENTO PARA CARGAR LOS DATOS EN EL EDITAR UNA RESERVA_SERVICIO--------------
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




----------------PROCEDIMIENTO PARA CONSULTAR UNA RESERVA DE SERVICIO------------
CREATE PROCEDURE Procedure_consultarReserva
	@_perDocIdentidad  [varchar] (100)
AS
	BEGIN
		SELECT RES_id as Reserva,SER_nombre as Servicio, RES_SER_cantidad as Cantidad, RES_fechA as Fecha, PER_docIdentidad as Cedula, convert(varchar(8),cast(RES_SER_horaInicio as time),100) as HoraInicio, convert(varchar(8),cast(RES_SER_horaFin as time),100) HoraFin
		FROM RESERVA R, RESERVA_SERVICIO RS, HORARIO H, SERVICIO S, PERSONA P, USUARIO U, ESTADO E
		WHERE PER_docIdentidad = 1
		AND PER_docIdentidad = FK_persona 
		AND U.USU_id = R.FK_usuario
		and RS.FK_reserva = R.RES_id
		and R.FK_estado = E.EST_id
		and E.EST_pertenece = 'Reserva'
		and E.EST_nombre = 'En espera'
		AND RES_id = FK_reserva 
		AND HOR_id = FK_horario  
		AND SER_id = FK_servicio

	END
GO





--------------PROCEDIMIENTO PARA ACTUALIZAR LA SECCION---------------
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



--------------AGREGAR RESERVA_SERVICIO-------------

/*CREATE PROCEDURE Procedure_insertarReservaServicio
	@_resHoraInicio [datetime],
	@_resHoraFin [datetime],
	@_resSerCantidad [int],
	@_fkReserva [int], 
	@_fkHorario [int]
	

AS
	BEGIN
		INSERT INTO RESERVA_SERVICIO(RES_SER_horaInicio,RES_SER_horaFin,RES_SER_cantidad,FK_horario,FK_reserva) 
		VALUES (NEXT VALUE FOR RESERVA_SERVICIO_SEQ,Convert(VARCHAR(8),@_resHoraInicio,108),Convert(VARCHAR(8),@_resHoraFin,108),@_resSerCantidad,@_fkReserva,@_fkHorario)	
	END

GO*/



------------INSERTAR UNA RESERVA------------------
CREATE PROCEDURE Procedure_insertarReserva
	@_resId [int],
	@_resFecha [date],
	@_fkUsuario [varchar] (100),
	@_fkEstado [int]

AS
 BEGIN


	INSERT INTO RESERVA
	VALUES(NEXT VALUE FOR RESERVA_SEQ,@_resFecha,@_fkUsuario,(SELECT E.EST_id
															  FROM ESTADO E
															  WHERE E.EST_nombre = @_fkEstado and E.EST_pertenece = 'Reserva'))
 END
GO






-------------------------PROCEDIMIENTO ME TRAE EL ID DEL SERVICIO DE UNA RESERVA-------------

CREATE PROCEDURE Procedure_traerIdDeServicio
	
	@_serNombre[varchar](100),
	@_resId [int]

AS
	BEGIN
		Select SER_id as Id 
		from SERVICIO S, RESERVA R, RESERVA_SERVICIO RS, HORARIO H
		WHERE R.RES_id= @_serNombre
		AND RS.FK_reserva = R.RES_id
		AND RS.FK_horario = H.HOR_id
		AND H.FK_servicio = S.SER_id
		AND S.SER_nombre= @_resId
		
	END
GO



----------------------------PROCEDIMIENTO PARA ACTUALIZAR ESTADO DE RESERVA DE EN ESPERA A OTRO----------

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

------TRAER NOMBRES DEL SERVICIO-------

CREATE PROCEDURE Procedure_consultarInformacionServicios

AS
	BEGIN

		select SER_id, SER_nombre 
		from SERVICIO;
	END
GO





---------------INSERTAR RESERVA PUESTO------------------

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




--------------------INSERTAR EN RESERVA_PUESTO---------------------------

/*CREATE PROCEDURE Procedure_insertarTablaReservaPuesto
@_resPueHoraIni  [varchar] (8),
@_resPueHoraFin  [varchar] (8),
@_fila [int] ,
@_columna [int]

AS
	BEGIN
		declare @_playa int;
		declare @_inventario int;
		declare @_resId int;

		set @_resId = (Select max(RES_id) from RESERVA);
		set @_playa = (select FK_playa from PUESTO where PUE_columna= @_columna and PUE_fila= @_fila);
		set @_inventario = (select FK_inventario from PUESTO where PUE_columna= @_columna and PUE_fila= @_fila);

			INSERT INTO RESERVA_PUESTO
			VALUES (NEXT VALUE FOR RESERVA_PUESTO_SEQ,Convert(VARCHAR(8),@_resPueHoraIni,108),Convert(VARCHAR(8),@_resPueHoraFin,108),@_resId, @_fila, @_columna, @_inventario, @_playa);	

	END
GO*/


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

---------------------------INSERTS TABLA RESERVA---------------------------------------------------------

INSERT INTO RESERVA  VALUES (1,'12/20/2014',1,10);
INSERT INTO RESERVA  VALUES (2,'6/12/2014',2,9);
INSERT INTO RESERVA  VALUES (3,'5/6/2014',3,11);
INSERT INTO RESERVA  VALUES (4,'12/22/2014',4,10);
INSERT INTO RESERVA  VALUES (5,'7/27/2014',5,9);
INSERT INTO RESERVA  VALUES (6,'10/25/2014',6,11);
INSERT INTO RESERVA  VALUES (7,'2/4/2014',4,10);
INSERT INTO RESERVA  VALUES (8,'3/15/2014',3,9);
INSERT INTO RESERVA  VALUES (9,'4/12/2014',2,9);
INSERT INTO RESERVA  VALUES (10,'2/4/2014',1,11);
INSERT INTO RESERVA  VALUES (11,'4/8/2014',2,10);
INSERT INTO RESERVA  VALUES (12,'8/10/2014',3,9);
INSERT INTO RESERVA  VALUES (13,'3/3/2014',4,9);
INSERT INTO RESERVA  VALUES (14,'9/16/2014',5,9);
INSERT INTO RESERVA  VALUES (15,'12/17/2014',6,10);
INSERT INTO RESERVA  VALUES (16,'9/23/2014',6,9);
INSERT INTO RESERVA  VALUES (17,'6/21/2014',5,10);
INSERT INTO RESERVA  VALUES (18,'5/25/2014',4,9);
INSERT INTO RESERVA  VALUES (19,'10/7/2014',3,9);
INSERT INTO RESERVA  VALUES (20,'2/19/2014',2,9);

---------------------------INSERTS TABLA RESERVA PUESTO--------------------------------------------------

INSERT INTO RESERVA_PUESTO  VALUES (1,'2014-12-20',1,1,1,1,1);
INSERT INTO RESERVA_PUESTO  VALUES (2,'2014-12-20',1,1,1,2,1);
INSERT INTO RESERVA_PUESTO  VALUES (3,'2014-12-20',1,1,1,61,1);
INSERT INTO RESERVA_PUESTO  VALUES (4,'2014-12-20',1,1,1,121,1);

INSERT INTO RESERVA_PUESTO  VALUES (5,'2014-12-6',2,1,2,3,1);
INSERT INTO RESERVA_PUESTO  VALUES (6,'2014-12-6',2,1,2,4,1);
INSERT INTO RESERVA_PUESTO  VALUES (7,'2014-12-6',2,1,2,62,1);
INSERT INTO RESERVA_PUESTO  VALUES (8,'2014-12-6',2,1,2,122,1);

INSERT INTO RESERVA_PUESTO  VALUES (9,'2014-6-5',3,1,3,5,1);
INSERT INTO RESERVA_PUESTO  VALUES (10,'2014-6-5',3,1,3,6,1);
INSERT INTO RESERVA_PUESTO  VALUES (11,'2014-6-5',3,1,3,63,1);
INSERT INTO RESERVA_PUESTO  VALUES (12,'2014-6-5',3,1,3,123,1);

INSERT INTO RESERVA_PUESTO  VALUES (13,'2014-12-22',4,1,4,7,1);
INSERT INTO RESERVA_PUESTO  VALUES (14,'2014-12-22',4,1,4,8,1);
INSERT INTO RESERVA_PUESTO  VALUES (15,'2014-12-22',4,1,4,64,1);
INSERT INTO RESERVA_PUESTO  VALUES (16,'2014-12-22',4,1,4,124,1);

INSERT INTO RESERVA_PUESTO  VALUES (17,'2014-7-27',5,1,5,9,1);
INSERT INTO RESERVA_PUESTO  VALUES (18,'2014-7-27',5,1,5,10,1);
INSERT INTO RESERVA_PUESTO  VALUES (19,'2014-7-27',5,1,5,65,1);
INSERT INTO RESERVA_PUESTO  VALUES (20,'2014-7-27',5,1,5,125,1);

INSERT INTO RESERVA_PUESTO  VALUES (21,'2014-10-25',6,1,6,11,1);
INSERT INTO RESERVA_PUESTO  VALUES (22,'2014-10-25',6,1,6,12,1);
INSERT INTO RESERVA_PUESTO  VALUES (23,'2014-10-25',6,1,6,66,1);
INSERT INTO RESERVA_PUESTO  VALUES (24,'2014-10-25',6,1,6,126,1);

INSERT INTO RESERVA_PUESTO  VALUES (25,'2014-4-2',7,1,7,13,1);
INSERT INTO RESERVA_PUESTO  VALUES (26,'2014-4-2',7,1,7,14,1);
INSERT INTO RESERVA_PUESTO  VALUES (27,'2014-4-2',7,1,7,67,1);
INSERT INTO RESERVA_PUESTO  VALUES (28,'2/4/2014',7,1,7,127,1);

INSERT INTO RESERVA_PUESTO  VALUES (29,'2014-3-15',8,1,8,15,1);
INSERT INTO RESERVA_PUESTO  VALUES (30,'2014-3-15',8,1,8,16,1);
INSERT INTO RESERVA_PUESTO  VALUES (31,'2014-3-15',8,1,8,68,1);
INSERT INTO RESERVA_PUESTO  VALUES (32,'2014-3-15',8,1,8,128,1);

INSERT INTO RESERVA_PUESTO  VALUES (33,'2014-12-4',9,1,9,17,1);
INSERT INTO RESERVA_PUESTO  VALUES (34,'2014-12-4',9,1,9,18,1);
INSERT INTO RESERVA_PUESTO  VALUES (35,'2014-12-4',9,1,9,69,1);
INSERT INTO RESERVA_PUESTO  VALUES (36,'2014-12-4',9,1,9,129,1);

INSERT INTO RESERVA_PUESTO  VALUES (37,'2014-4-2',10,1,10,19,1);
INSERT INTO RESERVA_PUESTO  VALUES (38,'2014-4-2',10,1,10,20,1);
INSERT INTO RESERVA_PUESTO  VALUES (39,'2014-4-2',10,1,10,70,1);
INSERT INTO RESERVA_PUESTO  VALUES (40,'2014-4-2',10,1,10,130,1);

---------------------------INSERTS TABLA RESERVA SERVICIO------------------------------------------------


INSERT INTO RESERVA_SERVICIO  VALUES (1, Convert(VARCHAR(10),'8:01 am',108), Convert(VARCHAR(10),'9:00 am',108),1,1,11);
INSERT INTO RESERVA_SERVICIO  VALUES (2, Convert(VARCHAR(10),'9:01 am',108), Convert(VARCHAR(10),'10:00 am',108),1,3,12);
INSERT INTO RESERVA_SERVICIO  VALUES (3, Convert(VARCHAR(10),'10:01 am',108), Convert(VARCHAR(10),'11:00 am',108),1,5,13);
INSERT INTO RESERVA_SERVICIO  VALUES (4, Convert(VARCHAR(10),'11:01 am',108), Convert(VARCHAR(10),'12:00 am',108),1,6,14);
INSERT INTO RESERVA_SERVICIO  VALUES (5, Convert(VARCHAR(10),'12:01 am',108), Convert(VARCHAR(10),'1:00 am',108),1,8,15);
INSERT INTO RESERVA_SERVICIO  VALUES (6, Convert(VARCHAR(10),'8:01 pm',108), Convert(VARCHAR(10),'9:00 am',108),1,9,16);
INSERT INTO RESERVA_SERVICIO  VALUES (7, Convert(VARCHAR(10),'9:01 pm',108), Convert(VARCHAR(10),'10:00 am',108),1,11,17);
INSERT INTO RESERVA_SERVICIO  VALUES (8, Convert(VARCHAR(10),'7:30 pm',108), Convert(VARCHAR(10),'10:00 am',108),1,12,18);
INSERT INTO RESERVA_SERVICIO  VALUES (9, Convert(VARCHAR(10),'3:01 pm',108), Convert(VARCHAR(10),'3:00 am',108),1,13,19);
INSERT INTO RESERVA_SERVICIO  VALUES (10, Convert(VARCHAR(10),'2:01 pm',108), Convert(VARCHAR(10),'4:00 am',108),1,10,20);

