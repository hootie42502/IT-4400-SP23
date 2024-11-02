using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
using System.Windows.Forms;
using System.IO;

namespace EricHootenChallengeM8
{
    public partial class MainWindow : Window
    {
        private TextDocument document = new TextDocument();
        
        public MainWindow()
        {
            InitializeComponent();
            document.New();
            DataContext = document;

        }

        private void TextModified(object sender, TextChangedEventArgs e)
        {
            if (!(txtEditor.Text.Equals(document.Content.ToString())))
            {
                document.Changed();
            }

        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            document.New();
            txtEditor.Text = document.Content;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if(document.IsChanged)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save the changes you made to the document?","Confirmation", MessageBoxButton.YesNoCancel);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        // Save the document and exit the application
                        Save_Click(sender, e);
                        System.Windows.Application.Current.Shutdown();
                        break;
                    case MessageBoxResult.No:
                        // Discard the changes and exit the application
                        System.Windows.Application.Current.Shutdown();
                        break;
                    case MessageBoxResult.Cancel:
                        // Do nothing and stay in the application
                        break;
                }
            } 
            else {
                this.Close();
            }
            
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Hello User! This application is a coding assignment meant to teach me how to:\r\n- Use classes FileStream, StreamReader and StreamWriter to read text from and write text to files.\r\n- Use OpenFileDialog and SaveDialog controls to display standard Windows dialog boxes for opening and saving files\r\n- Use \"Using\" statement to release resources\r\n\r\nI am Eric Hooten, I am a Computer Science student at Mizzou in my junior year");
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new System.Windows.Forms.OpenFileDialog();
            fileDialog.DefaultExt = "txt";
            fileDialog.Filter = "Text files (*.txt)|*.txt";
            fileDialog.Multiselect= false;
            fileDialog.ShowDialog();
            if (fileDialog.FileName != "")
            {
                if (System.IO.Path.GetExtension(fileDialog.FileName).ToLower() != ".txt")
                {
                    // Display an error message and return
                    System.Windows.MessageBox.Show("Please select a .txt file.");
                    return;
                }
                document.Open(fileDialog.FileName);
                txtEditor.Text = document.Content;
            }
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e) {
            var saveDialog = new System.Windows.Forms.SaveFileDialog();
            saveDialog.Filter = "Text files (*.txt)|*.txt";
            saveDialog.Title = "Save a text file";
            if(saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                document.Content = txtEditor.Text;
                document.SaveAs(saveDialog.FileName);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(document.FilePath != null)
            {
                document.Content = txtEditor.Text;
                document.Save();
            } 
            else {
                SaveAs_Click(sender, e);
            }
            

        }
    }
}
