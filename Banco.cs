using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using Microsoft.SqlServer.Server;

namespace SG_SIG
{
    internal class Banco
    {
        public static DataTable dataTable = null;
        public static SQLiteDataAdapter dataAdapter = null;
        public static SQLiteCommand cmd = null;
       public static SQLiteConnection dbConection(string value)
        {
            SQLiteConnection conn = new SQLiteConnection(value);
            conn.Open();
            return conn;
        }

       public static decimal SelectSum(string localData, string value, string table)
        {
            cmd = new SQLiteCommand();
            cmd.CommandText  = $"SELECT SUM({value}) FROM {table} ";
            cmd.Connection = dbConection(localData);
            var result = Convert.ToDecimal(cmd.ExecuteScalar());
            return result;
        }
        public static DataTable GetAll(string LocalData, string value)
        {
            cmd = new SQLiteCommand();
            cmd.CommandText = $"SELECT * FROM {value}";
            dataAdapter= new SQLiteDataAdapter(cmd.CommandText, dbConection(LocalData));
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        
    }
}
