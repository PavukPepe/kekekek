using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace PRACT_LAB_5.Admin
{
    /// <summary>
    /// Логика взаимодействия для Orders_admin_page.xaml
    /// </summary>
    public partial class Orders_admin_page : Page
    {
        OzonEntities1 DB = new OzonEntities1();
        public Orders_admin_page()
        {
            InitializeComponent();
            table_grid.ItemsSource = DB.Carts.ToList();
        }

        private void cancel_but_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem !=  null)
            {
                (table_grid.SelectedItem as Carts).Cart_statuses = DB.Cart_statuses.ToList().Where(item => item.Status_name == "Отменен").First();
            }
            Reload();
        }

        void Reload()
        {
            DB.SaveChanges();
            table_grid.ItemsSource = DB.Carts.ToList();
        }

        private void check_but_Click(object sender, RoutedEventArgs e)
        {
            if (table_grid.SelectedItem != null)
            {
                string path = $"Order_#{(table_grid.SelectedItem as Carts).Cart_id}_check.txt";
                File.WriteAllText(path, "\t\tOZON\n");
                File.AppendAllText(path, "Чек #" + (table_grid.SelectedItem as Carts).Cart_id.ToString() + "\n");
                decimal sum = 0;
                foreach (var item in DB.Cart_Goods.ToList().Where(i => i.ID_cart == (table_grid.SelectedItem as Carts).Cart_id))
                {
                    sum += item.amount * item.Goods.Good_price;
                    string name = item.Goods.Good_name;
                    string amount = item.amount.ToString();
                    var ij = item.Goods.Good_price * item.amount;
                    while (name.Length < 24)
                    {
                        name += " ";
                    }
                    while (amount.Length < 3)
                    {
                        amount += " ";
                    }
                    File.AppendAllText(path, $"\t" + name + " x " + amount + " | " + ij.ToString() + "\n");
                }
                string k = "Итого: ";
                while (k.Length < 50 - sum.ToString().Length)
                {
                    k += " ";
                }
                File.AppendAllText(path, $"{k + sum.ToString()}");
                Process.Start(new ProcessStartInfo { FileName = path, UseShellExecute = true });
            }
        }
    }
}
