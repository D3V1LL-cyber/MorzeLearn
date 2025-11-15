using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morze_Learn
{
    class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Dictionary<char, string> LoadMorseCodes()
        {
            Dictionary<char, string> codes = new Dictionary<char, string>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Symbol, Code FROM MorseCodes";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            char symbol = reader.GetChar(0);
                            string code = reader.GetString(1);
                            codes.Add(symbol, code);
                        }
                    }
                }
            }
            return codes;
        }
    }
}
