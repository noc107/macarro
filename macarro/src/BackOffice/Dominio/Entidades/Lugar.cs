using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
    public class Lugar : Entidad
    {
        #region Atributos

        private int _idLugar;
        private string _nombreLugar;
        private string _tipoLugar;
        private int _fkLugar;

        #endregion

        #region Gets y Sets

        public int IdLugar
        {
            get { return _idLugar; }
            set { _idLugar = value; }
        }

        public string NombreLugar
        {
            get { return _nombreLugar; }
            set { _nombreLugar = value; }
        }

        public string TipoLugar
        {
            get { return _tipoLugar; }
            set { _tipoLugar = value; }
        }

        public int FkLugar
        {
            get { return _fkLugar; }
            set { _fkLugar = value; }
        }

        #endregion

        #region Constructores

        public Lugar()
        {
            _idLugar = 0;
            _nombreLugar = string.Empty;
            _tipoLugar = string.Empty;
            _fkLugar = 0;
        }

        public Lugar(int idLugar, string nombreLugar, string tipoLugar, int fkLugar)
        {
            _idLugar = idLugar;
            _nombreLugar = nombreLugar;
            _tipoLugar = tipoLugar;
            _fkLugar = fkLugar;
        }

        #endregion

    }
}