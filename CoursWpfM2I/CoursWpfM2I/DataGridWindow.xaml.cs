using CoursWpfM2I.Classes;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour DataGridWindow.xaml
    /// </summary>
    public partial class DataGridWindow : Window
    {
        public List<Personne> listePersonne;
        public DataGridWindow()
        {
            InitializeComponent();
            listePersonne = new List<Personne>()
            {
                new Personne {Nom = "abadi", Prenom="Ihab"}
            };
            maDataGrid.ItemsSource = listePersonne;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Personne pr = maDataGrid.SelectedItem as Personne;
            foreach(Personne p in listePersonne)
            {
                MessageBox.Show(p.Tel);
            }
        }
    }
}
