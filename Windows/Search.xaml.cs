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
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        private readonly ResourceSet ResourceSet = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);

        public Search()
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
            CreateRecipeItems();
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
        /// Go back from recipe image and call <see cref="DisplayRecipes"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBackFromImageButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            RecipePanel.Children.Clear();

            RecipeImage.ImageSource = null;

            CreateRecipeItems();
        }

        /// <summary>
        /// Go back from generic recipe to the <see cref="MainWindow"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBackButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PrintedRecipes? Form = Application.Current.MainWindow as PrintedRecipes;

            Form.Frame.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Create the recipe button items
        /// </summary>
        private void CreateRecipeItems()
        {
            foreach (string recipe in AllPrintedRecipeModel.AllPrintedRecipeModelToString())
            {
                string name = Regex.Replace($"{recipe}Button", @"[^a-zA-Z0-9]+", "");

                Button button = new()
                {
                    Content = recipe,
                    Cursor = Cursors.Hand,
                    FontSize = 25,
                    FontWeight = FontWeights.Medium,
                    Background = null,
                    Foreground = Brushes.Blue,
                    Height = 50,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Name = ReplaceWithWord(name),
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

                            break;
                        }
                    }
                };

                RecipePanel.Children.Add(button);
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
                CreateRecipeItems();

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
