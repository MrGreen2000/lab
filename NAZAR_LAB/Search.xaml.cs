using System.Windows;
using System.Windows.Controls;

namespace NAZAR_LAB
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        public Search()
        {
            InitializeComponent();
            DB_ServerConnection cnn = DB_ServerConnection.getInstance();
            string str = cnn.Connect("select Student_First_Name, Student_Last_Name, Age, Student_Group, Institute, Specialty,  Student_Card_ID from Student where Student_First_Name is not null");
            Student_Grid.ItemsSource = DB_ServerConnection.MakeListFromString(str);
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            DB_ServerConnection cnn = DB_ServerConnection.getInstance();
            string s = SearchInput.Text;
            string str = cnn.Connect("select Student_First_Name, Student_Last_Name, Age, Student_Group, Institute, Specialty,  Student_Card_ID from Student where " +
                "Student_First_Name like'%" + s +
                "%' OR Student_Last_Name like '%" + s +
                "%' OR Age like '%" + s +
                "%' OR Student_Group like '%" + s +
                "%' OR  Institute like '%" + s +
                "%' OR  Specialty like '%" + s +
                "%' OR Student_Card_ID like '%" + s + "%'");
            Student_Grid.ItemsSource = DB_ServerConnection.MakeListFromString(str);
        }

    }
}
