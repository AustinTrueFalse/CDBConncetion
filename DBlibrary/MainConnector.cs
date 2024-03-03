using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DBlibrary
{
    public class MainConnector
    {

        readonly SqlConnection connection = new SqlConnection(ConnectionString.MsSqlConnection);
        public async Task<bool> ConnectAsync()
        {
            bool result;
            try
            {
                await connection.OpenAsync();
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result = false;
            }
            return result;


        }

        public async void DisconnectAsync()
        {
            if (connection.State == ConnectionState.Open)
            {
                await connection.CloseAsync();
            }
        }

        public SqlConnection GetConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                return connection;
            }
            else
            {
                throw new Exception("Connection closed");
            }
        }
    }


}
