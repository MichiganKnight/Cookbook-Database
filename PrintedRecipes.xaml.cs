using Cookbook_Database.DatabaseHandler;
using Cookbook_Database.Properties;
using System.Collections.Generic;
using System.Linq;
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
        private readonly List<string>? Recipes = new();
        
        public PrintedRecipes()
        {
            InitializeComponent();

            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        #region Button Click Section

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

        #endregion

        #region Display Recipes

        /// <summary>
        /// Display all recipes
        /// </summary>
        /// <param name="recipeType">Type of recipe</param>
        private void DisplayRecipes(string recipeType)
        {
            GoBackButton.Visibility = Visibility.Visible;

            Settings.Default.PreviousPageInfo = "PrintedRecipes";

            switch (recipeType)
            {
                case "Salad":
                    foreach (string recipe in SaladModel.SaladRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, RecipePanel, Frame, "Printed");

                        RecipePanel.Visibility = Visibility.Visible;
                    }
                    break;
                case "Soup":
                    foreach (string recipe in SoupModel.SoupRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, RecipePanel, Frame, "Printed");

                        RecipePanel.Visibility = Visibility.Visible;
                    }
                    break;
                case "Appetizer":
                    foreach (string recipe in AppetizerModel.AppetizerRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, RecipePanel, Frame, "Printed");

                        RecipePanel.Visibility = Visibility.Visible;
                    }
                    break;
                case "Meat":
                    foreach (string recipe in MeatModel.MeatRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, RecipePanel, Frame, "Printed");

                        RecipePanel.Visibility = Visibility.Visible;
                    }
                    break;
                case "Poultry":
                    foreach (string recipe in PoultryModel.PoultryRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, RecipePanel, Frame, "Printed");

                        RecipePanel.Visibility = Visibility.Visible;
                    }
                    break;
                case "Seafood":
                    foreach (string recipe in SeafoodModel.SeafoodRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, RecipePanel, Frame, "Printed");

                        RecipePanel.Visibility = Visibility.Visible;
                    }
                    break;
                case "Vegetable":
                    foreach (string recipe in VegetableModel.VegetableRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, RecipePanel, Frame, "Printed");

                        RecipePanel.Visibility = Visibility.Visible;
                    }
                    break;
                case "Side":
                    foreach (string recipe in SideModel.SideRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, RecipePanel, Frame, "Printed");

                        RecipePanel.Visibility = Visibility.Visible;
                    }
                    break;
                case "Dessert":
                    foreach (string recipe in DessertModel.DessertRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, RecipePanel, Frame, "Printed");

                        RecipePanel.Visibility = Visibility.Visible;
                    }
                    break;
                case "Breakfast":
                    foreach (string recipe in BreakfastModel.BreakfastRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, RecipePanel, Frame, "Printed");

                        RecipePanel.Visibility = Visibility.Visible;
                    }
                    break;
                case "Misc":
                    foreach (string recipe in MiscModel.MiscRecipeModelToString())
                    {
                        CreateRecipeButtons(recipe, RecipePanel, Frame, "Printed");

                        RecipePanel.Visibility = Visibility.Visible;
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Enter & Leave Functions

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            Label? label = sender as Label;

            label.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ddd");
            label.Foreground = Brushes.White;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            Label? label = sender as Label;

            label.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#333");
            label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#e5e5e5");
        }

        private void SearchInput_GotFocus(object sender, RoutedEventArgs e)
        {
            ChangeFocus(SearchInput);
        }

        private void SearchInput_LostFocus(object sender, RoutedEventArgs e)
        {
            ChangeFocus(SearchInput);
        }

        private void Submit_MouseEnter(object sender, MouseEventArgs e)
        {
            Submit.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ddd");
        }

        private void Submit_MouseLeave(object sender, MouseEventArgs e)
        {
            Submit.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ccc");
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

        #endregion

        #region Search & Autocomplete Section

        private void Submit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Search(SearchInput);
        }

        private void SearchInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Search(SearchInput);
            }
        }

        private string currentInput = "";
        private string currentSuggestion = "";
        private string currentText = "";

        private int selectionStart;
        private int selectionLength;

        private void SearchInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            var input = SearchInput.Text;

            if (input.Length > currentInput.Length && input != currentSuggestion)
            {
                currentSuggestion = Recipes.FirstOrDefault(x => x.StartsWith(input));

                if (currentSuggestion != null)
                {
                    currentText = currentSuggestion;
                    selectionStart = input.Length;
                    selectionLength = currentSuggestion.Length - input.Length;

                    SearchInput.Text = currentText;
                    SearchInput.Select(selectionStart, selectionLength);
                }
            }

            currentInput = input;
        }

        #endregion

        #region Navigation Section

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

        #endregion

        #region Switch Between Recipe Sets

        private void CooksCountryRecipesButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PrintedRecipes Form = Application.Current.Windows[0] as PrintedRecipes;

            GoBackButton.Visibility = Visibility.Hidden;

            Form.Frame.Visibility = Visibility.Visible;
            Form.Frame.NavigationService.Navigate(new CooksCountryRecipes());
        }

        #endregion

        #region Go Back

        private void GoBackButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Settings.Default.PreviousPageInfo == "PrintedRecipes")
            {
                TitleLabel.Content = "Cookbook Database";
                SubtitleLabel.Content = "Printed Recipes";

                RecipePanel.Children.Clear();
                RecipePanel.Visibility = Visibility.Collapsed;

                ButtonPanel.Visibility = Visibility.Visible;

                GoBackButton.Visibility = Visibility.Hidden;
                Settings.Default.PreviousPageInfo = "";
            }
        }

        #endregion
    }
}
