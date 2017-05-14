using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabOne
{
    class Student
    {
        int id;
        string surname;
        string gender = "М";
        DateTime birthDate;
        int course, group;
        bool scholarship = true;
        float scholarshipSize;

        public int Id
        {
            get {return id; }
            set { id = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public DateTime Birth
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public int Course
        {
            get { return course; }
            set { course = value; }
        }

        public int Group
        {
            get { return group; }
            set { group = value; }
        }

        public bool Scholarship
        {
            get { return scholarship; }
            set { scholarship = value; }
        }

        public float ScholarshipSize
        {
            get { return scholarshipSize; }
            set { scholarshipSize = value; }
        }
    }
}
