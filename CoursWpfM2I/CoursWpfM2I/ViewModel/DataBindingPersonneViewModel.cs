using CoursWpfM2I.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWpfM2I.ViewModel
{
    public class DataBindingPersonneViewModel
    {
        public Personne personne { get; set; }
        public ObservableCollection<Personne> listePersonne { get; set; }

        public DataBindingPersonneViewModel()
        {
            listePersonne = new ObservableCollection<Personne>();
        }
    }
}
