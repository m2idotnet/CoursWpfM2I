using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace MVVMSinglePage.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand listeCommand { get; set; }
        public ICommand addCommand { get; set; }
        public Grid maGrille;

        public MainWindowViewModel(Grid g)
        {
            maGrille = g;
            listeCommand = new RelayCommand(ListWindow);
            addCommand = new RelayCommand(AddWindow);
        }

        public void ListWindow()
        {
            ResetGrid();
            maGrille.DataContext = new ListClientsViewModel();
            ListView l = new ListView();
            GridView gridView = new GridView();
            gridView.Columns.Add(
                new GridViewColumn()
                {
                    Header = "Nom",
                    Width = 100,
                    DisplayMemberBinding = new Binding("Nom")
                }
                );
            gridView.Columns.Add(new GridViewColumn()
            {
                Header = "Prénom",
                Width = 100,
                DisplayMemberBinding = new Binding("Prenom")
            });
            l.View = gridView;
            l.ItemsSource = (maGrille.DataContext as ListClientsViewModel).listeClients;
            maGrille.Children.Add(l);
        }
        public void AddWindow()
        {
            ResetGrid();
            maGrille.DataContext = new AddClientViewModel();
            for(int i=1; i<= 3; i++)
            {
                maGrille.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                if(i < 3)
                {
                    
                    maGrille.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(i, GridUnitType.Star)});
                } 
                    
            }
            Label lNom = new Label {
                Content = "Nom"
            };
            maGrille.Children.Add(lNom);
            Grid.SetColumn(lNom, 0);
            Grid.SetRow(lNom, 0);
            Label lPrenom = new Label
            {
                Content = "Prénom"
            };
            maGrille.Children.Add(lPrenom);
            Grid.SetColumn(lPrenom, 0);
            Grid.SetRow(lPrenom, 1);
            TextBox tNom = new TextBox
            {
                Text = ""
            };
            maGrille.Children.Add(tNom);
            Grid.SetColumn(tNom, 1);
            Grid.SetRow(tNom, 0);
            TextBox tPrenom = new TextBox
            {
                Text = ""
            };
            maGrille.Children.Add(tPrenom);
            Grid.SetColumn(tPrenom, 1);
            Grid.SetRow(tPrenom, 1);
            Button bAdd = new Button
            {
                Content = "Ajouter",
                Command = (maGrille.DataContext as AddClientViewModel).addCommand
            };
            maGrille.Children.Add(bAdd);
            Grid.SetColumn(bAdd, 0);
            Grid.SetRow(bAdd, 2);
            Grid.SetColumnSpan(bAdd, 2);
            
        }

        private void ResetGrid()
        {
            maGrille.Children.Clear();
            maGrille.RowDefinitions.Clear();
            maGrille.ColumnDefinitions.Clear();
        }
    }
}
