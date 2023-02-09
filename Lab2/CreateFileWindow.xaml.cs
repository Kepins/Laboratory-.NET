using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Csharp_Lab2
{
    /// <summary>
    /// Interaction logic for CreateFileWindow.xaml
    /// </summary>
    public partial class CreateFileWindow : Window
    {
        public string name;
        public bool success;
        public FileAttributes fileAttributes;


        public CreateFileWindow()
        {
            this.name = "";
            this.success = false;
            this.fileAttributes = FileAttributes.Normal;
            InitializeComponent();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            FileAttributes fileAttributes = FileAttributes.Normal;
            if (directoryRadioBox.IsChecked.Value)
            {
                if(!Regex.IsMatch(name, @"^[1-9A-Za-z~_-]{1,8}$"))
                {
                    MessageBox.Show("Zła nazwa folderu");
                    return;
                }
                fileAttributes |= FileAttributes.Directory;
            }
            else if (!Regex.IsMatch(name, @"^[1-9A-Za-z~_-]{1,8}\.(txt|php|html)$"))
            {
                MessageBox.Show("Zła nazwa pliku");
                return;
            }
            if (readOnlyCheckBox.IsChecked.Value)
            {
                fileAttributes |= FileAttributes.ReadOnly;
            }
            if (archiveCheckBox.IsChecked.Value)
            {
                fileAttributes |= FileAttributes.Archive;
            }
            if (hiddenCheckBox.IsChecked.Value)
            {
                fileAttributes |= FileAttributes.Hidden;
            }
            if (systemCheckBox.IsChecked.Value)
            {
                fileAttributes |= FileAttributes.System;
            }
            this.name = name;
            this.fileAttributes = fileAttributes;
            this.success = true;
            Close();
            
            
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
