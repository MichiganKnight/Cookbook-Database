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
        int numberOfClicks = 0;

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
        }

        private void DisplayNames()
        {

            foreach (string name in NameModel.NameModelToString())
            {
                CreateButtons(name);
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

                numberOfClicks++;

                switch (numberOfClicks)
                {
                    case 1:
                        DisplayIssues();

                        break;
                    case 2:
                        DisplayNames();
                        
                        break;
                    case 3:
                        Settings.Default.CooksCountryRecipeToDisplay = button.Content.ToString();

                        Frame.Visibility = Visibility.Visible;
                        Frame.NavigationService.Navigate(new CooksCountryRecipeView());

                        break;
                    default:
                        break;
                }
            };
        }
    }
}
