---------------------------------  PROCEDURES  ----------------------------------------------------
use MACARRO
go
begin transaction;

go
--------------------------------------------------SECUENCIAS---------------------------------------------------------
CREATE SEQUENCE secuenciaIdMembresia
AS 
	int
	START WITH 1
	INCREMENT BY 1;
	
go

CREATE SEQUENCE secuenciaIdPago
AS 
	int
	START WITH 1
	INCREMENT BY 1;
 
go

-----------------------PROCEDIMIENTO PARA INSERTAR UN PAGO---------------------------
CREATE PROCEDURE Procedure_agregarPago
	
	@_plaMonto      [float] (53)	,
	@_pagFecha      [datetime]	,
	@_fkMembresia [int]
	   
AS
 BEGIN
	
	INSERT INTO PAGO(PAG_id,PAG_monto,PAG_fecha,FK_membresia)
	VALUES(NEXT VALUE FOR secuenciaIdPago, @_plaMonto,@_pagFecha,@_fkMembresia)
 END
GO

-----------------------PROCEDIMIENTO PARA INSERTAR UNA MEMBRESIA---------------------------
CREATE PROCEDURE Procedure_insertarMembresia
	
	@_memFadmision	[datetime],
	@_memFVencimiento	[datetime],
	@_memFoto	[varchar] (999),
	/*@_memCosto	[float] (53),*/
	@_memDescAplicado	[float] (53),
	@_memTelefono	[varchar] (100),
	@_fkUsuario		[int]
AS
	BEGIN
		DECLARE @_estado int;
		DECLARE @_costo float;

		SET @_estado = (SELECT EST_id FROM ESTADO 
			WHERE EST_nombre = 'Activado' AND EST_pertenece='General');
		SET @_costo = (SELECT COS_MEM_COSTO as float from COSTO_MEMBRESIA);

	   INSERT INTO MEMBRESIA(MEM_Id,MEM_fechaAdmision,MEM_fechaVencimiento,MEM_foto,MEM_costo,MEM_descAplicado,MEM_telefono,FK_estado,FK_usuario)
	   VALUES (NEXT VALUE FOR secuenciaIdMembresia,@_memFadmision,@_memFvencimiento,@_memFoto,@_costo,@_memDescAplicado,@_memTelefono,@_estado,@_fkUsuario)
 END
GO

-----------------------PROCEDIMIENTO PARA MODIFICAR UNA MEMBRESIA---------------------------
CREATE PROCEDURE Procedure_modificarMembresia
	@_memId	[int], 
	@_memStatus	[varchar] (15),
	@_memDescuento	[FLOAT] (8)
AS
	BEGIN
		DECLARE @_estado int;		

		SET @_estado = (SELECT EST_id FROM ESTADO 
			WHERE EST_nombre = @_memStatus AND EST_pertenece='General');
	
		UPDATE MEMBRESIA 
		SET
		   MEM_descAplicado = @_memDescuento,
		   FK_estado = @_estado
		WHERE 
		   MEM_id = @_memId ; 
	END
GO

-----------------------PROCEDIMIENTO PARA MODIFICAR LOS COSTOS DE LAS MEMBRESIAS DEL A�O ---------------------------
CREATE PROCEDURE Procedure_modificarCostoMembresia	
	@_cos_mem_Costo       [float]
AS
	UPDATE COSTO_MEMBRESIA 
	SET COS_MEM_costo = @_cos_mem_Costo

GO

--------------- PROCEDIMIENTO PARA CONSULTAR DETALLE DE MEMBRESIA Y DE PAGOS (PARTE 1)-------------------------------

CREATE PROCEDURE Procedure_consultarDetalleMembresia
	@_memId int
AS
	BEGIN
		SELECT m.MEM_id, m.MEM_telefono, m.MEM_descAplicado, m.MEM_fechaAdmision, m.MEM_fechaVencimiento,
		edo_activado.EST_nombre as estadoMembresia,u.USU_correo,p.PER_primerNombre, p.PER_segundoNombre, 
		p.PER_primerApellido, p.PER_segundoApellido,p.PER_docIdentidad, p.PER_fechaNacimiento,
		edo_identidad.EST_nombre as tipoDocumentoIdentidad, m.MEM_foto
		FROM MEMBRESIA m, USUARIO u, PERSONA p, ESTADO edo_activado, ESTADO edo_identidad   
		WHERE MEM_id = @_memId and m.FK_usuario = u.USU_id and
		u.FK_persona = p.PER_id and edo_activado.EST_id = m.FK_estado and
		edo_identidad.EST_id = p.FK_estadoTipoDoc;
	END
  
GO

--------------- PROCEDIMIENTO PARA CONSULTAR DETALLE DE MEMBRESIA Y DE PAGOS (PARTE 2)-------------------------------
CREATE PROCEDURE Procedure_membresiaPagos
	@_memId int
AS
	BEGIN
		SELECT  p.PAG_id,p.PAG_fecha,p.PAG_monto
		from PAGO p where p.FK_membresia = @_memId
	END
GO

  
-----------------------PROCEDIMIENTO PARA CONSULTAR COSTO DE MEMBRESIA GENERAL---------------------------------------
CREATE PROCEDURE Procedure_consultarCostoMembresia
	@_cos_mem_Id [float]
AS
  BEGIN
	   SELECT COS_MEM_costo
	   FROM COSTO_MEMBRESIA 
	   WHERE COS_MEM_id = @_cos_mem_Id
  END
GO
-----------------------funcion split--------------------------------------------------------------------------------
CREATE FUNCTION fnSplitString
( 
    @string NVARCHAR(MAX), 
    @delimiter CHAR(1) 
) 
RETURNS @output TABLE(splitdata NVARCHAR(MAX) 
) 
BEGIN 
    DECLARE @start INT, @end INT 
    SELECT @start = 1, @end = CHARINDEX(@delimiter, @string) 
    WHILE @start < LEN(@string) + 1 BEGIN 
        IF @end = 0  
            SET @end = LEN(@string) + 1
       
        INSERT INTO @output (splitdata)  
        VALUES(SUBSTRING(@string, @start, @end - @start)) 
        SET @start = @end + 1 
        SET @end = CHARINDEX(@delimiter, @string, @start)
        
    END 
    RETURN 
END
go
-----------------------PROCEDIMIENTO BUSCADOR EN EL GRIDVIEW DE MEMBRESIA-------------------------------------------
CREATE PROCEDURE Procedure_consultarMembresias
	@generico varchar (150)
AS
  BEGIN  	
	declare @_consultaEstatica varchar(700);	

	set @_consultaEstatica = 'select mem.MEM_id,mem.MEM_fechaAdmision,mem.MEM_fechaVencimiento, ';
	set @_consultaEstatica += 'mem.MEM_descAplicado, mem.MEM_costo, p.PER_primerNombre, p.PER_primerApellido, ';
	set @_consultaEstatica += 'p.PER_segundoNombre,p.PER_segundoApellido,p.PER_docIdentidad, ';
	set @_consultaEstatica += 'estTD.EST_nombre as tipoDocumento, est.EST_nombre as estadoMembresia ';
	set @_consultaEstatica += 'from MEMBRESIA mem, USUARIO u, PERSONA p, ESTADO est, ESTADO estTD ';
	set @_consultaEstatica += 'where mem.FK_estado = est.EST_id and mem.FK_usuario = u.USU_id and ';
	set @_consultaEstatica += 'u.FK_persona=p.PER_id and estTD.EST_id=p.FK_estadoTipoDoc ';

	if (@generico!='')
	begin
		declare @_cadena varchar(150);
		declare @_consulta varchar(MAX);
		declare @_flagInters int;
		declare @_ciclar cursor;
		set @_ciclar = cursor for select splitdata from fnSplitString(@generico,'|');
		set @_flagInters=0;
		set @_consulta='';
		open @_ciclar;

		fetch next from @_ciclar into @_cadena;
		while @@FETCH_STATUS = 0
		begin
			set @_cadena = LOWER(@_cadena);

			if @_flagInters=1
				set @_consulta += char(10)+'intersect'+char(10);
		
			set @_consulta += @_consultaEstatica;
			set @_consulta += 'and (lower(p.PER_primerNombre) like '+ char(39) + '%' + @_cadena + '%' + char(39) + ' or ';
			set @_consulta += 'lower(p.PER_primerApellido) like '+ char(39) + '%' + @_cadena + '%' + char(39) + ' or ';
			set @_consulta += 'lower(p.PER_segundoNombre) like '+ char(39) + '%' + @_cadena + '%' + char(39) + ' or ';
			set @_consulta += 'lower(p.PER_segundoApellido) like '+ char(39) + '%' + @_cadena + '%' + char(39) + ' or ';
			set @_consulta += 'lower(p.PER_docIdentidad) like '+ char(39) + '%' + @_cadena + '%' + char(39) + ' ) ';

			set @_flagInters=1;
			fetch next from @_ciclar into @_cadena;
		end

		close @_ciclar;
		deallocate @_ciclar;
		exec (@_consulta);
	end
	else
		exec (@_consultaEstatica);
  END
  go


 -----------------------PROCEDIMIENTO BUSCADOR DE MEMBRESIAS POR ID-----------------------------------------------
 CREATE PROCEDURE Procedure_consultarMembresiasId
	@_id [int]
as
	begin
		select mem.MEM_id,mem.MEM_fechaAdmision,mem.MEM_fechaVencimiento, 
		mem.MEM_descAplicado, mem.MEM_costo, p.PER_primerNombre, p.PER_primerApellido,
		p.PER_segundoNombre,p.PER_segundoApellido,p.PER_docIdentidad,
		estTD.EST_nombre as tipoDocumento, est.EST_nombre as estadoMembresia 
		from MEMBRESIA mem, USUARIO u, PERSONA p, ESTADO est, ESTADO estTD
		where mem.FK_estado = est.EST_id and mem.FK_usuario = u.USU_id and
		u.FK_persona=p.PER_id and estTD.EST_id=p.FK_estadoTipoDoc and mem.MEM_id=@_id
	end
go

-----------------------PROCEDIMIENTO BUSCADOR EN EL GRIDVIEW DE PAGOS-----------------------------------------------
CREATE PROCEDURE Procedure_consultarPagos
	@generico varchar (150)
AS
  BEGIN
	declare @_consultaEstatica varchar(700);

	set @_consultaEstatica = 'select pag.PAG_id, pag.PAG_monto, pag.PAG_fecha, pag.FK_membresia, ';
	set @_consultaEstatica += 'p.PER_primerNombre, p.PER_primerApellido, ';
	set @_consultaEstatica += 'p.PER_segundoNombre,p.PER_segundoApellido,p.PER_docIdentidad, ';
	set @_consultaEstatica += 'estTD.EST_nombre as tipoDocumento ';
	set @_consultaEstatica += 'from MEMBRESIA mem, USUARIO u, PERSONA p, ESTADO estTD, PAGO pag ';
	set @_consultaEstatica += 'where mem.FK_usuario = u.USU_id and u.FK_persona=p.PER_id and ';				
	set @_consultaEstatica += 'estTD.EST_id=p.FK_estadoTipoDoc and ';
	set @_consultaEstatica += 'pag.FK_membresia=mem.MEM_id ';

	if (@generico!='')
	begin
		declare @_cadena varchar(150);
		declare @_consulta varchar(MAX);
		declare @_flagInters int;
		declare @_ciclar cursor;
		set @_ciclar = cursor for select splitdata from fnSplitString(@generico,'|');
	

		set @_flagInters=0;
		set @_consulta='';
		open @_ciclar;

		fetch next from @_ciclar into @_cadena;
		while @@FETCH_STATUS = 0
		begin
			set @_cadena = LOWER(@_cadena);

			if @_flagInters=1
				set @_consulta += char(10)+'intersect'+char(10);

			set @_consulta += @_consultaEstatica;
			set @_consulta += 'and (lower(p.PER_primerNombre) like '+ char(39) + '%' + @_cadena + '%' + char(39) + ' or ';
			set @_consulta += 'lower(p.PER_primerApellido) like '+ char(39) + '%' + @_cadena + '%' + char(39) + ' or ';
			set @_consulta += 'lower(p.PER_segundoNombre) like '+ char(39) + '%' + @_cadena + '%' + char(39) + ' or ';
			set @_consulta += 'lower(p.PER_segundoApellido) like '+ char(39) + '%' + @_cadena + '%' + char(39) + ' or ';
			set @_consulta += 'lower(p.PER_docIdentidad) like '+ char(39) + '%' + @_cadena + '%' + char(39) + ' ) ';

			set @_flagInters=1;
			fetch next from @_ciclar into @_cadena;
		end

		close @_ciclar;
		deallocate @_ciclar;
		exec (@_consulta);
	end
	else
		exec(@_consultaEstatica);
  END
 go

 -----------------------PROCEDIMIENTO BUSCADOR DE PAGOS POR ID-----------------------------------------------
CREATE PROCEDURE Procedure_consultarPagosId
	@_id [int]
as
	begin

		select pag.PAG_id, pag.PAG_monto, pag.PAG_fecha, pag.FK_membresia,
		p.PER_primerNombre, p.PER_primerApellido,
		p.PER_segundoNombre,p.PER_segundoApellido,p.PER_docIdentidad,
		estTD.EST_nombre as tipoDocumento
		from MEMBRESIA mem, USUARIO u, PERSONA p, ESTADO estTD, PAGO pag
		where mem.FK_usuario = u.USU_id and u.FK_persona=p.PER_id and 
		estTD.EST_id=p.FK_estadoTipoDoc and 
		pag.FK_membresia=mem.MEM_id and pag.PAG_id=@_id
	end
go
------------------------------------------------------INSERT DE COSTO MEMBRESIA----------------------------------------
INSERT INTO COSTO_MEMBRESIA(COS_MEM_id,COS_MEM_costo)
		VALUES(1,20000);

--------------------------------------------------INSERTS DE MEMBRESIA----------------------------------------------------

EXEC Procedure_insertarMembresia '2013-10-11','2014-10-11','Ruta',0,'04264058285',1;
EXEC Procedure_insertarMembresia '2013-09-12','2014-09-12','Ruta',0,'04122367957',2;
EXEC Procedure_insertarMembresia '2014-08-13','2015-08-13','Ruta',0,'04122367954',3;
EXEC Procedure_insertarMembresia '2014-07-14','2015-07-14','Ruta',0,'04122767953',4;
EXEC Procedure_insertarMembresia '2014-06-15','2014-06-15','Ruta',0,'04122767943',5;

--------------------------------------------------INSERTS DE PAGO----------------------------------------------------

EXEC Procedure_agregarPago 20000,'2013-10-11', 1;
EXEC Procedure_agregarPago 20000,'2013-09-12', 2;
EXEC Procedure_agregarPago 20000,'2014-08-13', 3;
EXEC Procedure_agregarPago 20000,'2014-07-14', 4;
EXEC Procedure_agregarPago 20000,'2014-06-15', 5;

/*
INSERT INTO MEMBRESIA(MEM_id,MEM_fechaAdmision,MEM_fechaVencimiento,MEM_foto,MEM_costo,MEM_descAplicado,MEM_telefono,FK_estado,FK_usuario)
	   VALUES( 1,'2014-12-22','10-11-2014','Ruta',1500,0,'04264058285',1,1);

select	CONVERT(varchar(10),MEM_fechaAdmision,103) from MEMBRESIA

exec Procedure_consultarMembresias 'u|n|e|o'
exec Procedure_consultarPagos 'u|n|e|o'

*/

commit transaction;
go