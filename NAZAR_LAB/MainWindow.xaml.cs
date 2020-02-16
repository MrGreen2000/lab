using System.Windows;

namespace NAZAR_LAB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        public MainWindow()
        {
            InitializeComponent();
        }
      
        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            Register r = new Register();
            this.Close();
            r.Show();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            DB_ServerConnection cnn = DB_ServerConnection.getInstance();

            string[] res = cnn.Connect("select Student_Password from Student where Student_Login = '" + Login.Text + "'").Split('/');
            if(res[0].Length == 0)
            {
                MessageBox.Show("Користувача з таким логіном не існує");
            }
            else if (res[0] != Password.Password)
            {
                MessageBox.Show("Невірний пароль");
            }
            else if(res[0] == Password.Password)
            {
                ProfileSearchWindow p = new ProfileSearchWindow(Login.Text);
                this.Close();
                p.Show();
            }
        }
    }
}

