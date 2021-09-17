using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace FulfillData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, List<FulFilldata>> Data = new Dictionary<string, List<FulFilldata>>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Downloads"; //This will get the path

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = path;
            ofd.Filter = "Comma Seperated Value doc (.csv)|*.csv";

            if (ofd.ShowDialog() == true)
            {
                populatedata(ofd.FileName);

                PopulateListBox("Male", lstMales);
                PopulateListBox("Female", lstFemale);
                PopulateListBox("Both", lstBoth);
                PopulateListBoxForMeanGreaterThan();

            }
        }

        private void PopulateListBox(string gender, ListBox lst)
        {
            double maxmean = 0;

            foreach (var item in Data.Keys)
            {
                foreach (var gend in Data[item])
                {
                    if (gender.ToLower() == gend.Gender.ToLower())
                    {
                        if (gend.Mean > maxmean)
                        {
                            maxmean = gend.Mean;
                        }
                    }
                }
               

            }

            foreach (var state in Data.Keys)
            {
                foreach (var gend in Data[state])
                {
                    if (gender.ToLower() == gend.Gender.ToLower())
                    {
                        if (gend.Mean == maxmean)
                        {
                            lst.Items.Add(state);
                        }
                    }
                }


            }

        }

        private void PopulateListBoxForMeanGreaterThan()
        {
            double mean = 8;


            foreach (var state in Data.Keys)
            {
                foreach (var gend in Data[state])
                {
                    if ("both".ToLower() == gend.Gender.ToLower())
                    {
                        if (gend.Mean >= mean)
                        {
                            lstMean.Items.Add(state);
                        }
                    }
                }


            }

        }

                private void populatedata(string file)
        {
            var lines = File.ReadAllLines(file);

            string state = "";

            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                var pieces = line.Split(',');
                if (string.IsNullOrWhiteSpace(pieces[0]) == false)
                {
                    state = pieces[0];
                }

                double mean;
                int n;

                if (double.TryParse(pieces[2], out mean) == false)
                {
                    continue;
                }

                if (int.TryParse(pieces[3], out n) == false)
                {
                    continue;
                }

                if (Data.ContainsKey(state) == false)
                {
                    Data.Add(state, new List<FulFilldata>());
                }

                Data[state].Add(new FulFilldata()
                {
                    State = state,
                    Gender = pieces[1],
                    Mean = mean,
                    N = n,
                });
            }
        }
    }
}
