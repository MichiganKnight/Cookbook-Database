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
            List<QuantityModel> quantityModels = new();

            quantityModels = LoadQuantities();

            List<string> recipeStrings = new();

            foreach (QuantityModel quantityModel in quantityModels)
            {
                if (!string.IsNullOrEmpty(quantityModel.Quantity))
                {
                    recipeStrings.Add(quantityModel.Quantity);
                }
            }

            return recipeStrings;
        }
    }

    public class IngredientNameModel
    {
        public string? Name { get; set; }

        public static List<string> IngredientModelToString()
        {
            List<IngredientNameModel> ingredientNameModels = new();

            ingredientNameModels = LoadIngredientNames();

            List<string> recipeStrings = new();

            foreach (IngredientNameModel ingredientNameModel in ingredientNameModels)
            {
                if (!string.IsNullOrEmpty(ingredientNameModel.Name))
                {
                    recipeStrings.Add(ingredientNameModel.Name);
                }
            }

            return recipeStrings;
        }
    }

    public class StepModel
    {
        public string? Step { get; set; }

        public static List<string> StepModelToString()
        {
            List<StepModel> stepModels = new();

            stepModels = LoadSteps();

            List<string> recipeStrings = new();

            foreach (StepModel stepModel in stepModels)
            {
                if (!string.IsNullOrEmpty(stepModel.Step))
                {
                    recipeStrings.Add(stepModel.Step);
                }
            }

            return recipeStrings;
        }
    }

    public class InstructionModel
    {
        public string? Description { get; set; }

        public static List<string> InstructionModelToString()
        {
            List<InstructionModel> instructionsModels = new();

            instructionsModels = LoadInstructions();

            List<string> recipeStrings = new();

            foreach (InstructionModel instructionModel in instructionsModels)
            {
                if (!string.IsNullOrEmpty(instructionModel.Description))
                {
                    recipeStrings.Add(instructionModel.Description);
                }
            }

            return recipeStrings;
        }
    }
}
