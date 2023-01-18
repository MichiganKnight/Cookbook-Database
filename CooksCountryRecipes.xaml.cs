using Cookbook_Database.DatabaseHandler;
using Cookbook_Database.Properties;
using Cookbook_Database.Windows;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

using static Cookbook_Database.CommonFunctions;

namespace Cookbook_Database
{
    /// <summary>
    /// Interaction logic for CooksCountryRecipes.xaml
    /// </summary>
    public partial class CooksCountryRecipes : Page
    {
        public CooksCountryRecipes()
        {
            InitializeComponent();
        }

        private void DisplayRecipeNames()
        {
            foreach (string name in NameModel.NameModelToString())
            {
                CreateRecipeButtons(name);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Settings.Default.PreviousPageInfo = "Cooks Country Recipes";
        }

        private void Button_2018_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.CooksCountryYear = "2018";
            //Settings.Default.PreviousPageInfo = "2018";

            TitleLabel.Content = "Cookbook Database - Cooks Country Recipes";
            SubtitleLabel.Content = $"{Settings.Default.CooksCountryYear} Issue";

            YearPanel.Visibility = Visibility.Collapsed;

            IssuePanel.Visibility = Visibility.Visible;
        }

        private void FebMarchButton_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.CooksCountryIssue = "February / March";
            //Settings.Default.PreviousPageInfo = "February / March";

            TitleLabel.Content = "Cookbook Database - Cooks Country Recipes";
            SubtitleLabel.Content = $"{Settings.Default.CooksCountryIssue} Volume";

            IssuePanel.Visibility = Visibility.Collapsed;

            DisplayRecipeNames();
        }

        private void CreateRecipeButtons(string recipe)
        {
            //Settings.Default.PreviousPageInfo = Settings.Default.CooksCountryIssue;

            string recipeName = Regex.Replace($"{recipe}Button", @"[^a-zA-Z0-9]+", "");

            Button recipeButton = new()
            {
                Content = recipe,
                Cursor = Cursors.Hand,
                FontSize = 25,
                FontWeight = FontWeights.Medium,
                Background = null,
                Foreground = Brushes.Blue,
                BorderBrush = Brushes.LightGray,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Left,
                Name = ReplaceWithWord(recipeName),
                Margin = new Thickness(10, 0, 0, 0)
            };

            RecipePanel.Children.Add(recipeButton);

            recipeButton.MouseEnter += (s, e) =>
            {
                recipeButton.Background = Brushes.LightGray;
            };

            recipeButton.MouseLeave += (s, e) =>
            {
                recipeButton.Background = Brushes.White;
            };

            recipeButton.Click += (s, e) =>
            {
                Settings.Default.CooksCountryRecipeToDisplay = recipeButton.Content.ToString();

                Frame.Visibility = Visibility.Visible;
                Frame.NavigationService.Navigate(new CooksCountryRecipeView());
            };
        }

        private void Button_2019_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_2020_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_2021_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_2022_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
