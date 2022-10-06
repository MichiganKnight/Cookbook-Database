using System.Collections;
using System.Globalization;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

using static Cookbook_Database.CommonFunctions;

namespace Cookbook_Database.Windows
{
    /// <summary>
    /// Interaction logic for RecipeView.xaml
    /// </summary>
    public partial class RecipeView : Page
    {
        public RecipeView()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SwitchBetweenRecipeTypes();
        }

        private void GoBackFromImageButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            RecipePanel.Children.Clear();

            RecipeImage.ImageSource = null;

            SwitchBetweenRecipeTypes();
        }

        private void GoBackButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow? Form = Application.Current.MainWindow as MainWindow;

            Form.Frame.Visibility = Visibility.Collapsed;
        }

        private void CreateRecipeItems(string recipe)
        {
            Label label = new()
            {
                Content = recipe,
                Cursor = Cursors.Hand,
                FontSize = 25,
                FontWeight = FontWeights.Medium,
                Foreground = Brushes.Blue,
                HorizontalAlignment = HorizontalAlignment.Center,
                Name = Regex.Replace($"{recipe}Button", @"[^a-zA-Z]+", "")
            };

            label.MouseUp += (s, e) =>
            {
                ResourceSet resourceSet = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);

                var testWasTrue = false;

                foreach (DictionaryEntry entry in resourceSet)
                {
                    string name = entry.Key.ToString();
                    object resource = entry.Value;

                    string temp = $"{Regex.Replace(name, @"[^a-zA-Z]+", "")}Button";

                    if (temp == label.Name)
                    {
                        RecipeImage.ImageSource = LoadImage((byte[])resource);

                        RecipePanel.Children.Clear();

                        Label goBackFromImageButton = CreateGoBackButton();

                        RecipePanel.Children.Add(goBackFromImageButton);

                        goBackFromImageButton.MouseUp += GoBackFromImageButton_MouseUp;

                        break;
                    }
                }
            };

            RecipePanel.Children.Add(label);
        }

        private void SwitchBetweenRecipeTypes()
        {
            switch (Properties.Settings.Default.RecipeType)
            {
                case "Salad":
                    DisplayRecipes("Salad");
                    break;
                case "Soup":
                    DisplayRecipes("Soup");
                    break;
                case "Appetizer":
                    DisplayRecipes("Appetizer");
                    break;
                case "Meat":
                    DisplayRecipes("Meat");
                    break;
                case "Poultry":
                    DisplayRecipes("Poultry");
                    break;
                case "Seafood":
                    DisplayRecipes("Seafood");
                    break;
                case "Vegetable":
                    DisplayRecipes("Vegetable");
                    break;
                case "Side":
                    DisplayRecipes("Side");
                    break;
                case "Dessert":
                    DisplayRecipes("Dessert");
                    break;
                case "Breakfast":
                    DisplayRecipes("Breakfast");
                    break;
                case "Misc":
                    DisplayRecipes("Misc");
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Display all recipes of <see cref="Settings.Default.RecipeType"/>
        /// </summary>
        /// <param name="recipeType">Type of recipe</param>
        public void DisplayRecipes(string recipeType)
        {
            switch (recipeType)
            {
                case "Salad":
                    foreach (string recipe in SaladModel.SaladRecipeModelToString())
                    {
                        CreateRecipeItems(recipe);
                    }
                    break;
                case "Soup":
                    foreach (string recipe in SoupModel.SoupRecipeModelToString())
                    {
                        CreateRecipeItems(recipe);
                    }
                    break;
                case "Appetizer":
                    foreach (string recipe in AppetizerModel.AppetizerRecipeModelToString())
                    {
                        CreateRecipeItems(recipe);
                    }
                    break;
                case "Meat":
                    foreach (string recipe in MeatModel.MeatRecipeModelToString())
                    {
                        CreateRecipeItems(recipe);
                    }
                    break;
                case "Poultry":
                    foreach (string recipe in PoultryModel.PoultryRecipeModelToString())
                    {
                        CreateRecipeItems(recipe);
                    }
                    break;
                case "Seafood":
                    foreach (string recipe in SeafoodModel.SeafoodRecipeModelToString())
                    {
                        CreateRecipeItems(recipe);
                    }
                    break;
                case "Vegetable":
                    foreach (string recipe in VegetableModel.VegetableRecipeModelToString())
                    {
                        CreateRecipeItems(recipe);
                    }
                    break;
                case "Side":
                    foreach (string recipe in SideModel.SideRecipeModelToString())
                    {
                        CreateRecipeItems(recipe);
                    }
                    break;
                case "Dessert":
                    foreach (string recipe in DessertModel.DessertRecipeModelToString())
                    {
                        CreateRecipeItems(recipe);
                    }
                    break;
                case "Breakfast":
                    foreach (string recipe in BreakfastModel.BreakfastRecipeModelToString())
                    {
                        CreateRecipeItems(recipe);
                    }
                    break;
                case "Misc":
                    foreach (string recipe in MiscModel.MiscRecipeModelToString())
                    {
                        CreateRecipeItems(recipe);
                    }
                    break;
                default:
                    break;
            }

            Label goBackButton = CreateGoBackButton();

            RecipePanel.Children.Add(goBackButton);

            goBackButton.MouseUp += GoBackButton_MouseUp;
        }
    }
}
