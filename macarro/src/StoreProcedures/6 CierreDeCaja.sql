use MACARRO
go
begin transaction;
go

/* SECUENCIA */

CREATE SEQUENCE FAC_SEQ
    START WITH 1
    INCREMENT BY 1;
GO

CREATE SEQUENCE LINEAFAC_SEQ
	START WITH 1
	INCREMENT BY 1;
GO



/*INSERT FACTURA*/

INSERT INTO FACTURA VALUES (NEXT VALUE FOR FAC_SEQ, convert(datetime, '30/12/14', 5), 340, 380.8, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Facturada' AND EST_pertenece = 'Factura'), (SELECT USU_id FROM USUARIO WHERE USU_correo = 'amandaRodriguez@gmail.com'));
INSERT INTO FACTURA VALUES (NEXT VALUE FOR FAC_SEQ, convert(datetime, '20-12-14', 5), 440, 492.8, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Facturada' AND EST_pertenece = 'Factura'), (SELECT USU_id FROM USUARIO WHERE USU_correo = 'amandaRodriguez@gmail.com'));
INSERT INTO FACTURA VALUES (NEXT VALUE FOR FAC_SEQ, convert(datetime, '30-11-14', 5), 1020, 1142.4, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Facturada' AND EST_pertenece = 'Factura'), (SELECT USU_id FROM USUARIO WHERE USU_correo = 'gabrielGonzales@gmail.com'));
INSERT INTO FACTURA VALUES (NEXT VALUE FOR FAC_SEQ, convert(datetime, '20-11-14', 5), 49, 54.88, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Facturada' AND EST_pertenece = 'Factura'), (SELECT USU_id FROM USUARIO WHERE USU_correo = 'gabrielGonzales@gmail.com'));

INSERT INTO FACTURA VALUES (NEXT VALUE FOR FAC_SEQ, convert(datetime, '15-01-15', 5), 590, 660.8, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'No Facturada' AND EST_pertenece = 'Factura'), (SELECT USU_id FROM USUARIO WHERE USU_correo = 'alejandroVieira@gmail.com'));
INSERT INTO FACTURA VALUES (NEXT VALUE FOR FAC_SEQ, convert(datetime, '30-01-15', 5), 235, 263.2, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'No Facturada' AND EST_pertenece = 'Factura'), (SELECT USU_id FROM USUARIO WHERE USU_correo = 'andreaPaola@gmail.com'));
INSERT INTO FACTURA VALUES (NEXT VALUE FOR FAC_SEQ, convert(datetime, '22-01-15', 5), 289, 323.68, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'No Facturada' AND EST_pertenece = 'Factura'), (SELECT USU_id FROM USUARIO WHERE USU_correo = 'pabloWestphal@gmail.com'));
INSERT INTO FACTURA VALUES (NEXT VALUE FOR FAC_SEQ, convert(datetime, '01-01-15', 5), 17, 19.04, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'No Facturada' AND EST_pertenece = 'Factura'), (SELECT USU_id FROM USUARIO WHERE USU_correo = 'pabloWestphal@gmail.com'));
INSERT INTO FACTURA VALUES (NEXT VALUE FOR FAC_SEQ, convert(datetime, '01-02-15', 5), 510, 571.2, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'No Facturada' AND EST_pertenece = 'Factura'), (SELECT USU_id FROM USUARIO WHERE USU_correo = 'vanessaMartinez@gmail.com'));


/*INSERT LINEA FACTURA*/

INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1, 1, null, null, null, null, 1, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Restaurant' AND EST_pertenece = 'LineaFactura')); -- plato 100.00---
INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 2, 1, null, null, null, null, 17, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Restaurant' AND EST_pertenece = 'LineaFactura'));-- bebida 20. Total 40---
INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1, 1, null, null, null, 38, null, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Servicio' AND EST_pertenece = 'LineaFactura'));-- reserva puesto 100--
INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1, 1, null, null, null, 1, null, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Servicio' AND EST_pertenece = 'LineaFactura'));-- reserva puesto 100 -- 


INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 2,  2, null, null, null, null, 2,(SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Restaurant' AND EST_pertenece = 'LineaFactura'));-- plato 80 x 2 =160 ---
INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 4, 2, null, null, null, null, 17,(SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Restaurant' AND EST_pertenece = 'LineaFactura'));-- bebida 20 x 4= 80--
INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1,  2, null, null, null, 39, null, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Servicio' AND EST_pertenece = 'LineaFactura'));-- precio puesto 100--
INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1,  2, null, null, null, 40, null, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Servicio' AND EST_pertenece = 'LineaFactura'));-- precio puesto 100--


INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1, 3, null, null, null, null, 6, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Restaurant' AND EST_pertenece = 'LineaFactura'));-- plato 1 x 60= 60--
INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 2, 3, null, null, null, null, 10, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Restaurant' AND EST_pertenece = 'LineaFactura'));-- plato 2 x 100 = 200--
INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1, 3, null, null, null, null, 14, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Restaurant' AND EST_pertenece = 'LineaFactura'));-- plato 1 x 120 = 120--
INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1, 3, null, null, null, null, 11, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Restaurant' AND EST_pertenece = 'LineaFactura'));-- plato 1 x 200 = 200--
INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 2, 3, null, null, null, null, 1, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Restaurant' AND EST_pertenece = 'LineaFactura'));-- plato 2 x 100 = 200--
INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 2, 3, null, null, null, null, 20, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Restaurant' AND EST_pertenece = 'LineaFactura'));-- plato 2 x 100 = 200--
INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 2, 3, null, null, null, null, 17, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Restaurant' AND EST_pertenece = 'LineaFactura'));-- plato 2 x 20 = 40--


INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1, 4, 1, 1, null, null, null, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Estacionamiento' AND EST_pertenece = 'LineaFactura'));-- ticket 3h x 3 = 9
INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 2, 4, null, null, null, null, 17, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Restaurant' AND EST_pertenece = 'LineaFactura'));-- bebida 20. Total 40---


INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1, 5, null, null, 10, null, null, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Servicio' AND EST_pertenece = 'LineaFactura'));-- reserva servicio 3h x 1 x 75 = 225--
INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1, 5, null, null, 11, null, null, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Servicio' AND EST_pertenece = 'LineaFactura'));-- reserva servicio 1h x 1 x 45= 45 --- 
INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 2, 5, null, null, null, null, 20, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Restaurant' AND EST_pertenece = 'LineaFactura'));-- plato 2 x 160 = 320---


INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1, 6, null, null, null, null, 24, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Restaurant' AND EST_pertenece = 'LineaFactura'));-- plato 1 x 60 = 60---
INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1, 6, null, null, 4, null, null, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Servicio' AND EST_pertenece = 'LineaFactura')); -- reserva servicio 1h x 1 x 75=75 --
INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1, 6, null, null, null, 18, null, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Servicio' AND EST_pertenece = 'LineaFactura'));-- reserva servicio 100 --


INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1, 7, 2, 1, null, null, null, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Estacionamiento' AND EST_pertenece = 'LineaFactura'));-- ticket 3h x 3 = 9 ---
INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1,7, null, null, null, null, 13, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Restaurant' AND EST_pertenece = 'LineaFactura'));-- plato 1 x 140 = 140---
INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1,7, null, null, null, null, 20, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Restaurant' AND EST_pertenece = 'LineaFactura'));-- plato 1 x 160 =160 --


INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1, 8, 4, 1, null, null, null, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Estacionamiento' AND EST_pertenece = 'LineaFactura'));-- ticket 3h x 3 =9  --
INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1 ,8, null, null, null, null, 16, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Restaurant' AND EST_pertenece = 'LineaFactura'));-- plato 1 x 8 = 8 --


INSERT INTO LINEA_FACTURA(LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1, 9, null, null, 9, null, null, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Servicio' AND EST_pertenece = 'LineaFactura'));-- reserva servicio 2h x 1 x 20 = 40--
INSERT INTO LINEA_FACTURA(LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1, 9, null, null, 2, null, null, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Servicio' AND EST_pertenece = 'LineaFactura'));-- reserva servicio 9h x 1 x 30 = 270--
INSERT INTO LINEA_FACTURA(LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1, 9, null, null, null, 31, null, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Servicio' AND EST_pertenece = 'LineaFactura'));-- reserva puesto 100--
INSERT INTO LINEA_FACTURA(LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1, 9, null, null, null, 10, null, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Servicio' AND EST_pertenece = 'LineaFactura'));-- reserva puesto 100-- */



go
/* PROCEDIMIENTOS */

CREATE PROCEDURE Procedure_buscarCorreosClientes
AS
BEGIN
	SELECT USU_correo From USUARIO;
END;
go
-- CONSULTA PLATOS, TICKET, SERVICIOS DE UN USUARIO PARA FACTURAR --
CREATE PROCEDURE Procedure_buscarFacturacion
    @_busqueda [nvarchar] (100),
    @_tipo [nvarchar] (100),
    @_usuario [nvarchar] (100)
	
AS
    IF(@_tipo = 'Restaurant')
        BEGIN

            SELECT PLA_nombre as Plato, PLA_precio as Precio, PLA_id as ID  
            FROM PLATO, ESTADO 
            WHERE FK_estado = EST_id AND EST_nombre = 'Activado' AND EST_pertenece = 'General' AND
                ( UPPER(PLA_nombre) LIKE UPPER(@_busqueda) + '%') 
				OR ( UPPER(PLA_nombre) LIKE '%' + UPPER(@_busqueda))
				OR ( UPPER(PLA_nombre) LIKE '%' + UPPER(@_busqueda) + '%')
            ORDER BY Plato;
        END

        /*Falta restaurant y servicios, pensar como se pintaran*/
    
GO

-- GESTION/CONSULTA FACTURA --
CREATE PROCEDURE Procedure_buscarFacturas
    @_busqueda [nvarchar] (100),
    @_estado [nvarchar] (100)

AS

    BEGIN
        SELECT F.FAC_id as ID, F.FAC_fecha as FECHA, F.FAC_subTotal as SubTotal, FAC_total as Total, USU_correo as Usuario  
        FROM FACTURA F, ESTADO, USUARIO
        WHERE F.FK_estado = EST_id AND EST_nombre = @_estado AND EST_pertenece = 'Factura' AND FK_usuario = USU_id AND (
                ( UPPER(USU_correo) LIKE UPPER(@_busqueda) + '%')
				OR ( UPPER(USU_correo) LIKE '%' + UPPER(@_busqueda))
				OR ( UPPER(USU_correo) LIKE '%' + UPPER(@_busqueda) + '%') )

    END
GO


-- INSERTAR FACRUTA --
CREATE PROCEDURE Procedure_insertarFactura
	@_subtotal [float],
	@_total [float],
	@_estado [nvarchar] (100),
	@_usuario [nvarchar] (100)

AS

    BEGIN
        INSERT INTO FACTURA VALUES (NEXT VALUE FOR FAC_SEQ, SYSDATETIME(), @_subtotal, @_total, (SELECT EST_id FROM ESTADO WHERE EST_nombre = @_estado AND EST_pertenece = 'Factura'), (SELECT USU_id FROM USUARIO WHERE USU_correo = @_usuario))
    END
go


-- INSERTAR LINEA FACTURA --
CREATE PROCEDURE Procedure_insertarLineaFactura
    @_idFactura [int],
    @_tipoServico [varchar](15),
    @_cantidad[int],
    @_ticket [int],
    @_estacionamiento[int],
    @_plato[int],
    @_reservaServicio [int],
    @_reservaPuesto [int]
    

 AS

     BEGIN
          INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) 
          VALUES (NEXT VALUE FOR LINEAFAC_SEQ, @_cantidad, @_idFactura, @_ticket, @_estacionamiento,  @_reservaServicio, @_reservaPuesto, @_plato, @_tipoServico);
    END
GO


-- DETALLE FACTURA --
CREATE PROCEDURE Procedure_consultarLineaFactura
    @_idFactura[int]

AS 

    BEGIN
   
        SELECT PLA_nombre AS Servicio, LF.LIN_FAC_cantidad AS Cantidad, EST_nombre AS Tipo, (PLA_precio * LF.LIN_FAC_cantidad) AS Precio
        FROM LINEA_FACTURA LF, PLATO, ESTADO 
        WHERE LF.FK_factura = @_idFactura AND FK_plato = PLA_id AND LF.FK_estado = EST_id 
        UNION
        
        SELECT 'Ticket con placa '+T.TIC_placa AS Servicio, L.LIN_FAC_cantidad AS Cantidad, EST.EST_nombre AS Tipo, (SELECT (DATEDIFF(minute,T.TIC_fechaEntrada,SYSDATETIME()) * E.EST_tarifa)/60 AS TOTAL
        FROM TICKET T, ESTACIONAMIENTO E
        WHERE T.TIC_id = L.FK_ticket AND E.EST_id = T.FK_estacionamiento)
        FROM LINEA_FACTURA L, TICKET T, ESTACIONAMIENTO E, ESTADO EST 
        WHERE L.FK_ticket = T.TIC_id AND T.FK_estacionamiento = E.EST_id AND L.FK_factura=@_idFactura AND L.FK_estado = EST.EST_id
    
        /*Faltan los servicios*/

    END
GO

-- INFO CLIENTE PARA DETALLE FACTURA--
CREATE PROCEDURE Procedure_consultarClienteFactura
    @_idFactura [nvarchar](100)

AS 

    BEGIN
        SELECT PER_docIdentidad AS ID, ISNULL(PER_primerNombre+' '+PER_segundoNombre, PER_primerNombre) AS Nombres, PER_primerApellido+' '+ PER_segundoApellido AS Apellidos, EST_nombre AS Estado, MEM_descAplicado AS Descuento
        FROM PERSONA, USUARIO, FACTURA F, MEMBRESIA M, ESTADO  
        WHERE F.FAC_id = @_idFactura AND F.FK_usuario = USU_id AND FK_persona = PER_docIdentidad AND M.FK_usuario = USU_id AND M.FK_estado = EST_id
    END
GO


commit transaction;
go
	
