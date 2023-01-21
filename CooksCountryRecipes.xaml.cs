using Cookbook_Database.DatabaseHandler;
using Cookbook_Database.Properties;
using System.Collections.Generic;
using System.Linq;
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
        private readonly List<string>? Recipes = new();

        public CooksCountryRecipes()
        {
            InitializeComponent();
        }

        #region Page Loaded Function

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.PreviousPageInfo.EndsWith("Recipe"))
            {
                GoBackButton.Visibility = Visibility.Visible;

                Settings.Default.PreviousPageInfo = $"{Settings.Default.PreviousPageInfo}".Replace(" - Recipe", "");

                TitleLabel.Content = "Cookbook Database - Cooks Country Recipes";
                SubtitleLabel.Content = Settings.Default.RecipeIssue;

                YearPanel.Visibility = Visibility.Collapsed;
                IssuePanel.Visibility = Visibility.Collapsed;

                DisplayRecipeNames();
            }
        }

        #endregion        

        #region Button Click Section

        private void Button_2018_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;

            SetPreviousPageInfo(button);

            Settings.Default.RecipeYear = button.Content.ToString().Replace(" Issue", "");

            GoBackButton.Visibility = Visibility.Visible;

            TitleLabel.Content = "Cookbook Database - Cooks Country Recipes";
            SubtitleLabel.Content = button.Content.ToString();

            YearPanel.Visibility = Visibility.Collapsed;

            IssuePanel.Visibility = Visibility.Visible;
        }

        private void FebMarchButton_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;

            SetPreviousPageInfo(null, button.Content.ToString());

            Settings.Default.RecipeIssue = $"{Settings.Default.RecipeYear} Issue - February / March Volume";

            TitleLabel.Content = "Cookbook Database - Cooks Country Recipes";
            SubtitleLabel.Content = Settings.Default.RecipeIssue;

            IssuePanel.Visibility = Visibility.Collapsed;

            DisplayRecipeNames();
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

        #endregion

        #region Display Recipes

        private void DisplayRecipeNames()
        {
            foreach (string name in NameModel.NameModelToString())
            {
                CreateRecipeButtons(name, RecipePanel, Frame, false);
            }
        }

        #endregion

        #region Enter & Leave Functions

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            Label? label = sender as Label;

            label.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ddd");
            label.Foreground = Brushes.White;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            Label? label = sender as Label;

            label.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#333");
            label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#e5e5e5");
        }

        private void SearchInput_GotFocus(object sender, RoutedEventArgs e)
        {
            ChangeFocus(SearchInput);
        }

        private void SearchInput_LostFocus(object sender, RoutedEventArgs e)
        {
            ChangeFocus(SearchInput);
        }

        private void Submit_MouseEnter(object sender, MouseEventArgs e)
        {
            Submit.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ddd");
        }

        private void Submit_MouseLeave(object sender, MouseEventArgs e)
        {
            Submit.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ccc");
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

        #endregion

        #region Search & Autocomplete Section

        private void Submit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Search(SearchInput);
        }

        private void SearchInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Search(SearchInput);
            }
        }

        private string currentInput = "";
        private string currentSuggestion = "";
        private string currentText = "";

        private int selectionStart;
        private int selectionLength;

        private void SearchInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            var input = SearchInput.Text;

            if (input.Length > currentInput.Length && input != currentSuggestion)
            {
                currentSuggestion = Recipes.FirstOrDefault(x => x.StartsWith(input));

                if (currentSuggestion != null)
                {
                    currentText = currentSuggestion;
                    selectionStart = input.Length;
                    selectionLength = currentSuggestion.Length - input.Length;

                    SearchInput.Text = currentText;
                    SearchInput.Select(selectionStart, selectionLength);
                }
            }

            currentInput = input;
        }

        #endregion

        #region Switch Between Recipe Sets

        private void PrintedRecipesButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PrintedRecipes? Form = Application.Current.Windows[0] as PrintedRecipes;

            GoBackButton.Visibility = Visibility.Hidden;

            Form.Frame.Visibility = Visibility.Collapsed;
        }

        #endregion

        #region Go Back

        private void GoBackButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Settings.Default.PreviousPageInfo.EndsWith("Issue"))
            {
                TitleLabel.Content = "Cookbook Database";
                SubtitleLabel.Content = "Cooks Country Recipes";

                YearPanel.Visibility = Visibility.Visible;
                IssuePanel.Visibility = Visibility.Collapsed;

                GoBackButton.Visibility = Visibility.Hidden;
                Settings.Default.PreviousPageInfo = "";
                Settings.Default.RecipeYear = "";
            }
            else if (Settings.Default.PreviousPageInfo.EndsWith("Volume"))
            {
                TitleLabel.Content = "Cookbook Database - Cooks Country Recipes";
                SubtitleLabel.Content = $"{Settings.Default.RecipeYear} Issue";

                RecipePanel.Children.Clear();

                IssuePanel.Visibility = Visibility.Visible;

                Settings.Default.PreviousPageInfo = $"{Settings.Default.RecipeYear} Issue";
            }
        }

        private static void SetPreviousPageInfo(Button? button = null, string additionalText = "")
        {
            if (!string.IsNullOrEmpty(Settings.Default.PreviousPageInfo))
            {
                Settings.Default.PreviousPageInfo = $"{Settings.Default.PreviousPageInfo} - {additionalText}";
            }
            else
            {
                Settings.Default.PreviousPageInfo = button.Content.ToString();
            }
        }

        #endregion
    }
}
