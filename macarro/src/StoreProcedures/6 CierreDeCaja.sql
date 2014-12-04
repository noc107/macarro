use MACARRO
go
begin transaction;
go

--MODULO CIERRE DE CAJA

-----------------------------------------SECUENCIA 2-12-2014-----------------------------------------------
CREATE SEQUENCE FAC_SEQ
    START WITH 1
    INCREMENT BY 1;
GO
CREATE SEQUENCE LINEAFAC_SEQ
	START WITH 1
	INCREMENT BY 1;
GO


--PROCEDIMIENTO INSERTAR FACRUTA 2-12-14--------------------------------------------------------
CREATE PROCEDURE [dbo].[Procedure_insertarFactura]
	@fechaFactura [nvarchar](20),
	@subtotalFactura [float],
	@totalFactura [float],
	@facturadaFactura [varchar] (3),
	@fkUsuario [varchar] (100)
AS
BEGIN
    INSERT INTO [dbo].[Factura](FAC_id, FAC_fecha, FAC_subTotal, FAC_total, FAC_facturada, FK_usuario)
    VALUES(NEXT VALUE FOR FAC_SEQ, convert(date,@fechaFactura,5), @subtotalFactura, @totalFactura, @facturadaFactura, @fkUsuario)
END;
go
--PROCEDIMIENTO INSERTAR LINEA FACTURA 2-12-14--------------------------------------------------------
CREATE PROCEDURE [dbo].[Procedure_insertarLineaFactura]
@_idFactura [int],
@_TipoServico [varchar](15),
@_Cantidad[int],
@_ticket [int],
@_estacionamiento[int],
@_Plato[int],
@_ServicioPlaya [int]

 AS
 BEGIN
  INSERT INTO LINEA_FACTURA (LIN_FAC_id,LIN_FAC_cantidad,LIN_FAC_tipoServicio,FK_factura,FK_servicio,FK_ticket,FK_estacionamiento,FK_plato) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,@_Cantidad,@_TipoServico,@_idFactura,@_ServicioPlaya,@_ticket,@_estacionamiento,@_Plato);
END
GO


------ INSERT DE FACTURA 2-12-14-----------------------
EXEC Procedure_insertarFactura  @fechaFactura = '30-11-14', @subtotalFactura = 230, @totalFactura = 300, @facturadaFactura = 'Si', @fkUsuario = 'rubenalej@gmail.com' ;
EXEC Procedure_insertarFactura  @fechaFactura = '30-11-14', @subtotalFactura = 250, @totalFactura = 320, @facturadaFactura = 'Si', @fkUsuario = 'manueljos@hotmail.com' ;
EXEC Procedure_insertarFactura  @fechaFactura = '30-11-14', @subtotalFactura = 100, @totalFactura = 150, @facturadaFactura = 'Si', @fkUsuario = 'leydacenteno@gmail.com' ;
EXEC Procedure_insertarFactura  @fechaFactura = '30-11-14', @subtotalFactura = 170, @totalFactura = 240, @facturadaFactura = 'Si', @fkUsuario = 'ybucherenick@gmail.com' ;
EXEC Procedure_insertarFactura  @fechaFactura = '30-11-14', @subtotalFactura = 110, @totalFactura = 160, @facturadaFactura = 'Si', @fkUsuario = 'marianacarol@gmail.com' ;
------- LINEA FACTURA  2-12-14-------------------------------------------------------
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_plato) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Restaurant',1,1,1);-- precio plato 100.00---
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_ticket, FK_estacionamiento) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Estacionamiento',1,1,1,1);-- precio del ticket---
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_servicio) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Servicio',1,1,1);-- precio de tabla de surf 45--
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_servicio) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Servicio',1,1,4);-- precio de moto de agua 10 --
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_plato) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Restaurant',1,1,17);-- precio de bebida 20---
---------------------------2-12-14-------------------------------------------------
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_ticket, FK_estacionamiento) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Estacionamiento',1,2,2,1);-- precio =ticket---
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_plato) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Restaurant',1,2,2);-- precio plato 80---
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_servicio) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Servicio',1,2,7);-- precio de paseo en lancha 75--
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_servicio) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Servicio',1,2,8);-- precio de paseo en moto 150 ---
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_plato) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Restaurant',1,2,17);-- precio de bebida 20--
---------------------------------2-12-14-----------------------------------------------
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_plato) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Restaurant',1,3,6);-- precio plato 60--
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_plato) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Restaurant',1,3,10);-- precio plato 100--
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_plato) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Restaurant',2,3,16);-- precio bebida 8--
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_servicio) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Servicio',1,3,4);-- precio de moto de agua 10 --
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_ticket, FK_estacionamiento) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Estacionamiento',1,3,3,1);-- precio del ticket --
------------------------------------2-12-14---------------------------------------
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_servicio) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Servicio',1,4,9);-- precio de kit de araena 20--
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_servicio) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Servicio',1,4,10);-- precio del flotador 10--
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_servicio) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Servicio',1,4,3);-- precio de pelota 10--
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_servicio) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Servicio',1,4,1);-- precio de tabla de surf 45 --
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_ticket, FK_estacionamiento) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Estacionamiento',1,4,4,1);-- precio del ticket 
-----------------------------------2-12-14-----------------------------------------
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_plato) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Restaurant',1,5,11);-- precio plato 200--
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_ticket, FK_estacionamiento) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Estacionamiento',1,5,5,1);-- precio del ticket--
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_servicio) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Servicio',1,5,6);-- precio de kayak 75--
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_servicio) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Servicio',1,5,5);-- precio de snorkel 30 ---
INSERT INTO LINEA_FACTURA(LIN_FAC_id,LIN_FAC_tipoServicio,LIN_FAC_cantidad,FK_factura,FK_plato) VALUES (NEXT VALUE FOR LINEAFAC_SEQ,'Restaurant',1,5,16);-- precio de bebida 8---

commit transaction;
go