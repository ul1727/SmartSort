using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace SmartSort
{
    internal class Spisok : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        private List<string> _Files;
        public List<string> Files
        {
            get { return _Files; }
            set
            {
                _Files = value;
                OnPropertyChanged("Files");
            }
        }

        private BitmapSource _ImageSource;
        public BitmapSource ImageSource
        {
            get { return _ImageSource; }
            set
            {
                _ImageSource = value;
                OnPropertyChanged("ImageSource");
            }
        }
        private string _ChooseFile;
        public string ChooseFile
        {
            get { return _ChooseFile; }
            set
            {
                _ChooseFile = value;
                string[] photonames = new string[] { ".jpg", ".png", ".jpeg", ".tiff", ".gif", ".bmp", ".ico", ".webp", ".raw" };
                if (!string.IsNullOrEmpty(ChooseFile) && System.IO.File.Exists(ChooseFile) && Directory.Exists(System.IO.Path.GetDirectoryName(ChooseFile)))
                { //1
                    if (photonames.Contains(System.IO.Path.GetExtension(value)))
                    {
                       
                        BitmapImage X = new BitmapImage();
                        X.BeginInit();
                        X.UriSource = new Uri(value, UriKind.RelativeOrAbsolute);
                        X.EndInit();
                        ImageSource = X;

                    }
                    else
                    {
                        var icon = System.Drawing.Icon.ExtractAssociatedIcon(value);
                        BitmapSource X1 = Imaging.CreateBitmapSourceFromHIcon(
                            icon.Handle, System.Windows.Int32Rect.Empty,
                            BitmapSizeOptions.FromEmptyOptions());
                        ImageSource = X1;
                    }

                    OnPropertyChanged("ChooseFile");
                }//1
            }

        }

    }
}
