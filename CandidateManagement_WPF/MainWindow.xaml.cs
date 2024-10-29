﻿using CandidateManagement_BussinesObject;
using CandidateManagement_Service;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CandidateManagement_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IHRAccountService hRAccountService;
        public MainWindow()
        {
            InitializeComponent();
            hRAccountService = new HRAccountService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Hraccount? hraccount = hRAccountService.GetHraccountByEmail(txtEmail.Text);
            if (hraccount != null && txtPass.Password.Equals(hraccount.Password) && hraccount.MemberRole == 1)
            {
                this.Hide();
                CandidateProfileWindow profileWindow = new CandidateProfileWindow();
                //JobPostingWindow profileWindow = new JobPostingWindow();
                profileWindow.Show();
            }
            else
            {
                MessageBox.Show("Login faile");
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}