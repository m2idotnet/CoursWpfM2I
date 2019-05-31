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
    /// Logique d'interaction pour SaisirInfo.xaml
    /// </summary>
    public partial class SaisirInfo : Window
    {
        ObservableCollection<Personne> maListe;
        ListView maListeView;
        Personne personne;
        public SaisirInfo()
        {
            InitializeComponent();
        }

        public SaisirInfo(Personne p, ObservableCollection<Personne> l, ListView lV)
        {
            InitializeComponent();
            nom.Text = p.Nom;
            prenom.Text = p.Prenom;
            personne = p;
            maListe = l;
            maListeView = lV;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //personne.Nom = nom.Text;
            //personne.Prenom = prenom.Text;
            //maListe.ToList().ForEach((element) =>
            // {
            //     if (element.Nom == personne.Nom && element.Prenom == personne.Prenom)
            //     {
            //         element.Nom = nom.Text;
            //         element.Prenom = prenom.Text;
            //     }
            // });

            ObservableCollection<Personne> tmp = new ObservableCollection<Personne>();
            foreach(Personne pr in maListe)
            {
                if(pr.Nom == personne.Nom && pr.Prenom == personne.Prenom)
                {
                    pr.Nom = nom.Text;
                    pr.Prenom = prenom.Text;
                }
                tmp.Add(pr);
            }
            
            maListe = tmp;
            maListeView.ItemsSource = maListe;
            this.Close();
            //Personne p = new Personne { Nom = nom.Text, Prenom = prenom.Text };
            //DetailInfo windowDetail = new DetailInfo(p);
            //windowDetail.Show();
        }
    }
}
