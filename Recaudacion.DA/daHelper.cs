using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Recaudacion.DA
{
    public class daHelper
    {
        public string _CadenaConeccion = null;
        public static string conexion()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();

            string _ConnectionString = root.GetSection("ConnectionStrings").GetSection("SqlConnecionEncrypted").Value;
            return _ConnectionString;


            //return ConfigurationManager.ConnectionStrings["MyConnectionSQL"].ConnectionString;
        }
    }
}
