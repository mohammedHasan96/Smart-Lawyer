using MySql.Data.MySqlClient;
using SmartLawyer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SmartLawyer.Models
{
    partial class DataAccess
    {
        public static DataView CasesData()
        {
            var conn = OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"";
            var adapter = new MySqlDataAdapter((MySqlCommand)cmd);
            var dTable = new DataTable();
            adapter.Fill(dTable);
            return dTable.DefaultView;
        }
        public static DataView InsertCase(Case _case)
        {
            var conn = OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"";
            cmd.ExecuteNonQuery();
            return CasesData();
        }
        public static DataView UpdateCase(int CaseId, Case _case)
        {
            var conn = OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"";
            cmd.ExecuteNonQuery();
            return CasesData();
        }
        public static DataView DeleteCase(int CaseId)
        {
            var conn = OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"";
            cmd.ExecuteNonQuery();
            return CasesData();
        }
        public static DataView SearchCases(String searchKey)
        {
            var conn = OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"";
            var adapter = new MySqlDataAdapter((MySqlCommand)cmd);
            var dTable = new DataTable();
            adapter.Fill(dTable);
            return dTable.DefaultView;
        }
    }
}
