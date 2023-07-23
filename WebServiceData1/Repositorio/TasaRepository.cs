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
    public class TasaRepository : ITasaRepository
    {

        private readonly MYSQLConfiguration _connectionstring;

        public TasaRepository(MYSQLConfiguration connectionstring)
        {
            _connectionstring = connectionstring;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionstring.ConnectionString);
        }

        public Task<IEnumerable<TasaCambio>> GetTasa()
        {
            var db = dbConnection();

            var sql = @" select Moneda, Tasa from TasaCambio";

            return db.QueryAsync<TasaCambio>(sql, new { });
        }

        public Task<TasaCambio> GetTasa(string moneda)
        {
            var db = dbConnection();

            var sql = @" select Moneda, Tasa from TasaCambio
                         where moneda = @Moneda";

            return db.QueryFirstOrDefaultAsync<TasaCambio>(sql, new { Moneda = moneda });
        }
    }
}
