using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    class Person
    {
        public int? SSN;
        public string Name;
        public string Address;
        public int Age;

        public Person(int ssn, string name, string addr, int age)
        {
            SSN = ssn;
            Name = name;
            Address = addr;
            Age = age;
        }
    }

    public class Customer
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Sales { get; set; }
    }


    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
       
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Person
            List<Person> lsPerson = new List<Person>();

            lsPerson.Add(new Person(203456876, "John", "12 Main Street, Newyork, NY", 15));
            lsPerson.Add(new Person(203456877, "SAM", "1 Main Ct, Newyork, NY", 25));
            lsPerson.Add(new Person(203456878, "Elan", "14 Main Street, Newyork, NY", 35));
            lsPerson.Add(new Person(203456879, "Smith", "12 Main Street, Newyork, NY", 45));
            lsPerson.Add(new Person(203456880, "SAM", "345 Main Ave, Dayton, OH", 55));
            lsPerson.Add(new Person(203456881, "Sue", "32 Cranbrook Rd, Newyork, NY", 65));
            lsPerson.Add(new Person(203456882, "Winston", "1208 Alex St, Newyork, NY", 65));
            lsPerson.Add(new Person(203456883, "Mac", "126 Province Ave, Baltimore, NY", 85));
            lsPerson.Add(new Person(203456884, "SAM", "126 Province Ave, Baltimore, NY", 95));
            lsPerson.Add(new Person(-1, "SAM", null, 95));


            #region Boolean
            
            Console.WriteLine("\n------  Checking whether ANY person is above 60 ------");
            bool bAboveSixty = lsPerson.Any(e => e.Age > 60);
            if (bAboveSixty)
            {
                Console.WriteLine(" Yes, we have some persons above 60");
            }
            Console.ReadKey();

            Console.WriteLine("\n------  Checking whether ANY person is teenager or not ( Any ) ------");
            bool bTeen = lsPerson.Any(e => (e.Age >= 13 && e.Age <= 19));
            if (bTeen)
            {
                Console.WriteLine(" Yes, we have some teenagers in the list");
            }
            Console.ReadKey();

            Console.WriteLine("\n------  Cheking whether ALL the persons are older than 10 years or not ( All ) ------");
            bool bAbove10 = lsPerson.All(e => (e.Age > 10));
            if (bAbove10)
            {
                Console.WriteLine(" Yes, all the persons older than 10 years");
            }
            Console.ReadKey();

            Console.WriteLine("\n------  Checking whether a person having name 'SAM' EXISTS or not ( Exists )  ------");  // Exists and Any are same
            bool bExists = lsPerson.Exists(e => e.Name == "SAM");
            if (bExists)
            {
                Console.WriteLine(" Yes, A person having name 'SAM' exists in our list");
            }
            Console.ReadKey();

            Console.WriteLine("\n------  Checking all the persons have SSN or not' ( TrueForAll )  ------");
            bool bSSN = lsPerson.TrueForAll(e => e.SSN != null);
            if (bSSN)
            {
                Console.WriteLine(" No person is found without SSN");
            }
            else
            {
                Console.WriteLine("false");
            }
            Console.ReadKey();

            #endregion

            #region Aggreagate           
            Console.WriteLine("\n------  Getting AVERAGE of all the persons age ( Average )  ------");
            {
                double nAverageAge = lsPerson.Average(e => e.Age);
                Console.WriteLine(" The average of all the persons age is: " + nAverageAge);
                Console.ReadKey();
            }

            Console.WriteLine("\n------  Getting AVERAGE of all the persons age ( Average )  SQL Like------");
            {
                double nAverageAge = (from per in lsPerson
                                      select per.Age).Average();

                Console.WriteLine(" The average of all the persons age is: " + nAverageAge);
                Console.ReadKey();
            }

            Console.WriteLine("\n------  Getting Sum of all the persons age ( Sum )  ------");
            {
                int nSumOfAges = lsPerson.Sum(e => e.Age);
                Console.WriteLine(" Sum of the Ages " + nSumOfAges);
                Console.ReadKey();
            }

            Console.WriteLine("\n------  Getting Sum of all the persons age ( Sum )  SQL Like------");
            {
                int nSumOfAges = (from per in lsPerson
                                  select per.Age).Sum();

                Console.WriteLine(" Sum of the Ages " + nSumOfAges);
                Console.ReadKey();
            }


            Console.WriteLine("\n------  Getting max age ( Max )  ------");
            {
                int nMaxAge = lsPerson.Max(e => e.Age);
                Console.WriteLine(" Sum of the Ages " + nMaxAge);
                Console.ReadKey();
            }

            Console.WriteLine("\n------  Getting max age ( Max )  SQL Like------");
            {
                int nMaxAge = (from per in lsPerson
                               select per.Age).Max();
                Console.WriteLine(" Sum of the Ages " + nMaxAge);
                Console.ReadKey();
            }


            Console.WriteLine("\n------  Count age ( Count )  ------");
            int nCount = lsPerson.Count();
            Console.WriteLine(" Sum of the Ages " + nCount);
            Console.ReadKey();

            Console.WriteLine("\n------  Count persons whose name starts with S  ------");
            {
                int nCont = lsPerson.Count(x => x.Name.StartsWith("S"));
                Console.WriteLine(" Number persons whose name starts with S  " + nCont);
                Console.ReadKey();
            }

            Console.WriteLine("\n------  Count persons whose name starts with S  SQL Like------"); //not working
            {
                int nCont = (from per in lsPerson
                             select per.Name.StartsWith("S")).Count();
                Console.WriteLine(" Number persons whose name starts with S  " + nCont);
                Console.ReadKey();
            }

            Console.WriteLine("\n------  Find Yougest Person  ------");
            var Youngest = lsPerson.Min(e => e.Age);
            Console.WriteLine(Youngest);
            Console.ReadKey();
            #endregion

            #region Filtering
            Console.WriteLine("\n------  Finding the persons whose ages are 65 ( Where )  ------"); //FindAll and where are similar, where is LINQ whereas FindAll is only for List 
            var Age65 = lsPerson.Where(e => e.Age == 65);
            foreach (var item in Age65)
            {
                Console.WriteLine(item.Name + " " + item.Age);

            }
            Console.ReadKey();

            Console.WriteLine("\n------  Finding even SSN ( Where )  ------");
            var EvenSSN = lsPerson.Where(x => x.SSN % 2 == 0);
            foreach (var item in EvenSSN)
            {
                Console.WriteLine(item.Name + " " + item.SSN);

            }
            Console.ReadKey();

            Console.WriteLine("\n------!  Finding even SSN  ------");
            var EvnSSN = from evn in lsPerson
                         where evn.SSN % 2 == 0
                         select evn;
            foreach (var item in EvnSSN)
            {
                Console.WriteLine(item.Name + " " + item.SSN);

            }
            Console.ReadKey();


            Console.WriteLine("\n------ List of Persons above 60 ------");
            List<Person> lsAboveSixty = lsPerson.FindAll(e => (e.Age >= 60));
            foreach (Person AboveSixty in lsAboveSixty)
            {
                Console.WriteLine(AboveSixty.Name + " " + AboveSixty.Age);
            }
            Console.ReadKey();

            Console.WriteLine("\n------ List of Persons above 60 using where ------");
            IEnumerable<Person> lsAbovSixty = lsPerson.Where(e => (e.Age >= 60));
            foreach (Person AboveSixty in lsAboveSixty)
            {
                Console.WriteLine(AboveSixty.Name + " " + AboveSixty.Age);
            }
            Console.ReadKey();

            Console.WriteLine("\n------! List of Persons above 60 ------");
            var lsAboveSixty2 = from i in lsPerson
                                where i.Age > 60
                                select i;
            foreach (var item in lsAboveSixty2)
            {
                Console.WriteLine(item.Name + " " + item.Age);
            }

            Console.ReadKey();


            Console.WriteLine("\n------  List of teenagers  ------");
            List<Person> lsTeenAgers = lsPerson.FindAll(e => (e.Age >= 13 && e.Age <= 19));
            foreach (Person teen in lsTeenAgers)
            {
                Console.WriteLine(teen.Name + " " + teen.Age);
            }
            Console.ReadKey();

            Console.WriteLine("\n------ ! List of teenagers  ------");
            var lsTeen = from t in lsPerson
                         where t.Age > 12 && t.Age < 20
                         select t;
            foreach (var item in lsTeen)
            {
                Console.WriteLine(item.Name + "" + item.Age);
            }
            Console.ReadKey();

            Console.WriteLine("\n------  List of persons above 10 ( FindAll ) ------");
            List<Person> lsAbove10 = lsPerson.FindAll(e => (e.Age > 10));
            foreach (Person Above10 in lsAbove10)
            {
                Console.WriteLine(Above10.Name + " " + Above10.Age);
            }
            Console.ReadKey();

            Console.WriteLine("\n------ ! List of persons above 10 ( FindAll ) ------");
            var lsAbov10 = from abv10 in lsPerson
                           where abv10.Age > 10
                           select abv10;

            foreach (var item in lsAbov10)
            {
                Console.WriteLine(item.Name + " " + item.Age);
            }
            Console.ReadKey();

            Console.WriteLine("\n------  Finding the person whose SSN = 203456876 in the list ( Find )  ------");
            Person oPerson = lsPerson.Find(e => e.SSN == 203456876);
            Console.WriteLine(oPerson.Name + " " + oPerson.SSN);
            Console.ReadKey();


            Console.WriteLine("\n------  Skipping every person whose age is less than 60 years ( SkipWhile ) ------");
            var lsBelow60 = lsPerson.SkipWhile(e => e.Age < 60);
            foreach (var Below60 in lsBelow60)
            {
                Console.WriteLine(Below60.Name + " " + Below60.Age);
            }
            Console.ReadKey();

            Console.WriteLine("\n------ ! Skipping every person whose age is less than 60 years ( SkipWhile ) ------");
            var lsBlow60 = from b60 in lsPerson
                           where b60.Age > 60
                           select b60;

            foreach (var item in lsBlow60)
            {
                Console.WriteLine(item.Name + " " + item.Age);
            }
            Console.ReadKey();

            Console.WriteLine("\n------  Find age of Mac | SingleOrDefault  ------");
            {
                int nMacAge = lsPerson.SingleOrDefault(n => n.Name == "Mac").Age;

                Console.WriteLine("Age of Mac is {0}", nMacAge);
            }

            Console.ReadKey();


            Console.WriteLine("\n------  Find age of Mac | Find  ------");
            {
                int nMacAge = lsPerson.Find(n => n.Name == "Mac").Age;

                Console.WriteLine("Age of Mac is {0}", nMacAge);
            }


            #endregion

            #region Select
            Console.WriteLine("\n------ ( Select )  ------");
            var p = lsPerson.Select(e => e.Name);
            foreach (var item in p)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();


            Console.WriteLine("\n------ Anonymous Type ( Select )  ------");
            var list = lsPerson.Select(e => new { Name = e.Name, Age = e.Age });
            foreach (var item in list)
            {
                Console.WriteLine(item.Name + " " + item.Age);
            }

            Console.ReadKey();


            Console.WriteLine("\n------ Anonymous Type ( Select, Where )  ------");
            var ls = lsPerson.Select(e => new { PersonName = e.Name, PersonAge = e.Age }).Where(i => i.PersonAge > 60);
            foreach (var item in ls)
            {
                Console.WriteLine(item.PersonName + " " + item.PersonAge);
            }

            Console.ReadKey();

            Console.WriteLine("\n------  Finding SSN of John( Where )  ------");
            var JohnSSN = lsPerson.Select(e => new { Name = e.Name, SSN = e.SSN }).Where(e => e.Name == "John").ToList();
            Console.WriteLine("Name {0}, SSN {1}", JohnSSN[0].Name, JohnSSN[0].SSN);
            Console.ReadKey();
            #endregion

            #region Ordering
            Console.WriteLine("\n------  Order by name  ------");
            var OrderByName = lsPerson.OrderBy(e => e.Name);
            foreach (var item in OrderByName)
            {
                Console.WriteLine(item.Name);

            }
            Console.ReadKey();

            Console.WriteLine("\n------!  Order by name  ------");
            var OrdrByName = from bar in lsPerson
                             orderby bar.Name
                             select bar;
            foreach (var item in OrdrByName)
            {
                Console.WriteLine(item.Name);

            }
            Console.ReadKey();


            #endregion


            Console.WriteLine("\n------  Eldest person in the group ( First )  ------");
            var Eldest = lsPerson.First(e => e.Age == (lsPerson.Max(m => m.Age)));
            Console.WriteLine(Eldest.Name + " " + Eldest.Age);
            Console.ReadKey();


            Console.WriteLine("\n------  Checking the INDEX position of a person having name 'Smith' ( FindIndex )  ------");
            int nIndex = lsPerson.FindIndex(e => e.Name == "Smith");
            Console.WriteLine(" In the list, The index position of a person having name 'Smith' is : " + nIndex);
            Console.ReadKey();


            Console.WriteLine("\n------  Displaying the persons until we find a person with name starts with other than 'S'  ------"); // not working
            var a = lsPerson.TakeWhile(e => e.Name.StartsWith("J"));
            foreach (var p in a)
            {
                Console.WriteLine(p.Name + " " + p.Age);
            }
            Console.ReadKey();



            Console.WriteLine("\n------  Removing all the persons record from list that have “SAM” name ( RemoveAll )  ------");
            int foo = lsPerson.RemoveAll(e => e.Name == "SAM");
            foreach (var ab in lsPerson)
            {
                Console.WriteLine(ab.Name + " " + ab.Age);
            }

            Console.ReadKey();

            #endregion

            #region Customer
            List<Customer> lsCustomer = new List<Customer>();
            lsCustomer.Add(new Customer() { ID = "1", Name = "Atul", Category = "Medium", Sales = 451 });
            lsCustomer.Add(new Customer() { ID = "2", Name = "Binny", Category = "Medium", Sales = 124 });
            lsCustomer.Add(new Customer() { ID = "3", Name = "Nitin", Category = "High", Sales = 957 });
            lsCustomer.Add(new Customer() { ID = "4", Name = "Roshan", Category = "High", Sales = 24564 });
            lsCustomer.Add(new Customer() { ID = "4", Name = "Manu", Category = "Very High", Sales = 745 });
            lsCustomer.Add(new Customer() { ID = "5", Name = "Sushant", Category = "Very High", Sales = 654 });

            var query = from c in lsCustomer
                        group c by c.Category into grps
                        select new
                        {
                            Key = grps.Key,
                            Values = grps,
                            TotalSales = grps.Sum(g => g.Sales),
                            Total = grps.Count(),
                            AvgSales = grps.Average(g => g.Sales),
                            MaxSales = grps.Max(g => g.Sales),
                            MinSales = grps.Min(g => g.Sales),
                        };


            #endregion

            #region Join
            List<Department> lsDepartment = new List<Department>();
            lsDepartment.Add(new Department() { ID = 1, Name = "IT"});
            lsDepartment.Add(new Department() { ID = 2, Name = "HR" });

            List<Employee> lsEmployee = new List<Employee>();
            lsEmployee.Add(new Employee() { ID = 1, Name = "Mark", DepartmentID = 1});
            lsEmployee.Add(new Employee() { ID = 2, Name = "Steve", DepartmentID = 2 });
            lsEmployee.Add(new Employee() { ID = 3, Name = "Ben", DepartmentID = 1 });
            lsEmployee.Add(new Employee() { ID = 4, Name = "Philip", DepartmentID = 1 });
            lsEmployee.Add(new Employee() { ID = 5, Name = "Mark" });

            //Left Join 

            var Query = from emp in lsEmployee
                        join dept in lsDepartment on emp.DepartmentID equals dept.ID into grp
                        from dept in grp.DefaultIfEmpty()
                        select new
                        {
                            EmployeeName = emp.Name,
                            DepartmentName = dept == null ? "No Department" : dept.Name
                        };

            foreach (var item in Query)
            {
                Console.WriteLine(item.EmployeeName + "\t" + item.DepartmentName);
                Console.ReadLine();
            }



            #endregion


        }
    }
}
