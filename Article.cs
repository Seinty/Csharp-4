
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab3
{
    [Serializable]
    class Article : System.IComparable, System.Collections.Generic.IComparer<Article>
    {
        public Person person { get; set; }
        public string Title { get; set; }
        public double Raiting { get; set; }

        public Article(string title1, Person person1, double raiting1)
        {
            person = person1;
            Title = title1;
            Raiting = raiting1;
        }

        public Article()
        {
            person = new Person();
            Title = "Abc";
            Raiting = 7.5;

        }
        public override string ToString()
        {
            return new(Title.ToString() + ' ' + person.ToString1() + ' ' + Raiting.ToString());
        }

        public int CompareTo(object obj)
        {
            Article p = obj as Article;
            if (p != null)
                return this.Title.CompareTo(p.Title);
                throw new ArgumentException("Невозможно сравнить два объекта");
        }
        public int Compare(Article x, Article y)
        {
            if (x.person.Surname[0] > y.person.Surname[0])
                return 1;
            if (x.person.Surname[0] < y.person.Surname[0])
                return -1;
            return 1;
        }

    }
}
