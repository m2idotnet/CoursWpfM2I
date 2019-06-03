using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWpfM2I.Classes
{
    public class Personne : INotifyPropertyChanged
    {
        private string nom;
        private string prenom;
        private string tel;

        public string Nom { get => nom; set { nom = value; StartNotify("Nom"); } }
        public string Prenom { get => prenom; set { prenom = value; StartNotify("Prenom"); } }
        public string Tel { get => tel; set => tel = value; }

        public Personne()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void StartNotify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override string ToString()
        {
            return Nom + " "+ Prenom;
        }
    }
}
