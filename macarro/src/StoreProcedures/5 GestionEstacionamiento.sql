---------------DROPS DE INSERCIONES MODULO ESTACIONAMIENTO--------------------
use MACARRO
go
begin transaction;
go

------------------------SECUENCIA TICKET------------------------------------

CREATE SEQUENCE TICKET_SEQ
    START WITH 1
    INCREMENT BY 1;
GO

------------------------------------------------------------------------------

---------------------------------22-12-14----------------------------------------------------------
 ---------------------------INSERTAR UN TICKET---------------------------------------------
 GO
CREATE PROCEDURE [dbo].Procedure_InsertarTicket
	   @_TIC_fechaEntrada     		datetime,
	   @_TIC_fechaSalida 		     datetime,
	   @_TIC_placa      			[nvarchar] (100),
	   @_FK_estacionamiento    		[int]

AS
     
 BEGIN
	   INSERT INTO TICKET(TIC_id,TIC_fechaEntrada,TIC_fechaSalida,TIC_placa,FK_estacionamiento)
	   VALUES( NEXT VALUE FOR TICKET_SEQ,@_TIC_fechaEntrada,@_TIC_fechaSalida, @_TIC_placa,@_FK_estacionamiento) 

 END
GO

--------------------------------------22-12-14-----------------------------------------------------
 ---------------------------INSERTAR UN TICKET SIN SALIDA----------------------------------

CREATE PROCEDURE [dbo].Procedure_InsertarTicketNuevo
	  
	   @_TIC_placa      		[nvarchar](100),
	   @_FK_estacionamiento    		[int]

AS
     
 BEGIN
	   INSERT INTO TICKET(TIC_id,TIC_fechaEntrada,TIC_placa,FK_estacionamiento)
	   VALUES( NEXT VALUE FOR TICKET_SEQ,GETDATE(), @_TIC_placa,@_FK_estacionamiento) 

 END
GO


-------------------------------------22-12-22------------------------------------------------------
-----------------------------CONSULTAR TICKETS ENTRE FECHAS  POR FECHA DE ENTRADAS--------------------------------
CREATE PROCEDURE [dbo].Procedure_consultarTicketPorFecha
		@_TIC_fechaEntrada     		datetime,
		@_TIC_fechaEntrada2 			datetime
AS 
	BEGIN
		SELECT TIC_id,TIC_fechaEntrada,TIC_fechaSalida,TIC_placa,FK_estacionamiento
		FROM TICKET
		WHERE TIC_fechaEntrada BETWEEN CAST( @_TIC_fechaEntrada AS DATE) AND CAST( @_TIC_fechaEntrada2  AS DATE);
	END
GO

---------------------------------------------22-12-14----------------------------------------------
--------------------------------CONSULTAR TODO TICKET--------------------------------------
CREATE PROCEDURE [dbo].Procedure_consultarTodoTicket
AS 
	BEGIN
		SELECT TIC_id,TIC_fechaEntrada,TIC_fechaSalida,TIC_placa,FK_estacionamiento
		FROM TICKET;
	END
GO
---------------------------------------22-12-14----------------------------------------------------
-------------------------------CONSULTAR TICKET POR PLACA----------------------------------
CREATE PROCEDURE [dbo].Procedure_consultarTicketPorPlaca
	@_TIC_placa [nvarchar](100)
AS 
	BEGIN
		SELECT TIC_id,TIC_fechaEntrada,TIC_fechaSalida,TIC_placa,FK_estacionamiento
		FROM TICKET
		WHERE TIC_placa like concat(@_TIC_placa,'%');
	END
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


---------------------------------------22-12-14----------------------------------------------------
-----------------------------CONSULTAR ESTACIONAMIENTO-------------------------------------
CREATE PROCEDURE [dbo].Procedure_consultarEstacionamiento
	@_EST_id [int]
AS
	BEGIN
		SELECT EST_id,EST_nombre,EST_capacidad,EST_tarifa,EST_tarifaTicketPerdido,FK_estado
		FROM ESTACIONAMIENTO
		WHERE EST_id = @_EST_id AND FK_estado=1;

	END
GO
-------------------------------------------------------------------------------------------


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
			@_FK_estacionamiento   =   1;
GO
			EXEC Procedure_InsertarTicket
			@_TIC_fechaEntrada   =   '11-01-14 10:34:09 PM',
			@_TIC_fechaSalida   =   '12-01-14 01:33:09 PM',
			@_TIC_placa   =   'KIO98B',
			@_FK_estacionamiento   =   1;
GO
			EXEC Procedure_InsertarTicket
			@_TIC_fechaEntrada   =   '03-01-14 05:05:09 PM',
			@_TIC_fechaSalida   =   '03-01-14 10:34:09 PM',
			@_TIC_placa   =   'GBT67G',
			@_FK_estacionamiento   =   1;
GO
			EXEC Procedure_InsertarTicket
			@_TIC_fechaEntrada   =   '04-01-14 04:10:09 PM',
			@_TIC_fechaSalida   =   '04-01-14 06:34:09 PM',
			@_TIC_placa   =   'YUH66R',
			@_FK_estacionamiento   =   1;
GO
			EXEC Procedure_InsertarTicket
			@_TIC_fechaEntrada   =   '12-02-14 05:15:09 AM',
			@_TIC_fechaSalida   =   '12-02-14 06:34:09 PM',
			@_TIC_placa   =   'FRT55T',
			@_FK_estacionamiento   =   1;
GO
       
commit transaction;
go