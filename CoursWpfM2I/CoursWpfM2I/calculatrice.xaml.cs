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
    /// Logique d'interaction pour calculatrice.xaml
    /// </summary>
    public partial class calculatrice : Window
    {
        public Grid maGrille;
        public calculatrice()
        {
            InitializeComponent();
            maGrille = new Grid();
            string[] tabElement = new string[] { "C", "+/-", "%", "/", "7", "8", "9", "X", "4", "5", "6", "-", "1", "2", "3", "+", "0", ",", "=" };
            string[] tabOrange = new string[] { "/", "X", "-", "+", "=" };
            for(int i=1; i<=6; i++)
            {
                GridLength hauteur = (i == 1) ? new GridLength(3, GridUnitType.Star) : new GridLength(1, GridUnitType.Star);
                GridLength largeur = new GridLength(1, GridUnitType.Star);
                maGrille.RowDefinitions.Add(new RowDefinition { Height = hauteur });
                if(i <=4)
                {
                    maGrille.ColumnDefinitions.Add(new ColumnDefinition { Width = largeur });
                }
            }
            Label l = new Label
            {
                Content = "0",
                Background = Brushes.Black,
                Foreground = Brushes.White,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                VerticalContentAlignment = VerticalAlignment.Bottom,
                FontSize = 50
            };
            maGrille.Children.Add(l);
            Grid.SetColumn(l, 0);
            Grid.SetRow(l, 0);
            Grid.SetColumnSpan(l, 4);
            int x = 1, y = 0;
            foreach(string c in tabElement)
            {
                Button b = new Button
                {
                    Content = c
                };
                maGrille.Children.Add(b);
                Grid.SetRow(b, x);
                Grid.SetColumn(b, y);
                if(c == "0")
                {
                    Grid.SetColumnSpan(b, 2);
                    y++;
                }
                if (tabOrange.Contains(c))
                {
                    b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA500"));
                    b.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA500"));
                    b.Foreground = Brushes.White;
                }
                if((y+1)%4 != 0)
                {
                    y++;
                }
                else
                {
                    x++;
                    y = 0;
                }
            }
            Content = maGrille;
        }
    }
}
