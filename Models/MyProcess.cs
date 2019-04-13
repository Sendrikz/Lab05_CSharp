using Lab05_CSharp.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05_CSharp.Models
{
    public class MyProcess
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

        private HashSet<MyProcessModule> _modules;

        public HashSet<MyProcessModule> Modules
        {
            get
            {
                if (_modules == null)
                    RefreshModules();
                return _modules;
            }
        }

        private HashSet<MyProcessThread> _threads;

        public HashSet<MyProcessThread> Threads
        {
            get
            {
                if (_threads == null)
                    RefreshThreads();
                return _threads;
            }
        }

        internal void RefreshModules()
        {
            if (_modules == null)
                _modules = new HashSet<MyProcessModule>();
            foreach (ProcessModule m in _process.Modules)
            {
                _modules.Add(new MyProcessModule(m));
            }
        }

        internal void RefreshThreads()
        {
            if (_threads == null)
                _threads = new HashSet<MyProcessThread>();
            foreach (ProcessThread t in _process.Threads)
            {
                _threads.Add(new MyProcessThread(t));
            }
        }

        public override bool Equals(object obj)
        {
            return obj is MyProcessThread another && this.Id == another.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
        public class MyProcessThread
        {
            private readonly ProcessThread _thread;

            public int Id => _thread.Id;
            public ThreadState State => _thread.ThreadState;
            public DateTime StartTime => _thread.StartTime;

            internal MyProcessThread([NotNull] ProcessThread thread)
            {
                this._thread = thread;
            }

        public override bool Equals(object obj)
        {
            return obj is MyProcessThread another && this._thread.Equals(another._thread);
        }

        public override int GetHashCode()
        {
            return _thread.GetHashCode();
        }
    }

        public class MyProcessModule
        {
            private readonly ProcessModule _module;

            public string Name => _module.ModuleName;
            public string Path => _module.FileName;

            internal MyProcessModule([NotNull] ProcessModule module)
            {
                this._module = module;
            }

        public override bool Equals(object obj)
        {
            return obj is MyProcessModule another && this._module.Equals(another._module);
        }

        public override int GetHashCode()
        {
            return _module.GetHashCode();
        }
    }
    
}
