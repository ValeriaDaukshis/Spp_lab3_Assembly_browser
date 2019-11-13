using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Input;
using AssemblyBrowserView.Annotations;
using InfoCollector.Containers;

namespace AssemblyBrowserView
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string _openedFile;
        public ContainerInfo[] Containers { get; set; }
        private Model _browserModel;

        public string Filename
        {
            get
            {
                return Path.GetFileName(_openedFile);
            }
            set
            {
                _openedFile = value;
                OnPropertyChanged();
            }
        }

        public ContainerInfo[] Result
        {
            get
            {
                return Containers;
            }
            set
            {
                Containers = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand OpenFile { get { return new Command(OpenAssembly); } }

        public void OpenAssembly(object obj)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = @"Assemblies|*.dll;*.exe";
                openFileDialog.Title = @"Select assembly";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Filename = openFileDialog.FileName;
                    if (_browserModel == null)
                        _browserModel = new Model();
                    Result = _browserModel.GetResult(openFileDialog.FileName);
                    OnPropertyChanged(nameof(Filename));
                }
            }
        }
    }
}
