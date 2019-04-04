using Lab05_CSharp.ViewModel;
using System.Windows.Controls;

namespace Lab05_CSharp.Views
{
    /// <summary>
    /// Логика взаимодействия для ProcessListView.xaml
    /// </summary>
    public partial class ProcessListView : UserControl
    {
        public ProcessListView()
        {
            InitializeComponent();
            DataContext = new ProcessViewModel();
        }
    }
}
