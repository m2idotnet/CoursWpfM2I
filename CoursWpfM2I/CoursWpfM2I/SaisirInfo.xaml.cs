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
    /// Logique d'interaction pour SaisirInfo.xaml
    /// </summary>
    public partial class SaisirInfo : Window
    {
        public SaisirInfo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Personne p = new Personne { Nom = nom.Text, Prenom = prenom.Text };
            DetailInfo windowDetail = new DetailInfo(p);
            windowDetail.Show();
        }
    }
}
