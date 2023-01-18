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
                CreateLabels(name, NamePanel, 50, Brushes.Maroon);
            }

            foreach (string serving in ServingsModel.ServingsModelToString())
            {
                CreateLabels($"Serves {serving}", ServingsPanel, 50, Brushes.Maroon);
            }

            foreach (string description in DescriptionModel.DescriptionModelToString())
            {
                CreateTextBlocks(description, DescriptionPanel, false);
            }

            foreach (string quantity in QuantityModel.QuantityModelToString())
            {
                CreateLabels(quantity, QuantityPanel, 50, Brushes.Black);
            }

            foreach (string ingredient in IngredientNameModel.IngredientModelToString())
            {
                CreateLabels(ingredient, IngredientPanel, 50, Brushes.Black);
            }

            foreach (string step in StepModel.StepModelToString())
            {
                CreateLabels($"Step {step}:", StepPanel, 100, 300);
            }

            foreach (string instruction in InstructionModel.InstructionModelToString())
            {
                CreateTextBlocks(instruction, InstructionPanel, true);
            }
        }

        private static void CreateLabels(string text, StackPanel panel, int width, int height)
        {
            string name = Regex.Replace($"{text}Label", @"[^a-zA-Z0-9]+", "");

            Label label = new()
            {
                Content = text.Replace("Label", ""),
                FontSize = 25,
                FontWeight = FontWeights.Medium,
                Background = null,
                Foreground = Brushes.Black,
                Width = width,
                Height = height,
                HorizontalAlignment = HorizontalAlignment.Center,
                Name = ReplaceWithWord(name)
            };

            panel.Children.Add(label);    
        }

        private static void CreateLabels(string text, StackPanel panel, int height, SolidColorBrush solidColorBrush)
        {
            string name = Regex.Replace($"{text}Label", @"[^a-zA-Z0-9]+", "");

            Label label = new()
            {
                Content = text.Replace("Label", ""),
                FontSize = 25,
                FontWeight = FontWeights.Medium,
                Background = null,
                Foreground = solidColorBrush,
                Height = height,
                HorizontalAlignment = HorizontalAlignment.Center,
                Name = ReplaceWithWord(name)
            };

            panel.Children.Add(label);
        }

        private static void CreateTextBlocks(string text, Panel panel, bool needsScrollbar)
        {
            string name = Regex.Replace($"{text}TextBlock", @"[^a-zA-Z0-9]+", "");

            if (needsScrollbar)
            {
                Border border = new()
                {
                    Height = 300
                };

                ScrollViewer scrollViewer = new()
                {
                    VerticalScrollBarVisibility = ScrollBarVisibility.Auto
                };

                TextBlock textBlock = new()
                {
                    Text = text.Replace("TextBlock", ""),
                    FontSize = 25,
                    FontWeight = FontWeights.Medium,
                    Background = null,
                    Foreground = Brushes.Black,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Left,
                    Name = ReplaceWithWord(name),
                    TextWrapping = TextWrapping.Wrap,
                    Width = 750,
                    Margin = new Thickness(0, 5, 0, 0)
                };

                scrollViewer.Content = textBlock;

                border.Child = scrollViewer;

                panel.Children.Add(border);
            }
            else
            {
                TextBlock textBlock = new()
                {
                    Text = text.Replace("TextBlock", ""),
                    FontSize = 25,
                    FontWeight = FontWeights.Medium,
                    Background = null,
                    Foreground = Brushes.Black,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                    Name = ReplaceWithWord(name),
                    TextWrapping = TextWrapping.Wrap,
                    Width = 500
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
