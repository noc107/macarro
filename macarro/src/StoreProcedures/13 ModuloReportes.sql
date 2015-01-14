use MACARRO
go
begin transaction;
go
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-------CONSULTAR USUARIOS ACTIVOS E INACTIVOS-----------------
CREATE PROCEDURE ReporteUsuarioActivoInactivo

AS

  BEGIN
  
          select (select count(*) from USUARIO u where u.FK_estado = 1) 
          as Activos , (select count(*) from USUARIO u 
          where u.FK_estado = 2) as Inactivos;

  END

GO

------------CONSULTAR ROLES, CANTIDAD USUARIOS EN SISTEMA ASIGNADOS A DICHO ROL------------------

CREATE PROCEDURE ReporteRolesCantidadUsuariosAsignadosAlRol

AS

  BEGIN
  
          select count(*) as cantidad,(select r2.rol_nombre from rol r2 
          where r2.rol_id = r.rol_id) as rol
          from usuario u,usuario_rol ur,rol r
          where u.usu_id = ur.fk_usuario and ur.fk_rol = r.rol_id
          group by (r.rol_id);
	   
  END

GO

--------------------CONSULTAR PROVEEDOR, CON ITEMS VENDIDOS AL NEGOCIO Y CANTIDAD-------------------

CREATE PROCEDURE ReporteProveedorItemsVendidosYCantidad

AS

  BEGIN
  
          select (select p.pro_razonsocial from proveedor p where p.PRO_rif = pro.PRO_rif) as nombre,
		  SUM(proinv.PRO_INV_cantidad) as cantidad,i.ITE_nombre
          from proveedor pro, PROV_INVENTARIO proinv, ITEM_INVENTARIO iv,item i
          where iv.FK_item = i.ITE_id and proinv.FK_item_inventario = iv.ITE_INV_id
          and pro.PRO_id = proinv.FK_proveedor
          group by pro.PRO_rif,i.ITE_nombre;
	   
  END

GO

--------------------CONSULTAR PRODUCTO, CANTIDAD ACTUAL Y MINIMA----------------------------------------

CREATE PROCEDURE ReporteProductoCantidadActualYMinima

AS

  BEGIN
  
          select i.ite_nombre,iv.ite_inv_cantidad,iv.ite_inv_cantidadmin
          from item_inventario iv ,item i
          where i.ite_id=iv.fk_item ;
	   
  END

GO

-----------------------CONSULTAR INGRESOS POR MEMBRESIA CON FECHA------------------------------------------

CREATE PROCEDURE ReporteIngresosPorMembresiaConFecha

  @_fechaini    [datetime],
  @_fechafin    [datetime]
AS

  BEGIN
  
         select sum(p.pag_monto) as ingreso,format(p.pag_fecha,'yyyy, MM, dd')  as fecha 
         from Pago p 
         where p.pag_fecha >= @_fechaini and p.pag_fecha<= @_fechafin 
         group by p.pag_fecha ;
	   
  END
  
  GO
  
----------------CONSULTAR INGRESOS POR PUESTO DE SOMBRILLA CON FECHA------------------------------------------

CREATE PROCEDURE ReporteIngresosPorPuestoSombrillaConFecha

  @_fechaini   [datetime],
  @_fechafin   [datetime]
AS

  BEGIN
  
         select format(f.FAC_fecha,'yyyy, MM, dd') as fecha,
         sum(s.ser_costo*rs.res_ser_cantidad) as ingreso
         from factura f, linea_factura lf, servicio s, horario h, reserva_servicio rs,
         reserva r where lf.fk_reserva_servicio=rs.res_ser_id and rs.fk_horario=h.hor_id
         and s.ser_id=h.fk_servicio and lf.fk_factura=f.fac_id
         and rs.fk_reserva=r.res_id and
        (f.fac_fecha>= @_fechaini and f.fac_fecha<= @_fechafin)
         group by f.fac_fecha;
	   
  END
  
  GO
------------------------CONSULTAR INGRESOS POR PUESTO DE RESTAURANTE CON FECHA-----------------------------------

CREATE PROCEDURE ReporteIngresosPorPuestoRestauranteConFecha

  @_fechaini   [datetime],
  @_fechafin   [datetime]
AS

  BEGIN
  
        select format(f.FAC_fecha,'yyyy, MM, dd') as fecha,
        sum(p.pla_precio*lf.lin_fac_cantidad) as ingreso
        from factura f, linea_factura lf, plato p
        where p.pla_id=lf.fk_plato and lf.fk_factura=f.fac_id and
       (f.fac_fecha>= @_fechaini and f.fac_fecha<= @_fechafin)
        group by f.fac_fecha; 
	   
  END
  
  GO
 ------------------------------CONSULTAR INGRESOS POR PUESTO DE SERVICIO CON FECHA-------------------------------

CREATE PROCEDURE ReporteIngresosPorPuestoServicioConFecha

  @_fechaini   [datetime],
  @_fechafin   [datetime]
AS

  BEGIN
  
        select format(f.FAC_fecha,'yyyy, MM, dd') as fecha,
        sum(s.ser_costo*lf.lin_fac_cantidad) as ingreso
        from factura f, linea_factura lf, reserva_servicio rs, horario h, servicio s
        where lf.fk_reserva_servicio=rs.res_ser_id and rs.fk_horario=h.hor_id and s.ser_id=h.fk_servicio and lf.fk_factura=f.fac_id and
       (f.fac_fecha>= @_fechaini and f.fac_fecha<= @_fechafin)
        group by f.fac_fecha;
	   
  END
  
  GO 
  
--------------------------------CONSULTAR INGRESOS POR PUESTO DE ESTACIONAMIENTO CON FECHA-------------------------

CREATE PROCEDURE ReporteIngresosPorPuestoEstacionamientoConFecha

  @_fechaini   [datetime],
  @_fechafin   [datetime]
AS

  BEGIN
  
       select format(f.FAC_fecha,'yyyy, MM, dd') as fecha,
       sum(e.est_tarifa*DATEDIFF(mi, t.TIC_fechaEntrada,
       t.TIC_fechaSalida)) as ingreso
       from factura f, linea_factura lf, ticket t, estacionamiento e
       where lf.fk_factura=f.fac_id and t.tic_id=lf.fk_ticket
       and t.fk_estacionamiento=e.est_id and 
       (f.fac_fecha>= @_fechaini and f.fac_fecha<= @_fechafin)
       group by f.fac_fecha;
	   
  END
  
  GO   
  
------------------------------------CONSULTAR INGRESOS POR BEBIDAS CON FECHA-----------------------------------------

CREATE PROCEDURE ReporteIngresosPorBebidasConFecha

  @_fechaini   [datetime],
  @_fechafin   [datetime]
AS

  BEGIN
  
      select p.PLA_nombre, sum(lf.lin_fac_cantidad*p.pla_precio) as ingresos 
      from Plato p,linea_factura lf,seccion s,factura f
      where p.pla_id=lf.fk_plato and s.sec_id = p.fk_seccion and
      f.fac_id=lf.fk_factura and s.sec_nombre ='Bebidas' and
      f.fac_fecha >=  @_fechaini and f.fac_fecha <= @_fechafin
      group by p.PLA_nombre;
	 
  END
  
  GO   
--------------------------------------CONSULTAR INGRESOS POR PLATOS CON FECHA-----------------------------------------

CREATE PROCEDURE ReporteIngresosPorPlatosConFecha

  @_fechaini   [datetime],
  @_fechafin   [datetime]
AS

  BEGIN
  
      select p.PLA_nombre, sum(lf.lin_fac_cantidad*p.pla_precio) as ingresos 
      from Plato p,linea_factura lf,seccion s,factura f 
      where p.pla_id=lf.fk_plato and s.sec_id = p.fk_seccion and
      f.fac_id=lf.fk_factura and s.sec_nombre !='Bebidas' and 
      f.fac_fecha >=  @_fechaini and f.fac_fecha <= @_fechafin
      group by p.PLA_nombre;
									
  END
  
  GO      
  
--------------------------------------------------------------------------------------------------------------------------
commit transaction;
go  