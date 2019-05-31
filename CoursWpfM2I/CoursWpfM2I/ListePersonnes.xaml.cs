using CoursWpfM2I.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CoursWpfM2I
{
    /// <summary>
    /// Logique d'interaction pour ListesInfos.xaml
    /// </summary>
    public partial class ListePersonnes : Window
    {
        public ObservableCollection<Personne> maListe;
        public ListePersonnes()
        {
            InitializeComponent();
            maListe = new ObservableCollection<Personne>() { new Personne { Nom = "toto", Prenom="tata", Tel="06060606060"}, new Personne { Nom = "titi", Prenom = "Minet", Tel = "06060606060" } };
            maListeView.ItemsSource = maListe;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Personne p = maListeView.SelectedItem as Personne;
            if(p != default(Personne))
                maListe.Remove(maListe.First(x => x.Nom == p.Nom && x.Prenom == p.Prenom));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Personne p = maListeView.SelectedItem as Personne;
            if (p != default(Personne))
            {
                SaisirInfo windowSaisi = new SaisirInfo(p, maListe, maListeView);
                windowSaisi.Show();
            }
               
        }
    }
}
