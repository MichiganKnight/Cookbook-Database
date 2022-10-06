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
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        public Search()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayRecipes();
        }

        private void GoBackFromImageButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            RecipePanel.Children.Clear();

            RecipeImage.ImageSource = null;

            DisplayRecipes();
        }

        private void GoBackButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow? Form = Application.Current.MainWindow as MainWindow;

            Form.Frame.Visibility = Visibility.Collapsed;
        }

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
        /// Display all recipes of <see cref="Settings.Default.RecipeType"/>
        /// </summary>
        /// <param name="recipeType">Type of recipe</param>
        public void DisplayRecipes()
        {
            CreateRecipeItems();

            Label goBackButton = CreateGoBackButton();

            RecipePanel.Children.Add(goBackButton);

            goBackButton.MouseUp += GoBackButton_MouseUp;
        }
    }
}
