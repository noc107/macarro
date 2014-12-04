use MACARRO
go
begin transaction;
go

CREATE SEQUENCE RESERVA_SEQ
    START WITH 1
    INCREMENT BY 1;
GO
-------------PROCEDIMIENTO PARA INSERTAR UNA RESERVA----------------
CREATE PROCEDURE Procedure_insertarReserva
	@_resId [int],
	@_resTotal [float], 
	@_resEstado [nvarchar] (100),
	@_resFecha [date],
	@_fkUsuario [nvarchar] (100)

AS
	BEGIN
		INSERT INTO RESERVA(RES_id,RES_total,RES_estado,RES_fecha,FK_usuario) 
		VALUES (@_resId,@_resTotal,@_resEstado,@_resFecha,@_fkUsuario)	
	END 
GO


----------------PROCEDIMIENTO PARA CONSULTAR UNA RESERVA------------
CREATE PROCEDURE Procedure_consultarReserva
	@_resId [int]
AS
	BEGIN
		SELECT RES_id,RES_total,RES_estado,RES_fecha
		FROM RESERVA
		WHERE RES_id = @_resId

	END
GO

--------------PROCEDIMIENTO PARA ACTUALIZAR LA SECCION---------------
CREATE PROCEDURE Procedure_modificarReserva
	@_resId [int],
	@_resTotal [float], 
	@_resEstado [nvarchar] (100),
	@_resFecha [date]
	
AS
	UPDATE RESERVA
	SET 
		RES_total  = @_resTotal,
		RES_estado = @_resEstado,
		RES_fecha  = @_resFecha
	WHERE
		RES_id     = @_resId;
GO




--------------AGREGAR RESERVA_SERVICIO-------------
CREATE PROCEDURE Procedure_insertarReservaServicio
	@_resSerCantidad [int],
	@_fkReserva [int], 
	@_fkHorario [int]
	

AS
	BEGIN
		INSERT INTO RESERVA_SERVICIO(RES_SER_cantidad,FK_horario,FK_reserva) 
		VALUES (@_resSerCantidad,@_fkReserva,@_fkHorario)	
	END 
GO


--------------AGREGAR RESERVA_PUESTO-------------
CREATE PROCEDURE Procedure_insertarReservaPuesto
	@_resPueHoraInicio [datetime],
	@_resPueHoraFin [datetime],
	@_fkReserva [int], 
	@_fkPuestoFila [int],
	@_fkPuestoColumna [int],
	@_fkInventario [int],
	@_fkPlaya [int]
	

AS
	BEGIN
		INSERT INTO RESERVA_PUESTO(RES_PUE_horaInicio, RES_PUE_horaFin, FK_reserva, FK_puestoFila, FK_puestoColumna, FK_inventario, FK_playa) 
		VALUES (@_resPueHoraInicio,@_resPueHoraFin,@_fkReserva, @_fkPuestoFila, @_fkPuestoColumna, @_fkInventario, @_fkPlaya)	
	END 
GO


-------------------------------PARA PROBAR PROCEDURE-----------
EXEC Procedure_insertarReserva 1,75,'En espera','12/20/2014','amandaRodriguez@gmail.com';
EXEC Procedure_insertarReserva 2,75,'En espera','12/15/2014','amandaRodriguez@gmail.com'; 
EXEC Procedure_insertarReserva 3,20,'En espera','12/29/2014','amandaRodriguez@gmail.com'; 
EXEC Procedure_insertarReserva 4,150,'En espera','12/13/2014','amandaRodriguez@gmail.com'; 
EXEC Procedure_insertarReserva 5,20,'En espera','01/03/2015','amandaRodriguez@gmail.com'; 
EXEC Procedure_insertarReserva 6,10,'En espera','01/15/2015','alejandroVieira@gmail.com'; 
EXEC Procedure_insertarReserva 7,75,'En espera','01/23/2015','alejandroVieira@gmail.com'; 
EXEC Procedure_insertarReserva 8,30,'En espera','02/09/2015','alejandroVieira@gmail.com';
EXEC Procedure_insertarReserva 9,30,'En espera','02/06/2015','alejandroVieira@gmail.com'; 
EXEC Procedure_insertarReserva 10,10,'En espera','02/11/2015','alejandroVieira@gmail.com';
EXEC Procedure_insertarReserva 11,10,'En espera','03/01/2015','vanessaMartinez@gmail.com';
EXEC Procedure_insertarReserva 12,150,'En espera','03/02/2015','vanessaMartinez@gmail.com'; 
EXEC Procedure_insertarReserva 13,20,'En espera','03/09/2015','vanessaMartinez@gmail.com';
EXEC Procedure_insertarReserva 14,10,'En espera','03/16/2015','vanessaMartinez@gmail.com';
EXEC Procedure_insertarReserva 15,75,'En espera','04/18/2015','vanessaMartinez@gmail.com'; 
EXEC Procedure_insertarReserva 16,20,'En espera','04/19/2015','pabloWestphal@gmail.com';
EXEC Procedure_insertarReserva 17,75,'En espera','04/24/2015','pabloWestphal@gmail.com';
EXEC Procedure_insertarReserva 18,150,'En espera','04/16/2015','pabloWestphal@gmail.com';
EXEC Procedure_insertarReserva 19,170,'En espera','04/12/2015','pabloWestphal@gmail.com';
EXEC Procedure_insertarReserva 20,30,'En espera','05/11/2015','pabloWestphal@gmail.com';
EXEC Procedure_insertarReserva 21,75,'En espera','05/06/2015','andreaPaola@gmail.com';
EXEC Procedure_insertarReserva 22,10,'En espera','05/03/2015','andreaPaola@gmail.com';
EXEC Procedure_insertarReserva 23,10,'En espera','05/30/2015','andreaPaola@gmail.com';
EXEC Procedure_insertarReserva 24,150,'En espera','01/15/2015','andreaPaola@gmail.com';
EXEC Procedure_insertarReserva 25,10,'En espera','01/13/2015','andreaPaola@gmail.com';
EXEC Procedure_insertarReserva 26,112.25,'En espera','12/20/2014','amandaRodriguez@gmail.com';
EXEC Procedure_insertarReserva 27,112.25,'En espera','01/15/2015','alejandroVieira@gmail.com';
EXEC Procedure_insertarReserva 28,224.50,'En espera','03/01/2015','vanessaMartinez@gmail.com'; 
EXEC Procedure_insertarReserva 29,112.25,'En espera','04/19/2015','pabloWestphal@gmail.com';
EXEC Procedure_insertarReserva 30,112.25,'En espera','05/06/2015','andreaPaola@gmail.com';

EXEC Procedure_insertarReservaServicio 1,1,1;
EXEC Procedure_insertarReservaServicio 1,3,1;
EXEC Procedure_insertarReservaServicio 1,6,2;
EXEC Procedure_insertarReservaServicio 1,13,3;
EXEC Procedure_insertarReservaServicio 1,12,4;
EXEC Procedure_insertarReservaServicio 1,13,5;
EXEC Procedure_insertarReservaServicio 1,14,6;
EXEC Procedure_insertarReservaServicio 1,11,7;
EXEC Procedure_insertarReservaServicio 1,8,8;
EXEC Procedure_insertarReservaServicio 1,13,9;
EXEC Procedure_insertarReservaServicio 1,14,9;
EXEC Procedure_insertarReservaServicio 1,5,10;
EXEC Procedure_insertarReservaServicio 1,14,11;
EXEC Procedure_insertarReservaServicio 1,12,12;
EXEC Procedure_insertarReservaServicio 1,13,13;
EXEC Procedure_insertarReservaServicio 1,14,14;
EXEC Procedure_insertarReservaServicio 1,2,15;
EXEC Procedure_insertarReservaServicio 1,4,15;
EXEC Procedure_insertarReservaServicio 1,13,16;
EXEC Procedure_insertarReservaServicio 1,11,17;
EXEC Procedure_insertarReservaServicio 1,12,18;
EXEC Procedure_insertarReservaServicio 1,12,19;
EXEC Procedure_insertarReservaServicio 1,13,19;
EXEC Procedure_insertarReservaServicio 1,8,20;
EXEC Procedure_insertarReservaServicio 1,11,21;
EXEC Procedure_insertarReservaServicio 1,5,22;
EXEC Procedure_insertarReservaServicio 1,14,23;
EXEC Procedure_insertarReservaServicio 1,12,24;
EXEC Procedure_insertarReservaServicio 1,5,25;

EXEC Procedure_insertarReservaPuesto '08:00 am','05:00 pm',26,1,1,1,1;
EXEC Procedure_insertarReservaPuesto '08:00 am','05:00 pm',27,1,2,2,1;
EXEC Procedure_insertarReservaPuesto '08:00 am','05:00 pm',28,1,3,3,1;
EXEC Procedure_insertarReservaPuesto '08:00 am','05:00 pm',28,1,4,4,1;
EXEC Procedure_insertarReservaPuesto '08:00 am','05:00 pm',29,1,5,5,1;
EXEC Procedure_insertarReservaPuesto '08:00 am','05:00 pm',30,1,1,1,1;

commit transaction;
go