using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3
{
    class PermanentMigrant : Migrant, IComparable<Migrant>, IEntertainable
    {
        enum TypeOfAccomodation
        {
            No,
            Room = 2,
            Flat,
            House
        }
        struct Possesions
        {
            public int money;
            public TypeOfAccomodation accomodation;
        }

        Possesions permPoss;
        public PermanentMigrant(string firstName, string lastName, int age, string education, int experience, string qualification, string maritalStatus, string regionOfBirth)
            : base(firstName, lastName, age, education, experience, qualification, maritalStatus, regionOfBirth)
        {
            permPoss = new Possesions();
        }
        public override void Work()
        {
            base.Work();
            _age += 5;
            _experience += 5;
            Upgrade();
            permPoss.money += 30000;
        }
        public void GetCitizenship()
        {
            _age += 2;
            permPoss.money -= 200;
            if (_regionOfBirth == "CIS")
            {
                if (_qualification == "high")
                    _age += 1;
                else
                    _age += 3;
            }
            else if (_maritalStatus == "single")
            {
                Marriage();
                permPoss.money -= 500;
                _age += 2;
            }
            else
                Console.WriteLine("You can't get citizenship");

        }
        public void GetBenefits()
        {
            _age += 1;
            permPoss.money += 250;
        }
        public override void BuyAccomodation()
        {
            Random rand = new Random();
            int num = rand.Next(2, 5);
            if (num == 2)
            {
                permPoss.accomodation = TypeOfAccomodation.Room;
            }
            else if (num == 3)
            {
                permPoss.accomodation = TypeOfAccomodation.Flat;
            }
            else if (num == 4)
            {
                permPoss.accomodation = TypeOfAccomodation.House;
            }
            permPoss.money -= (int)permPoss.accomodation * 1000000;
        }
        public int CompareTo(Migrant other)
        {
            return Math.Sign(Age - other.Age);
        }

        public void EatOut()
        {
            permPoss.money -= 50;
        }

        public void Celebrate()
        {
            permPoss.money -= 500;
            Experience += 7;
        }
    }
}
