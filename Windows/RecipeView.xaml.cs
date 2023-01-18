using System.Collections;
using System.Globalization;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using static Cookbook_Database.CommonFunctions;

namespace Cookbook_Database.Windows
{
    /// <summary>
    /// Interaction logic for RecipeView.xaml
    /// </summary>
    public partial class RecipeView : Page
    {
        private readonly ResourceSet ResourceSet = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);

        public RecipeView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Page load function to call <see cref="SwitchBetweenRecipeTypes"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SwitchBetweenRecipeTypes();
        }

        /// <summary>
        /// Go back from recipe image and call <see cref="SwitchBetweenRecipeTypes"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBackFromImageButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            RecipePanel.Children.Clear();

            RecipeImage.ImageSource = null;

            SwitchBetweenRecipeTypes();
        }

        /// <summary>
        /// Print 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.P && RecipeImage.ImageSource != null)
            {
                BitmapImage image = (BitmapImage)RecipeImage.ImageSource;

                PrintImage(image);
            }

            if (e.Key == Key.X)
            {
                PrintedRecipes mainWindow = Application.Current.MainWindow as PrintedRecipes;

                mainWindow.Close();
            }
        }

        /// <summary>
        /// Create the recipe button items
        /// </summary>
        /// <param name="recipe">Name of recipe</param>
        private void CreateRecipeItems(string recipe)
        {
            string labelName = Regex.Replace($"{recipe}Label", @"[^a-zA-Z0-9]+", "");
            string buttonName = Regex.Replace($"{recipe}Button", @"[^a-zA-Z0-9]+", "");

            Button button = new()
            {
                Content = recipe,
                Cursor = Cursors.Hand,
                FontSize = 25,
                FontWeight = FontWeights.Medium,
                Background = null,
                Foreground = Brushes.Blue,
                BorderBrush = Brushes.LightGray,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Center,
                Name = ReplaceWithWord(buttonName),
            };

            button.MouseEnter += (s, e) =>
            {
                button.Background = Brushes.LightGray;
            };

            button.MouseLeave += (s, e) =>
            {
                button.Background = Brushes.White;
            };

            button.Click += (s, e) =>
            {
                foreach (DictionaryEntry entry in ResourceSet)
                {
                    string name = entry.Key.ToString();
                    object resource = entry.Value;

                    if ($"{Regex.Replace(ReplaceWithWord(name), @"[^a-zA-Z]+", "")}Button" == button.Name)
                    {
                        RecipeImage.ImageSource = LoadImage((byte[])resource);

                        RecipePanel.Children.Clear();

                        Properties.Settings.Default.IsImageVisible = true;

                        MenuSeperator.Visibility = Visibility.Visible;
                        PrintButton.Visibility = Visibility.Visible;

                        Label label = new()
                        {
                            Content = recipe,
                            FontSize = 25,
                            FontWeight = FontWeights.Bold,
                            Background = null,
                            Foreground = Brushes.Maroon,
                            Height = 50,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            Name = ReplaceWithWord(labelName)
                        };

                        RecipePanel.Children.Add(label);

                        break;
                    }
                }
            };

            RecipePanel.Children.Add(button);
        }

        /// <summary>
        /// Switch between recipes
        /// </summary>
        private void SwitchBetweenRecipeTypes()
        {
            RecipePanel.Children.Clear();

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
        }

        /// <summary>
        /// Go back button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.IsImageVisible == true)
            {
                SwitchBetweenRecipeTypes();

                RecipeImage.ImageSource = null;

                MenuSeperator.Visibility = Visibility.Collapsed;
                PrintButton.Visibility = Visibility.Collapsed;

                Properties.Settings.Default.IsImageVisible = false;
            }
            else
            {
                PrintedRecipes? Form = Application.Current.MainWindow as PrintedRecipes;

                Form.Frame.Visibility = Visibility.Collapsed;
            }
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.IsImageVisible == true)
            {
                PrintImage((BitmapImage)RecipeImage.ImageSource);
            }   
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            PrintedRecipes? Form = Application.Current.MainWindow as PrintedRecipes;

            Form.Close();
        }
    }
}
