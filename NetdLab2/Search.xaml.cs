//Project Name: Net3202_Lab2 Communication Activity
//Author: Jacky Yuan
//Date: Oct 20, 2020
//Description: Makes a database software program.
//Change log: Added search function

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace NetdLab2
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : UserControl
    {
        public Search()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for search button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            int tempint;
            //checks if the employee ID field is empty
            if ((txtSearchID.Text != string.Empty))
            {
                //checks if the employee ID is an integer
                if (int.TryParse(txtSearchID.Text, out tempint))
                {
                    FillDataGrid();
                }
                //error for non integer employee ID
                else
                {
                    txtSearchID.Focus();
                    txtSearchID.SelectAll();
                    MessageBox.Show("Employee ID must be and integer.");
                }
            }
            //error for empty employee ID search
            else
            {
                txtSearchID.Focus();
                txtSearchID.SelectAll();
                MessageBox.Show("You must enter an employee ID for search.");
            }
        }

        /// <summary>
        /// Function used to get data from the database
        /// </summary>
        private void FillDataGrid()
        {
            try
            { //Connect to data source
                string connectString = Properties.Settings.Default.connect_string;
                SqlConnection cn = new SqlConnection(connectString);
                cn.Open();
                //This is the SQL query we want to run.
                string selectionQuery = "SELECT * FROM Equipment WHERE empID ="+ txtSearchID.Text;
                SqlCommand command = new SqlCommand(selectionQuery, cn);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                //import the table
                DataTable dt = new DataTable("Users");
                sda.Fill(dt);
                //Bind datatable to the sql table
                dtgSearchDisplay.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                //Shows error in message box.
                MessageBox.Show(ex.ToString());
            }

        }

     
    }
}
