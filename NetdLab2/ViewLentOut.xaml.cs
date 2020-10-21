//Project Name: Net3202_Lab2
//Author: Jacky Yuan
//Date: Oct 15, 2020
//Description: Makes a database software program.
//Change log: N/A

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
    /// Interaction logic for ViewLentOut.xaml
    /// </summary>
    public partial class ViewLentOut : UserControl
    {
        public ViewLentOut()
        {
            InitializeComponent();
            FillDataGrid();
        }
        private void FillDataGrid()
        {
            try
            { //Connect to data source
                string connectString = Properties.Settings.Default.connect_string;
                SqlConnection cn = new SqlConnection(connectString);
                cn.Open();
                //This is the SQL query we want to run.
                string selectionQuery = "SELECT * FROM Equipment";
                SqlCommand command = new SqlCommand(selectionQuery, cn);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                //import the table
                DataTable dt = new DataTable("Users");
                sda.Fill(dt);
                //Bind datatable to the sql table
                dtgOutputDisplay.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                //Shows error in message box.
                MessageBox.Show(ex.ToString());
            }



        }
    }
}
