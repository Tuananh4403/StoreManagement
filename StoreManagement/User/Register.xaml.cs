using Repositories.Entities;
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
using Services;
using Repositories;
using Repositories.Repository.User;
using Services.Services;
using System.Data;

namespace StoreManagement
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private readonly IUserService _userService;

        public Register()
        {
            InitializeComponent();
        }
        public Register(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }
        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            int phone = int.Parse(txtPhone.Text);
            DateOnly birthday = DateOnly.Parse(txtBD.Text);
            string username = txtUserName.Text;
            string password = txtPassword.Password;
            string role = (cmbRole.SelectedItem as ComboBoxItem)?.Content.ToString();

            Staff newStaff = new Staff
            {
                FullName = fullName,
                Email = email,
                Phone = phone,
                Birthday = birthday,
                UserName = username,
                Password = password,
                Role = role
            };

            try
            {
                _userService.AddStaff(newStaff);
                ShowMessage("Registration successful!");
            }
            catch (Exception ex)
            {
                ShowMessage($"Registration failed: {ex.Message}");
            }
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message, "Registration", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
