using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Input;
using AssemblyBrowserView.Annotations;
using InfoCollector;
using InfoCollector.Containers;

namespace AssemblyBrowserView
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string _filename;
        private AssemblyResult _result;
        private Command _openFileCommand;
        private Model _browserModel;

        public string Filename
        {
            get
            {
                return Path.GetFileName(_filename);
            }
            set
            {
                _filename = value;
                OnPropertyChanged();
            }
        }

        public AssemblyResult Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public ICommand OpenFileCommand
        {
            get
            {
                return _openFileCommand ?? (_openFileCommand = new Command(OpenFileMethod));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void OpenFileMethod(object obj)
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
                }
            }
        }
    }
}
