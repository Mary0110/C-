using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3
{
    class WorkerMigrant : Migrant, IEntertain
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

        Possesions workerPoss;
        public WorkerMigrant(string firstName, string lastName, int age, string education, int experience, string qualification, string maritalStatus, string regionOfBirth)
            : base(firstName, lastName, age, education, experience, qualification, maritalStatus, regionOfBirth)
        {
            workerPoss = new Possesions();
        }

        public override void Work()
        {
            base.Work();
            _age += 3;
            _experience += 3;
            Upgrade();
            workerPoss.money += 50000;
        }
        public override void BuyAccomodation()
        {
            Random rand = new Random();
            int num = rand.Next(2, 5);
            if (num == 2)
            {
                workerPoss.accomodation = TypeOfAccomodation.Room;
            }
            else if (num == 3)
            {
                workerPoss.accomodation = TypeOfAccomodation.Flat;
            }
            else if (num == 3)
            {
                workerPoss.accomodation = TypeOfAccomodation.House;
            }
            workerPoss.money -= (int)workerPoss.accomodation * 1000000;
        }
        public int Compare(WorkerMigrant first, Migrant second)
        {
            if (first.Experience > second.Experience)
            {
                return 1;
            }
            if (first.Experience < second.Experience)
            {
                return -1;
            }
            return 2;
        }

        public void EatOut()
        {
            workerPoss.money -= 20;
        }

        public void Celebrate()
        {
            workerPoss.money -= 300;
            Experience += 1;
        }
    }
}
