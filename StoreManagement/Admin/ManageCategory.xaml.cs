using Repositories.Entities;
using Services.Services.Categories;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace StoreManagement
{
    public partial class ManageCategory : Window
    {
        private readonly ICategoryService _categoryService;

        public ManageCategory(ICategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;
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

        private async void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            string categoryName = txtCategory.Text;

            if (!string.IsNullOrEmpty(categoryName))
            {
                Category newCategory = new Category
                {
                    CategoryName = categoryName
                };

                try
                {
                    _categoryService.AddCategory(newCategory);
                    MessageBox.Show("Category added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to add category: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please enter a category name.");
            }
        }


    }
}
