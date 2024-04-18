using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PRACT_LAB_5
{
    /// <summary>
    /// Логика взаимодействия для HR_page.xaml
    /// </summary>
    public partial class HR_page : Page
    {

        OzonEntities1 DB = new OzonEntities1();
        public HR_page()
        {
            InitializeComponent();
        }

        private void candedats_but_Click(object sender, RoutedEventArgs e)
        {
            teble_frame.Content = new Kandidate_page();
        }

        private void role_but_Click(object sender, RoutedEventArgs e)
        {
            teble_frame.Content = new Roles_page();
        }

        private void employeers_but_Click(object sender, RoutedEventArgs e)
        {
            teble_frame.Content = new Employeers_page();
        }

        private void exit_but_Click(object sender, RoutedEventArgs e)
        {
            Window cuurent_win = Window.GetWindow(this);
            if (cuurent_win != null)
            {
                MainWindow reg = new MainWindow();
                cuurent_win.Close();
                reg.Show();
            }
        }
    }
}
