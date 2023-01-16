using Cookbook_Database.Properties;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using static Cookbook_Database.CommonFunctions;

namespace Cookbook_Database.Windows
{
    /// <summary>
    /// Interaction logic for CooksCountryRecipeView.xaml
    /// </summary>
    public partial class CooksCountryRecipeView : Page
    {
        public CooksCountryRecipeView()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CreateLabels(Settings.Default.CooksCountryRecipeToDisplay);
        }

        private void CreateLabels(string text)
        {
            string name = Regex.Replace($"{text}Label", @"[^a-zA-Z0-9]+", "");

            Label label = new()
            {
                Content = text.Replace("Label", ""),
                FontSize = 25,
                FontWeight = FontWeights.Medium,
                Background = null,
                Foreground = Brushes.Black,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Center,
                Name = ReplaceWithWord(name),
                Margin = new Thickness(10, 0, 0, 0)
            };

            RecipePanel.Children.Add(label);
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.CooksCountryRecipeToDisplay = "";

            PrintedRecipes? Form = Application.Current.Windows[0] as PrintedRecipes;

            Form.Frame.Visibility = Visibility.Visible;
            Form.Frame.NavigationService.Navigate(new CooksCountryRecipes());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            PrintedRecipes? Form = Application.Current.MainWindow as PrintedRecipes;

            Form.Close();
        }
    }
}
