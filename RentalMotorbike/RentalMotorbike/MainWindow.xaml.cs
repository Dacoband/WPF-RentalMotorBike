using Microsoft.VisualBasic.ApplicationServices;
using RentalMotorbike.BusinessObject.Entities;
using RentalMotorbike.Repositories.Implements;
using RentalMotorbike.Repositories.Interfaces;
using RentalMotorbike.Services.Implements;
using RentalMotorbike.Services.Interfaces;
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
using User = RentalMotorbike.BusinessObject.Entities.User;

namespace RentalMotorbike
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IUserRepository _userService;

        public MainWindow()
        {
            InitializeComponent();
            _userService = new UserRepository();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult answer = MessageBox.Show("Do you want to exit the app?", "Exit App!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Password))
            {
                MessageBox.Show("Please enter email and password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            User user = _userService.GetUserByEmailAndPassword(txtEmail.Text, txtPassword.Password);
            if (user == null)
            {
                MessageBox.Show("Invalid email or password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (user != null && txtPassword.Password.Equals(user.PasswordHash) && user.Role.RoleId == 1)
            {
                AdminProfileWindow adminProfileWindow = new AdminProfileWindow();
                adminProfileWindow.Show();
                this.Close();
            }
            else if (user != null && txtPassword.Password.Equals(user.PasswordHash) && user.Role.RoleId == 2)
            {
                EmployeeWindow employeeWindow = new EmployeeWindow();
                employeeWindow.Show();
                this.Close();
            }
            else if (user != null && txtPassword.Password.Equals(user.PasswordHash) && user.Role.RoleId == 3)
            {
                CustomerWindow customerWindow = new CustomerWindow();
                customerWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid email or password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}