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
    /// Logique d'interaction pour GridCSharp.xaml
    /// </summary>
    public partial class GridCSharp : Window
    {
        public Grid maGrille;
        public GridCSharp()
        {
            InitializeComponent();
            maGrille = new Grid();
            maGrille.RowDefinitions.Add(new RowDefinition()
            {
                //Height = new GridLength(300) // hauteur de 300px
                Height = new GridLength(5, GridUnitType.Star)
            });
            maGrille.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Star)
            });

            maGrille.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });
            maGrille.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star)
            });

            Button b = new Button
            {
                Content = "Click",
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDA6767"))
            };
            maGrille.Children.Add(b);
            Grid.SetColumn(b, 0);
            Grid.SetRow(b, 0);
            Content = maGrille;
        }
    }
}
