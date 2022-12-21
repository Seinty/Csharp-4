using System;


namespace Lab3
{
    enum Frequency { Weekly,Monthly,Yearly};
    [Serializable]
    class Person
    {
        public string name;
        public string surname;
        public DateTime date;

        public Person()
        {
            this.name = "Ivan";
            this.surname = "Ivanov";
            this.date = new DateTime(2000, 8, 9);

        }
        public Person(string name, string surname, DateTime data)
        {
            this.name = name;
            this.surname = surname;
            this.date = data;
        }

        public Person(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
            
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public int GetYear
        {
            get { return date.Year; }
            set { date = new DateTime(value, date.Month, date.Day); }
        }

        public override string ToString()
        {
            return new(name.ToString() + ' ' + surname.ToString() + ' ' + date.ToShortDateString());
        }
        public string ToString1()
        {
            return new(name.ToString() + ' ' + surname.ToString());
        }

        public virtual string ToShortString()
        {
            return new string(name.ToString() + ' ' + surname.ToString());
        }

        public override bool Equals(object obj)
        {
            Person other = obj as Person; 
            if (name.Equals(other.name) && surname.Equals(other.surname) && date.Equals(other.date))
            {
                return true;
            }
            else { return false; }
        }

        public override int GetHashCode()
        {
            int Hashcode = name.GetHashCode() + surname.GetHashCode() + date.GetHashCode();
            return Hashcode;
        }


    }
}