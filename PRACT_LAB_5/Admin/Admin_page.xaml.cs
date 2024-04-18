using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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


using System.Data;

namespace PRACT_LAB_5.Admin
{
    /// <summary>
    /// Логика взаимодействия для Admin_page.xaml
    /// </summary>
    public partial class Admin_page : Page
    {
        OzonEntities1 DB = new OzonEntities1();
        public Admin_page()
        {
            InitializeComponent();
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

        private void role_but_Click(object sender, RoutedEventArgs e)
        {
            teble_frame.Content = new Roles_page();
        }

        private void pvzs_but_Click(object sender, RoutedEventArgs e)
        {
            teble_frame.Content = new PVZs_page();
        }

        private void user_but_Click(object sender, RoutedEventArgs e)
        {
            teble_frame.Content = new Users_page();
        }

        private void auth_but_Click(object sender, RoutedEventArgs e)
        {
            teble_frame.Content = new Auth_page();
        }

        private void order_but_Click(object sender, RoutedEventArgs e)
        {
            teble_frame.Content = new Orders_admin_page();
        }

        private void posts_but_Click(object sender, RoutedEventArgs e)
        {
            teble_frame.Content = new Posts_page();
        }

        private void statuses_but_Click(object sender, RoutedEventArgs e)
        {
            teble_frame.Content = new Statuses_page();
        }

        private void back_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /*                using (SqlConnection v = new SqlCommand(DB.Database.Connection.ConnectionString))*/
                using (SqlConnection v = new SqlConnection(DB.Database.Connection.ConnectionString))
                {
                    v.Open();
                    using (SqlCommand j = new SqlCommand("dbo.BackupOzon", v))
                    {
                        j.CommandType = CommandType.StoredProcedure;
                        j.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Бэкап успешно сделан");
            }
            catch
            {
                MessageBox.Show("Не удалось сделаь бэкап обратитесть к сис. админу");
            }
        }
    }
}
