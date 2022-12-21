using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab3
{
    [Serializable]
    enum Update { Add, Replace, Property };
    [Serializable]
    class Edition : System.ComponentModel.INotifyPropertyChanged
    {
        protected string  name;    // название журнала
        protected DateTime datePubl;  // Дата выхода журнала
        protected int editions;       // Тираж

        public Edition(string nam,int editions1, DateTime datePubl1)
        {
            name = nam;
            editions = editions1;
            datePubl = datePubl1;
        }

        public Edition()
        {
            name = "QWE";
            datePubl = new DateTime(1970, 01, 01);
            editions = 1000;
        }

        public string Jornal
        {
            get { return name; }
            set { name = value; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public int Editions
        {
            get { return editions; }
            set {
                try
                {
                    if (value <= 0)
                    {
                        throw new Exception("Тираж не может быть отрицательным или нулевым");
                    }
                    else
                    {
                        editions = value;
                        PropertyChanged(this, new PropertyChangedEventArgs("Editions"));
                        
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                }
            }
        }

        public DateTime DatePubl
        {
            get { return datePubl; }
            set { datePubl = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DateofPublication"));
            }
        }

        public override string ToString()
        {
            return new(name.ToString() + ' ' + datePubl.ToShortDateString() + ' ' + editions.ToString());
        }

        public virtual bool Equals(Edition obj)
        {
            
            return name == obj.name && datePubl==obj.datePubl && editions==obj.editions;
        }

        public virtual object DeepCopy()
        {
            Edition obj = new();
            obj.name = name;
            obj.datePubl = datePubl;
            obj.editions = editions;
            return obj;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() ^ datePubl.GetHashCode() ^ editions.GetHashCode();
        }
    }
}
