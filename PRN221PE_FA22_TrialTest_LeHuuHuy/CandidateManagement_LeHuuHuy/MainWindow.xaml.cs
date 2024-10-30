using Can_BusinessObject;
using Can_Service;
using System.Windows;
using System.Windows.Controls;

namespace CandidateManagement_LeHuuHuy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IHRAccountService iRAccountService;

        public MainWindow()
        {
            InitializeComponent();
            iRAccountService = new HRAccountService();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Hraccount hraccount = iRAccountService.GetHraccountByEmail(txtEmail.Text);
            if (hraccount != null && txtPassword.Password.Equals(hraccount.Password) && hraccount.MemberRole == 1 || hraccount.MemberRole == 2)
            {
                this.Hide();
                CandidateProfileWindow jobPostingWindow = new CandidateProfileWindow(hraccount.MemberRole);
                jobPostingWindow.ShowDialog();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}