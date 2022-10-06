using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Cookbook_Database.Windows
{
    /// <summary>
    /// Interaction logic for UserControlMenuItem.xaml
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        private readonly List<string>? Recipes = new();

        public UserControlMenuItem()
        {
            InitializeComponent();

            SearchInput.TextChanged += SearchInput_TextChanged;

            Recipes.AddRange(AllRecipeModel.AllRecipeModelToString());
        }

        private void SaladInput_MouseUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog fileDialog = new()
            {
                Title = "Import Salad Recipe",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                DefaultExt = ".jpg",
                Filter = "JPEG Image (*.jpg)|*.jpg",
            };

            bool? result = fileDialog.ShowDialog();

            if (result == true)
            {
                string filename = fileDialog.FileName;
            }
        }

        private void SoupInput_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void AppetizerInput_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void CustomRecipe_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

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

                MainWindow? Form = Application.Current.Windows[0] as MainWindow;

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

        #region Mouse Enter & Leave Events

        private void DropdownButton_MouseEnter(object sender, MouseEventArgs e)
        {
            DropdownButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ddd");
            DropdownButton.Foreground = Brushes.White;

            Dropdown.IsOpen = true;
        }

        private void DropdownButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DropdownButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#333");
            DropdownButton.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#e5e5e5");

            Dropdown.IsOpen = false;
        }

        private void RemoveRecipe_MouseEnter(object sender, MouseEventArgs e)
        {
            RemoveRecipe.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ddd");
            RemoveRecipe.Foreground = Brushes.White;
        }

        private void RemoveRecipe_MouseLeave(object sender, MouseEventArgs e)
        {
            RemoveRecipe.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#333");
            RemoveRecipe.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#e5e5e5");
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

        private void RemoveRecipe_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Removing Recipes Is Not Yet Implemented");
        }

        private void DropdownButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Dropdown.IsOpen = !Dropdown.IsOpen;
        }

        private void Dropdown_MouseLeave(object sender, MouseEventArgs e)
        {
            Dropdown.IsOpen = false;
        }

        private void Dropdown_MouseEnter(object sender, MouseEventArgs e)
        {
            Dropdown.IsOpen = true;
        }
    }
}