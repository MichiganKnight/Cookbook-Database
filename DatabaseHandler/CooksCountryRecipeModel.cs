using System.Collections.Generic;
using static Cookbook_Database.SqLiteDataAccess;

namespace Cookbook_Database.DatabaseHandler
{
    public class AllCooksCountryRecipeModel
    {
        public string? Name { get; set; }
        public string? Servings { get; set; }
        public string? Description { get; set; }

        public static List<string> AllCooksCountryRecipeModelToString()
        {
            List<AllCooksCountryRecipeModel> recipeModels = new();

            recipeModels = LoadAllCooksCountryRecipes();

            List<string> recipeStrings = new();

            foreach (AllCooksCountryRecipeModel recipeModel in recipeModels)
            {
                if (!string.IsNullOrEmpty(recipeModel.Name))
                {
                    recipeStrings.Add(recipeModel.Name);
                }

                if (!string.IsNullOrEmpty(recipeModel.Servings))
                {
                    recipeStrings.Add(recipeModel.Servings);
                }

                if (recipeModel.Description != null)
                {
                    recipeStrings.Add(recipeModel.Description);
                }
            }

            return recipeStrings;
        }
    }

    public class IngredientModel
    {
        public string? Quantity { get; set; }
        public string? Name { get; set; }

        public static List<string> IngredientRecipeModelToString()
        {
            List<IngredientModel> ingredientModels = new();

            ingredientModels = LoadIngredients();

            List<string> recipeStrings = new();

            foreach (IngredientModel ingredientModel in ingredientModels)
            {
                if (!string.IsNullOrEmpty(ingredientModel.Quantity))
                {
                    recipeStrings.Add(ingredientModel.Quantity);
                }

                if (!string.IsNullOrEmpty(ingredientModel.Name))
                {
                    recipeStrings.Add(ingredientModel.Name);
                }
            }

            return recipeStrings;
        }
    }

    public class InstructionModel
    {
        public int Step { get; set; }
        public string? Description { get; set; }

        public static List<string> InstructionModelToString()
        {
            List<InstructionModel> instructionsModels = new();

            instructionsModels = LoadInstructions();

            List<string> recipeStrings = new();

            foreach (InstructionModel instructionModel in instructionsModels)
            {
                recipeStrings.Add(instructionModel.Step.ToString());

                if (!string.IsNullOrEmpty(instructionModel.Description))
                {
                    recipeStrings.Add(instructionModel.Description);
                }
            }

            return recipeStrings;
        }
    }
}
