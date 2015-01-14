use MACARRO
go
begin transaction;
go

/*INSERT FACTURA*/

INSERT INTO FACTURA VALUES (NEXT VALUE FOR FAC_SEQ, convert(datetime, '30/12/14', 5), 340, 380.8, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Facturada' AND EST_pertenece = 'Factura'), (SELECT USU_id FROM USUARIO WHERE USU_correo = 'amandaRodriguez@gmail.com'));
INSERT INTO FACTURA VALUES (NEXT VALUE FOR FAC_SEQ, convert(datetime, '20-12-14', 5), 340, 380.8, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Facturada' AND EST_pertenece = 'Factura'), (SELECT USU_id FROM USUARIO WHERE USU_correo = 'amandaRodriguez@gmail.com'));
INSERT INTO FACTURA VALUES (NEXT VALUE FOR FAC_SEQ, convert(datetime, '30-11-14', 5), 1140, 1276.8, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Facturada' AND EST_pertenece = 'Factura'), (SELECT USU_id FROM USUARIO WHERE USU_correo = 'gabrielGonzales@gmail.com'));
INSERT INTO FACTURA VALUES (NEXT VALUE FOR FAC_SEQ, convert(datetime, '20-11-14', 5), 2172.95, 2433.7, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Facturada' AND EST_pertenece = 'Factura'), (SELECT USU_id FROM USUARIO WHERE USU_correo = 'gabrielGonzales@gmail.com'));

INSERT INTO FACTURA VALUES (NEXT VALUE FOR FAC_SEQ, convert(datetime, '15-01-15', 5), 1071.25, 1199.8, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'No Facturada' AND EST_pertenece = 'Factura'), (SELECT USU_id FROM USUARIO WHERE USU_correo = 'alejandroVieira@gmail.com'));
INSERT INTO FACTURA VALUES (NEXT VALUE FOR FAC_SEQ, convert(datetime, '30-01-15', 5), 986.25, 1104.6, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'No Facturada' AND EST_pertenece = 'Factura'), (SELECT USU_id FROM USUARIO WHERE USU_correo = 'andreaPaola@gmail.com'));
INSERT INTO FACTURA VALUES (NEXT VALUE FOR FAC_SEQ, convert(datetime, '22-01-15', 5), 2432.95, 2724.9, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'No Facturada' AND EST_pertenece = 'Factura'), (SELECT USU_id FROM USUARIO WHERE USU_correo = 'pabloWestphal@gmail.com'));
INSERT INTO FACTURA VALUES (NEXT VALUE FOR FAC_SEQ, convert(datetime, '01-01-15', 5), 15.2, 17.02, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'No Facturada' AND EST_pertenece = 'Factura'), (SELECT USU_id FROM USUARIO WHERE USU_correo = 'pabloWestphal@gmail.com'));
INSERT INTO FACTURA VALUES (NEXT VALUE FOR FAC_SEQ, convert(datetime, '01-02-15', 5), 469.83, 526.20, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'No Facturada' AND EST_pertenece = 'Factura'), (SELECT USU_id FROM USUARIO WHERE USU_correo = 'vanessaMartinez@gmail.com'));


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
/*INSERT INTO LINEA_FACTURA (LIN_FAC_id, LIN_FAC_cantidad, FK_factura, FK_ticket, FK_estacionamiento, FK_reserva_servicio, FK_reserva_puesto, FK_plato, FK_estado) VALUES (NEXT VALUE FOR LINEAFAC_SEQ, 1, 5, null, null, 11, null, null, (SELECT EST_id FROM ESTADO WHERE EST_nombre = 'Servicio' AND EST_pertenece = 'LineaFactura'));-- reserva servicio 1h x 1 x 45= 45 --- */
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

CREATE PROCEDURE Procedure_consultarGridPorCorreo
	@correo	[nvarchar](100)
AS
BEGIN
	Select DISTINCT(RS.RES_SER_id) AS ID, (RES_SER_cantidad*SER_costo) AS Precio, SER_nombre AS Servicio, EST_nombre As Tipo
	From RESERVA_SERVICIO RS, HORARIO H, SERVICIO S, ESTADO, RESERVA R, USUARIO US
	Where 
	RS.FK_horario = H.HOR_id and H.FK_servicio = S.SER_id and R.RES_id = RS.FK_reserva  
	and US.USU_correo = @correo and EST_nombre = 'Servicio' and R.FK_usuario = US.USU_id
	and (Select count(*) From LINEA_FACTURA LN, FACTURA F, PERSONA P, USUARIO U Where LN.FK_factura = F.FAC_id
	and F.FK_usuario = U.USU_id and P.PER_id = U.FK_persona and LN.FK_reserva_servicio = RS.RES_SER_id 
	and U.USU_correo = @correo) = 0
	UNION
	Select DISTINCT(RP.RES_PUE_id) AS ID, (P.PUE_precio) AS Precio, (CONCAT(PUE_fila,CONCAT('-',CONCAT(PUE_columna,CONCAT('- Fecha: ',R.RES_fecha))))) AS Servicio, EST_nombre As Tipo
	From RESERVA_PUESTO RP, PUESTO P, ESTADO, RESERVA R, USUARIO US
	Where 
	R.RES_id = RP.FK_reserva  and US.USU_correo = @correo and EST_nombre = 'Puesto' 
	and R.FK_usuario = US.USU_id and P.PUE_fila = RP.FK_puestoFila and P.PUE_columna = RP.FK_puestoColumna 
	and P.FK_inventario = RP.FK_inventario and P.FK_playa = RP.FK_playa 
	and (Select count(*) From LINEA_FACTURA LN, FACTURA F, PERSONA P, USUARIO U Where LN.FK_factura = F.FAC_id
	and F.FK_usuario = U.USU_id and P.PER_id = U.FK_persona and LN.FK_reserva_puesto = RP.RES_PUE_id
	and U.USU_correo = @correo) = 0
	UNION
	Select P.PLA_id As ID, (P.PLA_precio) AS Precio, P.PLA_nombre As Servicio, EST_nombre As Tipo
	FROM Plato P, ESTADO
	Where EST_nombre = 'Restaurant'
	UNION
	Select T.TIC_id As ID, E.EST_tarifa As precio, CONCAT('Placa: ',T.TIC_placa) As Servicio, ES.EST_nombre As Tipo
	FROM TICKET T, ESTACIONAMIENTO E, ESTADO ES
	WHERE T.FK_estacionamiento = E.EST_id and ES.EST_nombre = 'Estacionamiento'
	Order By Tipo;
END;
go


CREATE PROCEDURE Procedure_verificarCorreoUsuario
	@correo	[nvarchar](100)  
AS 
BEGIN
	SELECT USU_id, PER_primerNombre, PER_primerApellido, PER_docIdentidad FROM USUARIO, PERSONA WHERE USU_correo = @correo and FK_persona = PER_id;
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

-- CIERRE DE CAJA DIARIO -- -- MODIFICADO AL 10/01 --
CREATE PROCEDURE Procedure_cierreCajaDiario
    @_fechaChar varchar(200),
    @_tipo varchar(200)

AS
	DECLARE @_fecha datetime 
	SET @_fecha = CONVERT(datetime,@_fechaChar,105);

    BEGIN
		IF(@_tipo = 'serPlaya')
			BEGIN
				SELECT  
					(SELECT isnull(sum(ss.ser_costo*slf.lin_fac_cantidad),0)
					 FROM FACTURA sf, LINEA_FACTURA slf, SERVICIO ss, RESERVA_SERVICIO srs, HORARIO sh
					 WHERE slf.FK_factura = sf.FAC_id and sf.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and sf.FAC_fecha < @_fecha and slf.FK_reserva_servicio = srs.RES_SER_id and srs.FK_horario = sh.HOR_id and sh.FK_servicio = ss.SER_id) 
					 as saldoAnt,
					 count(distinct f.fac_id) as cantidad, 
					 isnull(sum(s.ser_costo*lf.lin_fac_cantidad),0) as ingreso 
				FROM 
					FACTURA f, LINEA_FACTURA lf, SERVICIO s, RESERVA_SERVICIO rs, HORARIO h
				WHERE 
					lf.FK_factura = f.FAC_id and f.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and f.FAC_fecha = @_fecha and lf.FK_reserva_servicio = rs.RES_SER_id and rs.FK_horario = h.HOR_id and h.FK_servicio = s.SER_id;
			END
        ELSE IF(@_tipo = 'serPuestos')
			BEGIN
				SELECT
					(SELECT isnull(sum(sp.PUE_precio*slf.LIN_FAC_cantidad),0)
					 FROM FACTURA sf, LINEA_FACTURA slf, PUESTO sp, RESERVA_PUESTO srp
					 WHERE slf.FK_factura = sf.FAC_id and sf.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and sf.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and sf.FAC_fecha < @_fecha and slf.FK_reserva_puesto = srp.RES_PUE_id and srp.FK_puestoColumna = sp.PUE_columna and srp.FK_puestoFila = sp.PUE_fila and srp.FK_playa = sp.FK_playa and srp.FK_inventario = sp.FK_inventario) 
					 as saldoAnt,
					 count(distinct f.fac_id) as cantidad, 
					 isnull(sum(p.PUE_precio*lf.lin_fac_cantidad),0) as ingreso 
				FROM 
					FACTURA f, LINEA_FACTURA lf, PUESTO p, RESERVA_PUESTO rp
				WHERE 
					lf.FK_factura = f.FAC_id and f.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and f.FAC_fecha = @_fecha and lf.FK_reserva_puesto = rp.RES_PUE_id and rp.FK_puestoColumna = p.PUE_columna and rp.FK_puestoFila = p.PUE_fila and rp.FK_playa = p.FK_playa and rp.FK_inventario = p.FK_inventario;
			END
		ELSE IF(@_tipo = 'serEstacionamiento')
			BEGIN
				SELECT
					(SELECT cast(round(isnull(sum(datediff(MI, st.TIC_fechaEntrada, st.TIC_fechaSalida)/60.0*se.EST_tarifa*slf.LIN_FAC_cantidad),0),2) as numeric(36,2))
					 FROM FACTURA sf, LINEA_FACTURA slf, TICKET st, ESTACIONAMIENTO se
					 WHERE slf.FK_factura = sf.FAC_id and sf.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and sf.FAC_fecha < @_fecha and slf.FK_ticket = st.TIC_id and slf.FK_estacionamiento = st.FK_estacionamiento and st.FK_estacionamiento = se.est_id) 
					 as saldoAnt,
					 count(distinct f.fac_id) as cantidad, 
					 cast(round(isnull(sum(datediff(MI, t.TIC_fechaEntrada, t.TIC_fechaSalida)/60.0*e.EST_tarifa*lf.LIN_FAC_cantidad),0),2) as numeric(36,2)) as ingreso
				FROM 
					FACTURA f, LINEA_FACTURA lf, TICKET t, ESTACIONAMIENTO e
				WHERE 
					lf.FK_factura = f.FAC_id and f.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and f.FAC_fecha = @_fecha and lf.FK_ticket = t.TIC_id and lf.FK_estacionamiento = t.FK_estacionamiento and t.FK_estacionamiento = e.est_id; 
			END
		ELSE IF(@_tipo = 'serRestaurante')
			BEGIN
				SELECT
					(SELECT isnull(sum(sp.PLA_precio*slf.LIN_FAC_cantidad),0)
					 FROM FACTURA sf, LINEA_FACTURA slf, PLATO sp
					 WHERE slf.FK_factura = sf.FAC_id and sf.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and sf.FAC_fecha < @_fecha and slf.FK_plato = sp.PLA_id)
					 as saldoAnt,
					 count(distinct f.fac_id) as cantidad,
					 isnull(sum(p.PLA_precio*lf.LIN_FAC_cantidad),0) as ingreso
				FROM 
					FACTURA f, LINEA_FACTURA lf, PLATO p
				WHERE
					lf.FK_factura = f.FAC_id and f.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and f.FAC_fecha = @_fecha and lf.FK_plato = p.PLA_id;
			END
		ELSE
			BEGIN
				SELECT
					(SELECT isnull(sum(sf.FAC_subtotal),0)
					 FROM FACTURA sf
					 WHERE sf.FAC_fecha < @_fecha and sf.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura'))
					 as saldoAnt,
					 count(f.FAC_id) as cantidad,
					 isnull(sum(f.FAC_subtotal),0) as ingreso
				FROM 
					FACTURA f
				WHERE
					f.FAC_fecha = @_fecha and f.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura');	
			END
    END
GO


-- CIERRE CAJA DIARIO SEMANAL --  -- MODIFICADO AL 10/01 --
CREATE PROCEDURE Procedure_cierreCajaDiarioSemanal
    @_fechaChar [nvarchar](100),
    @_tipo [nvarchar] (100),
	@_ingresos [nvarchar](200) OUTPUT
AS
	BEGIN
		DECLARE @_fecha datetime 
		DECLARE @_iteracion int
		DECLARE @_ingresoDiario numeric(36,2)

		SET @_fecha = CONVERT(datetime,@_fechaChar,105)
		SET @_iteracion = 0
		SET @_ingresos = ''

		IF(@_tipo = 'serPlaya')
			BEGIN
				WHILE(@_iteracion < 7)
					BEGIN
						SELECT @_ingresoDiario = cast(sum(ss.ser_costo*slf.lin_fac_cantidad) as numeric(36,2))
						FROM FACTURA sf, LINEA_FACTURA slf, SERVICIO ss, RESERVA_SERVICIO srs, HORARIO sh
						WHERE slf.FK_factura = sf.FAC_id and sf.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and sf.FAC_fecha = (@_fecha-7+@_iteracion) and slf.FK_reserva_servicio = srs.RES_SER_id and srs.FK_horario = sh.HOR_id and sh.FK_servicio = ss.SER_id

						IF(@_ingresoDiario is not null)
							SET @_ingresos = concat(concat(@_ingresos,cast(@_ingresoDiario as [nvarchar](200))),'$')
						ELSE
							SET @_ingresos = concat(concat(@_ingresos,'x'),'$')
						SET @_iteracion = @_iteracion + 1
					END
			END
		ELSE IF(@_tipo = 'serPuestos')
			BEGIN
				WHILE(@_iteracion < 7)
					BEGIN
						SELECT @_ingresoDiario = cast(sum(sp.PUE_precio*slf.LIN_FAC_cantidad) as numeric(36,2))
						FROM FACTURA sf, LINEA_FACTURA slf, PUESTO sp, RESERVA_PUESTO srp
						WHERE slf.FK_factura = sf.FAC_id and sf.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and sf.FAC_fecha = (@_fecha-7+@_iteracion) and slf.FK_reserva_puesto = srp.RES_PUE_id and srp.FK_puestoColumna = sp.PUE_columna and srp.FK_puestoFila = sp.PUE_fila and srp.FK_playa = sp.FK_playa and srp.FK_inventario = sp.FK_inventario

						IF(@_ingresoDiario is not null)
							SET @_ingresos = concat(concat(@_ingresos,cast(@_ingresoDiario as [nvarchar](200))),'$')
						ELSE
							SET @_ingresos = concat(concat(@_ingresos,'x'),'$')
						SET @_iteracion = @_iteracion + 1
					END
			END
		ELSE IF(@_tipo = 'serEstacionamiento')
			BEGIN
				WHILE(@_iteracion < 7)
					BEGIN
						SELECT @_ingresoDiario = cast(round(sum(datediff(MI, st.TIC_fechaEntrada, st.TIC_fechaSalida)/60.0*se.EST_tarifa*slf.LIN_FAC_cantidad),2) as numeric(36,2))
						FROM FACTURA sf, LINEA_FACTURA slf, TICKET st, ESTACIONAMIENTO se
						WHERE slf.FK_factura = sf.FAC_id and sf.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and sf.FAC_fecha = (@_fecha-7+@_iteracion) and slf.FK_ticket = st.TIC_id and slf.FK_estacionamiento = st.FK_estacionamiento and st.FK_estacionamiento = se.est_id

						IF(@_ingresoDiario is not null)
							SET @_ingresos = concat(concat(@_ingresos,cast(@_ingresoDiario as [nvarchar](200))),'$')
						ELSE
							SET @_ingresos = concat(concat(@_ingresos,'x'),'$')
						SET @_iteracion = @_iteracion + 1
					END
			END
		ELSE IF(@_tipo = 'serRestaurante')
			BEGIN
				WHILE(@_iteracion < 7)
					BEGIN
						SELECT @_ingresoDiario = cast(round(sum(sp.PLA_precio*slf.LIN_FAC_cantidad),2) as numeric(36,2))
						FROM FACTURA sf, LINEA_FACTURA slf, PLATO sp
						WHERE slf.FK_factura = sf.FAC_id and sf.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and sf.FAC_fecha = (@_fecha-7+@_iteracion) and slf.FK_plato = sp.PLA_id

						IF(@_ingresoDiario is not null)
							SET @_ingresos = concat(concat(@_ingresos,cast(@_ingresoDiario as [nvarchar](200))),'$')
						ELSE
							SET @_ingresos = concat(concat(@_ingresos,'x'),'$')
						SET @_iteracion = @_iteracion + 1
					END
			END
		ELSE
			BEGIN
				WHILE(@_iteracion < 7)
					BEGIN
						SELECT @_ingresoDiario = cast(sum(sf.FAC_subtotal) as numeric(36,2))
						FROM FACTURA sf
						WHERE sf.FAC_fecha = (@_fecha-7+@_iteracion) and sf.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura')

						IF(@_ingresoDiario is not null)
							SET @_ingresos = concat(concat(@_ingresos,cast(@_ingresoDiario as [nvarchar](200))),'$')
						ELSE
							SET @_ingresos = concat(concat(@_ingresos,'x'),'$')
						SET @_iteracion = @_iteracion + 1
					END
			END
	END	
GO


-- CIERRE CAJA MENSUAL --   -- MODIFICADO AL 10/01 --
CREATE PROCEDURE Procedure_cierreCajaMensual
    @_mes int,
	@_año int,
    @_tipo varchar(200)
AS
    BEGIN
		IF(@_tipo = 'serPlaya')
			BEGIN
				SELECT  
					(SELECT isnull(sum(ss.ser_costo*slf.lin_fac_cantidad),0)
					 FROM FACTURA sf, LINEA_FACTURA slf, SERVICIO ss, RESERVA_SERVICIO srs, HORARIO sh
					 WHERE slf.FK_factura = sf.FAC_id and sf.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and (datepart(mm,sf.FAC_fecha) < @_mes and datepart(yyyy, sf.FAC_fecha) = @_año) and slf.FK_reserva_servicio = srs.RES_SER_id and srs.FK_horario = sh.HOR_id and sh.FK_servicio = ss.SER_id) 
					 as saldoAnt,
					 count(distinct f.fac_id) as cantidad, 
					 isnull(sum(s.ser_costo*lf.lin_fac_cantidad),0) as ingreso 
				FROM 
					FACTURA f, LINEA_FACTURA lf, SERVICIO s, RESERVA_SERVICIO rs, HORARIO h
				WHERE 
					lf.FK_factura = f.FAC_id and f.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and (datepart(mm,f.FAC_fecha) = @_mes and datepart(yyyy, f.FAC_fecha) = @_año) and lf.FK_reserva_servicio = rs.RES_SER_id and rs.FK_horario = h.HOR_id and h.FK_servicio = s.SER_id;
			END
        ELSE IF(@_tipo = 'serPuestos')
			BEGIN
				SELECT
					(SELECT isnull(sum(sp.PUE_precio*slf.LIN_FAC_cantidad),0)
					 FROM FACTURA sf, LINEA_FACTURA slf, PUESTO sp, RESERVA_PUESTO srp
					 WHERE slf.FK_factura = sf.FAC_id and sf.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and (datepart(mm,sf.FAC_fecha) < @_mes and datepart(yyyy, sf.FAC_fecha) = @_año) and slf.FK_reserva_puesto = srp.RES_PUE_id and srp.FK_puestoColumna = sp.PUE_columna and srp.FK_puestoFila = sp.PUE_fila and srp.FK_playa = sp.FK_playa and srp.FK_inventario = sp.FK_inventario) 
					 as saldoAnt,
					 count(distinct f.fac_id) as cantidad, 
					 isnull(sum(p.PUE_precio*lf.lin_fac_cantidad),0) as ingreso 
				FROM 
					FACTURA f, LINEA_FACTURA lf, PUESTO p, RESERVA_PUESTO rp
				WHERE 
					lf.FK_factura = f.FAC_id and f.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and (datepart(mm,f.FAC_fecha) = @_mes and datepart(yyyy, f.FAC_fecha) = @_año) and lf.FK_reserva_puesto = rp.RES_PUE_id and rp.FK_puestoColumna = p.PUE_columna and rp.FK_puestoFila = p.PUE_fila and rp.FK_playa = p.FK_playa and rp.FK_inventario = p.FK_inventario;
			END
		ELSE IF(@_tipo = 'serEstacionamiento')
			BEGIN
				SELECT
					(SELECT cast(round(isnull(sum(datediff(MI, st.TIC_fechaEntrada, st.TIC_fechaSalida)/60.0*se.EST_tarifa*slf.LIN_FAC_cantidad),0),2) as numeric(36,2))
					 FROM FACTURA sf, LINEA_FACTURA slf, TICKET st, ESTACIONAMIENTO se
					 WHERE slf.FK_factura = sf.FAC_id and sf.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and (datepart(mm,sf.FAC_fecha) < @_mes and datepart(yyyy, sf.FAC_fecha) = @_año) and slf.FK_ticket = st.TIC_id and slf.FK_estacionamiento = st.FK_estacionamiento and st.FK_estacionamiento = se.est_id) 
					 as saldoAnt,
					 count(distinct f.fac_id) as cantidad, 
					 cast(round(isnull(sum(datediff(MI, t.TIC_fechaEntrada, t.TIC_fechaSalida)/60.0*e.EST_tarifa*lf.LIN_FAC_cantidad),0),2) as numeric(36,2)) as ingreso
				FROM 
					FACTURA f, LINEA_FACTURA lf, TICKET t, ESTACIONAMIENTO e
				WHERE 
					lf.FK_factura = f.FAC_id and f.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and (datepart(mm,f.FAC_fecha) = @_mes and datepart(yyyy, f.FAC_fecha) = @_año) and lf.FK_ticket = t.TIC_id and lf.FK_estacionamiento = t.FK_estacionamiento and t.FK_estacionamiento = e.est_id; 
			END
		ELSE IF(@_tipo = 'serRestaurante')
			BEGIN
				SELECT
					(SELECT isnull(sum(sp.PLA_precio*slf.LIN_FAC_cantidad),0)
					 FROM FACTURA sf, LINEA_FACTURA slf, PLATO sp
					 WHERE slf.FK_factura = sf.FAC_id and sf.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and (datepart(mm,sf.FAC_fecha) < @_mes and datepart(yyyy, sf.FAC_fecha) = @_año) and slf.FK_plato = sp.PLA_id)
					 as saldoAnt,
					 count(distinct f.fac_id) as cantidad,
					 isnull(sum(p.PLA_precio*lf.LIN_FAC_cantidad),0) as ingreso
				FROM 
					FACTURA f, LINEA_FACTURA lf, PLATO p
				WHERE
					lf.FK_factura = f.FAC_id and f.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and (datepart(mm,f.FAC_fecha) = @_mes and datepart(yyyy, f.FAC_fecha) = @_año) and lf.FK_plato = p.PLA_id;
			END
		ELSE
			BEGIN
				SELECT
					(SELECT isnull(sum(sf.FAC_subtotal),0)
					 FROM FACTURA sf
					 WHERE (datepart(mm,sf.FAC_fecha) < @_mes and datepart(yyyy, sf.FAC_fecha) = @_año) and sf.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura'))
					 as saldoAnt,
					 count(f.FAC_id) as cantidad,
					 isnull(sum(f.FAC_subtotal),0) as ingreso
				FROM 
					FACTURA f
				WHERE
					(datepart(mm,f.FAC_fecha) = @_mes and datepart(yyyy, f.FAC_fecha) = @_año) and f.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura');	
			END
    END
GO

-- CIERRE CAJA MENSUAL ANUAL --  -- MODIFICADO AL 10/01 --
CREATE PROCEDURE Procedure_cierreCajaMensualAnual
    @_mes int,
    @_año int,
	@_tipo [nvarchar](200),
	@_ingresos [nvarchar](200) OUTPUT
AS
	BEGIN
		DECLARE @_iteracion int
		DECLARE @_ingresoDiario numeric(36,2)

		SET @_iteracion = @_mes - 1
		SET @_ingresos = ''

		IF(@_iteracion != 0)
			BEGIN
				IF(@_tipo = 'serPlaya')
					BEGIN
						WHILE(@_iteracion > 0)
							BEGIN
								SELECT @_ingresoDiario = cast(sum(ss.ser_costo*slf.lin_fac_cantidad) as numeric(36,2))
								FROM FACTURA sf, LINEA_FACTURA slf, SERVICIO ss, RESERVA_SERVICIO srs, HORARIO sh
								WHERE slf.FK_factura = sf.FAC_id and sf.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and (datepart(mm,sf.FAC_fecha) = @_iteracion and datepart(yyyy, sf.FAC_fecha) = @_año) and slf.FK_reserva_servicio = srs.RES_SER_id and srs.FK_horario = sh.HOR_id and sh.FK_servicio = ss.SER_id

								IF(@_ingresoDiario is not null)
									SET @_ingresos = concat(concat(@_ingresos,cast(@_ingresoDiario as [nvarchar](200))),'$')
								ELSE
									SET @_ingresos = concat(concat(@_ingresos,'x'),'$')
								SET @_iteracion = @_iteracion - 1
							END
					END
				ELSE IF(@_tipo = 'serPuestos')
					BEGIN
						WHILE(@_iteracion > 0)
							BEGIN
								SELECT @_ingresoDiario = cast(sum(sp.PUE_precio*slf.LIN_FAC_cantidad) as numeric(36,2))
								FROM FACTURA sf, LINEA_FACTURA slf, PUESTO sp, RESERVA_PUESTO srp
								WHERE slf.FK_factura = sf.FAC_id and sf.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and (datepart(mm,sf.FAC_fecha) = @_iteracion and datepart(yyyy, sf.FAC_fecha) = @_año) and slf.FK_reserva_puesto = srp.RES_PUE_id and srp.FK_puestoColumna = sp.PUE_columna and srp.FK_puestoFila = sp.PUE_fila and srp.FK_playa = sp.FK_playa and srp.FK_inventario = sp.FK_inventario

								IF(@_ingresoDiario is not null)
									SET @_ingresos = concat(concat(@_ingresos,cast(@_ingresoDiario as [nvarchar](200))),'$')
								ELSE
									SET @_ingresos = concat(concat(@_ingresos,'x'),'$')
								SET @_iteracion = @_iteracion - 1
							END
					END
				ELSE IF(@_tipo = 'serEstacionamiento')
					BEGIN
						WHILE(@_iteracion > 0)
							BEGIN
								SELECT @_ingresoDiario = cast(round(sum(datediff(MI, st.TIC_fechaEntrada, st.TIC_fechaSalida)/60.0*se.EST_tarifa*slf.LIN_FAC_cantidad),2) as numeric(36,2))
								FROM FACTURA sf, LINEA_FACTURA slf, TICKET st, ESTACIONAMIENTO se
								WHERE slf.FK_factura = sf.FAC_id and sf.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and (datepart(mm,sf.FAC_fecha) = @_iteracion and datepart(yyyy, sf.FAC_fecha) = @_año) and slf.FK_ticket = st.TIC_id and slf.FK_estacionamiento = st.FK_estacionamiento and st.FK_estacionamiento = se.est_id

								IF(@_ingresoDiario is not null)
									SET @_ingresos = concat(concat(@_ingresos,cast(@_ingresoDiario as [nvarchar](200))),'$')
								ELSE
									SET @_ingresos = concat(concat(@_ingresos,'x'),'$')
								SET @_iteracion = @_iteracion - 1
							END
					END
				ELSE IF(@_tipo = 'serRestaurante')
					BEGIN
						WHILE(@_iteracion > 0)
							BEGIN
								SELECT @_ingresoDiario = cast(round(sum(sp.PLA_precio*slf.LIN_FAC_cantidad),2) as numeric(36,2))
								FROM FACTURA sf, LINEA_FACTURA slf, PLATO sp
								WHERE slf.FK_factura = sf.FAC_id and sf.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura') and (datepart(mm,sf.FAC_fecha) = @_iteracion and datepart(yyyy, sf.FAC_fecha) = @_año) and slf.FK_plato = sp.PLA_id

								IF(@_ingresoDiario is not null)
									SET @_ingresos = concat(concat(@_ingresos,cast(@_ingresoDiario as [nvarchar](200))),'$')
								ELSE
									SET @_ingresos = concat(concat(@_ingresos,'x'),'$')
								SET @_iteracion = @_iteracion - 1
							END
					END
				ELSE
					BEGIN
						WHILE(@_iteracion > 0)
							BEGIN
								SELECT @_ingresoDiario = cast(sum(sf.FAC_subtotal) as numeric(36,2))
								FROM FACTURA sf
								WHERE (datepart(mm,sf.FAC_fecha) = @_iteracion and datepart(yyyy, sf.FAC_fecha) = @_año) and sf.FK_estado = (SELECT es.EST_id FROM ESTADO es WHERE es.EST_nombre = 'Facturada' and es.EST_pertenece = 'Factura')

								IF(@_ingresoDiario is not null)
									SET @_ingresos = concat(concat(@_ingresos,cast(@_ingresoDiario as [nvarchar](200))),'$')
								ELSE
									SET @_ingresos = concat(concat(@_ingresos,'x'),'$')
								SET @_iteracion = @_iteracion - 1
							END
					END
			END
	END	
GO


-- GESTION/CONSULTA FACTURA --  --AGREGADO EL 10/01--
CREATE PROCEDURE Procedure_consultarFacturas
	@_busqueda [nvarchar] (100),
	@_estado [nvarchar] (100)
	
AS

    IF(@_estado = '1')
        BEGIN
            SET @_estado = 'Facturada';
        END
    ELSE
        BEGIN
            SET @_estado = 'No Facturada';
        END

    BEGIN

        SELECT F.FAC_id as Nro_Factura, USU_correo as Cliente, Convert(Char(10), F.FAC_fecha,105) as Fecha, F.FAC_total as Total 
        FROM FACTURA as F, USUARIO, ESTADO
        WHERE FK_usuario = USU_id AND F.fk_estado = EST_id AND EST_pertenece = 'Factura' AND  EST_nombre = @_estado AND
        (( UPPER(USU_correo) LIKE UPPER(@_busqueda) + '%') 
        OR ( UPPER(USU_correo) LIKE '%' + UPPER(@_busqueda))
        OR ( UPPER(USU_correo) LIKE '%' + UPPER(@_busqueda) + '%'))

    END;
go

-- ELIMINAR FACTURA -- --AGREGADO EL 10/01--
CREATE PROCEDURE Procedure_eliminarFactura
	@_nroFactura int
	
AS

    BEGIN

        DELETE FROM LINEA_FACTURA WHERE fk_factura = @_nroFactura;
    
        DELETE FROM FACTURA WHERE FAC_id = @_nroFactura;

        IF (@@ERROR = 0)
            return 1;
        ELSE
            return 0;

    END;
go

-- CONSULTA DATOS DE FACTURA --   -- AGREGADO 11/01 --
CREATE PROCEDURE Procedure_datosFactura
	@_nroFactura int
	
AS

    BEGIN

        SELECT Convert(Char(10), FAC_fecha,105) as Fecha, FAC_subtotal as SubTotal, FAC_total as Total
		FROM FACTURA
		WHERE FAC_id = @_nroFactura 

    END;
go

-- CONSULTA DATOS CLIENTE POR FACTURA --   -- AGREGADO 11/01 --
CREATE PROCEDURE Procedure_datosClienteFactura
	@_nroFactura int
	
AS

    BEGIN

        SELECT PER_docIdentidad as DocIdentidad, (PER_primerNombre + ' ' + PER_segundoNombre) as Nombre, (PER_primerApellido + ' ' + PER_segundoApellido) as Apellido
        FROM USUARIO, FACTURA, PERSONA
        WHERE FAC_id = @_nroFactura AND FK_usuario = USU_id AND fk_persona = PER_id

    END;
go

-- CONSULTA DE LINEASFACTURA DE FACTURA -- -- MODIFICADO 11/01 --
CREATE PROCEDURE Procedure_consultarLineaFactura
    @_nroFactura int

AS

    BEGIN

        SELECT E.EST_nombre as Tipo, P.PLA_nombre as NombreItem, LF.LIN_FAC_cantidad AS Cantidad, cast((P.PLA_precio * LF.LIN_FAC_cantidad) as numeric (36,2)) as Precio, F.FAC_total AS Total
        FROM LINEA_FACTURA LF, FACTURA F, ESTADO E, PLATO P
        WHERE FAC_id = @_nroFactura  AND FK_factura = FAC_id AND LF.FK_plato = p.PLA_id AND lf.FK_estado = E.EST_id AND E.EST_pertenece = 'LineaFactura'
        UNION
        SELECT E.EST_nombre as Tipo, ('Placa: '+ T.TIC_placa) as NombreItem, LF.LIN_FAC_cantidad AS Cantidad, cast((((DATEDIFF(MINUTE, Convert(Datetime, T.TIC_fechaEntrada,120), Convert(Datetime, T.TIC_fechaSalida,120)) * ES.EST_tarifa) / 60 ) * LF.LIN_FAC_cantidad) as numeric (36,2)) as Precio, F.FAC_total AS Total
        FROM LINEA_FACTURA LF, FACTURA F, ESTADO E, TICKET T, ESTACIONAMIENTO ES
        WHERE FAC_id = @_nroFactura AND FK_factura = FAC_id AND LF.FK_ticket = T.TIC_id AND T.FK_estacionamiento = ES.EST_id  AND lf.FK_estado = E.EST_id AND E.EST_pertenece = 'LineaFactura'
        UNION 
        SELECT  DISTINCT('Reserva Puesto: '+ CAST(PUE_fila as Varchar(10)) + '-' + CAST(PUE_columna as Varchar(10))) as NombreItem, E.EST_nombre as Tipo,LF.LIN_FAC_cantidad AS Cantidad, cast((P.PUE_precio * LF.LIN_FAC_cantidad) as numeric (36,2)) AS Precio, F.FAC_total AS Total
        FROM LINEA_FACTURA LF, FACTURA F, ESTADO E, RESERVA_PUESTO RP, PUESTO P, INVENTARIO I, PLAYA PL
        WHERE FAC_id = @_nroFactura AND FK_factura = FAC_id AND LF.FK_reserva_puesto = RP.RES_PUE_id AND RP.FK_puestoFila = P.PUE_fila AND RP.FK_puestoColumna = P.PUE_columna AND P.FK_inventario = I.INV_id AND I.FK_playa = PL.PLA_id AND lf.FK_estado = E.EST_id AND E.EST_pertenece = 'LineaFactura'
        UNION
        SELECT  ('Reserva: '+ S.SER_nombre) as NombreItem, E.EST_nombre as Tipo, RS.RES_SER_cantidad AS Cantidad, cast(((ABS(DATEDIFF(MINUTE, Convert(Datetime, RS.RES_SER_horaInicio,120), Convert(Datetime, RS.RES_SER_horaFin ,120)) * S.SER_costo) / 60 ) * RS.RES_SER_cantidad) as numeric (36,2)) as Precio, F.FAC_total AS Total
        FROM LINEA_FACTURA LF, FACTURA F, ESTADO E, RESERVA_SERVICIO RS, SERVICIO S, HORARIO H
        WHERE FAC_id = @_nroFactura AND FK_factura = FAC_id AND LF.FK_reserva_servicio = RS.RES_SER_id AND RS.FK_horario = H.HOR_id AND H.FK_servicio = S.SER_id AND lf.FK_estado = E.EST_id AND E.EST_pertenece = 'LineaFactura'

    END;
go


commit transaction;
go