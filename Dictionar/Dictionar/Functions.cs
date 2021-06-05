using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionar
{
    class Functions
    {
        public void  Afisare(List<Cuvant> cuvinte)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "C:/Users/Gabi/Desktop/Dictionar.txt")))
            {
                foreach (Cuvant x in cuvinte)
                {
                    outputFile.Write(x.Nume);
                    outputFile.Write("-");
                    outputFile.Write(x.Categorie);
                    outputFile.Write("-");
                    outputFile.WriteLine(x.Definitie);
                }
            }
        }
        
        public List<Cuvant> Citire()
        {
            List<Cuvant> cuvinte = new List<Cuvant>();
            string[] lines = System.IO.File.ReadAllLines(@"C:/Users/Gabi/Desktop/Dictionar.txt");

            foreach (string line in lines)
            {
                int i1 = -1, i2 = -1;
                for (int index = 0; index < line.Length; index++)
                    if (line[index] == '-')
                    {
                        if (i1 == -1 && i2 == -1)
                            i1 = index;
                        else
                            if (i2 == -1)
                            i2 = index;

                    }
                int lenght = line.Length - 1;
                Cuvant c = new Cuvant(line.Substring(0, i1), line.Substring(i1 + 1, i2 - i1 - 1), line.Substring(i2 + 1, lenght - i2));
                cuvinte.Add(c);
            }
            return cuvinte;
        }
        public List<string> Cuvinte()
        {

            List<string> cuvinte = new List<string>();
            string[] lines = System.IO.File.ReadAllLines(@"C:/Users/Gabi/Desktop/Dictionar.txt");

            foreach (string line in lines)
            {
                int i1 = -1, i2 = -1;
                for (int index = 0; index < line.Length; index++)
                    if (line[index] == '-')
                    {
                        if (i1 == -1 && i2 == -1)
                            i1 = index;
                        else
                            if (i2 == -1)
                            i2 = index;

                    }

                if (cuvinte.Contains(line.Substring(0, i1)) == false)
                    cuvinte.Add(line.Substring(0,i1));
            }


            return cuvinte;
        }
        public List<string> Categorie()
        {
            
            List<string> categorii = new List<string>();
            string[] lines = System.IO.File.ReadAllLines(@"C:/Users/Gabi/Desktop/Dictionar.txt");

             foreach (string line in lines)
             {
                 int i1 = -1, i2 = -1;
                 for (int index = 0; index < line.Length; index++)
                     if (line[index] == '-')
                     {
                         if (i1 == -1 && i2 == -1)
                             i1 = index;
                         else
                             if (i2 == -1)
                             i2 = index;

                     }

                 if(categorii.Contains(line.Substring(i1 + 1, i2 - i1 - 1))==false)
                    categorii.Add(line.Substring(i1 + 1, i2 - i1 - 1));
             }
             
            
            return categorii;
        }
       
    }
}
