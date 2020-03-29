using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DesignPatterns
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count} : {text}");
            return count;
            
        }


        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        

    }

    public class Persistance
    {
        public void Save(Journal j,string filename, bool overrite = false)
        {
            if (overrite || !File.Exists(filename))
            File.WriteAllText(filename, ToString());
        }

        public static void Load(string filename)
        {

        }

        public void Load(Uri uri)
        {

        }
    }

    class Program_SRP
    {
        //static void Main(string[] args)
        //{
        //    var j = new Journal();
        //    j.AddEntry("I played today");
        //    j.AddEntry("I atea a bug");

        //    var p = new Persistance();
        //    var filename = @"C:\temp";
        //    p.Save(j, filename, true);
        //    Process.Start(filename);
        //}
    }
}
