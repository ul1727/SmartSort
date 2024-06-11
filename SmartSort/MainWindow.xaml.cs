using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;


namespace SmartSort
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Spisok();
        }

        string Path;
        List<string> Files = new List<string>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            if (fbd.SelectedPath != "")
            {
                Path = fbd.SelectedPath;
                Files = Directory.GetFiles(Path).ToList();
                List<string> FileNames = new List<string>();
                foreach(string path in Files)
                {
                    FileNames.Add(System.IO.Path.GetFileName(path));
                }
                FileNames.Sort(new RuleForSort2());
                Files.Sort(new RuleForSort2());
                (DataContext as Spisok).Files = FileNames;
            }
        
        }

        private void SPISOK_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var listBox = sender as System.Windows.Controls.ListBox;
            if (listBox != null)
            {
                if (listBox.SelectedItem != null)
                {
                    //string SelectFile = listBox.SelectedItem.ToString();
                    //Process.Start("explorer.exe", $"/select,\"{SelectFile}\"");
                    int ind = listBox.SelectedIndex;
                    Process.Start("explorer.exe", $"/select,\"{Files[ind]}\"");
                }
            }
        }

        private void SPISOK_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ind = SPISOK.SelectedIndex;
            if (SPISOK.SelectedItem != null)
            {
                (DataContext as Spisok).ChooseFile = Files[ind];
               
            }
        }
    }
}
