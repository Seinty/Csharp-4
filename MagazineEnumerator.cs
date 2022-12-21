using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab3
{
    internal class MagazineEnumerator : System.Collections.IEnumerator
    {
        public List<Article> jornals;
        public List<Person> redactor;
        int position = -1;

        public MagazineEnumerator()
        {
            jornals = new List<Article>(0);
            redactor = new List<Person>(0);
        }

        public bool MoveNext()
        {
            if (position < jornals.Count - 1)
            {
                position++;
                while (redactor.Contains(jornals[position].person) && position < jornals.Count - 1)
                {
                    position++;
                }
                if (!redactor.Contains(jornals[position].person))
                    return true;
                return false;
            }
            return false;
        }

        public void Reset()
        {
            position = -1;
        } 

        public MagazineEnumerator(List<Article> jorn, List<Person> red)
        {
            jornals = new List<Article>(jorn);
            redactor = new List<Person>(red);
        }

        public object Current
        {
            get
            {
                if (position == -1 || position >= jornals.Count)
                    throw new IndexOutOfRangeException();
                return jornals[position];
            }
        }

    }
}
