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
using archiver.src;
using archiver.src.windows;
using Microsoft.Win32;

namespace archiver
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




        /*
         * BUTTONS
         */

        private void btn_search(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                textbox_input.Text = filename;
            }

        }

        private void btn_archive(object sender, RoutedEventArgs e)
        {
            if (textbox_input.Text != "")
            {
                if (textbox_save_location.Text != "")
                {
                    FileParser file = new FileParser(textbox_input.Text, textbox_save_location.Text);
                    file.archive();
                }
                else
                {
                    FileParser file = new FileParser(textbox_input.Text);
                    file.archive();
                }
                
            }
        }

        private void btn_save_location_search(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                textbox_save_location.Text = filename;
            }
        }

        private void main_window_btn_clear_Click(object sender, RoutedEventArgs e)
        {
            textbox_save_location.Text = "";
            textbox_input.Text = "";
        }

        /*
         * MENU ITEMS
         */
        private void menuItem_about(object sender, RoutedEventArgs e)
        {
            about aboutWin = new about();
            aboutWin.Show();
        }
        // exits the program
        private void menuItem_exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        
    }
   
}
