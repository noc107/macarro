using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Security.Cryptography;

namespace back_office.Dominio
{
    public class Hash
    {
        #region Atributos

        private MD5 _md5Hash;

        #endregion

        #region Constructor

        public Hash()
        {
            _md5Hash = MD5.Create();
        }

        #endregion

        #region Metodos

        public string ObtenerMd5Hash(string input)
        {
            // Convierte el string en un array de byte calculando el hash
            byte[] data = _md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Crea un StringBuilder para construir un string con los bytes recolectados
            StringBuilder sBuilder = new StringBuilder();

            // Recorre cada byte del hash y le da formato a cada uno como un string hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public  bool VerificarMd5Hash(string input, string hash)
        {
            string hashOfInput = ObtenerMd5Hash(input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}