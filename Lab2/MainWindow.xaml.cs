using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MenuItem = System.Windows.Controls.MenuItem;
using Path = System.IO.Path;

namespace Csharp_Lab2
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

        private TreeViewItem CreateTreeViewItem(DirectoryInfo dir)
        {
            var tree = new TreeViewItem
            {
                Header = dir.Name,
                Tag = dir.FullName
            };
            tree.ContextMenu = new System.Windows.Controls.ContextMenu();
            var menuItemDir1 = new MenuItem { Header = "Create"};
            var menuItemDir2 = new MenuItem { Header = "Delete" };
            menuItemDir1.Click += new RoutedEventHandler(CreateInDir_Click);
            menuItemDir2.Click += new RoutedEventHandler(Delete_Click);
            tree.ContextMenu.Items.Add(menuItemDir1);
            tree.ContextMenu.Items.Add(menuItemDir2);
            tree.Selected += new RoutedEventHandler(StatusRASHUpdate);

            foreach (FileInfo fi in dir.GetFiles())
            {
                var item = new TreeViewItem
                {
                    Header = fi.Name,
                    Tag = fi.FullName
                };
                item.ContextMenu = new System.Windows.Controls.ContextMenu();
                var menuItemFile1 = new MenuItem { Header = "Open" };
                var menuItemFile2 = new MenuItem { Header = "Delete" };
                menuItemFile1.Click += new RoutedEventHandler(OpenFile_Click);
                menuItemFile2.Click += new RoutedEventHandler(Delete_Click);
                item.ContextMenu.Items.Add(menuItemFile1);
                item.ContextMenu.Items.Add(menuItemFile2);
                item.Selected += new RoutedEventHandler(StatusRASHUpdate);

                tree.Items.Add(item);
            }
            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                tree.Items.Add(CreateTreeViewItem(di));
            }

            return tree;
        }

        private void OpenOption_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new FolderBrowserDialog() { Description = "Select directory to open" };
            var result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK){
                fileTreeTreeView.Items.Clear();
                DirectoryInfo rootDir = new DirectoryInfo(dlg.SelectedPath);
                fileTreeTreeView.Items.Add(CreateTreeViewItem(rootDir));
            }
        }

        private void ExitOption_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreateInDir_Click(object sender, RoutedEventArgs e)
        {
            if (fileTreeTreeView.SelectedItem != null)
            {
                TreeViewItem selectedItem = (TreeViewItem)fileTreeTreeView.SelectedItem;
                string path = (string)selectedItem.Tag;
                if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
                {
                    CreateFileWindow createFileWindow = new CreateFileWindow();
                    createFileWindow.ShowDialog();
                    if (createFileWindow.success)
                    {
                        string name = createFileWindow.name;
                        FileAttributes fattr = createFileWindow.fileAttributes;

                        if (fattr.HasFlag(FileAttributes.Directory))
                        {
                            string newPath = Path.Combine(path, name);
                            DirectoryInfo newDi = Directory.CreateDirectory(newPath);
                            selectedItem.Items.Add(CreateTreeViewItem(newDi));
                            File.SetAttributes(newPath, fattr);
                        }
                        else
                        {
                            string newPath = Path.Combine(path, name);
                            File.Create(newPath);
                            File.SetAttributes(newPath, fattr);
                            FileInfo newFi = new FileInfo(newPath);
                            var item = new TreeViewItem
                            {
                                Header = newFi.Name,
                                Tag = newFi.FullName
                            };
                            item.ContextMenu = new System.Windows.Controls.ContextMenu();
                            var menuItemFile1 = new MenuItem { Header = "Open" };
                            var menuItemFile2 = new MenuItem { Header = "Delete" };
                            menuItemFile1.Click += new RoutedEventHandler(OpenFile_Click);
                            menuItemFile2.Click += new RoutedEventHandler(Delete_Click);
                            item.ContextMenu.Items.Add(menuItemFile1);
                            item.ContextMenu.Items.Add(menuItemFile2);

                            selectedItem.Items.Insert(0, item);
                        }
                    }
                }
            }
        }

        //deltes directory including 'read only' files and directories
        private void DeleteDirectoryRecursiveRO(DirectoryInfo root)
        {
            FileAttributes fattr = File.GetAttributes(root.FullName);
            //sets 'read only' to false
            File.SetAttributes(root.FullName, fattr & ~FileAttributes.ReadOnly);
            foreach (DirectoryInfo di in root.GetDirectories())
            {
                DeleteDirectoryRecursiveRO(di);
            }
            foreach (FileInfo fi in root.GetFiles())
            {
                File.SetAttributes(fi.FullName, FileAttributes.Normal);
                File.Delete(fi.FullName);
            }
            Directory.Delete(root.FullName);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (fileTreeTreeView.SelectedItem != null)
            {
                TreeViewItem tvitemToDelete = (TreeViewItem)fileTreeTreeView.SelectedItem;
                string path = (string)tvitemToDelete.Tag;
                FileAttributes fattr = File.GetAttributes(path);
                
                //sets 'read only' to false
                File.SetAttributes(path, fattr & ~FileAttributes.ReadOnly);

                if (fattr.HasFlag(FileAttributes.Directory))
                {
                    //removes directory from disk
                    DeleteDirectoryRecursiveRO(new DirectoryInfo(path));

                    //removes directory from tree
                    try
                    {
                        TreeViewItem parent = (TreeViewItem)tvitemToDelete.Parent;
                        parent.Items.Remove(tvitemToDelete);
                    }
                    catch
                    {
                        //has no parent
                        fileTreeTreeView.Items.Clear();
                    }
                }
                else
                {
                    //removes file from disk
                    File.Delete(path);

                    //removes file from tree
                    TreeViewItem parent = (TreeViewItem)tvitemToDelete.Parent;
                    parent.Items.Remove(tvitemToDelete);
                }
            }
        }
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)fileTreeTreeView.SelectedItem;
            if (item != null)
            {
                string path = (string)item.Tag;
                if (!File.GetAttributes(path).HasFlag(FileAttributes.Directory))
                {
                    fileContentScrollViewer.Content = new TextBlock() { Text = File.ReadAllText(path) };
                }
            }
           
        }

        private void StatusRASHUpdate(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)fileTreeTreeView.SelectedItem;
            FileAttributes fileAttributes = File.GetAttributes((string)item.Tag);

            string rash = "";

            rash += ((fileAttributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly) ? "r" : "-";
            rash += ((fileAttributes & FileAttributes.Archive) == FileAttributes.Archive) ? "a" : "-";
            rash += ((fileAttributes & FileAttributes.System) == FileAttributes.System) ? "s" : "-";
            rash += ((fileAttributes & FileAttributes.Hidden) == FileAttributes.Hidden) ? "h" : "-";

            StatusRASH.Text = rash;
        }

    }
}
