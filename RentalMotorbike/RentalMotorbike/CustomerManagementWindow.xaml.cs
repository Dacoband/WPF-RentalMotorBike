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
            try
            {
                var customers = _userRepository.GetCustomers();
                CustomerDataGrid.ItemsSource = customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchCustomer = SearchTextBox.Text.ToLower();
            var allCustomers = _userRepository.GetCustomers(); 
            var customers = allCustomers.Where(c =>
                c.Username.ToLower().Contains(searchCustomer) ||
                c.Email.ToLower().Contains(searchCustomer)
            ).ToList();

            CustomerDataGrid.ItemsSource = customers;
        }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchButton_Click(sender, e);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            User newCustomer = new User
            {
                Username = txtUserName.Text,
                PasswordHash = txtPassword.Text,
                Email = txtEmail.Text,
                RoleId = 3 
            };

            bool isSuccess = _userRepository.AddCustomer(newCustomer);
            if (isSuccess)
            {
                MessageBox.Show("Customer added successfully!");
                ClearInputFields();
                Window_Loaded(sender, e); 
            }
            else
            {
                MessageBox.Show("Failed to add customer.");
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem is User selectedCustomer)
            {
                selectedCustomer.Username = txtUserName.Text;
                selectedCustomer.PasswordHash = txtPassword.Text;
                selectedCustomer.Email = txtEmail.Text;

                bool isSuccess = _userRepository.UpdateCustomer(selectedCustomer);
                if (isSuccess)
                {
                    MessageBox.Show("Customer updated successfully!");
                    ClearInputFields();
                    Window_Loaded(sender, e); 
                }
                else
                {
                    MessageBox.Show("Failed to update customer.");
                }
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem is User selectedCustomer)
            {
                bool isSuccess = _userRepository.RemoveCustomer(selectedCustomer.UserId);
                if (isSuccess)
                {
                    MessageBox.Show("Customer deleted successfully!");
                    ClearInputFields();
                    Window_Loaded(sender, e); 
                }
                else
                {
                    MessageBox.Show("Failed to delete customer.");
                }
            }
        }
    }
}
