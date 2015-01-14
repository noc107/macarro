using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using back_office.Dominio;
using back_office.Datos.MenuRestaurante;
using back_office.Datos;
using System.Data.SqlClient; 

 

namespace unit_tests_back_office.Datos.MenuRestaurante
{
     public class PruebasUnitariasMenuRestaurant 
    {  
         //Inicializar el objeto de tipo SeccionBD que contiene el metodo agregarseccion que se probara
           private SeccionBD _seccionBD;
           private PlatosBD _platoBD;
         
           [SetUp]
           public void Init()
           {
                   SeccionBD _seccionBD = new SeccionBD();
                   PlatosBD _platoBD = new PlatosBD();
           } 
    
           [Test] 
             public void PruebaInsertaSeccion()
           {// Se genera la prueba de verificar si el agregar con estos datos se puede agregar 
            // y efectivamente no porque ya esta ingresado en la base de datos
                  SeccionBD _seccionBD = new SeccionBD();
                  Assert.AreEqual(_seccionBD.agregarNuevaSeccion("Internacionales", "Platos de marca internacional"), false);           
           }


           [Test]
           public void PruebaInsertaPlato()
           {// Se genera la prueba de verificar si el agregar con estos datos se puede agregar 
               // y efectivamente no porque ya esta ingresado en la base de datos
                  PlatosBD _platosBD = new PlatosBD();
                  Assert.AreEqual(_platosBD.agregarNuevoPlato("noquis", 50, "Comida italiana", "Internacionales"), false);
           }
         //hhhh


           [Test]
           public void PruebaModificarPlato()
           {// Se genera la prueba de verificar si el agregar con estos datos se puede agregar 
               // y efectivamente no porque ya esta ingresa en la base de datos
                    
                  PlatosBD _platoBD = new PlatosBD();
                  Plato _plato1 = new Plato();
                  _plato1.Codigo = 1;
                  int _pc = _plato1.Codigo;
                 _plato1.Nombre = "Pasta a la Bologna";
                 string _pn = _plato1.Nombre;
                 _plato1.Precio = 100;
                 float _pp = _plato1.Precio;
                 _plato1.Descripcion = "Típico plato italiano de pasta con salsa de carne de la mejor calidad";
                 string _pd = _plato1.Descripcion;
                 _plato1.Estado = "Activado";
                 string _pe = _plato1.Estado;
                 Plato _plato = new Plato(_pc, _pn, _pp, _pd, _pe, 1);
                 bool res = _platoBD.ModificarProducto(_plato);
                 Assert.AreEqual(false, res);
           }


           [Test]
          
           public void PruebaModificarSeccion()
           {// Se genera la prueba de verificar si el agregar con estos datos se puede agregar 
               // y efectivamente no porque ya esta ingresa en la base de datos

                 SeccionBD _seccionBD = new SeccionBD();
                 Seccion _seccion1 = new Seccion();
                 Plato _plato= new Plato();
                 _seccion1.Nombre = "Internacionales";
                 string _pn = _seccion1.Nombre;
                 _seccion1.Descripcion = "Platos de marca internacional";
                 string _pp = _seccion1.Descripcion;
                 _seccion1.Descripcion = "Activado";
                 string _pd = _seccion1.Estado;
                 List<Plato> _miLista = new List<Plato>();
                 Plato _plato1 = new Plato(26,"Pizza",300,"La pizza de la casa","Activado");
                 Plato _plato2 = new Plato (27,"Rabeolis",100,"Espagueti salteado por dentro de crema de espinaca","Activado");  
                 /*Plato _plato1 = new Plato(26,"Pizza",200.32,"Especialidad Hawai","Activado");
                 Plato _plato2 = new Plato(27, "Rabeolis", 200.32, "Espagueti salteado por dentro de crema de espinaca", "Activado");
                 Plato _plato3 = new Plato(28, "Cartocho", 200.32, "Carne a la parrilla con espagueti", "Activado");
                 Plato _plato4 = new Plato(29, "Pollo Ajonjoli", 200.32, "Pollo salteado de miel con ajonjoli", "Activado");
                 Plato _plato5 = new Plato(30, "Sangria", 200.32, "Bebida con 12 grados", "Activado");*/
                 _miLista.Add(_plato1);
                 Seccion _seccion = new Seccion(_pn, _pp, _pd, _miLista);
                 bool res = _seccionBD.ModificarSeccion(_seccion);
                 Assert.AreEqual(false,res);
                 
            }

           [Test]

           public void PruebaEliminarSeccion() 
           {
               SeccionBD _secBD = new SeccionBD();
               bool _res =  _secBD.EliminarSeccion(new Seccion(1,"Internacionales")); 
               Assert.AreEqual(false,_res); 
           }

           [Test]

           public void PruebaEliminarPlato() 
           {
               PlatosBD _plaBD = new PlatosBD();
               bool _res = _plaBD.EliminarProducto(new Plato(1));
               Assert.AreEqual(false, _res); 
           }

           [TearDown]
            public void Limpiar()
           {
            // se limpia la variable como es el garbage colector en java
           _seccionBD = null;
           _platoBD = null;
           }      
        }
 }