using Lab05_CSharp.Models;
using Lab05_CSharp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Lab05_CSharp.ViewModel
{
    class ProcessViewModel : INotifyPropertyChanged
    {
        public Process SelectedProcess { get; set; }
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


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
