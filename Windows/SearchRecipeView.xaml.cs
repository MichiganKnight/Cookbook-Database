using Cookbook_Database.DatabaseHandler;
using Cookbook_Database.Properties;
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
    /// Interaction logic for SearchRecipeView.xaml
    /// </summary>
    public partial class SearchRecipeView : Page
    {
        private readonly ResourceSet? ResourceSet = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);

        public SearchRecipeView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Page load function to call <see cref="DisplayRecipes"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.RecipeType == "Printed")
            {
                PrintButton.Visibility = Visibility.Visible;
                MenuSeperator.Visibility = Visibility.Visible;
                PrintedScrollViewer.Visibility = Visibility.Visible;

                ShowRecipeImage(Settings.Default.ButtonName, Settings.Default.RecipeString, Settings.Default.LabelName);
            }
            else if (Settings.Default.RecipeType == "Cooks Country")
            {
                PrintButton.Visibility = Visibility.Collapsed;
                MenuSeperator.Visibility = Visibility.Collapsed;

                CooksCountryScrollViewer.Visibility = Visibility.Visible;

                CreateRecipeSections(NamePanel, ServingsPanel, DescriptionPanel, QuantityPanel, IngredientPanel, StepPanel, InstructionPanel);
            }
        }

        private void ShowRecipeImage(string buttonName, string recipe, string labelName)
        {
            foreach (DictionaryEntry entry in ResourceSet)
            {
                string name = entry.Key.ToString();
                object resource = entry.Value;

                if ($"{Regex.Replace(ReplaceWithWord(name), @"[^a-zA-Z]+", "")}Button" == buttonName)
                {
                    RecipeImage.ImageSource = LoadImage((byte[])resource);

                    RecipePanel.Children.Clear();

                    Settings.Default.IsImageVisible = true;

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
        /// Go back button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.IsImageVisible == true)
            {
                RecipeImage.ImageSource = null;

                MenuSeperator.Visibility = Visibility.Collapsed;
                PrintButton.Visibility = Visibility.Collapsed;

                Settings.Default.IsImageVisible = false;

                PrintedRecipes? Form = Application.Current.MainWindow as PrintedRecipes;

                Form.Frame.Visibility = Visibility.Visible;
                Form.Frame.NavigationService.Navigate(new SearchRecipes());
            }
            else
            {
                PrintedRecipes? Form = Application.Current.MainWindow as PrintedRecipes;

                Form.Frame.Visibility = Visibility.Visible;
                Form.Frame.NavigationService.Navigate(new SearchRecipes());
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
