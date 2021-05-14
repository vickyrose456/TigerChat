using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TigerChatPeopleLib;

namespace TigerUsersGlobals
{
    public interface IListView
    {
        void PaintListView(string code);
    }

    public static class Globals
    {
        public static People people = new People();

        public static void AddPeopleData()
        {
            int i = 0;

            User user = null;
            Student student = null;
            Teacher teacher = null;

            Random rand = new Random();

            String[] specialty = new String[] { "Math", "Comp Sci", "History", "Chemistry", "English" };

            String[] firstName = new string[] { "Sue", "Tom", "Harry", "John", "David", "Rob", "Mary", "Cathy", "Amy", "Theresa", "Beth" };
            String[] lastName = new string[] { "Harris", "Smith", "Johnson", "Cass", "Murphy", "O'Malley", "Scott", "Peterson", "Clark" };

            for (i = 0; i < 50; ++i)
            {
                if (rand.Next(0, 2) == 0)
                {
                    //create a bew student
                    student = new Student();
                    student.gpa = rand.NextDouble() * 4;

                   user = student;
                }
                else
                {
                    //make new teacher
                    teacher = new Teacher();
                    //create teacher specialty
                    teacher.specialty = specialty[rand.Next(0, specialty.Length)];
                    user = teacher;
                }

                user.age = rand.Next(0, 81);

                user.email = "person_" + i.ToString() + "@rit.edu";
                user.userName = firstName[rand.Next(0, firstName.Length)] + " " + rand.Next(0, lastName.Length);

                people[user.email] = user;
            }
        }
    }
}