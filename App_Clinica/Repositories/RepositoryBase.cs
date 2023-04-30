using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Clinica.Repositories
{
    public class RepositoryBase
    {
        private readonly string _connectionString;

        public RepositoryBase()
        {
            _connectionString = "Server = DESKTOP-32GK00E\\SQLEXPRESS; Database = Clinica; Integrated Security = true";
        }

        protected SqlConnection GetConnection() { 
            return new SqlConnection(this._connectionString);
        }
    }
}
