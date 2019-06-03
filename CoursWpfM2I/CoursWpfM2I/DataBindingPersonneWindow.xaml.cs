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
    /// Logique d'interaction pour DataBindingPersonneWindow.xaml
    /// </summary>
    public partial class DataBindingPersonneWindow : Window
    {
        public DataBindingPersonneWindow()
        {
            InitializeComponent();
            Personne p = new Personne
            {
                Nom = "toto",
                Prenom = "tata"
            };
            //Lier la fenetre à l'objet p 
            DataContext = p;
        }
    }
}
