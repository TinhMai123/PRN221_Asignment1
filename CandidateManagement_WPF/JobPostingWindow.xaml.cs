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
    /// Interaction logic for JobPostingWindow.xaml
    /// </summary>
    public partial class JobPostingWindow : Window
    {
        private IJobPostingService _jobPostingService;

        public JobPostingWindow()
        {
            InitializeComponent();
            _jobPostingService = new JobPostingService();
        }

        private void LoadData()
        {
            dtgJobPosting.ItemsSource = _jobPostingService.GetJobPostings();
            txtJobPostingId.Text = String.Empty;
            txtTitle.Text = String.Empty;
            txtDescription.Document.Blocks.Clear();
            dtpPostDate.SelectedDate = DateTime.Now;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            JobPosting jobPosting = new()
            {
                PostingId = txtJobPostingId.Text,
                JobPostingTitle = txtTitle.Text,
                Description = (new TextRange(
                    txtDescription.Document.ContentStart,
                    txtDescription.Document.ContentEnd).Text)
                    .TrimEnd('\r', '\n'),
                PostedDate = dtpPostDate.SelectedDate,
            };
            if (_jobPostingService.AddJobPosting(jobPosting))
            {
                MessageBox.Show("Added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Something went wrong!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {


            JobPosting posting = new()
            {
                PostingId = txtJobPostingId.Text,
                JobPostingTitle = txtTitle.Text,
                PostedDate = DateTime.Parse(dtpPostDate.Text),
                Description = (new TextRange(
                   txtDescription.Document.ContentStart,
                   txtDescription.Document.ContentEnd).Text)
                   .TrimEnd('\r', '\n'),
            };
            if (_jobPostingService.UpdateJobPosting(posting))
            {
                MessageBox.Show("Updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Something went wrong!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dtgJobPosting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid)
            {
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
                if (row != null)
                {
                    if (dataGrid.Columns[0].GetCellContent(row).Parent is DataGridCell rowColumn)
                    {
                        string JobPostingId = ((TextBlock)rowColumn.Content).Text;
                        JobPosting? jobPosting = _jobPostingService.GetJobPosting(JobPostingId);
                        if (jobPosting != null)
                        {
                            txtJobPostingId.Text = jobPosting.PostingId;
                            txtTitle.Text = jobPosting.JobPostingTitle;
                            txtDescription.Document.Blocks.Clear();
                            txtDescription.Document.Blocks.Add(new Paragraph(new Run(jobPosting.Description)));
                            dtpPostDate.SelectedDate = jobPosting.PostedDate;
                        }
                    }
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            JobPosting jobPosting = new()
            {
                PostingId = txtJobPostingId.Text,
            };
            if (_jobPostingService.DeleteJobPosting(jobPosting))
            {
                MessageBox.Show("Deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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
            CandidateProfileWindow profileWindow = new CandidateProfileWindow();
            profileWindow.Show();
        }
    }
}
