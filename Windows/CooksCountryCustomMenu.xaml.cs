using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Cookbook_Database.Windows
{
    /// <summary>
    /// Interaction logic for CooksCountryCustomMenu.xaml
    /// </summary>
    public partial class CooksCountryCustomMenu : UserControl
    {
        private readonly List<string>? Recipes = new();

        public CooksCountryCustomMenu()
        {
            InitializeComponent();

            SearchInput.TextChanged += SearchInput_TextChanged;

            Recipes.AddRange(AllPrintedRecipeModel.AllPrintedRecipeModelToString());
        }

        private void PrintedRecipesButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PrintedRecipes Form = Application.Current.Windows[0] as PrintedRecipes;

            Form.Frame.Visibility = Visibility.Collapsed;
        }

        #region Mouse Enter & Leave Events

        private void PrintedRecipesButton_MouseEnter(object sender, MouseEventArgs e)
        {
            PrintedRecipesButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ddd");
            PrintedRecipesButton.Foreground = Brushes.White;
        }

        private void PrintedRecipesButton_MouseLeave(object sender, MouseEventArgs e)
        {
            PrintedRecipesButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#333");
            PrintedRecipesButton.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#e5e5e5");
        }

        private void Submit_MouseEnter(object sender, MouseEventArgs e)
        {
            Submit.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ddd");
        }

        private void Submit_MouseLeave(object sender, MouseEventArgs e)
        {
            Submit.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ccc");
        }

        #endregion

        #region Search For Recipe

        private void Submit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Search();
        }

        private void SearchInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Search();
            }
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(SearchInput.Text) || SearchInput.Text == "Search...")
            {
                MessageBox.Show("You must enter a valid recipe");
            }
            else
            {
                Properties.Settings.Default.SearchString = SearchInput.Text;

                PrintedRecipes? Form = Application.Current.Windows[0] as PrintedRecipes;

                Form.Frame.Visibility = Visibility.Visible;
                Form.Frame.NavigationService.Navigate(new Search());
            }
        }

        #endregion

        #region Autocomplete Section

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

        #region Handle Search Focus

        private void SearchInput_GotFocus(object sender, RoutedEventArgs e)
        {
            ChangeFocus();
        }

        private void SearchInput_LostFocus(object sender, RoutedEventArgs e)
        {
            ChangeFocus();
        }

        private void ChangeFocus()
        {
            if (SearchInput.Text == "Search...")
            {
                SearchInput.Text = "";
            }
            else
            {
                SearchInput.Text = "Search...";
            }
        }

        #endregion
    }
}
