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
    public class SaludRepository : ISaludRepository
    {

        private readonly MYSQLConfiguration _connectionstring;

        public SaludRepository(MYSQLConfiguration connectionstring)
        {
            _connectionstring = connectionstring;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionstring.ConnectionString);
        }

        public Task<IEnumerable<SaludFinanciera>> GetSalud()
        {
            var db = dbConnection();

            var sql = @" select Cedula, RNC, Indicador, comentario, MontoTotalendeudado from SaludFinanciera";

            return db.QueryAsync<SaludFinanciera>(sql, new { });
        }

        public Task<SaludFinanciera> GetSalud(string Cedula)
        {
            var db = dbConnection();

            var sql = @" select Cedula, RNC, Indicador, comentario, MontoTotalendeudado from SaludFinanciera
                            where Cedula = @Cedula";

            return db.QueryFirstOrDefaultAsync<SaludFinanciera>(sql, new { Cedula = Cedula });
        }
    }
}
