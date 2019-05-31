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
    /// Logique d'interaction pour DetailInfo.xaml
    /// </summary>
    public partial class DetailInfo : Window
    {
        public DetailInfo()
        {
            InitializeComponent();
        }

        public DetailInfo(Personne personne)
        {
            InitializeComponent();
            nom.Content = personne.Nom;
            prenom.Content = personne.Prenom;
        }
    }
}
