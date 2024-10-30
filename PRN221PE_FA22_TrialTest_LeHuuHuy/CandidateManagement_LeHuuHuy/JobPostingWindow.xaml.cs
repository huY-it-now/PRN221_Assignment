using Can_BusinessObject;
using Can_Service;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CandidateManagement_LeHuuHuy
{
    /// <summary>
    /// Interaction logic for JobPostingWindow.xaml
    /// </summary>
    public partial class JobPostingWindow : Window
    {
        private IJobPostingService jobPostingService;
        private int? RoleID = 0;

        public JobPostingWindow()
        {
            InitializeComponent();
            jobPostingService = new JobPostingService();
        }

        public JobPostingWindow(int? roleID)
        {
            InitializeComponent();
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

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            JobPosting jobPosting = new JobPosting();
            jobPosting.PostingId = txt_PostId.Text;
            jobPosting.Description = txt_Description.Text;
            jobPosting.JobPostingTitle = txt_Title.Text;
            jobPosting.PostedDate = DateTime.Parse(DPPostdate.Text);

            if (jobPostingService.AddJobPosting(jobPosting))
            {
                MessageBox.Show("Add Succeed");
                loadafter();
            }
            else
            {
                MessageBox.Show("Add nhu cai db");
            }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            JobPosting selectedJobPosting = new JobPosting();

            selectedJobPosting.PostingId = txt_PostId.Text;
            selectedJobPosting.Description = txt_Description.Text;
            selectedJobPosting.JobPostingTitle = txt_Title.Text;
            selectedJobPosting.PostedDate = DateTime.Parse(DPPostdate.Text);

            bool update = jobPostingService.UpdateJobPosting(selectedJobPosting);

            if (update)
            {
                MessageBox.Show("Update Succeed");
                loadafter();
            }
            else
            {
                MessageBox.Show("Failed to Update the job posting.");
            }
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DG_JobPost.SelectedItem != null)
            {
                JobPosting selectedJobPosting = DG_JobPost.SelectedItem as JobPosting;
                if (selectedJobPosting != null)
                {
                    bool isDeleted = jobPostingService.DeleteJobPosting(selectedJobPosting);

                    if (isDeleted)
                    {
                        MessageBox.Show("Delete Succeed");
                        loadafter();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the job posting.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a job posting to delete.");
            }
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DG_JobPost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DG_JobPost.ItemsSource = jobPostingService.GetPostings();
        }

        public void loadafter()
        {
            DG_JobPost.ItemsSource = jobPostingService.GetPostings();
        }
    }
}
