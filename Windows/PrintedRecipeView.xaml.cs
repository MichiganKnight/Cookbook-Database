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
    /// Interaction logic for PrintedRecipes.xaml
    /// </summary>
    public partial class PrintedRecipeView : Page
    {
        private static readonly ResourceSet? ResourceSet = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);

        public PrintedRecipeView()
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
            ShowRecipeImage(Settings.Default.ButtonName, Settings.Default.PrintedRecipe, Settings.Default.LabelName);
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

                Form.Frame.Visibility = Visibility.Collapsed;
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
