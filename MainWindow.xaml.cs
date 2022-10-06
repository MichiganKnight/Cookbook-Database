using System.Windows;

using static Cookbook_Database.CommonFunctions;

namespace Cookbook_Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void BtnSalads_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Salad");
        }

        private void BtnSoups_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Soup");
        }

        private void BtnAppetizers_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Appetizer");
        }

        private void BtnMeat_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Meat");
        }

        private void BtnPoultry_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Poultry");
        }

        private void BtnSeafood_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Seafood");
        }

        private void BtnVegetables_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Vegetable");
        }

        private void BtnSides_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Side");
        }

        private void BtnDesserts_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Dessert");
        }

        private void BtnBreakfast_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Breakfast");
        }

        private void BtnMisc_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Misc");
        }
    }
}
