using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace M12Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string imagesPath = System.IO.Path.Combine(path, "Images");
            imagePaths = System.IO.Directory.GetFiles(imagesPath, "*.jpg");
            image.Source = new BitmapImage(new Uri(imagePaths[currentIndex]));
        }

        private int currentIndex = 0;
        private string[] imagePaths;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (imagePaths == null)
            {
                string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string imagesPath = System.IO.Path.Combine(path, "Images");
                imagePaths = System.IO.Directory.GetFiles(imagesPath, "*.jpg");
                Array.Sort(imagePaths);
            }

            if (imagePaths.Length == 0)
            {
                return;
            }

            currentIndex = (currentIndex + 1) % imagePaths.Length;
            image.Source = new BitmapImage(new Uri(imagePaths[currentIndex]));
        }
    }
}
