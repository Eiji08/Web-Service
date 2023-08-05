using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceModel;

namespace WebServiceData1.Repositorio
{
    public class UsoRepository : IUsoRepository
    {
        private readonly MYSQLConfiguration _connectionstring;

        public UsoRepository(MYSQLConfiguration connectionstring)
        {
            _connectionstring = connectionstring;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionstring.ConnectionString);
        }

        public Task<IEnumerable<UsoServicio>> GetUso()
        {
            var db = dbConnection();

            var sql = @" select TablaConsultada, FechaConsultada from RegistroConsultas";

            return db.QueryAsync<UsoServicio>(sql, new { });
        }

        public Task<IEnumerable<UsoServicio>> GetUso(string NombreServicio)
        {
            var db = dbConnection();

            var sql = @" select TablaConsultada, FechaConsultada from RegistroConsultas
                                where TablaConsultada = @NombreServicio";

            return db.QueryAsync<UsoServicio>(sql, new { NombreServicio = NombreServicio });
        }

        public async Task GuardarUso(string nombreServicio)
        {
            var db = dbConnection();

            var sql = @" insert into RegistroConsultas values (@TablaConsultada, @FechaConsultada)";

            var usoServicio = new { 
                TablaConsultada = nombreServicio,
                FechaConsultada = DateTime.Now
            };

            await db.ExecuteAsync(sql, usoServicio);
        }

        public async Task<IEnumerable<UsoServicio>> GetFecha(DateTime Desde, DateTime Hasta)
        {
            var db = dbConnection();

            var sql = @"SELECT TablaConsultada, FechaConsultada FROM RegistroConsultas
                WHERE FechaConsultada >= @Desde AND FechaConsultada <= @Hasta";

            return await db.QueryAsync<UsoServicio>(sql, new { Desde, Hasta });
        }
    }
}
