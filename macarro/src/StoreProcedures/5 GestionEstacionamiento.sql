---------------DROPS DE INSERCIONES MODULO ESTACIONAMIENTO--------------------
use MACARRO
go
begin transaction;
go


------------------------------------------------------------------------------

---------------------------------22-12-14----------------------------------------------------------
 ---------------------------INSERTAR UN TICKET---------------------------------------------
 GO
CREATE PROCEDURE [dbo].Procedure_InsertarTicket
	   @_TIC_fechaEntrada     		datetime,
	   @_TIC_fechaSalida 		     datetime,
	   @_TIC_placa      			[nvarchar] (100),
	   @_FK_estacionamiento    		[int],
	   @_FK_estado					[int]

AS
     
 BEGIN
	   INSERT INTO TICKET(TIC_id,TIC_fechaEntrada,TIC_fechaSalida,TIC_placa,FK_estacionamiento,FK_estado)
	   VALUES( NEXT VALUE FOR TICKET_SEQ,@_TIC_fechaEntrada,@_TIC_fechaSalida, @_TIC_placa,@_FK_estacionamiento,@_FK_estado) 

 END
GO

--------------------------------------22-12-14-----------------------------------------------------
 ---------------------------INSERTAR UN TICKET SIN SALIDA----------------------------------

CREATE PROCEDURE [dbo].Procedure_InsertarTicketNuevo
	  
	   @_TIC_placa      		[nvarchar](100),
	   @_FK_estacionamiento    		[int],
	   @_FK_estado					[int]

AS
     
 BEGIN
	   INSERT INTO TICKET(TIC_id,TIC_fechaEntrada,TIC_placa,FK_estacionamiento,FK_estado)
	   VALUES( NEXT VALUE FOR TICKET_SEQ,GETDATE(), @_TIC_placa,@_FK_estacionamiento,@_FK_estado) 

 END
GO
-------------------------------------22-12-22------------------------------------------------------
-----------------------------CONSULTAR TICKETS ENTRE FECHAS  POR FECHA DE ENTRADAS--------------------------------
CREATE PROCEDURE [dbo].Procedure_consultarTicketPorFecha
		@_TIC_fechaEntrada     		datetime,
		@_TIC_fechaEntrada2 			datetime
AS 
	BEGIN
		SELECT TIC_id,TIC_fechaEntrada,TIC_fechaSalida,TIC_placa,FK_estacionamiento,E.EST_nombre
		FROM TICKET,ESTADO E
		WHERE TIC_fechaEntrada BETWEEN CAST( @_TIC_fechaEntrada AS DATE) AND CAST( @_TIC_fechaEntrada2  AS DATE) AND FK_estado=E.EST_id;
	END
GO

---------------------------------------------22-12-14----------------------------------------------
--------------------------------CONSULTAR TODO TICKET--------------------------------------
CREATE PROCEDURE [dbo].Procedure_consultarTodoTicket
AS 
	BEGIN
		SELECT TIC_id,TIC_fechaEntrada,TIC_fechaSalida,TIC_placa,FK_estacionamiento, E.EST_nombre
		FROM TICKET, ESTADO E WHERE FK_estado=E.EST_id;
	END
GO

---------------------------------------22-12-14----------------------------------------------------
-------------------------------CONSULTAR TICKET POR PLACA----------------------------------
CREATE PROCEDURE [dbo].Procedure_consultarTicketPorPlaca
	@_TIC_placa [nvarchar](100)
AS 
	BEGIN
		SELECT TIC_id,TIC_fechaEntrada,TIC_fechaSalida,TIC_placa,FK_estacionamiento,E.EST_nombre
		FROM TICKET, ESTADO E
		WHERE TIC_placa like concat(@_TIC_placa,'%') AND FK_estado=E.EST_id;
	END
GO
----------------------------------------------------------------------------------------------------
--------------------------------------6-1-15--------------------------------------------------------------
CREATE PROCEDURE [dbo].Procedure_VerificarTicketPorPlaca
	@_TIC_placa [nvarchar](100)
AS 
	BEGIN
		SELECT TIC_id,TIC_fechaEntrada,TIC_placa,FK_estacionamiento,E.EST_nombre
		FROM TICKET, ESTADO E
		WHERE TIC_placa like concat(@_TIC_placa,'%') AND FK_estado=E.EST_id AND TIC_fechaSalida IS NULL ;
	END
GO
-------------------------------------------30-12-14------------------------------------------------
-------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].Procedure_modificarTicket
	@_TIC_id        [int],
	@_FK_estado     [int]
	
AS
	UPDATE TICKET
	SET 
		TIC_fechaSalida = GETDATE(),
		FK_estado= @_FK_estado
	WHERE
		TIC_id     		= @_TIC_id AND TIC_fechaSalida IS NULL;

GO
--------------------------------------8-1-15-----------------------------------------------------------
-------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].Procedure_modificarTicketPorPlaca
	@_TIC_placa [nvarchar](100),
	@_FK_estado     [int]
	
AS
	UPDATE TICKET
	SET 
		TIC_fechaSalida = GETDATE(),
		FK_estado= @_FK_estado
	WHERE
	TIC_placa like concat(UPPER(@_TIC_placa),'%') AND TIC_fechaSalida IS NULL;

GO
------------------------------------------22-12-14-------------------------------------------------
----------------------------MODIFICAR ESTACIONAMIENTO--------------------------------------
CREATE PROCEDURE [dbo].Procedure_modificarEstacionamiento
	   @_EST_id 					[int],
	   @_EST_nombre      			[nvarchar] (100),
	   @_EST_capacidad 				[int],
	   @_EST_tarifa      			[float],
	   @_EST_tarifaTicketPerdido    [float],
	   @FK_EST_estado      			int
	
AS
	UPDATE ESTACIONAMIENTO
	SET 
		EST_nombre  	= @_EST_nombre,
		EST_capacidad 	= @_EST_capacidad,
		EST_tarifa  	= @_EST_tarifa,
		EST_tarifaTicketPerdido  = @_EST_tarifaTicketPerdido,
		FK_estado  	= @FK_EST_estado
	WHERE
		EST_id     		= @_EST_id;

GO


-------------------------------------------------------------------------------------------


---------------------------------------11-1-15----------------------------------------------------
-----------------------------CONSULTAR ESTACIONAMIENTO-------------------------------------
CREATE PROCEDURE [dbo].Procedure_consultarEstacionamiento
	@_EST_id [int]
AS
	BEGIN
     SELECT E.EST_id,E.EST_nombre ,E.EST_capacidad,E.EST_tarifa,E.EST_tarifaTicketPerdido,E.FK_estado ,E.EST_capacidad-(SELECT COUNT (T.TIC_id) as disponible FROM ESTACIONAMIENTO E, TICKET T
	 WHERE T.TIC_fechaSalida IS NULL AND CONVERT (date,T.TIC_fechaEntrada) = CONVERT(date, GETDATE())AND T.FK_estacionamiento=E.EST_id) AS DISPONIBLE,E2.EST_nombre
     FROM ESTACIONAMIENTO E, ESTADO E2
	 WHERE @_EST_id=E.EST_id AND E2.EST_id=E.FK_estado
	 GROUP BY E.EST_id,E.EST_nombre ,E.EST_capacidad,E.EST_tarifa,E.EST_tarifaTicketPerdido,E.FK_estado,E2.EST_nombre
		

	END
GO

-------------------------------------------------------------------------------------------
----------------------------------------5-1-14----------------------------------------------
-----------------------------------------DISPONIBLE ESTACIONAMIENTO-----------------------------
CREATE PROCEDURE [dbo].Procedure_ConsultarPuestosDisponiblesEstacionamiento
AS
BEGIN
	SELECT E.EST_capacidad-COUNT (T.TIC_id) as Disponible 
	FROM ESTACIONAMIENTO E, TICKET T
    WHERE T.TIC_fechaSalida IS NULL AND CONVERT (date,T.TIC_fechaEntrada) = CONVERT(date, GETDATE())AND T.FK_estacionamiento=E.EST_id
	GROUP BY  E.EST_capacidad;
END

GO
--------------------------------------------------------------------------------------
-------------------------------------22-12-14------------------------------------------------------
-------------------------CONSULTAR ESTACIONAMIENTO POR ESTADO-----------------------------
CREATE PROCEDURE [dbo].Procedure_consultarEstacionamientoPorEstatus
	@FK_EST_estado int
AS
	BEGIN
		SELECT EST_id,EST_nombre,EST_capacidad,EST_tarifa,EST_tarifaTicketPerdido,FK_estado
		FROM ESTACIONAMIENTO
		WHERE FK_estado = @FK_EST_estado;

	END
GO

-------------------------------------------------------------------------------------------

--------------------------------------------------------------------------------
--------------------------UNICO ESTACIONAMIENTO----------22-12-14------------------------------------------------

INSERT INTO ESTACIONAMIENTO(EST_id,EST_nombre,EST_capacidad,EST_tarifa,EST_tarifaTicketPerdido,FK_estado)
	   VALUES( 1,'Estacionamiento Playa Sur',300, 3,300,1) 

			

	--------------------------------------------------------------------------------
	--------------------EXECUTE TICKET-----------------------------------------

GO
            EXEC Procedure_InsertarTicket
			@_TIC_fechaEntrada   =   '11-01-14 10:34:09 PM',
			@_TIC_fechaSalida   =   '12-01-14 01:33:09 PM',
			@_TIC_placa   =   'MAV91V',
			@_FK_estacionamiento   =   1,
			@_FK_estado 		= 20;
GO
			EXEC Procedure_InsertarTicket
			@_TIC_fechaEntrada   =   '11-01-14 10:34:09 PM',
			@_TIC_fechaSalida   =   '12-01-14 01:33:09 PM',
			@_TIC_placa   =   'KIO98B',
			@_FK_estacionamiento   =   1,
			@_FK_estado 		= 20;
GO
			EXEC Procedure_InsertarTicket
			@_TIC_fechaEntrada   =   '03-01-14 05:05:09 PM',
			@_TIC_fechaSalida   =   '03-01-14 10:34:09 PM',
			@_TIC_placa   =   'GBT67G',
			@_FK_estacionamiento   =   1,
			@_FK_estado 		= 20;
GO
			EXEC Procedure_InsertarTicket
			@_TIC_fechaEntrada   =   '04-01-14 04:10:09 PM',
			@_TIC_fechaSalida   =   '04-01-14 06:34:09 PM',
			@_TIC_placa   =   'YUH66R',
			@_FK_estacionamiento   =   1,
			@_FK_estado 		= 20;
GO
			EXEC Procedure_InsertarTicket
			@_TIC_fechaEntrada   =   '12-02-14 05:15:09 AM',
			@_TIC_fechaSalida   =   '12-02-14 06:34:09 PM',
			@_TIC_placa   =   'FRT55T',
			@_FK_estacionamiento   =   1,
			@_FK_estado 		= 21;
GO
commit transaction;
go
	