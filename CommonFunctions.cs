using Cookbook_Database.Properties;
using Cookbook_Database.Windows;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Cookbook_Database
{
    public static class CommonFunctions
    {
        public static Label CreateGoBackButton()
        {
            Label goBack = new()
            {
                Content = "Go Back",
                Cursor = Cursors.Hand,
                FontSize = 30,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                Name = "GoBack",
                VerticalAlignment = VerticalAlignment.Bottom
            };

            return goBack;
        }

        public static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (MemoryStream? mem = new(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        public static void ShowRecipes(string recipeType)
        {
            switch (recipeType)
            {
                case "Salad":
                    Settings.Default.RecipeType = "Salad";
                    break;
                case "Soup":
                    Settings.Default.RecipeType = "Soup";
                    break;
                case "Appetizer":
                    Settings.Default.RecipeType = "Appetizer";
                    break;
                case "Meat":
                    Settings.Default.RecipeType = "Meat";
                    break;
                case "Poultry":
                    Settings.Default.RecipeType = "Poultry";
                    break;
                case "Seafood":
                    Settings.Default.RecipeType = "Seafood";
                    break;
                case "Vegetable":
                    Settings.Default.RecipeType = "Vegetable";
                    break;
                case "Side":
                    Settings.Default.RecipeType = "Side";
                    break;
                case "Dessert":
                    Settings.Default.RecipeType = "Dessert";
                    break;
                case "Breakfast":
                    Settings.Default.RecipeType = "Breakfast";
                    break;
                case "Misc":
                    Settings.Default.RecipeType = "Misc";
                    break;
                default:
                    break;
            }

            MainWindow Form = Application.Current.Windows[0] as MainWindow;

            Form.Frame.Visibility = Visibility.Visible;
            Form.Frame.NavigationService.Navigate(new RecipeView());
        }

        /// <summary>
        /// Use <see cref="Regex.Replace(string, MatchEvaluator)"/> to replace the number in a string to its word equivalent
        /// </summary>
        /// <param name="text">Text to replace</param>
        /// <returns>Replaced text</returns>
        public static string ReplaceWithWord(string text)
        {
            if (text.Contains('1'))
            {
                text = Regex.Replace(text, "1", "One");
            }
            if (text.Contains('2'))
            {
                text = Regex.Replace(text, "2", "Two");
            }
            if (text.Contains('3'))
            {
                text = Regex.Replace(text, "3", "Three");
            }
            if (text.Contains('4'))
            {
                text = Regex.Replace(text, "4", "Four");
            }
            if (text.Contains('5'))
            {
                text = Regex.Replace(text, "5", "Five");
            }
            if (text.Contains('6'))
            {
                text = Regex.Replace(text, "6", "Six");
            }
            if (text.Contains('7'))
            {
                text = Regex.Replace(text, "7", "Seven");
            }
            if (text.Contains('8'))
            {
                text = Regex.Replace(text, "8", "Eight");
            }
            if (text.Contains('9'))
            {
                text = Regex.Replace(text, "9", "Nine");
            }

            return text;
        }
    }
}