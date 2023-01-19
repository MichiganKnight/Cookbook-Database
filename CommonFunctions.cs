using Cookbook_Database.Properties;
using Cookbook_Database.Windows;
using System.IO;
using System.Printing;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Cookbook_Database
{
    public static class CommonFunctions
    {
        /// <summary>
        /// Create GoBack button for recipe pages
        /// </summary>
        /// <returns><see cref="Label"/> that acts as a button</returns>
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

        public static void CreateRecipeButtons(string recipe, Panel recipePanel, Frame frame, bool isPrintedRecipe, ImageBrush? recipeImage = null, Separator? menuSeperator = null, MenuItem? printButton = null)
        {
            string labelName = Regex.Replace($"{recipe}Label", @"[^a-zA-Z0-9]+", "");
            string buttonName = Regex.Replace($"{recipe}Button", @"[^a-zA-Z0-9]+", "");

            Button button = new()
            {
                Content = recipe,
                Cursor = Cursors.Hand,
                FontSize = 25,
                FontWeight = FontWeights.Medium,
                Background = null,
                Foreground = Brushes.Blue,
                BorderBrush = Brushes.LightGray,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Left,
                Name = ReplaceWithWord(buttonName),
                Margin = new Thickness(10, 0, 0, 0)
            };

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
                if (isPrintedRecipe)
                {
                    Settings.Default.ButtonName = buttonName;
                    Settings.Default.PrintedRecipe = recipe;
                    Settings.Default.LabelName = labelName;

                    frame.Visibility = Visibility.Visible;
                    frame.NavigationService.Navigate(new PrintedRecipeView());
                }
                else
                {
                    Settings.Default.CooksCountryRecipeToDisplay = button.Content.ToString();

                    frame.Visibility = Visibility.Visible;
                    frame.NavigationService.Navigate(new CooksCountryRecipeView());
                }
            };

            recipePanel.Children.Add(button);
        }

        /// <summary>
        /// Load image from <see cref="MemoryStream"/>
        /// </summary>
        /// <param name="imageData">Image as an array of bytes</param>
        /// <returns><see cref="BitmapImage"/></returns>
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

        /// <summary>
        /// Print Image
        /// </summary>
        /// <param name="image">Image to print</param>
        public static void PrintImage(BitmapImage image)
        {
            DrawingVisual drawingVisual = new();

            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                drawingContext.DrawImage(image, new Rect
                {
                    Width = image.Width,
                    Height = image.Height,
                });
            }

            LocalPrintServer printServer = new();
            PrintQueue? DefaultPrinter = printServer.DefaultPrintQueue;
            PrintDialog printDialog = new()
            {
                PrintQueue = DefaultPrinter
            };

            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(drawingVisual, "Print Recipe");
            }
        }
    }
}