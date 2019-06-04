using MVVMSinglePage.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSinglePage.ViewModels
{
    public class ListClientsViewModel
    {
        public ObservableCollection<Client> listeClients { get; set; }

        public ListClientsViewModel()
        {
            listeClients = Client.GetClients(); 
        }
    }
}
