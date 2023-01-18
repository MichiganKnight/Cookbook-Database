using System.Collections.Generic;

using static Cookbook_Database.SqLiteDataAccess;

namespace Cookbook_Database.DatabaseHandler
{
    public class NameModel
    {
        public string? Name { get; set; }

        public static List<string> NameModelToString()
        {
            List<NameModel> nameModels = new();

            nameModels = LoadNames();

            List<string> recipeStrings = new();

            foreach (NameModel nameModel in nameModels)
            {
                if (!string.IsNullOrEmpty(nameModel.Name))
                {
                    recipeStrings.Add(nameModel.Name);
                }
            }

            return recipeStrings;
        }
    }

    public class ServingsModel
    {
        public string? Servings { get; set; }

        public static List<string> ServingsModelToString()
        {
            List<ServingsModel> servingsModels = new();

            servingsModels = LoadServings();

            List<string> recipeStrings = new();

            foreach (ServingsModel servingModel in servingsModels)
            {
                if (!string.IsNullOrEmpty(servingModel.Servings))
                {
                    recipeStrings.Add(servingModel.Servings);
                }
            }

            return recipeStrings;
        }
    }

    public class DescriptionModel
    {
        public string? Description { get; set; }

        public static List<string> DescriptionModelToString()
        {
            List<DescriptionModel> descriptionModels = new();

            descriptionModels = LoadDescriptions();

            List<string> recipeStrings = new();

            foreach (DescriptionModel descriptionModel in descriptionModels)
            {
                if (!string.IsNullOrEmpty(descriptionModel.Description))
                {
                    recipeStrings.Add(descriptionModel.Description);
                }
            }

            return recipeStrings;
        }
    }

    public class QuantityModel
    {
        public string? Quantity { get; set; }

        public static List<string> QuantityModelToString()
        {
            List<string> quantityModels = new();

            quantityModels = LoadQuantities();

            List<string> recipeStrings = new();

            foreach (string quantityModel in quantityModels)
            {
                recipeStrings.Add(quantityModel);
            }

            return recipeStrings;
        }
    }

    public class IngredientNameModel
    {
        public string? Name { get; set; }

        public static List<string> IngredientModelToString()
        {
            List<string> ingredientNameModels = new();

            ingredientNameModels = LoadIngredientNames();

            List<string> recipeStrings = new();

            foreach (string ingredientNameModel in ingredientNameModels)
            {
                recipeStrings.Add(ingredientNameModel);
            }

            return recipeStrings;
        }
    }

    public class StepModel
    {
        public string? Step { get; set; }

        public static List<string> StepModelToString()
        {
            List<int> stepModels = new();

            stepModels = LoadSteps();

            List<string> recipeStrings = new();

            foreach (int stepModel in stepModels)
            {
                recipeStrings.Add(stepModel.ToString());
            }

            return recipeStrings;
        }
    }

    public class InstructionModel
    {
        public string? Description { get; set; }

        public static List<string> InstructionModelToString()
        {
            List<string> instrucitonModels = new();

            instrucitonModels = LoadInstructions();

            List<string> recipeStrings = new();

            foreach (string instructionModel in instrucitonModels)
            {
                recipeStrings.Add(instructionModel);
            }

            return recipeStrings;
        }
    }
}
