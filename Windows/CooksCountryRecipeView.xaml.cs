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
            Settings.Default.PreviousPageInfo = $"{Settings.Default.PreviousPageInfo} - Recipe";

            CreateRecipeSections(NamePanel, ServingsPanel, DescriptionPanel, QuantityPanel, IngredientPanel, StepPanel, InstructionPanel);
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
