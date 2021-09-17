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

namespace GraduationHandout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            bool check = true;

            if(string.IsNullOrWhiteSpace(citytxt.Text) == true)
            {
                check = false;
                MessageBox.Show("Please enter a valid city.");
            }
            if (string.IsNullOrWhiteSpace(fntxt.Text) == true)
            {
                check = false;
                MessageBox.Show("Please your first name.");
            }
            if (string.IsNullOrWhiteSpace(lntxt.Text) == true)
            {
                check = false;
                MessageBox.Show("Please your last name.");
            }
            if (string.IsNullOrWhiteSpace(majortxt.Text) == true)
            {
                check = false;
                MessageBox.Show("Please enter a valid major.");
            }
            double gpa;
            if (double.TryParse(gpatxt.Text, out gpa) == false)
            {
                check = false;
                MessageBox.Show("Please enter a valid GPA.");
            }
            if (string.IsNullOrWhiteSpace(statetxt.Text) == true)
            {
                check = false;
                MessageBox.Show("Please enter a valid state.");
            }
            if (string.IsNullOrWhiteSpace(snametxt.Text) == true)
            {
                check = false;
                MessageBox.Show("Please enter a valid street name.");
            }


            int streetnumber, zipcode;
            if (int.TryParse(snumtxt.Text, out streetnumber) == false)
            {
                check = false;
                MessageBox.Show("Please enter a valid GPA.");
            }
            if (int.TryParse(ziptxt.Text, out zipcode) == false)
            {
                check = false;
                MessageBox.Show("Please enter a valid GPA.");
            }

            if (check == false)
            {
                return;
            }

            Student student = new Student()
            {
                FirstName = fntxt.Text,
                GPA = gpa,
                LastName = lntxt.Text,
                Major = majortxt.Text
            };
            student.SetAddress(streetnumber, snumtxt.Text, statetxt.Text, citytxt.Text, zipcode);

            Studinfo.Items.Add(student);

        }
    }
}
