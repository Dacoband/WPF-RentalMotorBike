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
using static RentalMotorbike.MainWindow;

namespace RentalMotorbike
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private IUserRepository _customerRepository;
        private IMotorbikeRepository _motorbikeRepository;
        private IRentalRepository _rentalRepository;
        private int currentCustomerId;
        public CustomerWindow()
        {
            InitializeComponent();
            _customerRepository = new UserRepository();
            _motorbikeRepository = new MotorbikeRepository();
            _rentalRepository = new RentalRepository();
            currentCustomerId = AppState.CustomerId;
        }
        private void MotorbikeDataGrid_SelectionChanged()
        {
            try
            {
                var motorbike = _motorbikeRepository.GetMotorbikesAvailableForCustomer(currentCustomerId);
                MotorbikeDataGrid2.ItemsSource = motorbike;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MotorbikeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Window_Loaded2(object sender, RoutedEventArgs e)
        {
            MotorbikeDataGrid_SelectionChanged();
        }

        
        private void RentalButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(MotorbikeDataGrid2.SelectedItem is Motorbike selectedMotorbike)
                {
                    var rental = new Rental
                    {
                        MotorbikeId = selectedMotorbike.MotorbikeId,
                        UserId = currentCustomerId,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(1),
                        TotalPrice = selectedMotorbike.RentalPricePerDay,
                    };
                    var Motorbike = _motorbikeRepository.GetMotorbikeById(selectedMotorbike.MotorbikeId);
                    Motorbike.StatusId = 3;
                    _motorbikeRepository.UpdateMotorbike(Motorbike);
                    _rentalRepository.AddRental(rental);
                    MessageBox.Show($"Rental successfully : {selectedMotorbike.LicensePlate}");
                    var motorbike = (List<Motorbike>)MotorbikeDataGrid2.ItemsSource;
                    motorbike.Remove(selectedMotorbike);
                    MotorbikeDataGrid2.ItemsSource = null;
                    MotorbikeDataGrid2.ItemsSource = motorbike;
                }
                else
                {
                    MessageBox.Show("Please select a motorbike to rent!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            RentalWindow rentalWindow = new RentalWindow();
            rentalWindow.ShowDialog();
            this.Hide();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchMotorbike = SearchTextBox.Text.ToLower();
            var allMotorbikes = _motorbikeRepository.GetAllMotorbikes();
            var motorbikes = allMotorbikes.Where(m =>
            m.Brand.ToLower().Contains(searchMotorbike) ||
            m.Model.ToLower().Contains(searchMotorbike) ||
            m.LicensePlate.ToLower().Contains(searchMotorbike)).ToList();
            MotorbikeDataGrid2.ItemsSource = motorbikes;
        }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchButton_Click(sender, e);
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
    }
}
