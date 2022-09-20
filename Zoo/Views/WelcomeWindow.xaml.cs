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
using Zoo.ViewModels;

namespace Zoo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        public WelcomeWindow()
        {
            InitializeComponent();
            DataContext = new WelcomeWindowVM();            
            /*this.AnimalsView.Items.Add("Влечуги");
            this.AnimalsView.Items.Add("Бозайници");
            this.AnimalsView.Items.Add("Земноводни");
            this.EventsView.Items.Add("Разходка с колело");
            this.EventsView.Items.Add("Разходка плюс пуканки");
            this.TicketsView.Items.Add("Семеен");         
            this.TicketsView.Items.Add("Ученически");         
            this.TicketsView.Items.Add("Редовен");                 
            AnimalsView.Visibility = Visibility.Visible;
            EventsView.Visibility = Visibility.Collapsed;
            TicketsView.Visibility = Visibility.Collapsed;
            btnBuy.Visibility = Visibility.Collapsed;
            btnInfo.Visibility = Visibility.Collapsed;*/
         



        }
        
            
        /*private void btnAnimals_Click(object sender, RoutedEventArgs e)
        {
            EventsView.Visibility = Visibility.Collapsed;
            TicketsView.Visibility = Visibility.Collapsed;
            AnimalsView.Visibility = Visibility.Visible;
            btnBuy.Visibility = Visibility.Collapsed;
            btnInfo.Visibility = Visibility.Collapsed;
            btnSearch.Visibility = Visibility.Visible;

        }

        private void btnEvents_Click(object sender, RoutedEventArgs e)
        {
            AnimalsView.Visibility = Visibility.Collapsed;
            TicketsView.Visibility = Visibility.Collapsed;
            EventsView.Visibility = Visibility.Visible;
            btnInfo.Visibility = Visibility.Visible;
            btnSearch.Visibility = Visibility.Collapsed;
            btnBuy.Visibility = Visibility.Collapsed;
        }

        private void btnTickets_Click(object sender, RoutedEventArgs e)
        {
            AnimalsView.Visibility = Visibility.Collapsed;
            EventsView.Visibility = Visibility.Collapsed;
            TicketsView.Visibility = Visibility.Visible;
            btnSearch.Visibility = Visibility.Collapsed;
            btnInfo.Visibility= Visibility.Collapsed;
            btnBuy.Visibility = Visibility.Visible;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {


           
            if(AnimalsView.SelectedItems.Count == 0)
            {
                AllAnimals window = new AllAnimals();
                window.Show();
                this.Close();
            }
        
           else if(AnimalsView.SelectedItem.Equals("Бозайници"))                                                              
            {
                Bozainici window = new Bozainici();
                window.Show();
                this.Close();
            }
            else  if (AnimalsView.SelectedItem.Equals("Влечуги"))
            {
                Vlechugi window = new Vlechugi();
                window.Show();
                this.Close();
            }
            else  if (AnimalsView.SelectedItem.Equals("Земноводни"))
            {
                Zemnovodni window = new Zemnovodni();
                window.Show();
                this.Close();
            }
            

        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            if (EventsView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Избери събитие");
            }
            else if (EventsView.SelectedItems.Equals("Разходка с колело"))
            {   
                
                MessageBox.Show("Събитието включва разходка с колело и обиколка на цялата зоогическа градина. Има трайност около 2 часа  и е много интересно за децата.Цената е 10лв. на човек");
            }


        }
        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Успещно закупихте билет!");


        }*/
    }
}
