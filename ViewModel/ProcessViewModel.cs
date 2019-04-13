using Lab05_CSharp.Models;
using Lab05_CSharp.Properties;
using Lab05_CSharp.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace Lab05_CSharp.ViewModel
{
    class ProcessViewModel : INotifyPropertyChanged
    {
        private MyProcess _selectedProcess;
        public HashSet<MyProcess> ProcessesList { get; set; }
       

        internal ProcessViewModel()
        {
            Process[] processes = Process.GetProcesses();
            ProcessesList = new HashSet<MyProcess>();

            foreach (var process in processes)
            {
                ProcessesList.Add(new MyProcess(process));
            }
        }

        public MyProcess SelectedProcess
        {
            get => _selectedProcess;
            set
            {
                _selectedProcess = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
