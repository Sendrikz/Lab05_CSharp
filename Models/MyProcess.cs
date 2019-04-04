using Lab05_CSharp.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05_CSharp.Models
{
    class MyProcess
    {
        private readonly Process _process;
        
        public string Name => _process.ProcessName;
        public int Id => _process.Id;
        public string UserName => _process.MachineName;
        //public string FilePath => _process.MainModule.FileName;
        //public DateTime StartDate => _process.StartTime;
        
        public bool isActive => _process.Responding;
        public float CPU => 0;
        public long RAM => _process.PrivateMemorySize64 / 1024;
        public int ThreadCount => _process.Threads.Count;

        internal MyProcess([NotNull] Process process)
        {
            this._process = process;
        }
    }
}
