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


using System.Data.SqlClient;

namespace NetdLab2
{
    /// <summary>
    /// Interaction logic for LendOut.xaml
    /// </summary>
    public partial class LendOut : UserControl
    {
        public LendOut()
        {
            InitializeComponent();
        }

        private void btnAddToDB_Click(object sender, RoutedEventArgs e)
        {
            int tempint;
            //checks if the name field is empty
            if ((txtName.Text != string.Empty))
            {
                //checks if the employee ID field is empty
                if ((txtEmployeeID.Text != string.Empty))
                {
                    //checks if the employee ID is an integer
                    if (int.TryParse(txtEmployeeID.Text, out tempint))
                    {
                        //checks if the equipment description field is empty
                        if ((txtEquipmentDesc.Text != string.Empty))
                        {
                            //checks if the contact number field is empty
                            if ((txtContactPhone.Text != string.Empty))
                            {
                            
                                try
                                {
                                    //Connect to data source
                                    string connectString = Properties.Settings.Default.connect_string;
                                    SqlConnection cn = new SqlConnection(connectString);
                                    cn.Open();
                                    //Insert a query
                                    string insertQuery = "INSERT INTO Equipment (name, empID, description, phone) VALUES('" + txtName.Text + "', '" + txtEmployeeID.Text + "', '" + txtEquipmentDesc.Text + "', '" + txtContactPhone.Text + "')";
                                    SqlCommand command = new SqlCommand(insertQuery, cn);
                                    command.ExecuteNonQuery();
                                    cn.Close();
                                    //Messagebox for a successful input
                                    MessageBox.Show("Equipment loan has been submitted.");
                                    //Empty the textboxes
                                    txtName.Text = string.Empty;
                                    txtEmployeeID.Text = string.Empty;
                                    txtEquipmentDesc.Text = string.Empty;
                                    txtContactPhone.Text = string.Empty;


                                }
                                //catching any sort of exceptions that might occur.
                                catch (Exception ex)
                                {

                                    MessageBox.Show(ex.ToString());
                                }
                            }
                            //error for empty contact number
                            else
                            {
                                txtContactPhone.Focus();
                                txtContactPhone.SelectAll();
                                MessageBox.Show("You must enter a phone number.");
                            }
                        }
                        //error for empty equipment description
                        else
                        {
                            txtEquipmentDesc.Focus();
                            txtEquipmentDesc.SelectAll();
                            MessageBox.Show("You must enter equipment description.");
                        }
                    }
                    //error for not integer employee ID
                    else
                    {
                        txtEmployeeID.Focus();
                        txtEmployeeID.SelectAll();
                        MessageBox.Show("Employee ID must be and integer.");
                    }
                }
                //error for empty employee ID
                else
                {
                    txtEmployeeID.Focus();
                    txtEmployeeID.SelectAll();
                    MessageBox.Show("You must enter your Employee ID.");
                }
            }
            //error for empty Name
            else
            {
                txtName.Focus();
                txtName.SelectAll();
                MessageBox.Show("You must enter your Name.");
            }
        }
    }
}
