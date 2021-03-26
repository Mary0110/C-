using System;

namespace lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Person.Human girl = new Person.Human("Ivan", "Ivanov", 18, "secondary", 0, "low", "single", "CIS");
            girl.GrowingUp();
            girl.Educate();
            girl.Marriage();
            girl.Work();
            girl.Upgrade();
            girl.Information();
        }
    }
}

namespace Person
{
    class Human
    {
        protected string _firstName;
        protected string _lastName;
        protected int _age;
        private string _education;
        private int _experience;
        protected string _qualification;
        protected string _maritalStatus;
        protected string _regionOfBirth;
        protected uint _id;
        static uint _amount;

        static string CheckInput(string str)
        {
            int count = -1;
            while (count != str.Length)
            {
                count = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    if (i == 0 && str[i] >= 'A' && str[i] <= 'Z')
                    {
                        count++;
                    }
                    else if (i > 0 && str[i] >= 'a' && str[i] <= 'z')
                    {
                        count++;
                    }
                }
                if (count != str.Length)
                {
                    Console.WriteLine($"{str} - invalid data. Try again");
                    str = "-";
                }
            }
            return str;
        }
        
        public Human(string firstName, string lastName, int age)
            : this(firstName, lastName, age, "-", 0, "-", "-", "-")
        {

        }
        public Human(string firstName, string lastName, int age, string education, int experience, string qualification, string maritalStatus, string regionOfBirth)
        {
            _firstName = CheckInput(firstName);
            _lastName = CheckInput(lastName);
            _age = age;             
            _education = education;
            _experience = experience;
            _maritalStatus = maritalStatus;
            _regionOfBirth = regionOfBirth;
             _amount++;
            _id = _amount;
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if(value == CheckInput(value))
                {
                    _firstName = value;
                }
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value == CheckInput(value))
                {
                    _lastName = value;
                }
            }
}

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (!(value >= 0 && value <= 120))
                {
                    Console.WriteLine("Invalid age");
                }
                else
                {
                    _age = value;
                }
            }

        }

        public string Education
        {
            get
            {
                return _education;
            }
            set
            {
                string[] eduArr = { "no", "primary", "high" };
                for (int i = 0; i < 3; i++)
                {
                    if (eduArr[i] != value)
                    {
                        Console.WriteLine("invalid education");
                    }

                    else
                    {
                        _education = value;
                    }

                }
            }
        }

        public string MaritalStatus
        {
            get
            {
                return _maritalStatus;
            }
            set
            {
                string[] marrArr = { "single", "married" };
                for(int i =0; i < 2; i++)
                {
                    if(marrArr[i] == value)
                    {
                        _maritalStatus = value;
                    }
                    else
                    {
                        Console.WriteLine("invalid marital status");
                    }
                }
            }
        }

        public int Experience
        {
            get
            {
                return _experience;
            }
            set
            {
                if (value>=0 && value <= 100)
                { 
                    _experience = value; 
                }
                else
                {
                    Console.WriteLine("invalid experience");
                }
            }
        }

        public string Qualification
        {
            get
            {
                return _qualification;
            }
            set
            {
                string[] qualArr = { "low", "medium", "high" };
                for (int i = 0; i < 3; i++)
                {
                    if (qualArr[i] == value)
                    {
                        _qualification = value;
                    }
                    else
                    {
                        _qualification = "-";
                    }
                }
            }
        }
        public string RegionOfBirth
        {
            get
            {
                return _regionOfBirth;
            }
            set
            {
                string[] qualArr = { "CIS", "EU", "US" };
                for (int i = 0; i < 3; i++)
                {
                    if (qualArr[i] == value)
                    {
                        _regionOfBirth = value;
                    }
                    else
                    {
                        _regionOfBirth = "other";
                    }
                }
            }
        }

        public string this[string fieldName]
        {
            get
            {
                switch (fieldName)
                {
                    case "firstName": 
                        return _firstName;
                    case "lastName":
                        return _lastName;
                    case "age": 
                        return Convert.ToString(_age);
                    case "education": 
                        return _education;
                    case "experience":
                        return Convert.ToString(_experience);
                    case "marital status":
                        return _maritalStatus;
                    case "qualification": 
                        return _qualification;
                    case "region of birth":
                        return _regionOfBirth;
                    default: 
                        return "There is no such field";
                }
            }
        }

        public void Marriage()
        {
            if (_age >= 18 && _maritalStatus == "single")
            {
                _maritalStatus = "married";
            }
            else
            {
                Console.WriteLine($"{_firstName}, you cannot get married.You are underage.");
            }
        }

        public void Educate()
        {
            if (_education == "no" && _age >= 6)
            {
                _education = "secondary";
                _age += 11;
            }
            else if (_education == "secondary")
            {
                _education = "high";
                _age += 4;
            }
            else
            {
                Console.WriteLine("Your education level is enough");
            }
        }
        public void Work()
        {
            if ( _age >= 16)
            {
                _experience +=1;
                _age += 1;
            }
            else
            {
                Console.WriteLine("You are under age");
            }
        }
        public void Upgrade()
        {
            if (_experience > 10 && _education == "high")
            {
                _qualification = "high";
            }
            else
            {
                _qualification = "high";
            }
        }
        public void GrowingUp()
        {
            _age++;

        }
        public void Information()
        {
            Console.WriteLine($"ID: {_id}\nfirst name: {_firstName}\nlast name: {_lastName}\nAge: {_age}" +
                $" \nQualification: {_qualification}\nRegion of birth: {_regionOfBirth}\nMaritalStatus: {_maritalStatus}\n");
        }
    }
}

