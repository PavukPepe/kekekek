using PRACT_LAB_5.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PRACT_LAB_5.ViewModels
{
    internal class MainViewModel : BindingHelper
    {
        OzonEntities1 DB = new OzonEntities1();

        public string LoginText { get; set; }

        public string PassText {  get; set; }

        public CommandHelper Enter {  get; set; }


        private void ent_but_Click()
        {
            if (LoginText != "" && PassText != "")
            {
                if (DB.Authorizations.ToList().FindIndex(item => item.Auth_login == LoginText && item.Auth_pass == PassText) != -1)
                {
                    Work_win win = new Work_win((DB.Authorizations.ToList().Where(item => item.Auth_login == LoginText && item.Auth_pass == PassText).ToList()[0]).Users.ToList()[0]);
                    win.Show();
                    Application.Current.MainWindow.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }

        public MainViewModel() 
        {
            Enter = new CommandHelper(_ => ent_but_Click());
        }

        
    }
}
