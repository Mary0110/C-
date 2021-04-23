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
            PermanentMigrant man = new PermanentMigrant("Kevin", "Smith", 46, "high", 23, "high", "single", "other");
            man.Work();
            man.GetCitizenship();
            List<Migrant> migrList = new List<Migrant>() {man, girl, stud1};
            migrList.Sort();
        }
    }
}

