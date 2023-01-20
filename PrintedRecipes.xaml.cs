using Cookbook_Database.DatabaseHandler;
using Cookbook_Database.Properties;
using Cookbook_Database.Windows;
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
            TitleLabel.Content = "Cookbook Database - Printed Country Recipes";
            SubtitleLabel.Content = "Salad Recipes";

            ButtonPanel.Visibility = Visibility.Collapsed;

            DisplayRecipes("Salad");
        }

        private void BtnSoups_Click(object sender, RoutedEventArgs e)
        {
            TitleLabel.Content = "Cookbook Database - Printed Country Recipes";
            SubtitleLabel.Content = "Soup Recipes";

            ButtonPanel.Visibility = Visibility.Collapsed;

            DisplayRecipes("Soup");
        }

        private void BtnAppetizers_Click(object sender, RoutedEventArgs e)
        {
            TitleLabel.Content = "Cookbook Database - Printed Country Recipes";
            SubtitleLabel.Content = "Appetizer Recipes";

            ButtonPanel.Visibility = Visibility.Collapsed;

            DisplayRecipes("Appetizer");
        }

        private void BtnMeat_Click(object sender, RoutedEventArgs e)
        {
            TitleLabel.Content = "Cookbook Database - Printed Country Recipes";
            SubtitleLabel.Content = "Meat Recipes";

            ButtonPanel.Visibility = Visibility.Collapsed;

            DisplayRecipes("Meat");
        }

        private void BtnPoultry_Click(object sender, RoutedEventArgs e)
        {
            TitleLabel.Content = "Cookbook Database - Printed Country Recipes";
            SubtitleLabel.Content = "Poultry Recipes";

            ButtonPanel.Visibility = Visibility.Collapsed;

            DisplayRecipes("Poultry");
        }

        private void BtnSeafood_Click(object sender, RoutedEventArgs e)
        {
            TitleLabel.Content = "Cookbook Database - Printed Country Recipes";
            SubtitleLabel.Content = "Seafood Recipes";

            ButtonPanel.Visibility = Visibility.Collapsed;

            DisplayRecipes("Seafood");
        }

        private void BtnVegetables_Click(object sender, RoutedEventArgs e)
        {
            TitleLabel.Content = "Cookbook Database - Printed Country Recipes";
            SubtitleLabel.Content = "Vegetable Recipes";

            ButtonPanel.Visibility = Visibility.Collapsed;

            DisplayRecipes("Vegetable");
        }

        private void BtnSides_Click(object sender, RoutedEventArgs e)
        {
            TitleLabel.Content = "Cookbook Database - Printed Country Recipes";
            SubtitleLabel.Content = "Side Recipes";

            ButtonPanel.Visibility = Visibility.Collapsed;

            DisplayRecipes("Side");
        }

        private void BtnDesserts_Click(object sender, RoutedEventArgs e)
        {
            TitleLabel.Content = "Cookbook Database - Printed Country Recipes";
            SubtitleLabel.Content = "Dessert Recipes";

            ButtonPanel.Visibility = Visibility.Collapsed;

            DisplayRecipes("Dessert");
        }

        private void BtnBreakfast_Click(object sender, RoutedEventArgs e)
        {
            TitleLabel.Content = "Cookbook Database - Printed Country Recipes";
            SubtitleLabel.Content = "Breakfast Recipes";

            ButtonPanel.Visibility = Visibility.Collapsed;

            DisplayRecipes("Breakfast");
        }

        private void BtnMisc_Click(object sender, RoutedEventArgs e)
        {
            TitleLabel.Content = "Cookbook Database - Printed Country Recipes";
            SubtitleLabel.Content = "Misc Recipes";

            ButtonPanel.Visibility = Visibility.Collapsed;

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
                        CreateRecipeButtons(recipe, RecipePanel, Frame, true);

                        RecipePanel.Visibility = Visibility.Visible;
                    }
                    break;
                case "Soup":
                    foreach (string recipe in SoupModel.SoupRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, RecipePanel, Frame, true);

                        RecipePanel.Visibility = Visibility.Visible;
                    }
                    break;
                case "Appetizer":
                    foreach (string recipe in AppetizerModel.AppetizerRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, RecipePanel, Frame, true);

                        RecipePanel.Visibility = Visibility.Visible;
                    }
                    break;
                case "Meat":
                    foreach (string recipe in MeatModel.MeatRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, RecipePanel, Frame, true);

                        RecipePanel.Visibility = Visibility.Visible;
                    }
                    break;
                case "Poultry":
                    foreach (string recipe in PoultryModel.PoultryRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, RecipePanel, Frame, true);

                        RecipePanel.Visibility = Visibility.Visible;
                    }
                    break;
                case "Seafood":
                    foreach (string recipe in SeafoodModel.SeafoodRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, RecipePanel, Frame, true);

                        RecipePanel.Visibility = Visibility.Visible;
                    }
                    break;
                case "Vegetable":
                    foreach (string recipe in VegetableModel.VegetableRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, RecipePanel, Frame, true);

                        RecipePanel.Visibility = Visibility.Visible;
                    }
                    break;
                case "Side":
                    foreach (string recipe in SideModel.SideRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, RecipePanel, Frame, true);

                        RecipePanel.Visibility = Visibility.Visible;
                    }
                    break;
                case "Dessert":
                    foreach (string recipe in DessertModel.DessertRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, RecipePanel, Frame, true);

                        RecipePanel.Visibility = Visibility.Visible;
                    }
                    break;
                case "Breakfast":
                    foreach (string recipe in BreakfastModel.BreakfastRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, RecipePanel, Frame, true);

                        RecipePanel.Visibility = Visibility.Visible;
                    }
                    break;
                case "Misc":
                    foreach (string recipe in MiscModel.MiscRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, RecipePanel, Frame, true);

                        RecipePanel.Visibility = Visibility.Visible;
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

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Content.ToString() == "Cookbook_Database.CooksCountryRecipes")
            {
                TitleLabel.Content = "Cookbook Database";
                SubtitleLabel.Content = "Printed Recipes";

                RecipePanel.Children.Clear();
                RecipePanel.Visibility = Visibility.Collapsed;
                
                ButtonPanel.Visibility = Visibility.Visible;
            }
        }
    }
}
