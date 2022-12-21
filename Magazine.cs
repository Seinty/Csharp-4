using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab3
{
    interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();
    }
    [Serializable]
    class Magazine : Edition
    {
        protected Frequency freq;
        private List<Person> Editor;
        private List<Article> Journal;

        public Magazine(string jornal1, Frequency period1, int editions1, DateTime datePubl1) : base(jornal1, editions1, datePubl1)
        {
            freq = period1;
            Editor = new (0);
            Journal = new(0);
        }

        public Magazine() : base()
        {
            freq = Frequency.Weekly;
            Editor = new List<Person>();
            Journal = new List<Article>();

        }

        public Frequency Freque
        {
            get { return freq; }
            set { freq = value; }
        }

        public List<Article> jornal
        {
            get { return Journal; }
            set { Journal = value; }
        }

        public List<Person> editor
        {
            get { return Editor; }
            set { Editor = value; }
        }

        public double AverageRaiting
        {
            get
            {
                if (Journal.Count == 0)
                {
                    return 0.0;
                }
                if (Journal == null)
                {
                    return 0.0;
                }

                double sum = 0;
                for (int i = 0; i < Journal.Count; i++)
                    sum += Journal[i].Raiting;
                return sum / Journal.Count;
            }

        }

        public bool this[Frequency period1]
        {
            get
            {
                return freq == period1;
            }
        }

        public override string ToString()
        {
            string str = "";
            str += name.ToString() + ' ' + freq.ToString() + ' ' + datePubl.ToShortDateString()
                + ' ' + editions.ToString() + "\n Статьи:\n";
            foreach (Article element in Journal)
            {
                str+=element.Title.ToString() + ' ' + element.person.ToString1() + ' ' + element.Raiting.ToString()+"\n";
            }
            str+=" Редакторы: \n";
            foreach (Person element in Editor)
            {
                str+=element.ToString()+"\n";
            }
            return str+"\n";
        }

        public Edition Edition
        {
            get
            {
                return new Edition(name, editions, datePubl);
            }
        }

        public void AddArticle(params Article[] jorn)
        {
            if (Journal.Count == 0)
            {
                Journal = new List<Article>();
            }
            for (int i = 0; i < jorn.Length; i++)
            {
                Journal.Add(jorn[i]);
            }
        }

        public void AddEditor(params Person[] red)
        {
            if (Editor == null)
            {
                Person test = new();
                Editor.Add(test);
            }
            for (int i = 0; i < red.Length; i++)
            {
                Editor.Add(red[i]);
            }
        }

        public virtual string ToShortString()
        {
            return "Журнал: " + name + "\nПереодичность: " + freq
                + "\nДата выхода: " + datePubl.ToShortDateString() +
                "\nТираж: " + editions.ToString() + "\nСредний рейтинг: " + AverageRaiting.ToString();
        }

        /*public override object DeepCopy()
        {

            Magazine obj = new();
            obj.name = name;
            obj.datePubl = datePubl;
            obj.editions = editions;
            obj.freq = freq;
            Person[] red = new Person[Editor.Count()];
            Article[] jorn = new Article[Journal.Count()];
            Editor.CopyTo(0, red, 0, Editor.Count());
            Journal.CopyTo(0, jorn, 0, Journal.Count());
            obj.AddEditor(red);
            obj.AddArticle(jorn);

            return obj;
        }*/

        public IEnumerator GetEnumerator()
        {
            return new MagazineEnumerator(Journal, Editor);
        }

        public IEnumerable Edit_red()
        {
            
            foreach (Person element in Editor)
            {
                foreach(Article element2 in Journal)
                {
                    if (element.Equals(element2.person))
                        yield return element2;
                }
            }
        }

        public IEnumerable Edit_no_art()
        {
            int count = 0;
            for (int i = 0; i < Editor.Count; i++)
            {
                bool isCorrect = false;
                for (int j = 0; j < Journal.Count; j++)
                {
                    
                    if (Journal[j].person.Equals(Editor[i]))
                    {
                        isCorrect = true;
                        break;
                    }
                }
                if (!isCorrect) 
                {
                    count++;
                    yield return Editor[i]; 

                }
            }
            if (count == 0)
            {
                Console.WriteLine("У всех редакторов есть публикации");
            }
        }

        public void sortByTitle()
        {
            Journal.Sort();
        }

        public void sortByPersonSur()
        {
            IComparer<Article> cmpr = new Article();
            Journal.Sort(cmpr);
        }

        public void sortByRating()
        {
            //ListArticle.Sort();
            IComparer<Article> cmpr = new ArticleRatingComparer();
            Journal.Sort(cmpr);
        }

        public new Magazine DeepCopy()
        {
            BinaryFormatter format = new BinaryFormatter();
            Magazine copyRt;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                format.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                copyRt = (Magazine)format.Deserialize(memoryStream);
            }
            return copyRt;
        }

        public bool Save(string filename)
        {
            BinaryFormatter format = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    format.Serialize(fs, this);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Load(string filename)
        {
            try
            {
                BinaryFormatter format = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    Magazine mg = (Magazine)format.Deserialize(fs);
                    Console.WriteLine(mg.ToString());
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool AddFromConsole()
        {
            try
            {
                Console.WriteLine("Введите имя,фамилию, дату рождения автора(01.01.1970), название публикации и рейтинг публикации");
                string line = Console.ReadLine();
                string[] endline = line.Split(" ");
                Person tmpPerson = new Person(endline[0], endline[1], Convert.ToDateTime(endline[2]));
                Article tmpArt = new Article(endline[3], tmpPerson, Convert.ToDouble(endline[4]));
                Editor.Add(tmpPerson);
                Journal.Add(tmpArt);
                return true;
            }
            catch
            {
                Console.WriteLine("ERROR");
                return false;
            }
        }
        public static bool Save(string filename, Magazine copyRt)
        {
            BinaryFormatter format = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    format.Serialize(fs, copyRt);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool Load(string filename, ref Magazine copyRt)
        {
            BinaryFormatter format = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    copyRt = (Magazine)format.Deserialize(fs);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
