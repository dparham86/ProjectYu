using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectYu
{
    public class DataLayer
    {
        public DataTable GetNewVideos()
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=DESKTOP-9A0CTF1\\SQLEXPRESS;Initial Catalog=ProjectYu;Integrated Security=SSPI;";
            DataTable dataTable = new DataTable();
            cnn = new SqlConnection(connetionString);

                cnn.Open();
                try
                {
                    //cnn.Open();
                    using (var command = new SqlCommand("SELECT TOP 50 * FROM Video", cnn))
                    {
                        //command.Parameters.AddWithValue("@userName", UserName);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        // this will query your database and return the result to your datatable
                        da.Fill(dataTable);
                        //nn.Close();
                        da.Dispose();

                    }

                    //MessageBox.Show("Connection Open ! ");
                    //cnn.Close();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Can not open connection ! ");
                }
            
                return dataTable;
        }
    }
}
            
