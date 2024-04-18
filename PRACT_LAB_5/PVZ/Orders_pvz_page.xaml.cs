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
    /// Логика взаимодействия для Orders_pvz_page.xaml
    /// </summary>
    public partial class Orders_pvz_page : Page
    {
        OzonEntities1 DB = new OzonEntities1();
        Users u = new Users();
        public Orders_pvz_page(Users user)
        {
            InitializeComponent();
            u = user;
            table_grid.ItemsSource = DB.Carts.ToList().Where(item => item.ID_status != DB.Cart_statuses.ToList().Where(iten => iten.Status_name == "Активная").First().Status_id && item.Users.Pvzs.Pvz_address == user.Pvzs.Pvz_address);
        }

        private void get_but_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null)
            {
                if ((table_grid.SelectedItem as Carts).Cart_statuses.Status_name.ToString() == "В пути")
                {
                    (table_grid.SelectedItem as Carts).Cart_statuses = DB.Cart_statuses.ToList().Where(item => item.Status_name == "Ожидает получения").First();
                    Reload();
                }
            }
        }

        private void cancel_but_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null)
            {
                if ((table_grid.SelectedItem as Carts).Cart_statuses.Status_name.ToString() == "В пути")
                {
                    (table_grid.SelectedItem as Carts).Cart_statuses = DB.Cart_statuses.ToList().Where(item => item.Status_name == "Отменен").First();
                    Reload();
                }
            }
        }

        void Reload()
        {
            DB.SaveChanges();
            table_grid.ItemsSource = DB.Carts.ToList().Where(item => item.ID_status != DB.Cart_statuses.ToList().Where(iten => iten.Status_name == "Активная").First().Status_id && item.Users.Pvzs.Pvz_address == u.Pvzs.Pvz_address);
        }
    }
}
