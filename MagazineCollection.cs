using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Lab3
{

    delegate void MagazineChangedHandler<TKey>(object source, MagazinesChangedEventArgs<TKey> args);
    internal class MagazineCollection<TKey>
    {
        private Dictionary<TKey, Magazine> MagazineDictionary = new Dictionary<TKey, Magazine>();
        private KeySelector<TKey> MyKeySelector;

        public MagazineCollection(KeySelector<TKey> tempKey)
        {
            this.MyKeySelector = tempKey;
            MagazineDictionary = new Dictionary<TKey, Magazine>();
        }
        public event MagazineChangedHandler<TKey> MagazineChanged;
        public void AddDefaults()
        {
            Magazine temp = new Magazine();
            TKey tkey = MyKeySelector(temp);
            MagazineDictionary.Add(tkey, temp);
        }
        public void AddMagazine(params Magazine[] magazines)
        {
            foreach (Magazine item in magazines)
            {
                TKey tkey = MyKeySelector(item);
                MagazineDictionary.Add(tkey, item);
                item.PropertyChanged += OnPropertyChange;
            }
        }
        public override string ToString()
        {
            string ret = "";
            foreach (var items in MagazineDictionary)
            {
                ret += items.Key.ToString();
                ret += "\n";
                ret += items.Value.ToString();
                ret += "\n";
            }
            return ret;
        }

        public string ToShortString()
        {
            string str = "";
            foreach (var items in MagazineDictionary)
            {
                str += items.Key.ToString();
                str += items.Value.ToShortString();
            }
            return str;
        }

        public double MaxavrRating
        {
            get
            {
                if (MagazineDictionary.Count == 0)
                {
                    return 0.0;
                }
                if (MagazineDictionary.Values == null)
                {
                    return 0.0;
                }
                return MagazineDictionary.Values.Max(x => x.AverageRaiting);
            }
        }

        public IEnumerable<KeyValuePair<TKey, Magazine>> FrequencyGroup(Frequency value)
        {
            return MagazineDictionary.Where(x => x.Value.Freque == value);
        }

        public IEnumerable<IGrouping<Frequency, KeyValuePair<TKey, Magazine>>> GroupByFreq
        {
            get { return MagazineDictionary.GroupBy(x => x.Value.Freque);  }
        }

        public string CollectName { get; set; } //открытое автореализуемое свойство


        public void OnPropertyChange(object mag, System.ComponentModel.PropertyChangedEventArgs args)
        {
            Magazine mag1 = mag as Magazine;
            if (MagazineDictionary.ContainsValue(mag1))
            {
                foreach (KeyValuePair<TKey, Magazine> i in MagazineDictionary)
                    if (i.Value == mag1)
                    {
                        MagazineChanged(mag1, new MagazinesChangedEventArgs<TKey>(CollectName, Update.Property, args.PropertyName, i.Key));

                    }
            }

        }

        public bool Replace(Magazine mold, Magazine mnew)
            {
                if (MagazineDictionary.ContainsValue(mold))
                {
                    foreach (KeyValuePair<TKey, Magazine> i in MagazineDictionary)
                    {
                        if (i.Value == mold)
                        {
                            MagazineChanged(MagazineDictionary, new MagazinesChangedEventArgs<TKey>(CollectName, Update.Replace, "Replace", i.Key));
                            break;
                        }
                    }
                    return true;
                }
                else
                    return false;
            }
        public static string GenerateKey(Magazine mag)
        {
            return mag.Edition.ToString();
        }

    }
}
