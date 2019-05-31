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
    /// Logique d'interaction pour Impot.xaml
    /// </summary>
    public partial class Impot : Window
    {
        public Impot()
        {
            InitializeComponent();
        }

        public void Calculer(object sender, EventArgs e)
        {
            int nbEnfants;
            if(!Int32.TryParse(nbEnfant.Text, out nbEnfants))
            {
                MessageBox.Show("Entrez un entier positif");
            }
            int marier;
            if ((bool)rbOui.IsChecked)
            {
                marier = 0;
            }
            else
            {
                marier = 1;
            }
            double salaire;
            if(!Double.TryParse(salaireAnnuel.Text, out salaire))
            {
                MessageBox.Show("Entrez un nombre");
            }

            double nbPart, impot = 0;

            nbPart = 1;

            if (marier == 0)
                nbPart += 1;
            if (nbEnfants == 1)
                nbPart += 0.5;
            else if (nbEnfants > 1)
                nbPart += nbEnfants - 1;
            salaire *= 0.9;

            if (salaire / nbPart <= 9964)
            {
                impot = 0;
            }
            else if (salaire / nbPart > 9964 && salaire / nbPart <= 27519)
            {
                impot = salaire * 0.14 - 1394.96 * nbPart;
            }
            else if (salaire / nbPart > 27519 && salaire / nbPart <= 73779)
            {
                impot = salaire * 0.3 - 5798 * nbPart;
            }
            else if (salaire / nbPart > 73779 && salaire / nbPart <= 156244)
            {
                impot = salaire * 0.41 - 13913.69 * nbPart;
            }
            else if (salaire / nbPart > 156244)
            {
                impot = salaire * 0.45 - 20163.45 * nbPart;
            }

            TotalImpot.Content = $"Votre impot est de {impot} €";
        }
    }
}
