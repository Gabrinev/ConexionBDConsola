using System;
using System.Data.SqlClient;

namespace ConexionBDConsola
{
    internal class DbConnect
    {
        public SqlConnection conexion;
        
            

        public void OpenConection()
        {
            conexion = new SqlConnection(Properties.Settings.Default.connStr);
            conexion.Open();
            

        }


        public void CloseConnection()
        {
            conexion.Close();
        }
    
    }
}