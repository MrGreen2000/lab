using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace NAZAR_LAB
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();
            DB_ServerConnection cnn = DB_ServerConnection.getInstance();
            string str = cnn.Connect("select Student_First_Name, Student_Last_Name, Age, Student_Group, Institute, Specialty,  Student_Card_ID from Student where Student_Login = '"
                + ProfileSearchWindow.GetUser() + "'");
            List<Student> User = DB_ServerConnection.MakeListFromString(str);
            inpName.Text = User[0].FirstName;
            inpSurname.Text = User[0].LastName;
            inpStudID.Text = User[0].Student_Card_ID;
            inpAge.Text = User[0].Age;
            inpInst.Text = User[0].Institute;
            InpSpec.Text = User[0].Specialty;
            inpGroup.Text = User[0].Group;
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            DB_ServerConnection cnn = DB_ServerConnection.getInstance();

            cnn.Connect("update Student set Student_First_Name = '" + inpName.Text +
                            "', Student_Last_Name = '" + inpSurname.Text +
                            "', Age = '" + inpAge.Text +
                            "', Student_Group = '" + inpGroup.Text +
                            "', Institute = '" + inpInst.Text +
                            "', Specialty = '" + InpSpec.Text +
                            "', Student_Card_ID= '" + inpStudID.Text +
                            "' where Student_Login = '" + ProfileSearchWindow.GetUser() + "'");
            MessageBox.Show("Зміни збережено");
        }
    }
}
