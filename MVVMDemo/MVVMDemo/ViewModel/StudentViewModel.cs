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
            students.Add(new Model.Student { Firstname = "Kalle", LastName = "Jalkanen", Asioid = "A1234" });
            students.Add(new Model.Student { Firstname = "Teppo", LastName = "Testaaja", Asioid = "B1234" });
            students.Add(new Model.Student { Firstname = "Tomi", LastName = "Töttenström", Asioid = "C1234" });
            students.Add(new Model.Student { Firstname = "Anni", LastName = "Ainokainen", Asioid = "D1234" });
            Students = students; //property
        }
    }
}
