using Repositories.Repository.User;
using Services.Services;
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
using StoreManagement;
using Repositories.EF;
using Repositories.Entities;

namespace ManageStored
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly IUserService _userService;

        public Login()
        {
            InitializeComponent();
            _userService = new UserService(new UserRepository(new MyStoreDBContext()));
        }
        public Login(IUserService userService)
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
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Password;

            Staff user = await _userService.LoginAsync(username, password);

            if (user != null)
            {
                MessageBox.Show("Login successful!");
                if (user.Role == "Admin")
                {
                    AdminPage adminPage = new AdminPage(user.FullName);
                    adminPage.Show();
                }
                else if (user.Role == "Staff")
                {
                    StaffPage staffPage = new StaffPage();
                    staffPage.Show();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Register registerWindow = new Register(_userService);
            registerWindow.Show();
            this.Close(); 
        }


    }
}
