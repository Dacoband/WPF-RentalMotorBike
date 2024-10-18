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
    /// Interaction logic for AdminProfileWindow.xaml
    /// </summary>
    public partial class AdminProfileWindow : Window
    {
        public AdminProfileWindow()
        {
            InitializeComponent();
        }

        private void btnMotorbikeManagement_Click(object sender, RoutedEventArgs e)
        {
            MotorbikeManagementWindow motorbikeManagementWindow = new MotorbikeManagementWindow();
            motorbikeManagementWindow.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận đăng xuất", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                this.Close();
            }
        }

        private void btnCustomerManagement_Click(object sender, RoutedEventArgs e)
        {
            CustomerManagementWindow customerManagementWindow = new CustomerManagementWindow();
            customerManagementWindow.Show();
            this.Hide();
        }
    }
}
