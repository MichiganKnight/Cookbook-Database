using Cookbook_Database.DatabaseHandler;
using Cookbook_Database.Properties;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

using static Cookbook_Database.CommonFunctions;

namespace Cookbook_Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PrintedRecipes : Window
    {
        public PrintedRecipes()
        {
            InitializeComponent();

            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void BtnSalads_Click(object sender, RoutedEventArgs e)
        {
            ButtonPanel.Children.Clear();

            DisplayRecipes("Salad");
        }

        private void BtnSoups_Click(object sender, RoutedEventArgs e)
        {
            ButtonPanel.Children.Clear();

            DisplayRecipes("Soup");
        }

        private void BtnAppetizers_Click(object sender, RoutedEventArgs e)
        {
            ButtonPanel.Children.Clear();

            DisplayRecipes("Appetizer");
        }

        private void BtnMeat_Click(object sender, RoutedEventArgs e)
        {
            ButtonPanel.Children.Clear();

            DisplayRecipes("Meat");
        }

        private void BtnPoultry_Click(object sender, RoutedEventArgs e)
        {
            ButtonPanel.Children.Clear();

            DisplayRecipes("Poultry");
        }

        private void BtnSeafood_Click(object sender, RoutedEventArgs e)
        {
            ButtonPanel.Children.Clear();

            DisplayRecipes("Seafood");
        }

        private void BtnVegetables_Click(object sender, RoutedEventArgs e)
        {
            ButtonPanel.Children.Clear();

            DisplayRecipes("Vegetable");
        }

        private void BtnSides_Click(object sender, RoutedEventArgs e)
        {
            ButtonPanel.Children.Clear();

            DisplayRecipes("Side");
        }

        private void BtnDesserts_Click(object sender, RoutedEventArgs e)
        {
            ButtonPanel.Children.Clear();

            DisplayRecipes("Dessert");
        }

        private void BtnBreakfast_Click(object sender, RoutedEventArgs e)
        {
            ButtonPanel.Children.Clear();

            DisplayRecipes("Breakfast");
        }

        private void BtnMisc_Click(object sender, RoutedEventArgs e)
        {
            ButtonPanel.Children.Clear();

            DisplayRecipes("Misc");
        }

        /// <summary>
        /// Display all recipes of <see cref="Settings.Default.RecipeType"/>
        /// </summary>
        /// <param name="recipeType">Type of recipe</param>
        private void DisplayRecipes(string recipeType)
        {
            switch (recipeType)
            {
                case "Salad":
                    foreach (string recipe in SaladModel.SaladRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, ButtonPanel, Frame, true);
                    }
                    break;
                case "Soup":
                    foreach (string recipe in SoupModel.SoupRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, ButtonPanel, Frame, true);
                    }
                    break;
                case "Appetizer":
                    foreach (string recipe in AppetizerModel.AppetizerRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, ButtonPanel, Frame, true);
                    }
                    break;
                case "Meat":
                    foreach (string recipe in MeatModel.MeatRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, ButtonPanel, Frame, true);
                    }
                    break;
                case "Poultry":
                    foreach (string recipe in PoultryModel.PoultryRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, ButtonPanel, Frame, true);
                    }
                    break;
                case "Seafood":
                    foreach (string recipe in SeafoodModel.SeafoodRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, ButtonPanel, Frame, true);
                    }
                    break;
                case "Vegetable":
                    foreach (string recipe in VegetableModel.VegetableRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, ButtonPanel, Frame, true);
                    }
                    break;
                case "Side":
                    foreach (string recipe in SideModel.SideRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, ButtonPanel, Frame, true);
                    }
                    break;
                case "Dessert":
                    foreach (string recipe in DessertModel.DessertRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, ButtonPanel, Frame, true);
                    }
                    break;
                case "Breakfast":
                    foreach (string recipe in BreakfastModel.BreakfastRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, ButtonPanel, Frame, true);
                    }
                    break;
                case "Misc":
                    foreach (string recipe in MiscModel.MiscRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, ButtonPanel, Frame, true);
                    }
                    break;
                default:
                    break;
            }
        }

        private void Btn_MouseEnter(object sender, MouseEventArgs e)
        {
            Button? button = sender as Button;

            button.Background = Brushes.LightGray;
        }

        private void Btn_MouseLeave(object sender, MouseEventArgs e)
        {
            Button? button = sender as Button;

            button.Background = Brushes.White;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            PrintedRecipes? Form = Application.Current.MainWindow as PrintedRecipes;

            Form.Close();
        }
    }
}
