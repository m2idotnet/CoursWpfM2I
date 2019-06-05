using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MVVMSinglePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMSinglePage.ViewModels
{
    public class AddClientViewModel : ViewModelBase
    {
        public Client client { get; set; }
        

        public string Nom { get
            {
                return client.Nom;
            }
            set
            {
                client.Nom = value;
                RaisePropertyChanged();
            }
        }

        public string Prenom
        {
            get
            {
                return client.Prenom;
            }
            set
            {
                client.Prenom = value;
                RaisePropertyChanged();
            }
        }

        public ICommand addCommand { get; set; }

        public AddClientViewModel()
        {
            client = new Client();
            addCommand = new RelayCommand(AddClient);
        }
        
        public void AddClient()
        {
            Client.GetClients().Add(client);
            Nom = "";
            Prenom = "";
        }
    }
}
