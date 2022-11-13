using Krasotka3.Entities;
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

namespace Krasotka3.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {   
        
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Btn_SignIn_Click(object sender, RoutedEventArgs e)
        {
            
            User? user;
            using(ApplicationDbContext context = new())
            {
                user = context.Users.FirstOrDefault(u => u.UserLogin == TB_Login.Text && u.UserPassword == TB_Pass.Text);
            }
            if(user == null)
            {
                MessageBox.Show("Неверный логин или пароль");
                TB_Login.Text = string.Empty;
                TB_Pass.Text = string.Empty;
                return;
            }
            UserWindow window = new UserWindow(user);
                window.Show();
            Close();
        }

        private void Btn_Guest_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.UserSurname = "Guest";
            user.UserRole = 0;
            UserWindow window = new UserWindow(user);
            window.Show();
            Close();
        }
    }
}
