using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWpfM2I.Classes
{
    public class Personne
    {
        private string nom;
        private string prenom;
        private string tel;

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Tel { get => tel; set => tel = value; }

        public override string ToString()
        {
            return Nom + " "+ Prenom;
        }
    }
}
