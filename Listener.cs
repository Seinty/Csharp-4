using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Listener
    {
        private List<ListEntry> ListofChange = new List<ListEntry>();
        public void OnPropertyChange(object source, MagazinesChangedEventArgs<string> obj)
        {

            ListEntry teamJE = new ListEntry(obj.CollectionName, obj.upd, obj.NameM, obj.Key);
            ListofChange.Add(teamJE);
        }

        public override string ToString()
        {
            string result = "";
            foreach (ListEntry i in ListofChange)
            {
                result += i.ToString() + "\n\n";
            }
            return result;
        }
    }
}
