---------------------------------  PRODEDURES  ----------------------------------------------------
use MACARRO
go
begin transaction;
go
-----------------------PROCEDIMIENTO PARA INSERTAR UN PAGO---------------------------
CREATE PROCEDURE Procedure_agregarPago
	@_pagId         [int]           ,
	@_plaMonto      [float] (53)    ,
	@_pagFecha      [date]          ,
	@_fkMembresia	[int]           
	   
AS
 BEGIN
	INSERT INTO PAGO(PAG_id,PAG_monto,PAG_fecha,FK_membresia)
	VALUES(@_pagId,@_plaMonto,@_pagFecha,@_fkMembresia)
 END
GO

-----------------------PROCEDIMIENTO PARA INSERTAR UNA MEMBRESIA---------------------------
CREATE PROCEDURE Procedure_insertarMembresia
	@_memId          	[int]   	,
	@_memFadmision	 	[date]		,
	@_memFvencimiento	[date]		,	
	@_memFoto		[varchar] (999)	,
	@_memEstado		[varchar] (100)	,
	@_memCosto		[float] (53)	,
	@_memDescAplicado	[float] (53)	,
	@_memTelefono		[varchar] (100)	,
	@_fkUsuario		[varchar] (100)   
AS
 BEGIN
	   INSERT INTO MEMBRESIA(MEM_id,MEM_fechaAdmision,MEM_fechaVencimiento,MEM_foto,MEM_estado,MEM_costo,MEM_descAplicado,MEM_telefono,FK_usuario)
	   VALUES(@_memId,@_memFadmision,@_memFvencimiento,@_memFoto,@_memEstado,@_memCosto,@_memDescAplicado,@_memTelefono,@_fkUsuario)
 END
GO

-----------------------PROCEDIMIENTO PARA MODIFICAR UNA MEMBRESIA---------------------------
CREATE PROCEDURE Procedure_modificarMembresia
	@_memId          [int], 
	@_memStatus      [varchar] (15),
	@_memDescuento   [FLOAT] (8)
AS
	UPDATE MEMBRESIA 
	SET
	   MEM_descAplicado = @_memDescuento,
	   MEM_estado = @_memStatus
	   
	WHERE 
	   MEM_id          = @_memId ; 

GO

-----------------------PROCEDIMIENTO PARA CONSULTAR LISTA DE MEMBRESIA ---------------------------------------

CREATE PROCEDURE Procedure_consultarMembresia
	@_memId		[int]
AS
  BEGIN
	   SELECT MEM_id, MEM_fechaAdmision, MEM_fechaVencimiento, MEM_telefono, MEM_estado, MEM_descAplicado,
			  PER_docIdentidad, PER_primerNombre, PER_primerApellido, PER_fechaNacimiento,
			  direccion.LUG_nombre, ciudad.LUG_nombre, estado.LUG_nombre, pais.LUG_nombre 
			  
	   FROM MEMBRESIA 
	   INNER JOIN USUARIO ON FK_usuario = USU_correo
	   INNER JOIN PERSONA ON FK_persona = PER_docIdentidad
	   INNER JOIN LUGAR direccion ON direccion.FK_lugar = direccion.LUG_id
	   INNER JOIN LUGAR ciudad ON ciudad.FK_lugar = ciudad.LUG_id
	   INNER JOIN LUGAR estado ON estado.FK_lugar = estado.LUG_id
	   INNER JOIN LUGAR pais ON pais.FK_lugar = pais.LUG_id
	   
	   WHERE  MEM_id = @_memId
 
  END

GO


-----------------------PROCEDIMIENTO PARA CONSULTAR LISTA DE MEMBRESIA POR CEDULA--------------------------------------- 01-12-2014 10:10pm

CREATE PROCEDURE Procedure_consultarMembresiaCedula
	@_perId		[int]
AS
  BEGIN
	   SELECT MEM_id, MEM_estado, PER_docIdentidad, PER_primerNombre, PER_primerApellido 
			  
	   FROM MEMBRESIA 
	   INNER JOIN USUARIO ON FK_usuario = USU_correo
	   INNER JOIN PERSONA ON FK_persona = PER_docIdentidad
	   
	   WHERE  PER_docIdentidad = @_perId
 
  END

GO

-----------------------PROCEDIMIENTO PARA CONSULTAR LISTA DE MEMBRESIA POR CARNET---------------------------------------01-12-2014 10:10pm

CREATE PROCEDURE Procedure_consultarMembresiaCarnet
	@_memId		[int]
AS
  BEGIN
	   SELECT MEM_id, MEM_estado, PER_docIdentidad, PER_primerNombre, PER_primerApellido 
			  
	   FROM MEMBRESIA 
	   INNER JOIN USUARIO ON FK_usuario = USU_correo
	   INNER JOIN PERSONA ON FK_persona = PER_docIdentidad
	   
	   WHERE  MEM_id = @_memId
 
  END

GO


-----------------------PROCEDIMIENTO PARA CONSULTAR LISTA DE MEMBRESIA POR GENERAL---------------------------------------01-12-2014 10:10pm

CREATE PROCEDURE Procedure_consultarMembresiaGeneral
	@_memId		[int]
AS
  BEGIN
	   SELECT MEM_id, MEM_estado, PER_docIdentidad, PER_primerNombre, PER_primerApellido 
			  
	   FROM MEMBRESIA 
	   INNER JOIN USUARIO ON FK_usuario = USU_correo
	   INNER JOIN PERSONA ON FK_persona = PER_docIdentidad
	   ORDER BY PER_primerApellido;
	   
 
  END

GO

-----------------------PROCEDIMIENTO PARA CONSULTAR LISTA DE MEMBRESIA POR USUARIO---------------------------------------02-12-2014 12:02am
CREATE PROCEDURE Procedure_consultarMembresiaUsuario
	@_usuId		[VARCHAR]
AS
  BEGIN
	   SELECT MEM_id, MEM_fechaAdmision, MEM_fechaVencimiento, MEM_telefono, MEM_estado, MEM_descAplicado,
			  PER_docIdentidad, PER_primerNombre, PER_primerApellido, PER_fechaNacimiento,
			  direccion.LUG_nombre, ciudad.LUG_nombre, estado.LUG_nombre, pais.LUG_nombre 
			  
	   FROM MEMBRESIA 
	   INNER JOIN USUARIO ON FK_usuario = USU_correo
	   INNER JOIN PERSONA ON FK_persona = PER_docIdentidad
	   INNER JOIN LUGAR direccion ON direccion.FK_lugar = direccion.LUG_id
	   INNER JOIN LUGAR ciudad ON ciudad.FK_lugar = ciudad.LUG_id
	   INNER JOIN LUGAR estado ON estado.FK_lugar = estado.LUG_id
	   INNER JOIN LUGAR pais ON pais.FK_lugar = pais.LUG_id
	   
	   WHERE  USU_correo = @_usuId
 
  END

GO


--------------------------------------------------INSERTS DE MEMBRESIA----------------------------------------------------
INSERT INTO MEMBRESIA(MEM_id,MEM_fechaAdmision,MEM_fechaVencimiento,MEM_foto,MEM_estado,MEM_costo,MEM_descAplicado,MEM_telefono,FK_usuario)
	   VALUES( 1,'10-11-2013','10-11-2014','Ruta','Desactivado',1500,0,'04264058285','alejandroVieira@gmail.com');

INSERT INTO MEMBRESIA(MEM_id,MEM_fechaAdmision,MEM_fechaVencimiento,MEM_foto,MEM_estado,MEM_costo,MEM_descAplicado,MEM_telefono,FK_usuario)
	   VALUES(2,'09-12-2013','09-12-2014','Ruta','Desactivado',2000,0,'04122567854','amandaRodriguez@gmail.com');
INSERT INTO MEMBRESIA(MEM_id,MEM_fechaAdmision,MEM_fechaVencimiento,MEM_foto,MEM_estado,MEM_costo,MEM_descAplicado,MEM_telefono,FK_usuario)
	   VALUES(3,'08-13-2014','08-13-2015','Ruta','Activado',2000,0,'04122367954','andreaPaola@gmail.com');
INSERT INTO MEMBRESIA(MEM_id,MEM_fechaAdmision,MEM_fechaVencimiento,MEM_foto,MEM_estado,MEM_costo,MEM_descAplicado,MEM_telefono,FK_usuario)
	   VALUES(4,'07-14-2014','07-14-2015','Ruta','Activado',2500,0,'04122767953','gabrielGonzales@gmail.com');
INSERT INTO MEMBRESIA(MEM_id,MEM_fechaAdmision,MEM_fechaVencimiento,MEM_foto,MEM_estado,MEM_costo,MEM_descAplicado,MEM_telefono,FK_usuario)
	   VALUES(5,'06-15-2014','06-15-2015','Ruta','Activado',3000,0,'04122767943','pabloWestphal@gmail.com');

--------------------------------------------------INSERTS DE PAGO----------------------------------------------------
EXEC Procedure_agregarPago 1,1500,'10-11-2013', 1;
EXEC Procedure_agregarPago 2,2000,'09-12-2013', 2;
EXEC Procedure_agregarPago 3,2000,'08-13-2014', 3;
EXEC Procedure_agregarPago 4,2500,'07-14-2014', 4;
EXEC Procedure_agregarPago 5,3000,'06-15-2014', 5;

commit transaction;
go