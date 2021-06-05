using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionar
{
    class Cuvant
    {
        public string Nume{get;set;}
        public string Categorie{get;set;}
        public string Definitie{get;set;}

        public Cuvant(string numeInput, string categorieInput,string definitieInput)
        {
            Nume = numeInput;
            Categorie = categorieInput;
            Definitie = definitieInput;
        }

        public Cuvant() { }

    }
}
