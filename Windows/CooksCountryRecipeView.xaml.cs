using Cookbook_Database.DatabaseHandler;
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
            foreach (string name in NameModel.NameModelToString())
            {
                CreateLabels(name, NamePanel);
            }

            foreach (string serving in ServingsModel.ServingsModelToString())
            {
                CreateLabels($"Serves {serving}", ServingsPanel);
            }

            foreach (string description in DescriptionModel.DescriptionModelToString())
            {
                CreateTextBlocks(description, DescriptionPanel);
            }

            foreach (string quantity in QuantityModel.QuantityModelToString())
            {
                CreateLabels(quantity, QuantityPanel);
            }

            foreach (string ingredient in IngredientNameModel.IngredientModelToString())
            {
                CreateLabels(ingredient, IngredientPanel);
            }

            foreach (string step in StepModel.StepModelToString())
            {
                CreateLabels($"Step {step}:", StepPanel);
            }

            foreach (string instruction in InstructionModel.InstructionModelToString())
            {
                CreateTextBlocks(instruction, InstructionPanel);
            }
        }

        private void CreateLabels(string text, Panel panel)
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
                Name = ReplaceWithWord(name)
            };

            panel.Children.Add(label);
        }

        private void CreateTextBlocks(string text, Panel panel)
        {
            string name = Regex.Replace($"{text}TextBox", @"[^a-zA-Z0-9]+", "");

            TextBlock textBlock = new()
            {
                Text = text.Replace("TextBox", ""),
                FontSize = 25,
                FontWeight = FontWeights.Medium,
                Background = null,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Center,
                TextAlignment = TextAlignment.Center,
                Name = ReplaceWithWord(name),
                Margin = new Thickness(10, 0, 0, 0),
                TextWrapping = TextWrapping.Wrap,
                Width = 500
            };

            panel.Children.Add(textBlock);
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
