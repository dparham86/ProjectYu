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

        public DataTable GetVideoNamesForAutoComplete()
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
                using (var command = new SqlCommand("SELECT VideoName FROM Video", cnn))
                {
                    //command.Parameters.AddWithValue("@fileName", fileName);
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

        public DataTable GetVideoByFileName(string fileName)
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
                using (var command = new SqlCommand("SELECT * FROM Video WHERE FileName = @fileName", cnn))
                {
                    command.Parameters.AddWithValue("@fileName", fileName);
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

        public DataTable GetVideosByFileNameContains(string VideoName)
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
                using (var command = new SqlCommand("SELECT * FROM Video WHERE FileName LIKE @VideoName", cnn))
                {
                    command.Parameters.AddWithValue("@VideoName", VideoName  + "%");
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

        public DataTable GetVideosByUserID()
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
                using (var command = new SqlCommand("SELECT * FROM Video WHERE CreatedByUserID = 2", cnn))
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

        public bool CheckForExistingUser(string UserName, string passWord)
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=DESKTOP-9A0CTF1\\SQLEXPRESS;Initial Catalog=ProjectYu;Integrated Security=SSPI;";
            int result = 0;
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                using (var command = new SqlCommand("SELECT * FROM dbo.[User] WHERE userName = @userName AND passWord = @passWord", cnn))
                {
                    command.Parameters.AddWithValue("@userName", UserName);
                    command.Parameters.AddWithValue("@passWord", passWord);
                    var result2 = command.ExecuteScalar();
                    try
                    {
                        result = (int)result2;
                    }
                    catch
                    {
                        result = -1;
                    }

                }

                //MessageBox.Show("Connection Open ! ");
                cnn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Can not open connection ! ");
            }
            if (result == -1)
                return false;
            else
                return true;
        }

        public DataTable getAllUserData(string userName)
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=DESKTOP-9A0CTF1\\SQLEXPRESS;Initial Catalog=ProjectYu;Integrated Security=SSPI;";
            DataTable dataTable = new DataTable();
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                using (var command = new SqlCommand("SELECT * FROM dbo.[User] WHERE UserName = @userName", cnn))
                {
                    command.Parameters.AddWithValue("@userName", userName);
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

        public DataTable getFavoritesList(int favoriteListID)
        {

            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=DESKTOP-9A0CTF1\\SQLEXPRESS;Initial Catalog=ProjectYu;Integrated Security=SSPI;";
            DataTable dataTable = new DataTable();
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                using (var command = new SqlCommand("SELECT * FROM[ProjectYu].[dbo].[UserFavoritesList] AS f INNER JOIN dbo.Video AS v ON F.VideoID = v.VideoID  WHERE f.FavoritesListID = @FavoritesListID", cnn))
                {
                    command.Parameters.AddWithValue("@FavoritesListID", favoriteListID);
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

        public bool addNewVideo(string fileName, string fileExt, int userId)
        {
            string connetionString = null;
            int result = 0;
            SqlConnection cnn;
            connetionString = "Data Source=DESKTOP-9A0CTF1\\SQLEXPRESS;Initial Catalog=ProjectYu;Integrated Security=SSPI;";
            DataTable dataTable = new DataTable();
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                using (var command = new SqlCommand("INSERT INTO Video(VideoName, CreatedByUserID, CreatedDateTime, Likes, Dislikes, Rating, CommentsListID, FileName) VALUES (@VideoName, @CreatedByUserId, @CreatedDateTime, 0, 0, 0, 0, @FileName)", cnn))

                {
                    command.Parameters.AddWithValue("@FileName", fileName + fileExt);
                    command.Parameters.AddWithValue("@VideoName", fileName);
                    command.Parameters.AddWithValue("@CreatedByUserId", userId);
                    command.Parameters.AddWithValue("@CreatedDateTime", DateTime.Now);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    var result2 = command.ExecuteScalar();
                    // this will query your database and return the result to your datatable
                    try
                    {
                        result = (int)result2;
                    }
                    catch
                    {
                        result = -1;
                    }


                }

                //MessageBox.Show("Connection Open ! ");
                //cnn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Can not open connection ! ");
            }
            if (result == -1)
                return false;
            else
                return true;

        }
    }
}
            
