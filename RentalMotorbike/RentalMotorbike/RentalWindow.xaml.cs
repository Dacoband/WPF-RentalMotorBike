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
    /// Interaction logic for RentalWindow.xaml
    /// </summary>
    public partial class RentalWindow : Window
    {
        private IRentalRepository _rentalRepository;
        private IMotorbikeRepository _motorbikeRepository;
        private IUserRepository _userRepository;
        private int currentCustomerId;
        public RentalWindow()
        {
            InitializeComponent();
            _rentalRepository = new RentalRepository();
            _motorbikeRepository = new MotorbikeRepository();
            _userRepository = new UserRepository();
            currentCustomerId = AppState.CustomerId;
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var rentals = _rentalRepository.GetRentalsByUserId(currentCustomerId);
                dgRentalMotorbike.ItemsSource = rentals;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgRentalMotorbike_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
