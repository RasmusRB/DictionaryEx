using System;
using System.Collections.Generic;

namespace DictionaryEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<FileEndPoint>> dic = new Dictionary<string, List<FileEndPoint>>();
            string filename = "Rasmus.txt";
            FileEndPoint fep1 = new FileEndPoint("localhost", 3030);
            FileEndPoint fep2 = new FileEndPoint("localhost", 3031);
            FileEndPoint fep3 = new FileEndPoint("localhost", 3032);
            FileEndPoint fep4 = new FileEndPoint("localhost", 3033);

            InsertIntoDictionary(dic, filename, fep1); // key findes ikke i forvejen
            InsertIntoDictionary(dic, filename, fep2); // key findes

            DeleteFromDictionary(dic, filename, fep1);
            DeleteFromDictionary(dic, "fileFindesIkke.txt", fep1);

            List<FileEndPoint> liste = SearchInDictionary(dic, filename);
            foreach (FileEndPoint endPoint in liste)
            {
                Console.WriteLine(endPoint);
            }

            InsertIntoDictionary(dic, filename, fep3);
            InsertIntoDictionary(dic, filename, fep4);
            List<FileEndPoint> newListe = SearchInDictionary(dic, "Rasmus.txt");
            foreach (FileEndPoint endPoint in newListe)
            {
                Console.WriteLine(endPoint);
            }

            Console.WriteLine("finito");
        }

        private static void InsertIntoDictionary(Dictionary<string, List<FileEndPoint>> dic, string filename,
            FileEndPoint fep)
        {
            /*
             * insert into dictionary
             */
            if (dic.ContainsKey(filename))
            {
                // key does exist
                List<FileEndPoint> listOfFep = dic[filename];
                listOfFep.Add(fep);
            }
            else
            {
                // key doesn't exist
                List<FileEndPoint> listOfFep = new List<FileEndPoint>();
                listOfFep.Add(fep);
                dic.Add(filename, listOfFep);
            }
        }

        private static void DeleteFromDictionary(Dictionary<string, List<FileEndPoint>> dic, string filename,
            FileEndPoint fep)
        {
            /*
             * delete from dictionary
             */
            if (dic.ContainsKey(filename))
            {
                // key does exist
                List<FileEndPoint> listOfFep = dic[filename];
                listOfFep.RemoveAll(f => f.IpAddress == fep.IpAddress && f.Port == fep.Port);

                // hvis equals er overskredet i FileEndPoint klassen
                // listOfFep.Remove(fep)
            }
            else
            {
                // key doesn't exist
                // kan ikke gøre noget
            }
        }

        private static List<FileEndPoint> SearchInDictionary(Dictionary<string, List<FileEndPoint>> dic,
            string filename)
        {
            if (dic.ContainsKey(filename))
            {
                return dic[filename];
            }

            // returnere en tom liste
            return new List<FileEndPoint>();
        }
    }
}
