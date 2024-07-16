using Repositories.EF;
using Repositories.Repository.Products;
using Repositories.Repository.User;
using Services.Services;
using Services.Services.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace StoreManagement
{
    public partial class AdminPage : Window
    {
        private readonly IUserService _userService;
        private string _fullName;

        public AdminPage(string fullname)
        {
            InitializeComponent();
            _userService = new UserService(new UserRepository(new MyStoreDBContext()));
            FullName = fullname;
            DataContext = this;
        }

        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            MyStoreDBContext dbContext = new MyStoreDBContext();
            IProductRepository productRepository = new ProductRepository(dbContext);
            IProductService productService = new ProductService(productRepository);

            ManageProduct manageProduct = new ManageProduct(productService);
            manageProduct.Show();
            this.Close();

        }
        private void btnStaff_Click(object sender, RoutedEventArgs e)
        {
            ManageStaff manageStaffPage = new ManageStaff();
            manageStaffPage.Show();
            this.Close();
        }
        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            AdminProfile manageProfile = new AdminProfile();
            manageProfile.Show();
            this.Close();
        }
    }
}
