using Can_BusinessObject;
using Can_Service;
using System.Windows;
using System.Windows.Controls;

namespace CandidateManagement_LeHuuHuy
{
    /// <summary>
    /// Interaction logic for CandidateProfileWindow.xaml
    /// </summary>
    public partial class CandidateProfileWindow : Window
    {
        private ICandidateService candidateService;
        private IJobPostingService jobPostingService;
        private int? RoleID = 0;

        public CandidateProfileWindow(int? roleID)
        {
            InitializeComponent();
            candidateService = new CandidateService();
            jobPostingService = new JobPostingService();
            this.RoleID = roleID;
            switch (roleID)
            {
                case 1:
                    break;
                case 2:
                    this.btn_add.IsEnabled = false;
                    break;
                default:
                    break;
            }
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            loadInitData();
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            var seacrh = txt_search.Text;
            if (seacrh != null)
            {
                var list = candidateService.SearchByName(seacrh);

                DG_Candidate.ItemsSource = list;
            }
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DG_Candidate.SelectedItem != null)
            {
                CandidateProfile selected = DG_Candidate.SelectedItem as CandidateProfile;
                if (selected != null)
                {
                    bool isDeleted = candidateService.DeleteCandidate(selected);

                    if (isDeleted)
                    {
                        MessageBox.Show("Delete Succeed");
                        loadafter();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the Candidate.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a Candidate to delete.");
            }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfile can = new CandidateProfile();

            can.CandidateId = txt_CandidateID.Text;
            can.ProfileShortDescription = txt_Description.Text;
            can.Fullname = txt_FullName.Text;
            can.Birthday = DateTime.Parse(DPBirthday.Text);
            var jobpos = CB_JobPosting.SelectedValue;
            can.PostingId = jobpos.ToString();
            can.ProfileUrl = txt_Image.Text;


            bool update = candidateService.UpdateCandidate(can);

            if (update)
            {
                MessageBox.Show("Update Succeed");
                loadafter();
            }
            else
            {
                MessageBox.Show("Failed to Update the Candidate.");
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfile can = new CandidateProfile();
            can.CandidateId = txt_CandidateID.Text;
            can.Fullname = txt_FullName.Text;
            can.ProfileShortDescription = txt_Description.Text;
            can.Birthday = DateTime.Parse(DPBirthday.Text);
            can.ProfileUrl = txt_Image.Text;
            var pos = CB_JobPosting.SelectedValue;
            can.PostingId = pos.ToString();

            if (candidateService.AddCandidateProfile(can))
            {
                MessageBox.Show("Add Succeed");
                loadafter();
            }
            else
            {
                MessageBox.Show("Uncessfully");
            }
        }

        private void DG_JobPost_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var jobpost = (CandidateProfile)DG_Candidate.SelectedItem;
            if (jobpost != null)
            {
                CB_JobPosting.SelectedValue = jobpost.PostingId;
                txt_CandidateID.IsReadOnly = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadInitData();
        }

        private void loadInitData()
        {
            DG_Candidate.ItemsSource = candidateService.GetCandidates();
            this.CB_JobPosting.ItemsSource = jobPostingService.GetPostings();
            this.CB_JobPosting.DisplayMemberPath = "JobPostingTitle";
            this.CB_JobPosting.SelectedValuePath = "PostingId";
        }

        public void loadafter()
        {
            DG_Candidate.ItemsSource = candidateService.GetCandidates();
        }
    }
}
