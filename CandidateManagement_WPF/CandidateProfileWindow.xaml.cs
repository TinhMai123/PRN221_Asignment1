using CandidateManagement_BussinesObject;
using CandidateManagement_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CandidateManagement_WPF
{
    /// <summary>
    /// Interaction logic for CandidateProfileWindow.xaml
    /// </summary>
    public partial class CandidateProfileWindow : Window
    {
        private ICandidateProfileService _candidateProfileService;
        private IJobPostingService _jobPostingService;
        public CandidateProfileWindow()
        {
            InitializeComponent();
            _candidateProfileService = new CandidateProfileService();
            _jobPostingService = new JobPostingService();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            dtgCandidateProfile.ItemsSource = _candidateProfileService.GetCandidateProfiles();
            cmbPostId.ItemsSource = _jobPostingService.GetJobPostings();
            cmbPostId.DisplayMemberPath = "JobPostingTitle";
            cmbPostId.SelectedValuePath = "PostingId";
            txtCandidateId.Text = string.Empty;
            txtFullname.Text = string.Empty;
            dtpBirthDay.SelectedDate = DateTime.Now;
            txtImageURL.Text = string.Empty;
            txtDescription.Document.Blocks.Clear();
            cmbPostId.SelectedValue = null;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            JobPosting? jobPosting = cmbPostId.SelectedItem as JobPosting;
            if (jobPosting != null)
            {
                CandidateProfile candidateProfile = new()
                {
                    Birthday = dtpBirthDay.SelectedDate,
                    CandidateId = txtCandidateId.Text,
                    Fullname = txtFullname.Text,
                    PostingId = jobPosting.PostingId,
                    ProfileShortDescription = (new TextRange(
                        txtDescription.Document.ContentStart,
                        txtDescription.Document.ContentEnd).Text)
                        .TrimEnd('\r', '\n'),
                    ProfileUrl = txtImageURL.Text,
                };
                if (_candidateProfileService.AddCandidateProfile(candidateProfile))
                {
                    MessageBox.Show("Added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Something went wrong!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }


        }



        private void dtgCandidateProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid)
            {
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
                if (row != null)
                {
                    if (dataGrid.Columns[0].GetCellContent(row).Parent is DataGridCell rowColumn)
                    {
                        string CandidateId = ((TextBlock)rowColumn.Content).Text;
                        CandidateProfile? candidateProfile = _candidateProfileService.GetCandidateProfileById(CandidateId);
                        if (candidateProfile != null)
                        {
                            txtCandidateId.Text = candidateProfile.CandidateId;
                            txtFullname.Text = candidateProfile.Fullname;
                            dtpBirthDay.SelectedDate = candidateProfile.Birthday;
                            txtImageURL.Text = candidateProfile.ProfileUrl;
                            txtDescription.Document.Blocks.Clear();
                            txtDescription.Document.Blocks.Add(new Paragraph(new Run(candidateProfile.ProfileShortDescription)));
                            cmbPostId.SelectedValue = candidateProfile.PostingId;
                        }
                    }
                }
            }
        }
        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {
            CandidateProfile candidateProfile = new()
            {
                CandidateId = txtCandidateId.Text,
            };
            if (_candidateProfileService.DeleteCandidateProfile(candidateProfile))
            {
                MessageBox.Show("Deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Something went wrong!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnUpdate_Click_1(object sender, RoutedEventArgs e)
        {
                CandidateProfile candidate = new CandidateProfile();
                candidate.CandidateId = txtCandidateId.Text;
                candidate.Fullname = txtFullname.Text;
                candidate.Birthday = DateTime.Parse(dtpBirthDay.Text);
                candidate.ProfileUrl = txtImageURL.Text;
                candidate.PostingId = cmbPostId.SelectedValue.ToString();
                candidate.ProfileShortDescription = (new TextRange(
                        txtDescription.Document.ContentStart,
                        txtDescription.Document.ContentEnd).Text)
                        .TrimEnd('\r', '\n');
                if (_candidateProfileService.UpdateCandidateProfile(candidate))
                {
                    MessageBox.Show("Updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Something went wrong!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            JobPostingWindow profileWindow = new JobPostingWindow();
            profileWindow.Show();
        }
    }
}
