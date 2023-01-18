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
