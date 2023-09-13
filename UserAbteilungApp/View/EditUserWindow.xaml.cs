using System.Text.RegularExpressions;
using System.Windows;
using UserAbteilungApp.Model;
using UserAbteilungApp.ViewModel;

namespace UserAbteilungApp.View
{
    /// <summary>
    /// Interaction logic for EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        public EditUserWindow(User userToEdit)
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            DataManageVM.SelectedUser = userToEdit;
            DataManageVM.UserName = userToEdit.Name;
            DataManageVM.UserSurName = userToEdit.SurName;
            DataManageVM.UserPhone = userToEdit.Phone;


        }
        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
