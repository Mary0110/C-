using System;
using System.Collections.Generic;

namespace lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Migrant girl = new Migrant("Yana", "Ivanova", 18, "secondary", 0, "low", "single", "CIS");
            girl.GrowingUp();
            girl.Marriage();
            girl.Work();
            girl.Information();
            StudentMigrant stud1 = new StudentMigrant("Petr", "Ivanov", 17, "secondary", 0, "low", "single", "CIS");
            stud1.Educate();
            stud1.Work();
            stud1.Information();
            PermanentMigrant man = new PermanentMigrant("Kevin", "Smith", 46, "high", 23, "high", "single", "other");
            man.Work();
            man.GetCitizenship();
            man.Information();

            List<Migrant> migrList = new List<Migrant>() 
            {girl, stud1, man
               /* new StudentMigrant("Maria", "Ivanova", 18, "secondary", 5, "low", "single", "CIS"),
                new WorkerMigrant("Alex", "Sobolev", 45, "secondary", 21, "low", "married", "other"),
                new PermanentMigrant("Will", "Smith", 50, "high", 22, "high", "single", "US"),*/
            };
            foreach (Migrant m in migrList)
            {
                m.Work();
                m.BuyAccomodation();
            }



        }
    }
}

