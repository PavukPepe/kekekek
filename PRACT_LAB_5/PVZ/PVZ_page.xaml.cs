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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PRACT_LAB_5.PVZ
{
    /// <summary>
    /// Логика взаимодействия для PVZ_page.xaml
    /// </summary>
    public partial class PVZ_page : Page
    {
        Users u = new Users();
        public PVZ_page(Users user)
        {
            InitializeComponent();
            u = user;
        }

        private void orders_but_Click(object sender, RoutedEventArgs e)
        {
            teble_frame.Content = new Orders_pvz_page(u);
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
