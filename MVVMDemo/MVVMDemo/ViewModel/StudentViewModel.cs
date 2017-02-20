using MVVMDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            students.Add(new Model.Student { Firstname = "Kalle", LastName = "Jalkanen" });
            students.Add(new Model.Student { Firstname = "Teppo", LastName = "Testaaja" });
            students.Add(new Model.Student { Firstname = "Tomi", LastName = "Töttenström" });
            students.Add(new Model.Student { Firstname = "Anni", LastName = "Ainokainen" });
            Students = students; //property
        }
    }
}
