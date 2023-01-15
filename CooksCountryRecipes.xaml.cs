using Cookbook_Database.DatabaseHandler;
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
        bool areIssuesDisplayed = false;
        bool areNamesDisplayed = false;

        public CooksCountryRecipes()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string year in YearModel.YearModelToString())
            {
                CreateButtons(year);
            }
        }

        private void DisplayIssues()
        {
            foreach (string issue in IssueModel.IssueModelToString())
            {
                CreateButtons(issue);
            }

            areIssuesDisplayed = true;
        }

        private string DisplayNames()
        {
            string returnValue = "";

            foreach (string name in NameModel.NameModelToString())
            {
                CreateButtons(name);

                returnValue = name;
            }

            return returnValue;
        }

        private void DisplayRecipes()
        {
            foreach (string name in NameModel.NameModelToString())
            {
                CreateLabels(name);
            }
        }

        private void CreateButtons(string recipe)
        {
            string name = Regex.Replace($"{recipe}Button", @"[^a-zA-Z0-9]+", "");

            Button button = new()
            {
                Content = recipe,
                Cursor = Cursors.Hand,
                FontSize = 25,
                FontWeight = FontWeights.Medium,
                Background = null,
                Foreground = Brushes.Blue,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Left,
                Name = ReplaceWithWord(name),
                Margin = new Thickness(10, 0, 0, 0)
            };

            RecipePanel.Children.Add(button);

            button.MouseEnter += (s, e) =>
            {
                button.Background = Brushes.LightGray;
            };

            button.MouseLeave += (s, e) =>
            {
                button.Background = Brushes.White;
            };

            button.Click += (s, e) =>
            {
                RecipePanel.Children.Clear();

                if (!areIssuesDisplayed)
                {
                    DisplayIssues();
                }
                else
                {
                    string temp = DisplayNames();

                    areNamesDisplayed = true;

                    if (!areNamesDisplayed)
                    {
                        MessageBox.Show($"Button Text: {button.Content}\nDisplayNames Text: {temp}");

                        if (temp == button.Content)
                        {
                            MessageBox.Show("true");

                            DisplayRecipes();
                        }
                    }
                    
                }
            };
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
    }
}
