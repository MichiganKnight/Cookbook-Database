﻿using Cookbook_Database.DatabaseHandler;
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
        #region Create Recipe Buttons

        /// <summary>
        /// Create recipe buttons
        /// </summary>
        /// <param name="recipe">Name of the recipe</param>
        /// <param name="recipePanel">Recipe panel to add the button to</param>
        /// <param name="frame">Frame that determines which view to transition to</param>
        /// <param name="isPrintedRecipe">Is the recipe a printed recipe?</param>
        /// <param name="recipeImage"><see cref="ImageBrush"/> that displays the printed recipe</param>
        /// <param name="menuSeperator">A menu seperator</param>
        /// <param name="printButton">Button to print the recipe</param>
        public static void CreateRecipeButtons(string recipe, Panel recipePanel, Frame frame, string recipeType, ImageBrush? recipeImage = null, Separator? menuSeperator = null, MenuItem? printButton = null)
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
                if (recipeType == "Printed")
                {
                    Settings.Default.ButtonName = buttonName;
                    Settings.Default.RecipeString = recipe;
                    Settings.Default.LabelName = labelName;

                    frame.Visibility = Visibility.Visible;
                    frame.NavigationService.Navigate(new PrintedRecipeView());
                }
                else if (recipeType == "Cooks Country")
                {
                    Settings.Default.CooksCountryRecipeToDisplay = button.Content.ToString();

                    frame.Visibility = Visibility.Visible;
                    frame.NavigationService.Navigate(new CooksCountryRecipeView());
                }
                else if (recipeType == "Search")
                {
                    Settings.Default.CooksCountryRecipeToDisplay = button.Content.ToString();
                    Settings.Default.ButtonName = buttonName;
                    Settings.Default.RecipeString = recipe;
                    Settings.Default.LabelName = labelName;

                    frame.Visibility = Visibility.Visible;
                    frame.NavigationService.Navigate(new SearchRecipeView());
                }
            };

            recipePanel.Children.Add(button);
        }

        #endregion

        #region Create Recipe Sections

        public static void CreateRecipeSections(StackPanel NamePanel, StackPanel ServingsPanel, StackPanel DescriptionPanel, StackPanel QuantityPanel, StackPanel IngredientPanel, StackPanel StepPanel, StackPanel InstructionPanel)
        {
            foreach (string name in NameModel.NameModelToString())
            {
                CreateLabels(name, NamePanel, 50, Brushes.Maroon, FontWeights.Bold);
            }

            foreach (string serving in ServingsModel.ServingsModelToString())
            {
                CreateLabels($"Serves {serving}", ServingsPanel, 50, Brushes.Maroon, FontWeights.Medium);
            }

            foreach (string description in DescriptionModel.DescriptionModelToString())
            {
                CreateTextBlocks(description, DescriptionPanel, false);
            }

            foreach (string quantity in QuantityModel.QuantityModelToString())
            {
                CreateLabels(quantity, QuantityPanel, 50, Brushes.Black, FontWeights.Medium);
            }

            foreach (string ingredient in IngredientNameModel.IngredientModelToString())
            {
                CreateLabels(ingredient, IngredientPanel, 50, Brushes.Black, FontWeights.Medium);
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

        private static void CreateLabels(string text, StackPanel panel, int height, SolidColorBrush solidColorBrush, FontWeight fontWeight)
        {
            string name = Regex.Replace($"{text}Label", @"[^a-zA-Z0-9]+", "");

            Label label = new()
            {
                Content = text.Replace("Label", ""),
                FontSize = 25,
                FontWeight = fontWeight,
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

        #endregion

        #region Search

        public static void Search(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text) || textBox.Text == "Search...")
            {
                MessageBox.Show("You must ender a valid recipe");
            }
            else
            {
                Settings.Default.SearchString = textBox.Text;

                PrintedRecipes? Form = Application.Current.Windows[0] as PrintedRecipes;

                Form.Frame.Visibility = Visibility.Visible;
                Form.Frame.NavigationService.Navigate(new SearchRecipes());
            }
        }

        public static void ChangeFocus(TextBox textBox)
        {
            if (textBox.Text == "Search...")
            {
                textBox.Text = "";
            }
            else
            {
                textBox.Text = "Search...";
            }
        }

        #endregion

        #region Various Image Usability

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

        #endregion

        #region Replace Text With Word

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

        #endregion
    }
}