using Cookbook_Database.Windows;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<string>? Recipes = new();

        public MainWindow()
        {
            InitializeComponent();

            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            SearchInput.TextChanged += SearchInput_TextChanged;

            Recipes.AddRange(AllRecipeModel.AllRecipeModelToString());
        }

        private void BtnSalads_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Salad");
        }

        private void BtnSoups_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Soup");
        }

        private void BtnAppetizers_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Appetizer");
        }

        private void BtnMeat_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Meat");
        }

        private void BtnPoultry_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Poultry");
        }

        private void BtnSeafood_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Seafood");
        }

        private void BtnVegetables_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Vegetable");
        }

        private void BtnSides_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Side");
        }

        private void BtnDesserts_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Dessert");
        }

        private void BtnBreakfast_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Breakfast");
        }

        private void BtnMisc_Click(object sender, RoutedEventArgs e)
        {
            ShowRecipes("Misc");
        }

        private void Btn_MouseEnter(object sender, MouseEventArgs e)
        {
            Button? button = sender as Button;

            button.Background = Brushes.LightGray;
            button.BorderBrush = null;
        }

        private void Btn_MouseLeave(object sender, MouseEventArgs e)
        {
            Button? button = sender as Button;

            button.Background = Brushes.White;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? Form = Application.Current.MainWindow as MainWindow;

            Form.Close();
        }

        private void Submit_MouseEnter(object sender, MouseEventArgs e)
        {
            Submit.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ddd");
        }

        private void Submit_MouseLeave(object sender, MouseEventArgs e)
        {
            Submit.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ccc");
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

        private void SaladInput_Click(object sender, RoutedEventArgs e)
        {
            ImportRecipe("Salad");
        }

        private void SoupInput_Click(object sender, RoutedEventArgs e)
        {
            ImportRecipe("Soup");
        }

        private void AppetizerInput_Click(object sender, RoutedEventArgs e)
        {
            ImportRecipe("Appetizer");
        }

        private void MeatInput_Click(object sender, RoutedEventArgs e)
        {
            ImportRecipe("Meat");
        }

        private void PoultryInput_Click(object sender, RoutedEventArgs e)
        {
            ImportRecipe("Poultry");
        }

        private void SeafoodInput_Click(object sender, RoutedEventArgs e)
        {
            ImportRecipe("Seafood");
        }

        private void VegetableInput_Click(object sender, RoutedEventArgs e)
        {
            ImportRecipe("Vegetable");
        }

        private void SideInput_Click(object sender, RoutedEventArgs e)
        {
            ImportRecipe("Side");
        }

        private void DessertInput_Click(object sender, RoutedEventArgs e)
        {
            ImportRecipe("Dessert");
        }

        private void BreakfastInput_Click(object sender, RoutedEventArgs e)
        {
            ImportRecipe("Breakfast");
        }

        private void MiscInput_Click(object sender, RoutedEventArgs e)
        {
            ImportRecipe("Misc");
        }

        private void RemoveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Function Not Yet Implemented");
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
    }
}
