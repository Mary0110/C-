using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3
{
    
    class StudentMigrant : Migrant
    {
        enum TypeOfAccomodation
        {
            No,
            Room = 2,
            Flat,
            House
        }
        private struct Possesions
        {
            public int money;
            public TypeOfAccomodation accomodation;
        }
        Possesions studPoss;

        public StudentMigrant(string firstName, string lastName, int age, string education, int experience, string qualification, string maritalStatus, string regionOfBirth)
            : base(firstName, lastName, age, education, experience, qualification, maritalStatus, regionOfBirth)
        {
            studPoss = new Possesions();
        }
        public override void BuyAccomodation()
        {
            base.BuyAccomodation();
            studPoss.accomodation = TypeOfAccomodation.Room;
            studPoss.money -= (int)studPoss.accomodation * 1000000;
        }

        public void Educate()
        {
            _education = "high";
            Upgrade();
            _age += 4;
            studPoss.money -= 4000;
        }
        public override void Work()
        {
            base.Work();
            if (_education != "high")
            {
                _age += 1;
                _experience += 1;
                Upgrade();
                studPoss.money += 100;
            }
            else
            {
                _age += 5;
                _experience += 5;
                Upgrade();
                studPoss.money += 20000;
                studPoss.accomodation = TypeOfAccomodation.Flat;
            }
        }
        public void HangOut()
        {
            studPoss.money -= 500;
        }
    }
}
