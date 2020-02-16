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

namespace NAZAR_LAB
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }
        public void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            if(Login.Text.Length == 0 || RegisterPassword.Text.Length == 0 || ConfirmPassword.Text.Length == 0)
            {
                MessageBox.Show("Заповніть всі поля");
                return;
            }
            else if(RegisterPassword.Text != ConfirmPassword.Text)
            {
                MessageBox.Show("Паролі не співпадають");
                return;
            }
            else
            {
                DB_ServerConnection cnn = DB_ServerConnection.getInstance();

                string[] res = cnn.Connect("select Student_Password from Student where Student_Login = '" + Login.Text + "'").Split('/');
                if (res[0].Length != 0)
                {
                    MessageBox.Show("Користувач з таким логіном вже існує");
                }
                else
                {
                    cnn.Connect("insert into Student (Student_Login, Student_Password) values('" + Login.Text + "', '" + RegisterPassword.Text + "')");
                    ProfileSearchWindow p = new ProfileSearchWindow(Login.Text);
                    p.Show();
                    this.Close();
                }
            }
        }
    }
}
