using System.Windows;
using UserAbteilungApp.ViewModel;

namespace UserAbteilungApp.View
{
    /// <summary>
    /// Interaction logic for AddNewDepartmentWindow.xaml
    /// </summary>
    public partial class AddNewDepartmentWindow : Window
    {
        public AddNewDepartmentWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }
    }
}
