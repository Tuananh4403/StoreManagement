using Repositories.Entities;
using Services.Services.Products;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace StoreManagement
{
    public partial class ManageProduct : Window
    {
        private readonly IProductService _productService;

        public ManageProduct(IProductService productService)
        {
            InitializeComponent();
            _productService = productService;
            LoadCategories();
        }

        private void LoadCategories()
        {
            var categories = _productService.GetCategories();
            cmbTypeOfProduct.ItemsSource = categories;
        }

        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "Input product name...")
            {
                txtSearch.Text = "";
                txtSearch.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Input product name...";
                txtSearch.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = txtSearch.Text;
            var filteredProducts = _productService.SearchProducts(searchText);
            dataGridProducts.ItemsSource = filteredProducts;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearch.Text;
            var filteredProducts = _productService.SearchProducts(searchText);
            dataGridProducts.ItemsSource = filteredProducts;
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            string productName = txtProductName.Text;
            var selectedCategories = cmbTypeOfProduct.SelectedItems.Cast<Category>().ToList();
            decimal price;
            decimal.TryParse(txtPrice.Text, out price);
            string unit = txtUnit.Text;

            if (!string.IsNullOrEmpty(productName) && selectedCategories.Any() && price > 0 && !string.IsNullOrEmpty(unit))
            {
                Product newProduct = new Product
                {
                    ProductName = productName,
                    Categories = selectedCategories,
                    Price = price,
                    Unit = unit
                };

                try
                {
                    _productService.AddProduct(newProduct);
                    MessageBox.Show("Product added successfully!");
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to add product: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields correctly.");
            }
        }

        private void LoadProducts()
        {
            var products = _productService.GetAllProducts();
            dataGridProducts.ItemsSource = products;
        }
    }
}