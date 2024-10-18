using RentalMotorbike.BusinessObject.Entities;
using RentalMotorbike.Repositories.Implements;
using RentalMotorbike.Repositories.Interfaces;
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

namespace RentalMotorbike
{
    /// <summary>
    /// Interaction logic for CustomerManagementWindow.xaml
    /// </summary>
    public partial class CustomerManagementWindow : Window
    {
        private IUserRepository _userRepository;
        public CustomerManagementWindow()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
        }
        private void ClearInputFields()
        {
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AdminProfileWindow adminProfileWindow = new AdminProfileWindow();
            adminProfileWindow.Show();

            this.Hide();
        }
        private void CustomerDataGrid_SelectionChanged()
        {
            try
            {
                var customer = _userRepository.GetCustomers();
                CustomerDataGrid.ItemsSource = customer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CustomerDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem is User selectedCustomer)
            {
                txtUserName.Text = selectedCustomer.Username;
                txtPassword.Text = selectedCustomer.PasswordHash;
                txtEmail.Text = selectedCustomer.Email;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CustomerDataGrid_SelectionChanged();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchCustomer = SearchTextBox.Text.ToLower();
            var allCustomer = _userRepository.GetCustomers;
            var customer = allCustomer.GetType().GetProperties().Where(p => p.GetValue(allCustomer).ToString().ToLower().Contains(searchCustomer)).ToList();

            CustomerDataGrid.ItemsSource = customer;
        }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchButton_Click(sender, e);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
