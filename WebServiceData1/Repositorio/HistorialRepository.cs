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
    public class HistorialRepository : IHistorialRepository
    {
        private readonly MYSQLConfiguration _connectionstring;

        public HistorialRepository(MYSQLConfiguration connectionstring)
        {
            _connectionstring = connectionstring;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionstring.ConnectionString);
        }

        public Task<IEnumerable<HistorialCrediticio>> GetHistorial()
        {
            var db = dbConnection();

            var sql = @" select Cedula, RNCEmpresa, ConceptoDeuda, Fecha, MontoAdeudado from HistorialCrediticio";

            return db.QueryAsync<HistorialCrediticio>(sql, new { });
        }

        public Task<HistorialCrediticio> GetHistorial(string Cedula)
        {
            var db = dbConnection();

            var sql = @" select Cedula, RNCEmpresa, ConceptoDeuda, Fecha, MontoAdeudado from HistorialCrediticio
                            where Cedula = @Cedula";

            return db.QueryFirstOrDefaultAsync<HistorialCrediticio>(sql, new { Cedula = Cedula });
        }
    }
}
