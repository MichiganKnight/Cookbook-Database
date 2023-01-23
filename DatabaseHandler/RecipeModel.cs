using System.Collections.Generic;

using static Cookbook_Database.SqLiteDataAccess;

namespace Cookbook_Database.DatabaseHandler
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

            List<string> saladStrings = new();

            foreach (SaladModel saladModel in saladModels)
            {
                if (!string.IsNullOrEmpty(saladModel.Salad))
                {
                    saladStrings.Add(saladModel.Salad);
                }
            }

            return saladStrings;
        }
    }

    public class SoupModel
    {
        public string? Soup { get; set; }

        public static List<string> SoupRecipeModelToString()
        {
            List<SoupModel> soupModels = new();

            soupModels = LoadSoups();

            List<string> soupStrings = new();

            foreach (SoupModel soupModel in soupModels)
            {
                if (!string.IsNullOrEmpty(soupModel.Soup))
                {
                    soupStrings.Add(soupModel.Soup);
                }
            }

            return soupStrings;
        }
    }

    public class AppetizerModel
    {
        public string? Appetizer { get; set; }

        public static List<string> AppetizerRecipeModelToString()
        {
            List<AppetizerModel> appetizerModels = new();

            appetizerModels = LoadAppetizers();

            List<string> appetizerStrings = new();

            foreach (AppetizerModel appetizerModel in appetizerModels)
            {
                if (!string.IsNullOrEmpty(appetizerModel.Appetizer))
                {
                    appetizerStrings.Add(appetizerModel.Appetizer);
                }
            }

            return appetizerStrings;
        }
    }

    public class MeatModel
    {
        public string? Meat { get; set; }

        public static List<string> MeatRecipeModelToString()
        {
            List<MeatModel> meatModels = new();

            meatModels = LoadMeat();

            List<string> meatStrings = new();

            foreach (MeatModel meatModel in meatModels)
            {
                if (!string.IsNullOrEmpty(meatModel.Meat))
                {
                    meatStrings.Add(meatModel.Meat);
                }
            }

            return meatStrings;
        }
    }

    public class PoultryModel
    {
        public string? Poultry { get; set; }

        public static List<string> PoultryRecipeModelToString()
        {
            List<PoultryModel> poultryModels = new();

            poultryModels = LoadPoultry();

            List<string> poultryStrings = new();

            foreach (PoultryModel poultryModel in poultryModels)
            {
                if (!string.IsNullOrEmpty(poultryModel.Poultry))
                {
                    poultryStrings.Add(poultryModel.Poultry);
                }
            }

            return poultryStrings;
        }
    }

    public class SeafoodModel
    {
        public string? Seafood { get; set; }

        public static List<string> SeafoodRecipeModelToString()
        {
            List<SeafoodModel> seafoodModels = new();

            seafoodModels = LoadSeafood();

            List<string> seafoodStrings = new();

            foreach (SeafoodModel seafoodModel in seafoodModels)
            {
                if (!string.IsNullOrEmpty(seafoodModel.Seafood))
                {
                    seafoodStrings.Add(seafoodModel.Seafood);
                }
            }

            return seafoodStrings;
        }
    }

    public class VegetableModel
    {
        public string? Vegetable { get; set; }

        public static List<string> VegetableRecipeModelToString()
        {
            List<VegetableModel> vegetableModels = new();

            vegetableModels = LoadVegetables();

            List<string> vegetableStrings = new();

            foreach (VegetableModel vegetableModel in vegetableModels)
            {
                if (!string.IsNullOrEmpty(vegetableModel.Vegetable))
                {
                    vegetableStrings.Add(vegetableModel.Vegetable);
                }
            }

            return vegetableStrings;
        }
    }

    public class SideModel
    {
        public string? Side { get; set; }

        public static List<string> SideRecipeModelToString()
        {
            List<SideModel> sideModels = new();

            sideModels = LoadSides();

            List<string> sideStrings = new();

            foreach (SideModel sideModel in sideModels)
            {
                if (!string.IsNullOrEmpty(sideModel.Side))
                {
                    sideStrings.Add(sideModel.Side);
                }
            }

            return sideStrings;
        }
    }

    public class DessertModel
    {
        public string? Dessert { get; set; }

        public static List<string> DessertRecipeModelToString()
        {
            List<DessertModel> dessertModels = new();

            dessertModels = LoadDesserts();

            List<string> dessertStrings = new();

            foreach (DessertModel dessertModel in dessertModels)
            {
                if (!string.IsNullOrEmpty(dessertModel.Dessert))
                {
                    dessertStrings.Add(dessertModel.Dessert);
                }
            }

            return dessertStrings;
        }
    }

    public class BreakfastModel
    {
        public string? Breakfast { get; set; }

        public static List<string> BreakfastRecipeModelToString()
        {
            List<BreakfastModel> breakfastModels = new();

            breakfastModels = LoadBreakfast();

            List<string> breakfastStrings = new();

            foreach (BreakfastModel breakfastModel in breakfastModels)
            {
                if (!string.IsNullOrEmpty(breakfastModel.Breakfast))
                {
                    breakfastStrings.Add(breakfastModel.Breakfast);
                }
            }

            return breakfastStrings;
        }
    }

    public class MiscModel
    {
        public string? Misc { get; set; }

        public static List<string> MiscRecipeModelToString()
        {
            List<MiscModel> miscModels = new();

            miscModels = LoadMisc();

            List<string> miscStrings = new();

            foreach (MiscModel miscModel in miscModels)
            {
                if (!string.IsNullOrEmpty(miscModel.Misc))
                {
                    miscStrings.Add(miscModel.Misc);
                }
            }

            return miscStrings;
        }
    }

    public class NameModel
    {
        public string? Name { get; set; }

        public static List<string> NameModelToString()
        {
            List<NameModel> nameModels = new();

            nameModels = LoadNames();

            List<string> nameStrings = new();

            foreach (NameModel nameModel in nameModels)
            {
                if (!string.IsNullOrEmpty(nameModel.Name))
                {
                    nameStrings.Add(nameModel.Name);
                }
            }

            return nameStrings;
        }
    }

    public class SearchByNameModel
    {
        public string? Name { get; set; }

        public static List<string> NameModelToString()
        {
            List<SearchByNameModel> searchByNameModels = new();

            searchByNameModels = LoadSearchByNames();

            List<string> searchByNameStrings = new();

            foreach(SearchByNameModel searchByNameModel in searchByNameModels)
            {
                if (!string.IsNullOrEmpty(searchByNameModel.Name))
                {
                    searchByNameStrings.Add(searchByNameModel.Name);
                }
            }

            return searchByNameStrings;
        }
    }

    public class ServingsModel
    {
        public string? Servings { get; set; }

        public static List<string> ServingsModelToString()
        {
            List<ServingsModel> servingsModels = new();

            servingsModels = LoadServings();

            List<string> servingsStrings = new();

            foreach (ServingsModel servingModel in servingsModels)
            {
                if (!string.IsNullOrEmpty(servingModel.Servings))
                {
                    servingsStrings.Add(servingModel.Servings);
                }
            }

            return servingsStrings;
        }
    }

    public class DescriptionModel
    {
        public string? Description { get; set; }

        public static List<string> DescriptionModelToString()
        {
            List<DescriptionModel> descriptionModels = new();

            descriptionModels = LoadDescriptions();

            List<string> descriptionStrings = new();

            foreach (DescriptionModel descriptionModel in descriptionModels)
            {
                if (!string.IsNullOrEmpty(descriptionModel.Description))
                {
                    descriptionStrings.Add(descriptionModel.Description);
                }
            }

            return descriptionStrings;
        }
    }

    public class QuantityModel
    {
        public string? Quantity { get; set; }

        public static List<string> QuantityModelToString()
        {
            List<string> quantityModels = new();

            quantityModels = LoadQuantities();

            List<string> quantityStrings = new();

            foreach (string quantityModel in quantityModels)
            {
                quantityStrings.Add(quantityModel);
            }

            return quantityStrings;
        }
    }

    public class IngredientNameModel
    {
        public string? Name { get; set; }

        public static List<string> IngredientModelToString()
        {
            List<string> ingredientNameModels = new();

            ingredientNameModels = LoadIngredientNames();

            List<string> ingredientNameStrings = new();

            foreach (string ingredientNameModel in ingredientNameModels)
            {
                ingredientNameStrings.Add(ingredientNameModel);
            }

            return ingredientNameStrings;
        }
    }

    public class StepModel
    {
        public string? Step { get; set; }

        public static List<string> StepModelToString()
        {
            List<int> stepModels = new();

            stepModels = LoadSteps();

            List<string> stepStrings = new();

            foreach (int stepModel in stepModels)
            {
                stepStrings.Add(stepModel.ToString());
            }

            return stepStrings;
        }
    }

    public class InstructionModel
    {
        public string? Description { get; set; }

        public static List<string> InstructionModelToString()
        {
            List<string> instrucitonModels = new();

            instrucitonModels = LoadInstructions();

            List<string> instructionStrings = new();

            foreach (string instructionModel in instrucitonModels)
            {
                instructionStrings.Add(instructionModel);
            }

            return instructionStrings;
        }
    }
}
