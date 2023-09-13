using System.Text.RegularExpressions;
using System.Windows;
using UserAbteilungApp.ViewModel;

namespace UserAbteilungApp.View
{
    /// <summary>
    /// Interaction logic for AddNewPositionWindow.xaml
    /// </summary>
    public partial class AddNewPositionWindow : Window
    {
        public AddNewPositionWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }

        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
