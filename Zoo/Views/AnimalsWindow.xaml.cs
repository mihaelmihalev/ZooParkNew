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

namespace Zoo.Views
{
    /// <summary>
    /// Interaction logic for AnimalsWindow.xaml
    /// </summary>
    public partial class AnimalsWindow : Window
    {
        public AnimalsWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            DataContext = new WelcomeWindowVM();
        }
    }
}
