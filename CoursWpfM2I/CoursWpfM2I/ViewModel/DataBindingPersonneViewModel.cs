using CoursWpfM2I.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWpfM2I.ViewModel
{
    public class DataBindingPersonneViewModel : INotifyPropertyChanged
    {
        public Personne personne { get; set; }
        private string message;
        public ObservableCollection<Personne> listePersonne { get; set; }
        public string Message {
            get
            {
                return message;
            }
            set
            {
                message = value;
                StartNotify("Message");
            }
        }

        public DataBindingPersonneViewModel()
        {
            listePersonne = new ObservableCollection<Personne>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void StartNotify(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
