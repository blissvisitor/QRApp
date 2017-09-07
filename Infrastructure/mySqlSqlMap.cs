using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data;
using MySql.Data.MySqlClient;


namespace Infrastructure
{
    public class mySqlSqlMap
    {
        public string Sql { get; set; }

        public MySqlParameter[] SqlParameters { get; set; }
    }
}
