using CoursWpfM2I.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
            maListe = new ObservableCollection<Personne>();
            SqlConnection connection = new SqlConnection(@"Data Source=(localDb)\CoursAdoNet;Integrated Security=True");
            SqlCommand command = new SqlCommand("SELECT * FROM Client", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Personne p = new Personne
                {
                    Nom = reader.GetString(1),
                    Prenom = reader.GetString(2),
                    Tel = reader.GetString(3),
                };
                maListe.Add(p);
            }
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
