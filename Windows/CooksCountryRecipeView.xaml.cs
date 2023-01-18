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
                CreateLabels(name, NamePanel, 50, false);
            }

            foreach (string serving in ServingsModel.ServingsModelToString())
            {
                CreateLabels($"Serves {serving}", ServingsPanel, 50, false);
            }

            foreach (string description in DescriptionModel.DescriptionModelToString())
            {
                CreateTextBlocks(description, DescriptionPanel, false);
            }

            foreach (string quantity in QuantityModel.QuantityModelToString())
            {
                CreateLabels(quantity, QuantityPanel, 50, false);
            }

            foreach (string ingredient in IngredientNameModel.IngredientModelToString())
            {
                CreateLabels(ingredient, IngredientPanel, 50, false);
            }

            foreach (string step in StepModel.StepModelToString())
            {
                CreateLabels($"Step {step}:", StepPanel, 375, false);
            }

            foreach (string instruction in InstructionModel.InstructionModelToString())
            {
                CreateTextBlocks(instruction, InstructionPanel, true);
            }
        }

        /// <summary>
        /// Creates labels for recipe parts
        /// </summary>
        /// <param name="text">Text to display</param>
        /// <param name="panel">Panel parent</param>
        /// <param name="height">Height</param>
        /// <param name="hasMargin">If a margin should be added</param>
        private static void CreateLabels(string text, StackPanel panel, int height, bool hasMargin)
        {
            string name = Regex.Replace($"{text}Label", @"[^a-zA-Z0-9]+", "");

            if (hasMargin)
            {
                Label label = new()
                {
                    Content = text.Replace("Label", ""),
                    FontSize = 25,
                    FontWeight = FontWeights.Medium,
                    Background = null,
                    Foreground = Brushes.Black,
                    Height = height,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Name = ReplaceWithWord(name),
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1)
                };

                panel.Children.Add(label);
            }
            else
            {
                Label label = new()
                {
                    Content = text.Replace("Label", ""),
                    FontSize = 25,
                    FontWeight = FontWeights.Medium,
                    Background = null,
                    Foreground = Brushes.Black,
                    Height = height,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Name = ReplaceWithWord(name),
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1)
                };

                panel.Children.Add(label);
            }            
        }

        private static void CreateTextBlocks(string text, Panel panel, bool needsScrollbar)
        {
            string name = Regex.Replace($"{text}TextBox", @"[^a-zA-Z0-9]+", "");

            if (needsScrollbar)
            {
                ScrollViewer scrollViewer = new()
                {
                    VerticalScrollBarVisibility = ScrollBarVisibility.Visible,
                    Height = 375
                };

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
                    TextWrapping = TextWrapping.Wrap,
                    Height = 375,
                    Width = 750
                };

                scrollViewer.Content = textBlock;

                panel.Children.Add(scrollViewer);
            }
            else
            {
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
                    TextWrapping = TextWrapping.Wrap,
                    Width = 500,
                    
                    // Wrap in a border
                };

                panel.Children.Add(textBlock);
            }
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
