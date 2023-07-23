using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceModel;

namespace WebServiceData1.Repositorio
{
    public class InflacionRepository : IInflacionRepository
    {

        private readonly MYSQLConfiguration _connectionstring;

        public InflacionRepository(MYSQLConfiguration connectionstring)
        {
            _connectionstring = connectionstring;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionstring.ConnectionString);
        }

        public Task<IEnumerable<Inflacion>> GetInflacion()
        {
            var db = dbConnection();

            var sql = @" select Fecha, inflacion from Inflacion";

            return db.QueryAsync<Inflacion>(sql, new { });
        }

        public Task<Inflacion> GetInflacion(string fecha)
        {
            var db = dbConnection();

            var sql = @" select Fecha, inflacion from Inflacion
                         where fecha = @Fecha";

            return db.QueryFirstOrDefaultAsync<Inflacion>(sql, new { Fecha = fecha });
        }
    }
}
