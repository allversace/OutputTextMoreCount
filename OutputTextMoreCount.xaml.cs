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

namespace WpfApp10
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WriteText.MaxLength = 100;
            WriteCount.MaxLength = 100;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Poisk_Click(object sender, RoutedEventArgs e)
        {
            if (WriteCount.Text != "")
            {
                string inputWrite = WriteText.Text;
                int inpuCount = int.Parse(WriteCount.Text);

                List<string> words = inputWrite.Split(' ').ToList();
                List<string> count = words.Where(i => i.Length > inpuCount).ToList();
                Result.Text = String.Join(" ", count);
            }
        }

        private void WriteCount_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void WriteCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(!Char.IsDigit(e.Text,0))
                e.Handled = true;
        }
    }
}
