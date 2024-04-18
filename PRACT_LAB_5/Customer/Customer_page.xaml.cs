using PRACT_LAB_5.Customer;
using PRACT_LAB_5.Properties;
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

namespace PRACT_LAB_5
{
    /// <summary>
    /// Логика взаимодействия для Customer_page.xaml
    /// </summary>
    public partial class Customer_page : Page
    {
        public Users user;
        public Customer_page(Users user)
        {
            InitializeComponent();
            this.user = user;
            teble_frame.Content = new Goods_Cart_page(user);
        }

        private void goods_but_Click(object sender, RoutedEventArgs e)
        {
            teble_frame.Content = new Goods_Cart_page(user);
        }


        private void orders_but_Click(object sender, RoutedEventArgs e)
        {
            teble_frame.Content = new Orders_page(user);
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
