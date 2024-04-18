using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace PRACT_LAB_5.Properties
{
    /// <summary>
    /// Логика взаимодействия для Goods_Cart_page.xaml
    /// </summary>
    public partial class Goods_Cart_page : Page
    {
        OzonEntities1 DB = new OzonEntities1();
        Carts cart = new Carts();
        Users u = new Users();

        public Goods_Cart_page(Users user)
        {
            u = user;
            InitializeComponent();
            DataContext = this;
            Check_cart(user);
            goods_grid.ItemsSource = DB.Goods.ToList().Where(item => item.Good_amount > 0);
            var cart_goods = DB.Cart_Goods.ToList().Where(item => item.Carts == cart);
            foreach (var item in cart_goods)
            {
                item.cum_sum = item.amount * item.Goods.Good_price;
            }
            cart_grid.ItemsSource = cart_goods;
        }

        private void clear_cart_but_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in DB.Cart_Goods.ToList().Where(item => item.Carts == cart))
            {
                DB.Cart_Goods.Remove(item as Cart_Goods);
            }
            Reload();
        }

        private void order_but_Click(object sender, RoutedEventArgs e)
        {
            if (cart_grid.Items.Count > 0)
            {
                cart.Cart_statuses = DB.Cart_statuses.ToList().Where(item => item.Status_name == "В обработке").First();
                DB.SaveChanges();
                Check_cart(u);
                Reload();
            }
            else
            {
                MessageBox.Show("На блокировку кнопок нехватило сил, заказ пуст");
            }
        }

        private void add_good_but_Click_1(object sender, RoutedEventArgs e)
        {
            if (goods_grid.SelectedItem != null)
            {
                Cart_Goods goods = new Cart_Goods();
                goods.Goods = goods_grid.SelectedItem as Goods;
                goods.ID_cart = cart.Cart_id;
                goods.amount = 1;
                if (DB.Cart_Goods.ToList().Where(item => item.ID_cart == cart.Cart_id && item.Goods == goods.Goods).Count() != 0)
                    DB.Cart_Goods.ToList().Where(item => item.ID_cart == cart.Cart_id && item.Goods == goods.Goods).First().amount += 1;
                else
                    DB.Cart_Goods.Add(goods);
            }
            Reload();
        }

        private void del_good_but_Click(object sender, RoutedEventArgs e)
        {
            if (cart_grid.SelectedItem != null)
            {
                var i = (cart_grid.SelectedItem as Cart_Goods);
                if (i.amount > 1)
                {
                    i.amount -= 1;
                }
                else
                {
                    DB.Cart_Goods.Remove(i);
                }
            }
            Reload();
        }

        void Reload()
        {
            DB.SaveChanges();
            goods_grid.ItemsSource = DB.Goods.ToList().Where(item => item.Good_amount > 0);
            var cart_goods = DB.Cart_Goods.ToList().Where(item => item.Carts == cart);
            foreach (var item in cart_goods)
            {
                item.cum_sum = item.amount * item.Goods.Good_price;
            }
            cart_grid.ItemsSource = cart_goods;
        }

        void Check_cart(Users user)
        {
            if (DB.Carts.ToList().Where(item => item.ID_user == user.User__id && item.Cart_statuses.Status_name == "Активная").Count() == 0)
            {
                cart.ID_user = user.User__id;
                cart.Cart_statuses = (DB.Cart_statuses.ToList().Where(item => item.Status_name == "Активная").ToList()[0]);
                DB.Carts.Add(cart);
                try
                {
                    DB.SaveChanges();
                }
                catch
                {
                    Window cuurent_win = Window.GetWindow(this);
                    if (cuurent_win != null)
                    {
                        Work_win reg = new Work_win(u);
                        cuurent_win.Close();
                        reg.Show();
                    }
                }
            }
            else
            {
                cart = DB.Carts.ToList().Where(item => item.ID_user == user.User__id && item.Cart_statuses.Status_name == "Активная").First();
            }
        }

        private void goods_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
