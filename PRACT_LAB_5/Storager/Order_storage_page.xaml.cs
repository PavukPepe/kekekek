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

namespace PRACT_LAB_5.Storager
{
    /// <summary>
    /// Логика взаимодействия для Order_storage_page.xaml
    /// </summary>
    public partial class Order_storage_page : Page
    {
        OzonEntities1 DB = new OzonEntities1();
        public Order_storage_page()
        {
            InitializeComponent();
            table_grid.ItemsSource = DB.Carts.ToList().Where(item => item.ID_status == DB.Cart_statuses.ToList().Where(iten => iten.Status_name == "В обработке").First().Status_id);
        }

        private void get_but_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null)
            {
                if ((table_grid.SelectedItem as Carts).Cart_statuses.Status_name.ToString() == "В обработке")
                {
                    bool falg = true;
                    foreach (var item in DB.Cart_Goods.ToList())
                    {
                        if (item.Goods.Good_amount - item.amount < 0 && item.Carts == table_grid.SelectedItem as Carts)
                            falg = false;
                    }
                    if (falg)
                    {
                        foreach (var item in DB.Cart_Goods.ToList())
                        {
                            if (item.Carts == table_grid.SelectedItem as Carts)
                                item.Goods.Good_amount -= item.amount;
                        }
                        (table_grid.SelectedItem as Carts).Cart_statuses = DB.Cart_statuses.ToList().Where(item => item.Status_name == "В пути").First();

                    }
                    else
                    {
                        (table_grid.SelectedItem as Carts).Cart_statuses = DB.Cart_statuses.ToList().Where(item => item.Status_name == "Отменен").First();
                    }
                    Reload();

                }
            }
        }

        private void cancel_but_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null)
            {
                if ((table_grid.SelectedItem as Carts).Cart_statuses.Status_name.ToString() == "В обработке")
                {
                    (table_grid.SelectedItem as Carts).Cart_statuses = DB.Cart_statuses.ToList().Where(item => item.Status_name == "Отменен").First();
                    Reload();
                }
            }
        }

        void Reload()
        {
            DB.SaveChanges();
            table_grid.ItemsSource = DB.Carts.ToList().Where(item => item.ID_status == DB.Cart_statuses.ToList().Where(iten => iten.Status_name == "В обработке").First().Status_id);
        }
    }
}
