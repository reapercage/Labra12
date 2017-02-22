using MVVMDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVMDemo.ViewModel
{
    public class StudentViewModel
    {
        public ObservableCollection<Student> Students
        {
            get;
            set;
        }
        public void LoadStudents()
        {
            ObservableCollection<Student> students = new ObservableCollection<Model.Student>();
            //lisätään esimerkin vuoksi muutama opiskelija, oikeassa sovelluksessa haettaisiin esim. tietokannasta
            students.Add(new Model.Student { Firstname = "Kalle", LastName = "Jalkanen", Asioid = "A1234" });
            students.Add(new Model.Student { Firstname = "Teppo", LastName = "Testaaja", Asioid = "B1234" });
            students.Add(new Model.Student { Firstname = "Tomi", LastName = "Töttenström", Asioid = "C1234" });
            students.Add(new Model.Student { Firstname = "Anni", LastName = "Ainokainen", Asioid = "D1234" });
            Students = students; //property
        }
        //metodi StudentViewModeliin jolla haetaan oppilastiedot mysql-palvemilta
        public void LoadStudentsFromMysql()
        {
            try
            {
                ObservableCollection<Student> students = new ObservableCollection<Student>();
                //luodaan yhteys labranetin mysql-palvelimelle
                string connStr = GetMysqlConnectionString();
                string sql = "SELECT firstname, lastname, asioid FROM student";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MVVMDemo.Model.Student s = new Model.Student();
                            s.Firstname = reader.GetString(0);
                            s.LastName = reader.GetString(1);
                            s.Asioid = reader.GetString(2);
                            students.Add(s);
                        }
                        Students = students;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        private string GetMysqlConnectionString()
        {
            string pw = "";
            //haetaan salasana App.Config- konfiguraatiotiedostosta
            pw = MVVMDemo.Properties.Settings.Default.passu;
            //return string.Format("Data source-mysql.labranet.jamk.fi;Initial Catalog-H4026;user-h4026;password-{0}", pw);
            return string.Format("Data source-mysql.labranet.jamk.fi;Initial Catalog-H4026;user-h4026;");
        }
    }
}
