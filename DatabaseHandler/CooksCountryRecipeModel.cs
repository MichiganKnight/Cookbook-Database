using System.Collections.Generic;

using static Cookbook_Database.SqLiteDataAccess;

namespace Cookbook_Database.DatabaseHandler
{
    public class YearModel
    {
        public string? Year { get; set; }

        public static List<string> YearModelToString()
        {
            List<YearModel> recipeModels = new();

            recipeModels = LoadYears();

            List<string> recipeStrings = new();

            foreach (YearModel recipeModel in recipeModels)
            {
                if (!string.IsNullOrEmpty(recipeModel.Year))
                {
                    recipeStrings.Add(recipeModel.Year);
                }
            }

            return recipeStrings;
        }
    }

    public class IssueModel
    {
        public string? Issue { get; set; }

        public static List<string> IssueModelToString()
        {
            List<IssueModel> issueModels = new();

            issueModels = LoadIssues();

            List<string> recipeStrings = new();

            foreach (IssueModel issueModel in issueModels)
            {
                if (!string.IsNullOrEmpty(issueModel.Issue))
                {
                    recipeStrings.Add(issueModel.Issue);
                }
            }

            return recipeStrings;
        }
    }

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
        public string? Step { get; set; }
        public string? Description { get; set; }

        public static List<string> InstructionModelToString()
        {
            List<InstructionModel> instructionsModels = new();

            instructionsModels = LoadInstructions();

            List<string> recipeStrings = new();

            foreach (InstructionModel instructionModel in instructionsModels)
            {
                if (!string.IsNullOrEmpty(instructionModel.Step))
                {
                    recipeStrings.Add(instructionModel.Step);
                }

                if (!string.IsNullOrEmpty(instructionModel.Description))
                {
                    recipeStrings.Add(instructionModel.Description);
                }
            }

            return recipeStrings;
        }
    }
}
