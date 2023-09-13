using System.Windows;
using UserAbteilungApp.Model;
using UserAbteilungApp.ViewModel;

namespace UserAbteilungApp.View
{
    /// <summary>
    /// Interaction logic for EditDepartmentWindow.xaml
    /// </summary>
    public partial class EditDepartmentWindow : Window
    {
        public EditDepartmentWindow(Department departmentToEdit)
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            DataManageVM.SelectedDepartment = departmentToEdit;
            DataManageVM.DepartmentName = departmentToEdit.Name;

        }
    }
}
