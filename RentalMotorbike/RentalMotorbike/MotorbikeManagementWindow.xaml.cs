using RentalMotorbike.BusinessObject.Entities;
using RentalMotorbike.Repositories.Implements;
using RentalMotorbike.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for MotorbikeManagementWindow.xaml
    /// </summary>
    public partial class MotorbikeManagementWindow : Window
    {
        private IMotorbikeRepository _motorbikeRepository;

        public MotorbikeManagementWindow()
        {
            InitializeComponent();
            _motorbikeRepository = new MotorbikeRepository();
        }

        private void ClearInputFields()
        {
            txtBrand.Text = string.Empty;
            txtModel.Text = string.Empty;
            txtLicensePlate.Text = string.Empty;
            txtRentalPrice.Text = string.Empty;
            txtStatus.Text = string.Empty;
        }

        private void MotorbikeDataGrid_SelectionChanged()
        {
            try
            {
                var motorbike = _motorbikeRepository.GetAllMotorbikes();
                MotorbikeDataGrid.ItemsSource = motorbike;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MotorbikeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MotorbikeDataGrid.SelectedItem is Motorbike selectedMotorbike)
            {
                txtBrand.Text = selectedMotorbike.Brand;
                txtModel.Text = selectedMotorbike.Model;
                txtLicensePlate.Text = selectedMotorbike.LicensePlate;
                txtRentalPrice.Text = selectedMotorbike.RentalPricePerDay.ToString();
                txtStatus.Text = selectedMotorbike.StatusId.ToString();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MotorbikeDataGrid_SelectionChanged();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchMotorbike = SearchTextBox.Text.ToLower();
            var allMotorbikes = _motorbikeRepository.GetAllMotorbikes();
            var motorbikes = allMotorbikes.Where(m =>
            m.Brand.ToLower().Contains(searchMotorbike) ||
            m.Model.ToLower().Contains(searchMotorbike) ||
            m.LicensePlate.ToLower().Contains(searchMotorbike)).ToList();
            MotorbikeDataGrid.ItemsSource = motorbikes;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchButton_Click(sender, e);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string licensePlate = txtLicensePlate.Text;
                if (!Regex.IsMatch(licensePlate, "^[0-9]{2}[A-Z]{1}-[0-9]{5}$"))
                {
                    MessageBox.Show("License plate is not in correct format. Example: 29A-12345");
                    return;
                }
                Motorbike motorbike = new Motorbike
                {
                    Brand = txtBrand.Text,
                    Model = txtModel.Text,
                    LicensePlate = licensePlate,
                    RentalPricePerDay = Convert.ToDecimal(txtRentalPrice.Text),
                    StatusId = Convert.ToInt32(txtStatus.Text)
                };
                _motorbikeRepository.AddMotorbike(motorbike);
                MessageBox.Show("Add Motorbike successfully !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MotorbikeDataGrid_SelectionChanged();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string licensePlate = txtLicensePlate.Text;
                if (!Regex.IsMatch(licensePlate, "^[0-9]{2}[A-Z]{1}-[0-9]{5}$"))
                {
                    MessageBox.Show("License plate is not in correct format. Example: 29A-12345");
                    return;
                }
                if (MotorbikeDataGrid.SelectedItem is Motorbike selectedMotorbike)
                {
                    selectedMotorbike.Brand = txtBrand.Text;
                    selectedMotorbike.Model = txtModel.Text;
                    selectedMotorbike.LicensePlate = licensePlate;
                    selectedMotorbike.RentalPricePerDay = Convert.ToDecimal(txtRentalPrice.Text);
                    selectedMotorbike.StatusId = Convert.ToInt32(txtStatus.Text);
                    _motorbikeRepository.UpdateMotorbike(selectedMotorbike);
                }
                MessageBox.Show("Update Motorbike successfully !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MotorbikeDataGrid_SelectionChanged();
                ClearInputFields();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MotorbikeDataGrid.SelectedItem is Motorbike selectedMotorbike)
                {
                    selectedMotorbike.Brand = txtBrand.Text;
                    selectedMotorbike.Model = txtModel.Text;
                    selectedMotorbike.LicensePlate = txtLicensePlate.Text;
                    selectedMotorbike.RentalPricePerDay = Convert.ToDecimal(txtRentalPrice.Text);
                    selectedMotorbike.StatusId = Convert.ToInt32(txtStatus.Text);
                    _motorbikeRepository.RemoveMotorbike(selectedMotorbike.MotorbikeId);
                }
                MessageBox.Show("Delete Motorbike successfully !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MotorbikeDataGrid_SelectionChanged();
                ClearInputFields();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AdminProfileWindow adminProfileWindow = new AdminProfileWindow();
            adminProfileWindow.Show();

            this.Hide();
        }
        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchTextBox.Text == "Search by Brand, Model, or License Plate")
            {
                SearchTextBox.Text = string.Empty;
                SearchTextBox.Foreground = Brushes.Black;
            }
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchTextBox.Text = "Search by Brand, Model, or License Plate";
                SearchTextBox.Foreground = Brushes.Gray;
            }
        }

    }
}
