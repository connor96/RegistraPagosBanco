using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class coneccion
    {
       
        //public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OU38DP6;Initial Catalog=ProgICPNA; Persist Security Info=True;User ID=sa;Password=Aa123456");
        //public SqlConnection con = new SqlConnection(@"Data Source=190.223.61.252;Initial Catalog=ProgICPNA; Persist Security Info=True;User ID=sysnet;Password=dOj*g515$1cpn@");
        public SqlConnection con = new SqlConnection(@"Data Source=192.168.0.10;Initial Catalog=ProgICPNA; Persist Security Info=True;User ID=sysnet;Password=dOj*g515$1cpn@");
        //public SqlConnection con = new SqlConnection(@"Data Source=192.168.0.152;Initial Catalog=ProgICPNA; Persist Security Info=True;User ID=sa;Password=genoma666");
        //public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5CKVJ4S\MSSQLSERVER2;Initial Catalog=ProgICPNA; Persist Security Info=True;User ID=sa;Password=Aa123456");
        //public SqlConnection con = new SqlConnection(@"Data Source=192.168.1.47;Initial Catalog=ProgICPNA; Persist Security Info=True;User ID=sa;Password=Aa123456");
        //public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4ROAEM2;Initial Catalog=ProgICPNA; Integrated Security=True");
       
    }
}
