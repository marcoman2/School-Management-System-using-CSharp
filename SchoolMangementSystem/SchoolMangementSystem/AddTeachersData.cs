using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SchoolMangementSystem
{
    class AddTeachersData
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\WINDOWS 10\Documents\school.mdf;Integrated Security=True;Connect Timeout=30");
        public int ID { set; get; }
        public string TeacherID { set; get; }
        public string TeacherName { set; get; }
        public string TeacherGender { set; get; }
        public string TeacherAddress { set; get; }
        public string TeacherImage { set; get; }
        public string Status { set; get; }
        public string DateInsert { set; get; }

        public List<AddTeachersData> teacherData()
        {
            List<AddTeachersData> listData = new List<AddTeachersData>();
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string sql = "SELECT * FROM teachers WHERE date_delete IS NULL";

                    using(SqlCommand cmd = new SqlCommand(sql, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            AddTeachersData addTD = new AddTeachersData();
                            addTD.ID = (int)reader["id"];
                            addTD.TeacherID = reader["teacher_id"].ToString();
                            addTD.TeacherName = reader["teacher_name"].ToString();
                            addTD.TeacherGender = reader["teacher_geder"].ToString();
                            addTD.TeacherAddress = reader["teacher_address"].ToString();
                            addTD.TeacherImage = reader["teacher_image"].ToString();
                            addTD.Status = reader["teacher_status"].ToString();
                            addTD.DateInsert = reader["date_insert"].ToString();

                            listData.Add(addTD);
                        }
                        reader.Close();
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error connecting Database: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            return listData;

        }
    }
}
