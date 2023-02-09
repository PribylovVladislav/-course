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
using static System.Net.Mime.MediaTypeNames;

namespace Practice9._5
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

        private void ButtonSplit_Click(object sender, RoutedEventArgs e)
        {
            string sentence = InputBox.Text;
            string[] splitted = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            OutputSplit.ItemsSource= splitted;
        }

        private void ButtonReverse_Click(object sender, RoutedEventArgs e)
        {
            string sentence = InputBoxReverse.Text;
            string[] splitted = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(splitted);
            StringBuilder output = new StringBuilder();
            foreach (string s in splitted)
            {
                output.Append(s + " ");
            }
            LabelTextBlock.Text = output.ToString();
        }
    }
}
