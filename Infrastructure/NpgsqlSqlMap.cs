using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace Infrastructure
{
    public class NpgsqlSqlMap
    {
        public string Sql { get; set; }

        public NpgsqlParameter[] SqlParameters { get; set; }
    }
}
