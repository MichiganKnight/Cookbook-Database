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
            DisplayRecipes();
        }

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
        /// Go back from recipe image and call <see cref="DisplayRecipes"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBackFromImageButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            RecipePanel.Children.Clear();

            RecipeImage.ImageSource = null;

            DisplayRecipes();
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
        /// Create the recipe button items
        /// </summary>
        private void CreateRecipeItems()
        {
            foreach (string recipe in AllRecipeModel.AllRecipeModelToString())
            {
                string name = Regex.Replace($"{recipe}Button", @"[^a-zA-Z0-9]+", "");

                Label label = new()
                {
                    Content = recipe,
                    Cursor = Cursors.Hand,
                    FontSize = 25,
                    FontWeight = FontWeights.Medium,
                    Foreground = Brushes.Blue,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Name = ReplaceWithWord(name)
                };

                label.MouseUp += (s, e) =>
                {
                    ResourceSet resourceSet = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);

                    var testWasTrue = false;

                    foreach (DictionaryEntry entry in resourceSet)
                    {
                        string name = entry.Key.ToString();
                        object resource = entry.Value;

                        if ($"{Regex.Replace(ReplaceWithWord(name), @"[^a-zA-Z]+", "")}Button" == label.Name)
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
        }

        /// <summary>
        /// Display all recipes
        /// </summary>
        public void DisplayRecipes()
        {
            CreateRecipeItems();

            Label goBackButton = CreateGoBackButton();

            RecipePanel.Children.Add(goBackButton);

            goBackButton.MouseUp += GoBackButton_MouseUp;
        }
    }
}
