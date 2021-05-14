using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TigerChatPeopleLib
    {
        public enum genderPronoun
        {
            him,
            her,
            them
        }
        public enum collegeYear : byte
        {
            freshman = 23,
            sophomore = 22,
            junior = 21,
            senior = 20
        }

        public interface ICourseList
        {
            List<string> CourseList
            {
                get;
                set;
            }
        }

        public abstract class User
        {
            public string userName;
            public int age;
            public genderPronoun userGender;
            public string email;

            public string photoPath;
            public string homePageURL;
            public DateTime dateOfBirth;


            private string password;
            public bool resetPassword;
            
            public string Password
            {
                get
                {
                    return password;
                }
                set 
                {
                    //allow user to reset password
                    if (resetPassword == true)
                    {
                        password = value;
                    }
                }
            }
        public User()
        { 
        }

            public static bool operator <(User p1, User p2)
            {
                return (p1.age < p2.age);
            }

            public static bool operator >(User p1, User p2)
            {
                return (p1.age > p2.age);
            }

            public static bool operator <=(User p1, User p2)
            {
                return (p1.age <= p2.age);
            }

            public static bool operator >=(User p1, User p2)
            {
                return (p1.age >= p2.age);
            }

            public static bool operator ==(User p1, User p2)
            {
                return (p1.age == p2.age);
            }

            public static bool operator !=(User p1, User p2)
            {
                return (p1.age != p2.age);
            }

        }

        public interface IStudent
        {
            
        }

        public interface IUser
    {
        }

        public class Student : User, IUser, IStudent, ICourseList
        {
            public double gpa;
            public collegeYear eCollegeYear;
            public List<string> courseCodes = new List<string>();

            public string favoriteFood;

            public List<String> CourseList
            {
                get
                {
                    return this.courseCodes;
                }

                set
                {
                    this.courseCodes = value;
                }
            }

            public static bool operator <(Student s1, Student s2)
            {
                return (s1.gpa < s2.gpa);
            }

            public static bool operator <=(Student s1, Student s2)
            {
                return (s1.gpa <= s2.gpa);
            }

            public static bool operator >(Student s1, Student s2)
            {
                return (s1.gpa > s2.gpa);
            }

            public static bool operator >=(Student s1, Student s2)
            {
                return (s1.gpa >= s2.gpa);
            }

            public static bool operator ==(Student s1, Student s2)
            {
                return (s1.gpa == s2.gpa);
            }

            public static bool operator !=(Student s1, Student s2)
            {
                return (s1.gpa != s2.gpa);
            }


        }

        public class Teacher : User, IUser, ICourseList
        {
            public string specialty;
            public List<string> courseCodes = new List<string>();

            public List<String> CourseList
            {
                get
                {
                    return this.courseCodes;
                }

                set
                {
                    this.courseCodes = value;
                }
            }

        }

        public class People
        {
            // the generic SortedList class uses a template <> to store indexed data
            // the first type is the data type to index on
            // the second type is the data type to store in the list
            public SortedList<string, User> myList = new SortedList<string, User>();

            public void Remove(string userName)
            {
                if (userName != null)
                {
                    myList.Remove(userName);
                }
            }

            // indexer property allows array access to sortedList via the class object
            // and catching missing keys and duplicate key exceptions 
          
            public User this[string userName]
            {
                get
                {
                    User returnVal;
                    try
                    {
                        returnVal = (User)myList[userName];
                    }
                    catch
                    {
                        returnVal = null;
                    }

                    return (returnVal);
                }

                set
                {
                    try
                    {
                    // we can add to the list using these 2 methods
                    //      sortedList.Add(email, value);
                        myList[userName] = value;
                    }
                    catch
                    {
                        // an exception will be raised if an entry with a duplicate key is added
                        // duplicate key handling (currently ignoring any exceptions)
                    }
                }
            }
        }

    }