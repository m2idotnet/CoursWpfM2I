using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursMVVM.Models
{
    public class Client
    {
        private int id;
        private string nom;
        private string prenom;
        private string tel;

        public string Nom { get => nom; set => nom = value; }
        public int Id { get => id; set => id = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Tel { get => tel; set => tel = value; }

        public void Add()
        {
            //Ajouter dans une base de donnée
        }
    }
}
