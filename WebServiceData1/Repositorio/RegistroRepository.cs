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
    public class RegistroRepository : IRegistroRepository
    {
        private readonly MYSQLConfiguration _connectionstring;

        public RegistroRepository(MYSQLConfiguration connectionstring)
        {
            _connectionstring = connectionstring;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionstring.ConnectionString);
        }

        public Task<IEnumerable<RegistroConsultas>> GetRegistro()
        {
            var db = dbConnection();

            var sql = @" select TablaConsultada, FechaConsultada from RegistroConsultas";

            return db.QueryAsync<RegistroConsultas>(sql, new { });
        }

        public Task<RegistroConsultas> GetRegistro(string TablaConsultada)
        {
            var db = dbConnection();

            var sql = @" select TablaConsultada, FechaConsultada from RegistroConsultas
                            where TablaConsultada = @TablaConsultada";

            return db.QueryFirstOrDefaultAsync<RegistroConsultas>(sql, new { TablaConsultada = TablaConsultada });
        }
    }
}
