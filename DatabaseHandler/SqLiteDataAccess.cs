using Cookbook_Database.DatabaseHandler;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Cookbook_Database
{
    public class SqLiteDataAccess
    {
        public static List<AllPrintedRecipeModel> LoadAllPrintedRecipes()
        {
            using IDbConnection cnn = new SQLiteConnection(LoadPrintedRecipeConnectionString());
            
            var salads = cnn.Query<AllPrintedRecipeModel>($"select Salad from SaladTable where Salad like '%{Properties.Settings.Default.SearchString}%' order by Salad asc", new DynamicParameters());
            var soups = cnn.Query<AllPrintedRecipeModel>($"select Soup from SoupTable where Soup like '%{Properties.Settings.Default.SearchString}%' order by Soup asc", new DynamicParameters());
            var appetizers = cnn.Query<AllPrintedRecipeModel>($"select Appetizer from AppetizerTable where Appetizer like '%{Properties.Settings.Default.SearchString}%' order by Appetizer asc", new DynamicParameters());
            var meat = cnn.Query<AllPrintedRecipeModel>($"select Meat from MeatTable where Meat like '%{Properties.Settings.Default.SearchString}%' order by Meat asc", new DynamicParameters());
            var poultry = cnn.Query<AllPrintedRecipeModel>($"select Poultry from PoultryTable where Poultry like '%{Properties.Settings.Default.SearchString}%' order by Poultry asc", new DynamicParameters());
            var seafood = cnn.Query<AllPrintedRecipeModel>($"select Seafood from SeafoodTable where Seafood like '%{Properties.Settings.Default.SearchString}%' order by Seafood asc", new DynamicParameters());
            var vegetables = cnn.Query<AllPrintedRecipeModel>($"select Vegetable from VegetableTable where Vegetable like '%{Properties.Settings.Default.SearchString}%' order by Vegetable asc", new DynamicParameters());
            var sides = cnn.Query<AllPrintedRecipeModel>($"select Side from SideTable where Side like '%{Properties.Settings.Default.SearchString}%' order by Side asc", new DynamicParameters());
            var desserts = cnn.Query<AllPrintedRecipeModel>($"select Dessert from DessertTable where Dessert like '%{Properties.Settings.Default.SearchString}%' order by Dessert asc", new DynamicParameters());
            var breakfast = cnn.Query<AllPrintedRecipeModel>($"select Breakfast from BreakfastTable where Breakfast like '%{Properties.Settings.Default.SearchString}%' order by Breakfast asc", new DynamicParameters());
            var misc = cnn.Query<AllPrintedRecipeModel>($"select Misc from MiscTable where Misc like '%{Properties.Settings.Default.SearchString}%' order by Misc asc", new DynamicParameters());

            List<AllPrintedRecipeModel>? recipeModels = salads
                .Union(soups)
                .Union(appetizers)
                .Union(meat)
                .Union(poultry)
                .Union(seafood)
                .Union(vegetables)
                .Union(sides)
                .Union(desserts)
                .Union(breakfast)
                .Union(misc)
                .ToList();

            return recipeModels;
        }

        public static List<YearModel> LoadYears()
        {
            using IDbConnection cnn = new SQLiteConnection(LoadCooksCountryRecipeConnectionString());

            var year = cnn.Query<YearModel>($"select Year from Recipe order by Year asc", new DynamicParameters());

            List<YearModel>? recipeModels = year.ToList();

            return recipeModels;
        }

        public static List<IssueModel> LoadIssues()
        {
            using IDbConnection cnn = new SQLiteConnection(LoadCooksCountryRecipeConnectionString());

            var issue = cnn.Query<IssueModel>($"select Issue from Recipe order by Year asc", new DynamicParameters());

            List<IssueModel>? recipeModels = issue.ToList();

            return recipeModels;
        }

        public static List<IngredientModel> LoadIngredients()
        {
            using IDbConnection cnn = new SQLiteConnection(LoadCooksCountryRecipeConnectionString());

            var ingredient = cnn.Query<IngredientModel>($"select * from Ingredients order by Name asc", new DynamicParameters());

            List<IngredientModel>? ingredientModels = ingredient.ToList();

            return ingredientModels;
        }

        public static List<InstructionModel> LoadInstructions()
        {
            using IDbConnection cnn = new SQLiteConnection(LoadCooksCountryRecipeConnectionString());

            var step = cnn.Query<InstructionModel>($"select Step from Instructions order by Step asc", new DynamicParameters());
            var description = cnn.Query<InstructionModel>($"select Description from Instructions order by Step asc", new DynamicParameters());

            List<InstructionModel>? instructionModels = step
                .Union(description)
                .ToList();

            return instructionModels;
        }

        /// <summary>
        /// Load all salad recipes from database
        /// </summary>
        /// <returns>
        /// WIP - All salad recipes as a list
        /// </returns>
        public static List<SaladModel> LoadSalads()
        {
            using IDbConnection cnn = new SQLiteConnection(LoadPrintedRecipeConnectionString());
            var output = cnn.Query<SaladModel>("select Salad from SaladTable order by Salad asc", new DynamicParameters());

            return output.ToList();
        }

        /// <summary>
        /// Load all soup recipes from database
        /// </summary>
        /// <returns>
        /// WIP - All soup recipes as a list
        /// </returns>
        public static List<SoupModel> LoadSoups()
        {
            using IDbConnection cnn = new SQLiteConnection(LoadPrintedRecipeConnectionString());
            var output = cnn.Query<SoupModel>("select Soup from SoupTable order by Soup asc", new DynamicParameters());

            return output.ToList();
        }

        /// <summary>
        /// Load all appetizer recipes from database
        /// </summary>
        /// <returns>
        /// WIP - All appetizer recipes as a list
        /// </returns>
        public static List<AppetizerModel> LoadAppetizers()
        {
            using IDbConnection cnn = new SQLiteConnection(LoadPrintedRecipeConnectionString());
            var output = cnn.Query<AppetizerModel>("select Appetizer from AppetizerTable order by Appetizer asc", new DynamicParameters());

            return output.ToList();
        }

        /// <summary>
        /// Load all meat recipes from database
        /// </summary>
        /// <returns>
        /// WIP - All meat recipes as a list
        /// </returns>
        public static List<MeatModel> LoadMeat()
        {
            using IDbConnection cnn = new SQLiteConnection(LoadPrintedRecipeConnectionString());
            var output = cnn.Query<MeatModel>("select Meat from MeatTable order by Meat asc", new DynamicParameters());

            return output.ToList();
        }

        /// <summary>
        /// Load all poultry recipes from database
        /// </summary>
        /// <returns>
        /// WIP - All poultry recipes as a list
        /// </returns>
        public static List<PoultryModel> LoadPoultry()
        {
            using IDbConnection cnn = new SQLiteConnection(LoadPrintedRecipeConnectionString());
            var output = cnn.Query<PoultryModel>("select Poultry from PoultryTable order by Poultry asc", new DynamicParameters());

            return output.ToList();
        }

        /// <summary>
        /// Load all seafood recipes from database
        /// </summary>
        /// <returns>
        /// WIP - All seafood recipes as a list
        /// </returns>
        public static List<SeafoodModel> LoadSeafood()
        {
            using IDbConnection cnn = new SQLiteConnection(LoadPrintedRecipeConnectionString());
            var output = cnn.Query<SeafoodModel>("select Seafood from SeafoodTable order by Seafood asc", new DynamicParameters());

            return output.ToList();
        }

        /// <summary>
        /// Load all vegetable recipes from database
        /// </summary>
        /// <returns>
        /// WIP - All vegetable recipes as a list
        /// </returns>
        public static List<VegetableModel> LoadVegetables()
        {
            using IDbConnection cnn = new SQLiteConnection(LoadPrintedRecipeConnectionString());
            var output = cnn.Query<VegetableModel>("select Vegetable from VegetableTable order by Vegetable asc", new DynamicParameters());

            return output.ToList();
        }

        /// <summary>
        /// Load all side recipes from database
        /// </summary>
        /// <returns>
        /// WIP - All side recipes as a list
        /// </returns>
        public static List<SideModel> LoadSides()
        {
            using IDbConnection cnn = new SQLiteConnection(LoadPrintedRecipeConnectionString());
            var output = cnn.Query<SideModel>("select Side from SideTable order by Side asc", new DynamicParameters());

            return output.ToList();
        }

        /// <summary>
        /// Load all dessert recipes from database
        /// </summary>
        /// <returns>
        /// WIP - All dessert recipes as a list
        /// </returns>
        public static List<DessertModel> LoadDesserts()
        {
            using IDbConnection cnn = new SQLiteConnection(LoadPrintedRecipeConnectionString());
            var output = cnn.Query<DessertModel>("select Dessert from DessertTable order by Dessert asc", new DynamicParameters());

            return output.ToList();
        }

        /// <summary>
        /// Load all breakfast recipes from database
        /// </summary>
        /// <returns>
        /// WIP - All breakfast recipes as a list
        /// </returns>
        public static List<BreakfastModel> LoadBreakfast()
        {
            using IDbConnection cnn = new SQLiteConnection(LoadPrintedRecipeConnectionString());
            var output = cnn.Query<BreakfastModel>("select Breakfast from BreakfastTable order by Breakfast asc", new DynamicParameters());

            return output.ToList();
        }

        /// <summary>
        /// Load all misc recipes from database
        /// </summary>
        /// <returns>
        /// WIP - All misc recipes as a list
        /// </returns>
        public static List<MiscModel> LoadMisc()
        {
            using IDbConnection cnn = new SQLiteConnection(LoadPrintedRecipeConnectionString());
            var output = cnn.Query<MiscModel>("select Misc from MiscTable order by Misc asc", new DynamicParameters());

            return output.ToList();
        }

        private static string LoadPrintedRecipeConnectionString()
        {
            return Properties.Settings.Default.PrintedRecipeConnectionString;
        }

        private static string LoadCooksCountryRecipeConnectionString()
        {
            return Properties.Settings.Default.CooksCountryRecipeConnectionString;
        }
    }
}
