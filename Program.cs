using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    delegate TKey KeySelector<TKey>(Magazine mg);
    delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    class Program
    {
        static void Main(string[] args)
        {
            Person person_1 = new Person("Test1", "Test1", new DateTime(1999, 1, 1));
            Person person_2 = new Person("Test2", "Test2", new DateTime(2000, 2, 2));
            Person person_3 = new Person("Test3", "Test3", new DateTime(2001, 3, 3));
            Person person_4 = new Person("Test4", "Test4", new DateTime(2002, 4, 4));

            Article art_1 = new Article("art_1", person_1, 3);
            Article art_2 = new Article("art_2", person_2, 5);
            Article art_3 = new Article("art_3", person_1, 5);
            Article art_4 = new Article("art_4", person_2, 2);

            Magazine mg_1 = new Magazine("Test_mg_1", Frequency.Weekly, 31, new DateTime(2022, 12,11));
            mg_1.AddEditor(person_1, person_2, person_3, person_4);
            mg_1.AddArticle(art_1, art_2, art_3, art_4);
            Magazine mg_2 = new Magazine("Test_mg_2", Frequency.Monthly, 32, new DateTime(2022, 12, 21));
            mg_2.AddEditor(person_1, person_2);
            mg_2.AddArticle(art_1,art_2);
            Magazine mg_3 = new Magazine("Test_mg_3", Frequency.Monthly, 33, new DateTime(2022, 12, 14));
            mg_3.AddEditor(person_3, person_4);
            mg_3.AddArticle(art_3, art_4);
            Magazine mg_4 = new Magazine("Test_mg_4", Frequency.Yearly, 34, new DateTime(2022, 12, 7));
            mg_4.AddEditor(person_1, person_4);
            mg_4.AddArticle(art_1, art_4);

            /*          Console.WriteLine("-----------------------------Exercise 1---------------------------------");

                      Console.WriteLine("-----------------Collection 1-----------------");
                      KeySelector<string> ex1 = MagazineCollection<string>.GenerateKey;
                      MagazineCollection<string> mag1 = new MagazineCollection<string>(ex1);
                      MagazineCollection<string> mag2 = new MagazineCollection<string>(ex1);
                      mag1.AddMagazine(mg_1, mg_2);
                      mag1.CollectName = "Collection 1";
                      Console.WriteLine(mag1.ToString());
                      Console.WriteLine("-----------------Collection 2-----------------");

                      mag2.AddMagazine(mg_2, mg_3);
                      mag2.CollectName = "Collection 2";
                      Console.WriteLine(mag2.ToString());

                      Console.WriteLine("-----------------------------Exercise 2/3/4---------------------------------");
                      Listener lst = new Listener();
                      mag1.MagazineChanged += lst.OnPropertyChange;
                      mag2.MagazineChanged += lst.OnPropertyChange;
                      //Добавить элементы в коллекции
                      mag1.AddMagazine(mg_4);
                      mag2.AddMagazine(mg_1);
                      //Изменить значения разных свойств элементов, входящих в коллекциb
                      mg_1.Editions = 13;
                      mg_4.DatePubl = new DateTime(2020, 11, 12);
                      //Заменить один из элементов коллекции
                      mag1.Replace(mg_1, mg_2);
                      mag2.Replace(mg_2,mg_3);
                      //Изменить данные в удаленном элементе
                      mg_1.jornal[1].Title = "[Delete]";
                      Console.WriteLine(lst.ToString());*/

            Console.WriteLine("-----------------------------Exercise 1---------------------------------");
            Console.WriteLine("");

            Magazine originalObject = new Magazine("Lab_5", Frequency.Monthly, 8191500, new DateTime(2022,12,10));
            originalObject.AddEditor(person_1);
            originalObject.AddArticle(art_1);
            Magazine deepCopyObject = originalObject.DeepCopy();
            Console.WriteLine("-----------------Original Object----------------- ");
            Console.WriteLine(originalObject.ToString());
            Console.WriteLine("-----------------Copy of object-----------------");
            Console.WriteLine(deepCopyObject.ToString());

            Console.WriteLine("-----------------------------Exercise 2---------------------------------");
            Console.Write("Введите название файла: ");
            string fn = Console.ReadLine();

            FileInfo fileInfo = new FileInfo(fn);
            Magazine rtInput = new Magazine();

            if (fileInfo.Exists)
            {
                rtInput.Load(fn);
            }
            else
            {
                Console.WriteLine("Создане файла...");
                fileInfo.Create();
            }

            //Console.WriteLine(rtInput.ToString());
            rtInput.AddFromConsole();
            Console.WriteLine("");
            rtInput.Save(fn);
            Console.WriteLine(rtInput.ToString());
            Magazine.Load(fn, ref rtInput);
            rtInput.AddFromConsole();
            Console.WriteLine("");
            Magazine.Save(fn, rtInput);
            Console.WriteLine(rtInput.ToString());
        }
    }
}