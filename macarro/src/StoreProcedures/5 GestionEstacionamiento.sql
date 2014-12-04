---------------DROPS DE INSERCIONES MODULO ESTACIONAMIENTO--------------------
use MACARRO
go
begin transaction;
go


------------------------------------------------------------------------
------------------INSERTAR UN ESTACIONAMIENTO---------------------------------
CREATE PROCEDURE Procedure_agregarEstacionamiento
	   @_EST_id          			[int],
	   @_EST_nombre      			[nvarchar] (100),
	   @_EST_capacidad 				[int],
	   @_EST_tarifa      			[float],
	   @_EST_tarifaTicketPerdido    [float],
	   @_EST_estado      			[nvarchar] (100)
AS

 BEGIN
	   INSERT INTO ESTACIONAMIENTO(EST_id,EST_nombre,EST_capacidad,EST_tarifa,EST_tarifaTicketPerdido,EST_estado)
	   VALUES( @_EST_id,@_EST_nombre,@_EST_capacidad, @_EST_tarifa,@_EST_tarifaTicketPerdido,@_EST_estado) 
 END

GO

-------------------------------------------------------------------------------------------
 ---------------------------INSERTAR UN TICKET---------------------------------------------

CREATE PROCEDURE [dbo].Procedure_InsertarTicket
	   @_TIC_id          			[int],
	   @_TIC_fechaEntrada     		[nvarchar](20),
	   @_TIC_fechaSalida 			[nvarchar](20),
	   @_TIC_placa      			[nvarchar] (100),
	   @_FK_estacionamiento    		[int]

AS
     
 BEGIN


	   INSERT INTO TICKET(TIC_id,TIC_fechaEntrada,TIC_fechaSalida,TIC_placa,FK_estacionamiento)
	   VALUES( @_TIC_id,convert(datetime,@_TIC_fechaEntrada,5),convert(datetime,@_TIC_fechaEntrada,5), @_TIC_placa,@_FK_estacionamiento) 

 END
GO
--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
---EXECUTE ESTACIONAMIENTO--

            EXEC Procedure_agregarEstacionamiento
			@_EST_id           = 001,
            @_EST_nombre   = 'Estacionamiento Playa Sur',
            @_EST_capacidad        = 300,
            @_EST_tarifa     =  3,
            @_EST_tarifaTicketPerdido = 300,
            @_EST_estado      = 'Activado';
GO
            EXEC Procedure_agregarEstacionamiento
			@_EST_id           = 002,
            @_EST_nombre   = 'Estacionamiento Playa Norte',
            @_EST_capacidad        = 200,
            @_EST_tarifa     =  4,
            @_EST_tarifaTicketPerdido = 300,
            @_EST_estado      = 'Activado';
GO
            EXEC Procedure_agregarEstacionamiento
			@_EST_id           = 003,
            @_EST_nombre   = 'Estacionamiento Techado',
            @_EST_capacidad        = 250,
            @_EST_tarifa     =  5,
            @_EST_tarifaTicketPerdido = 500,
            @_EST_estado      = 'Activado';
GO
            EXEC Procedure_agregarEstacionamiento
			@_EST_id           = 004,
            @_EST_nombre   = 'Estacionamiento Subterraneo',
            @_EST_capacidad        = 500,
            @_EST_tarifa     =  3,
            @_EST_tarifaTicketPerdido = 300,
            @_EST_estado      = 'Activado';
GO
            EXEC Procedure_agregarEstacionamiento
			@_EST_id           = 005,
            @_EST_nombre   = 'Estacionamiento VIP',
            @_EST_capacidad        = 50,
            @_EST_tarifa     =  10,
            @_EST_tarifaTicketPerdido = 600,
            @_EST_estado      = 'Activado';
			

	--------------------------------------------------------------------------------
	--------------------EXECUTE TICKET-----------------------------------------

GO
            EXEC Procedure_InsertarTicket
	        @_TIC_id        =                1,
			@_TIC_fechaEntrada   =   '11-01-14 10:34:09 PM',
			@_TIC_fechaSalida   =   '12-01-14 01:33:09 PM',
			@_TIC_placa   =   'MAV91V',
			@_FK_estacionamiento   =   1;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                2,
			@_TIC_fechaEntrada   =   '11-01-14 10:34:09 PM',
			@_TIC_fechaSalida   =   '12-01-14 01:33:09 PM',
			@_TIC_placa   =   'KIO98B',
			@_FK_estacionamiento   =   1;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                3,
			@_TIC_fechaEntrada   =   '03-01-14 05:05:09 PM',
			@_TIC_fechaSalida   =   '03-01-14 10:34:09 PM',
			@_TIC_placa   =   'GBT67G',
			@_FK_estacionamiento   =   1;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                4,
			@_TIC_fechaEntrada   =   '04-01-14 04:10:09 PM',
			@_TIC_fechaSalida   =   '04-01-14 06:34:09 PM',
			@_TIC_placa   =   'YUH66R',
			@_FK_estacionamiento   =   1;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                5,
			@_TIC_fechaEntrada   =   '12-02-14 05:15:09 AM',
			@_TIC_fechaSalida   =   '12-02-14 06:34:09 PM',
			@_TIC_placa   =   'FRT55T',
			@_FK_estacionamiento   =   1;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                6,
			@_TIC_fechaEntrada   =   '03-01-14 08:34:09 PM',
			@_TIC_fechaSalida   =   '03-01-14 11:50:09 PM',
			@_TIC_placa   =   'DFT55T',
			@_FK_estacionamiento   =   2;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                7,
			@_TIC_fechaEntrada   =   '09-01-14 11:34:09 AM',
			@_TIC_fechaSalida   =   '09-01-14 01:10:00 PM',
			@_TIC_placa   =   'DFG44T',
			@_FK_estacionamiento   =   2;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                8,
			@_TIC_fechaEntrada   =   '11-01-14 10:34:09 AM',
			@_TIC_fechaSalida   =   '11-01-14 05:00:09 PM',
			@_TIC_placa   =   'DHY55F',
			@_FK_estacionamiento   =   2;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                9,
			@_TIC_fechaEntrada   =   '06-02-14 11:50:09 PM',
			@_TIC_fechaSalida   =   '07-02-14 10:34:09 AM',
			@_TIC_placa   =   'POI87H',
			@_FK_estacionamiento   =   2;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                10,
			@_TIC_fechaEntrada   =   '06-02-14 10:34:09 AM',
			@_TIC_fechaSalida   =   '06-02-14 06:25:09 PM',
			@_TIC_placa   =   'GHY66F',
			@_FK_estacionamiento   =   2;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                11,
			@_TIC_fechaEntrada   =   '11-02-14 10:34:09 AM',
			@_TIC_fechaSalida   =   '11-02-14 02:34:09 PM',
			@_TIC_placa   =   'POD77A',
			@_FK_estacionamiento   =   3;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                12,
			@_TIC_fechaEntrada   =   '10-03-14 09:34:09 AM',
			@_TIC_fechaSalida   =   '10-03-14 10:34:09 PM',
			@_TIC_placa   =   'SDR44R',
			@_FK_estacionamiento   =   3;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                13,
			@_TIC_fechaEntrada   =   '12-04-14 08:25:00 AM',
			@_TIC_fechaSalida   =   '12-04-14 09:22:01 PM',
			@_TIC_placa   =   'DFR44G',
			@_FK_estacionamiento   =   3;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                14,
			@_TIC_fechaEntrada   =   '06-05-14 01:34:09 AM',
			@_TIC_fechaSalida   =   '06-05-14 11:34:09 PM',
			@_TIC_placa   =   'DFR87J',
			@_FK_estacionamiento   =   3;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                15,
			@_TIC_fechaEntrada   =   '08-01-14 09:12:09 PM',
			@_TIC_fechaSalida   =   '08-01-14 10:34:09 PM',
			@_TIC_placa   =   'FRK16F',
			@_FK_estacionamiento   =   3;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                16,
			@_TIC_fechaEntrada   =   '03-01-14 05:22:00 PM',
			@_TIC_fechaSalida   =   '03-01-14 10:34:05 PM',
			@_TIC_placa   =   'POY76H',
			@_FK_estacionamiento   =   4;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                17,
			@_TIC_fechaEntrada   =   '04-02-14 07:33:09 AM',
			@_TIC_fechaSalida   =   '04-02-14 11:12:09 AM',
			@_TIC_placa   =   'PQI87S',
			@_FK_estacionamiento   =   4;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                18,
			@_TIC_fechaEntrada   =   '08-02-14 11:34:09 AM',
			@_TIC_fechaSalida   =   '08-02-14 10:34:09 PM',
			@_TIC_placa   =   'POI77D',
			@_FK_estacionamiento   =   4;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                19,
			@_TIC_fechaEntrada   =   '25-03-14 03:01:02 PM',
			@_TIC_fechaSalida   =   '25-03-14 05:11:09 PM',
			@_TIC_placa   =   'SDR56G',
			@_FK_estacionamiento   =   4;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                20,
			@_TIC_fechaEntrada   =   '08-03-14 09:10:00 AM',
			@_TIC_fechaSalida   =   '08-03-14 11:11:11 AM',
			@_TIC_placa   =   'QWE33E',
			@_FK_estacionamiento   =   4;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                21,
			@_TIC_fechaEntrada   =   '11-01-14 10:34:09 PM',
			@_TIC_fechaSalida   =   '11-01-14 11:30:09 PM',
			@_TIC_placa   =   'QW3TT3',
			@_FK_estacionamiento   =   5;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                22,
			@_TIC_fechaEntrada   =   '15-01-14 01:34:09 AM',
			@_TIC_fechaSalida   =   '15-01-14 10:34:09 PM',
			@_TIC_placa   =   'TYT33F',
			@_FK_estacionamiento   =   5;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                23,
			@_TIC_fechaEntrada   =   '22-05-14 02:20:09 PM',
			@_TIC_fechaSalida   =   '22-05-14 10:34:09 PM',
			@_TIC_placa   =   'LKG787G',
			@_FK_estacionamiento   =   5;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                24,
			@_TIC_fechaEntrada   =   '10-09-14 07:34:09 PM',
			@_TIC_fechaSalida   =   '10-09-14 11:55:09 PM',
			@_TIC_placa   =   'FGT27Y',
			@_FK_estacionamiento   =   5;
GO
			EXEC Procedure_InsertarTicket
	        @_TIC_id        =                25,
			@_TIC_fechaEntrada   =   '22-11-14 06:44:09 PM',
			@_TIC_fechaSalida   =   '22-11-14 09:50:00 PM',
			@_TIC_placa   =   'QQA50P',
			@_FK_estacionamiento   =   5;
       
commit transaction;
go