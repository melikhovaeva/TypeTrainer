using System.Windows;
using TypeMaster.Services;

namespace TypeMaster
{
    public partial class MainWindow : Window
    {
        public MainWindow(INavigationService nav)
        {
            InitializeComponent();
            DataContext = nav;
        }
    }
}