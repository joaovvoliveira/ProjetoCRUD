using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.DAL
{
    public abstract class Conexao
    {
        protected SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Servidor"].ConnectionString);
    }
}
