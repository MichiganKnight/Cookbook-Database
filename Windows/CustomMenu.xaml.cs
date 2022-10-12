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
    public partial class CustomMenu : UserControl
    {
        private readonly List<string>? Recipes = new();

        public CustomMenu()
        {
            InitializeComponent();

            SearchInput.TextChanged += SearchInput_TextChanged;

            Recipes.AddRange(AllRecipeModel.AllRecipeModelToString());
        }

        #region Recipe Button Click Events

        private void SaladInput_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ImportRecipe("Salad");
        }

        private void SoupInput_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ImportRecipe("Soup");
        }

        private void AppetizerInput_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ImportRecipe("Appetizer");
        }

        private void MeatInput_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ImportRecipe("Meat");
        }

        private void PoultryInput_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ImportRecipe("Poultry");
        }

        private void SeafoodInput_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ImportRecipe("Seafood");
        }

        private void VegetableInput_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ImportRecipe("Vegetable");
        }

        private void SideInput_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ImportRecipe("Side");
        }

        private void DessertInput_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ImportRecipe("Dessert");
        }

        private void BreakfastInput_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ImportRecipe("Breakfast");
        }

        private void MiscInput_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ImportRecipe("Misc");
        }

        /// <summary>
        /// Import recipe from image file
        /// </summary>
        /// <param name="recipeType">Recipe to import</param>
        private void ImportRecipe(string recipeType)
        {
            MessageBox.Show("Function Not Yet Implemented");
            /*DropdownButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#333");
            DropdownButton.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#e5e5e5");

            Dropdown.IsOpen = false;

            OpenFileDialog fileDialog = new()
            {
                Title = $"Import {recipeType} Recipe",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                DefaultExt = ".jpg",
                Filter = "JPEG Image (*.jpg)|*.jpg",
            };

            bool? result = fileDialog.ShowDialog();

            if (result == true)
            {
                string filename = fileDialog.FileName;
            }*/
        }

        #endregion

        private void RemoveRecipe_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Function Not Yet Implemented");
        }

        private void DropdownButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Dropdown.IsOpen = !Dropdown.IsOpen;
        }

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

        private void Dropdown_MouseEnter(object sender, MouseEventArgs e)
        {
            Dropdown.IsOpen = true;

            DropdownButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ddd");
            DropdownButton.Foreground = Brushes.White;
        }

        private void Dropdown_MouseLeave(object sender, MouseEventArgs e)
        {
            Dropdown.IsOpen = false;

            DropdownButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#333");
            DropdownButton.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#e5e5e5");
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
    }
}