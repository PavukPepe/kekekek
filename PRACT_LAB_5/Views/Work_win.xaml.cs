using PRACT_LAB_5.Admin;
using PRACT_LAB_5.PVZ;
using PRACT_LAB_5.ViewModels;
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
using System.Windows.Shapes;

namespace PRACT_LAB_5
{
    /// <summary>
    /// Логика взаимодействия для Work_win.xaml
    /// </summary>
    public partial class Work_win : Window
    {
        OzonEntities1 DB = new OzonEntities1();
        public Work_win(Users user)
        {
            InitializeComponent();
            DataContext = new WorkerViewModel(user);
        }

        public void CloseToAuth()
        {
            MainWindow n = new MainWindow();
            Close();
            n.Show();
        }
    }
}
