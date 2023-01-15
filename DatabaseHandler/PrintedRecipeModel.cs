using System.Collections.Generic;
using static Cookbook_Database.SqLiteDataAccess;

namespace Cookbook_Database
{
    public class AllPrintedRecipeModel
    {
        public string? Salad { get; set; }
        public string? Soup { get; set; }
        public string? Appetizer { get; set; }
        public string? Meat { get; set; }
        public string? Poultry { get; set; }
        public string? Seafood { get; set; }
        public string? Vegetable { get; set; }
        public string? Side { get; set; }
        public string? Dessert { get; set; }
        public string? Breakfast { get; set; }
        public string? Misc { get; set; }

        /// <summary>
        /// Converts <see cref="AllRecipeModel"/> object to a list of strings
        /// </summary>
        /// <returns>
        /// List of strings
        /// </returns>
        public static List<string> AllPrintedRecipeModelToString()
        {
            List<AllPrintedRecipeModel> recipeModels = new();

            recipeModels = LoadAllPrintedRecipes();

            List<string> recipeStrings = new();

            foreach (AllPrintedRecipeModel recipe in recipeModels)
            {
                if (!string.IsNullOrEmpty(recipe.Salad))
                {
                    recipeStrings.Add(recipe.Salad);
                }

                if (!string.IsNullOrEmpty(recipe.Soup))
                {
                    recipeStrings.Add(recipe.Soup);
                }

                if (!string.IsNullOrEmpty(recipe.Appetizer))
                {
                    recipeStrings.Add(recipe.Appetizer);
                }

                if (!string.IsNullOrEmpty(recipe.Meat))
                {
                    recipeStrings.Add(recipe.Meat);
                }

                if (!string.IsNullOrEmpty(recipe.Poultry))
                {
                    recipeStrings.Add(recipe.Poultry);
                }

                if (!string.IsNullOrEmpty(recipe.Seafood))
                {
                    recipeStrings.Add(recipe.Seafood);
                }

                if (!string.IsNullOrEmpty(recipe.Vegetable))
                {
                    recipeStrings.Add(recipe.Vegetable);
                }

                if (!string.IsNullOrEmpty(recipe.Side))
                {
                    recipeStrings.Add(recipe.Side);
                }

                if (!string.IsNullOrEmpty(recipe.Dessert))
                {
                    recipeStrings.Add(recipe.Dessert);
                }

                if (!string.IsNullOrEmpty(recipe.Breakfast))
                {
                    recipeStrings.Add(recipe.Breakfast);
                }

                if (!string.IsNullOrEmpty(recipe.Misc))
                {
                    recipeStrings.Add(recipe.Misc);
                }
            }

            return recipeStrings;
        }
    }

    public class SaladModel
    {
        public string? Salad { get; set; }

        public static List<string> SaladRecipeModelToString()
        {
            List<SaladModel> saladModels = new();

            saladModels = LoadSalads();

            List<string> recipeStrings = new();

            foreach (SaladModel saladModel in saladModels)
            {
                if (!string.IsNullOrEmpty(saladModel.Salad))
                {
                    recipeStrings.Add(saladModel.Salad);
                }
            }

            return recipeStrings;
        }
    }

    public class SoupModel
    {
        public string? Soup { get; set; }

        public static List<string> SoupRecipeModelToString()
        {
            List<SoupModel> soupModels = new();

            soupModels = LoadSoups();

            List<string> recipeStrings = new();

            foreach (SoupModel soupModel in soupModels)
            {
                if (!string.IsNullOrEmpty(soupModel.Soup))
                {
                    recipeStrings.Add(soupModel.Soup);
                }
            }

            return recipeStrings;
        }
    }

    public class AppetizerModel
    {
        public string? Appetizer { get; set; }

        public static List<string> AppetizerRecipeModelToString()
        {
            List<AppetizerModel> appetizerModels = new();

            appetizerModels = LoadAppetizers();

            List<string> recipeStrings = new();

            foreach (AppetizerModel appetizerModel in appetizerModels)
            {
                if (!string.IsNullOrEmpty(appetizerModel.Appetizer))
                {
                    recipeStrings.Add(appetizerModel.Appetizer);
                }
            }

            return recipeStrings;
        }
    }

    public class MeatModel
    {
        public string? Meat { get; set; }

        public static List<string> MeatRecipeModelToString()
        {
            List<MeatModel> meatModels = new();

            meatModels = LoadMeat();

            List<string> recipeStrings = new();

            foreach (MeatModel meatModel in meatModels)
            {
                if (!string.IsNullOrEmpty(meatModel.Meat))
                {
                    recipeStrings.Add(meatModel.Meat);
                }
            }

            return recipeStrings;
        }
    }

    public class PoultryModel
    {
        public string? Poultry { get; set; }

        public static List<string> PoultryRecipeModelToString()
        {
            List<PoultryModel> poultryModels = new();

            poultryModels = LoadPoultry();

            List<string> recipeStrings = new();

            foreach (PoultryModel poultryModel in poultryModels)
            {
                if (!string.IsNullOrEmpty(poultryModel.Poultry))
                {
                    recipeStrings.Add(poultryModel.Poultry);
                }
            }

            return recipeStrings;
        }
    }

    public class SeafoodModel
    {
        public string? Seafood { get; set; }

        public static List<string> SeafoodRecipeModelToString()
        {
            List<SeafoodModel> seafoodModels = new();

            seafoodModels = LoadSeafood();

            List<string> recipeStrings = new();

            foreach (SeafoodModel seafoodModel in seafoodModels)
            {
                if (!string.IsNullOrEmpty(seafoodModel.Seafood))
                {
                    recipeStrings.Add(seafoodModel.Seafood);
                }
            }

            return recipeStrings;
        }
    }

    public class VegetableModel
    {
        public string? Vegetable { get; set; }

        public static List<string> VegetableRecipeModelToString()
        {
            List<VegetableModel> vegetableModels = new();

            vegetableModels = LoadVegetables();

            List<string> recipeStrings = new();

            foreach (VegetableModel vegetableModel in vegetableModels)
            {
                if (!string.IsNullOrEmpty(vegetableModel.Vegetable))
                {
                    recipeStrings.Add(vegetableModel.Vegetable);
                }
            }

            return recipeStrings;
        }
    }

    public class SideModel
    {
        public string? Side { get; set; }

        public static List<string> SideRecipeModelToString()
        {
            List<SideModel> sideModels = new();

            sideModels = LoadSides();

            List<string> recipeStrings = new();

            foreach (SideModel sideModel in sideModels)
            {
                if (!string.IsNullOrEmpty(sideModel.Side))
                {
                    recipeStrings.Add(sideModel.Side);
                }
            }

            return recipeStrings;
        }
    }

    public class DessertModel
    {
        public string? Dessert { get; set; }

        public static List<string> DessertRecipeModelToString()
        {
            List<DessertModel> dessertModels = new();

            dessertModels = LoadDesserts();

            List<string> recipeStrings = new();

            foreach (DessertModel dessertModel in dessertModels)
            {
                if (!string.IsNullOrEmpty(dessertModel.Dessert))
                {
                    recipeStrings.Add(dessertModel.Dessert);
                }
            }

            return recipeStrings;
        }
    }

    public class BreakfastModel
    {
        public string? Breakfast { get; set; }

        public static List<string> BreakfastRecipeModelToString()
        {
            List<BreakfastModel> breakfastModels = new();

            breakfastModels = LoadBreakfast();

            List<string> recipeStrings = new();

            foreach (BreakfastModel breakfastModel in breakfastModels)
            {
                if (!string.IsNullOrEmpty(breakfastModel.Breakfast))
                {
                    recipeStrings.Add(breakfastModel.Breakfast);
                }
            }

            return recipeStrings;
        }
    }

    public class MiscModel
    {
        public string? Misc { get; set; }

        public static List<string> MiscRecipeModelToString()
        {
            List<MiscModel> miscModels = new();

            miscModels = LoadMisc();

            List<string> recipeStrings = new();

            foreach (MiscModel miscModel in miscModels)
            {
                if (!string.IsNullOrEmpty(miscModel.Misc))
                {
                    recipeStrings.Add(miscModel.Misc);
                }
            }

            return recipeStrings;
        }
    }
}
