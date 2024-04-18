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
    /// Логика взаимодействия для Storager_page.xaml
    /// </summary>
    public partial class Storager_page : Page
    {
        public Storager_page()
        {
            InitializeComponent();
        }

        private void package_but_Click(object sender, RoutedEventArgs e)
        {
            teble_frame.Content = new Package_types_page();
        }

        private void category_but_Click(object sender, RoutedEventArgs e)
        {
            teble_frame.Content = new Goods_categories_page();
        }

        private void good_but_Click(object sender, RoutedEventArgs e)
        {
            teble_frame.Content = new Goods_page();
        }

        private void orders_but_Click(object sender, RoutedEventArgs e)
        {
            teble_frame.Content = new Storager.Order_storage_page();
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
