use MACARRO
go
begin transaction;
go

---------SEQUENCIA PERSONA ------------
CREATE SEQUENCE PERSONA_SEQ
    START WITH 1
    INCREMENT BY 1;
GO

---------SEQUENCIA USUARIO------------

CREATE SEQUENCE USUARIO_SEQ
    START WITH 1
    INCREMENT BY 1;
GO

---------SEQUENCIA ROL------------

CREATE SEQUENCE ROL_SEQ
    START WITH 1
    INCREMENT BY 1;
GO

---------SEQUENCIA SERVICIO------------

CREATE SEQUENCE secuenciaIdServicio
AS 
	int
	START WITH 50
	INCREMENT BY 1;
go

---------SEQUENCIA CATEGORIA------------
CREATE SEQUENCE secuenciaIdCategoria
AS 
	int
	START WITH 50
	INCREMENT BY 1;
go

---------SEQUENCIA HORARIO------------

CREATE SEQUENCE secuenciaIdHorario
AS 
	int
	START WITH 50
	INCREMENT BY 1;
go

---------SEQUENCIA SECCIÓN------------
CREATE SEQUENCE SEQ_SECCION 
 START WITH 1
 INCREMENT BY 1
GO

---------SEQUENCIA PLATO------------
CREATE SEQUENCE SEQ_PLATO 
 START WITH 1
 INCREMENT BY 1
GO

----------SECUENCIA TICKET-----------

CREATE SEQUENCE TICKET_SEQ
    START WITH 1
    INCREMENT BY 1;
GO

----------SECUENCIA FACTURA-----------
CREATE SEQUENCE FAC_SEQ
    START WITH 1
    INCREMENT BY 1;
GO

-------SECUENCIA LINEA FACTURA -------
CREATE SEQUENCE LINEAFAC_SEQ
	START WITH 1
	INCREMENT BY 1;
GO

--------Secuencial de la Tabla Playa--------------

CREATE SEQUENCE secuenciaTablaPlaya
    START WITH 1
    INCREMENT BY 1 ;
GO

--------Secuencial de la Tabla Inventario--------------

CREATE SEQUENCE secuenciaTablaInventario
    START WITH 1
    INCREMENT BY 1 ;
GO

-------SECUENCIA MEMBRESÍA -------
CREATE SEQUENCE secuenciaIdMembresia
AS 
	int
	START WITH 1
	INCREMENT BY 1;
	
go

-------SECUENCIA PAGO -------
CREATE SEQUENCE secuenciaIdPago
AS 
	int
	START WITH 1
	INCREMENT BY 1;
 
go

-------SECUENCIA TARJETA -------
CREATE SEQUENCE secuenciaIdTarjeta
AS 
	int
	START WITH 1
	INCREMENT BY 1;
 
go

-------SECUENCIA RESERVA -------
CREATE SEQUENCE RESERVA_SEQ
AS
    INT
    START WITH 50
    INCREMENT BY 1;
GO

-------SECUENCIA RESERVA SERVICIO -------
CREATE SEQUENCE RESERVA_SERVICIO_SEQ
AS 
	int
	START WITH 50
	INCREMENT BY 1;
GO

-------SECUENCIA RESERVA PUESTO -------
CREATE SEQUENCE RESERVA_PUESTO_SEQ
AS 
	int
	START WITH 50
	INCREMENT BY 1;
GO

commit transaction;
go