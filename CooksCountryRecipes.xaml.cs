using Cookbook_Database.DatabaseHandler;
using Cookbook_Database.Properties;
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
        public CooksCountryRecipes()
        {
            InitializeComponent();
        }

        private void DisplayRecipeNames()
        {
            foreach (string name in NameModel.NameModelToString())
            {
                CreateRecipeButtons(name, RecipePanel, Frame, false);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // TODO: Figure out the go back buttons

            //Settings.Default.PreviousPageInfo = "Cooks Country Recipes";
        }

        private void Button_2018_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.CooksCountryYear = "2018";
            //Settings.Default.PreviousPageInfo = "2018";

            TitleLabel.Content = "Cookbook Database - Cooks Country Recipes";
            SubtitleLabel.Content = $"{Settings.Default.CooksCountryYear} Issue";

            YearPanel.Visibility = Visibility.Collapsed;

            IssuePanel.Visibility = Visibility.Visible;
        }

        private void FebMarchButton_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.CooksCountryIssue = "February / March";
            //Settings.Default.PreviousPageInfo = "February / March";

            TitleLabel.Content = "Cookbook Database - Cooks Country Recipes";
            SubtitleLabel.Content = $"{Settings.Default.CooksCountryIssue} Volume";

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
    }
}
