﻿using System.Collections;
using System.Globalization;
using System.Printing;
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
        /// Go back from generic recipe to the <see cref="MainWindow"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBackButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow? Form = Application.Current.MainWindow as MainWindow;

            Form.Frame.Visibility = Visibility.Collapsed;
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
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

                mainWindow.Close();
            }
        }

        /// <summary>
        /// Create the recipe button items
        /// </summary>
        /// <param name="recipe">Name of recipe</param>
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
                foreach (DictionaryEntry entry in ResourceSet)
                {
                    string name = entry.Key.ToString();
                    object resource = entry.Value;

                    string recipeButton = $"{Regex.Replace(name, @"[^a-zA-Z]+", "")}Button";

                    if (recipeButton == label.Name)
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

        /// <summary>
        /// Switch between recipes
        /// </summary>
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