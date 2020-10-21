//Project Name: Net3202_Lab2 Communication Activity
//Author: Jacky Yuan
//Date: Oct 20, 2020
//Description: Makes a database software program.
//Change log: Added search functionality

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

namespace NetdLab2
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

        //Event handler for when listview object lendOut is selected
        private void lwiLendOut_Selected(object sender, RoutedEventArgs e)
        {
            //clears current user control and calls the user control LendOut
            this.gridLendOut.Children.Clear();
            Control lendOutControl = new LendOut();
            this.gridLendOut.Children.Add(lendOutControl);
        }
        //Event handler for when listview object viewlentOut is selected
        private void lwiViewLentOut_Selected(object sender, RoutedEventArgs e)
        {
            //clears current user control and calls the user control ViewLentOut
            this.gridLendOut.Children.Clear();
            Control viewLentOutControl = new ViewLentOut();
            this.gridLendOut.Children.Add(viewLentOutControl);
        }

        //Event handler for when listview object search is selected
        private void lwiSearch_Selected(object sender, RoutedEventArgs e)
        {
            //clears current user control and calls the user control ViewLentOut
            this.gridLendOut.Children.Clear();
            Control viewLentOutControl = new Search();
            this.gridLendOut.Children.Add(viewLentOutControl);
        }
    }
}
