using CoursMVVM.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoursMVVM.ViewModels
{
    public class ClientsViewModel : ViewModelBase
    {
        public Client client { get; set; }
        public string Nom
        {
            get
            {
                return client.Nom;
            }
            set
            {
                client.Nom = value;
                //methode vient du ViewModelBase de Package MVVMLight qui permet de notifier les changement sur la props
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
        public string Tel
        {
            get
            {
                return client.Tel;
            }
            set
            {
                client.Tel = value;
                RaisePropertyChanged();
            }
        }
        public ICommand addCommand { get; set; }

        public ObservableCollection<Client> listeClients { get; set; }

        public ClientsViewModel()
        {
            client = new Client();
            listeClients = new ObservableCollection<Client>();
            addCommand = new RelayCommand(AddClient);
        }

        private void AddClient()
        {
            client.Add();
            listeClients.Add(client);
        }

    }
}
