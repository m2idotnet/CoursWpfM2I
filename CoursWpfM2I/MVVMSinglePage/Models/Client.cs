using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSinglePage.Models
{
    public class Client
    {
        private static ObservableCollection<Client> StaticClients = new ObservableCollection<Client>() { new Client { Nom = "toto", Prenom = "tata" } };
        private string nom;
        private string prenom;

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }

        public void Add()
        {

        }

        public static ObservableCollection<Client> GetClients()
        {
            return StaticClients;
        }
    }
}
