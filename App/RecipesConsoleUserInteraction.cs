using Improved_Cookie_Cookbook.Recipes.Ingredients;
using Improved_Cookie_Cookbook.Recipes;

namespace Improved_Cookie_Cookbook.App
{
  public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
  private readonly IIngredientsRegister _ingredientsRegister;
  public RecipesConsoleUserInteraction(IIngredientsRegister ingredientsRegister) => _ingredientsRegister = ingredientsRegister;

  public void ShowMessage(string message) => System.Console.WriteLine(message);
  
  public void Exit() => System.Console.WriteLine($"Press any key to close\n{Console.ReadKey()}");

    // public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes) => System.Console.WriteLine(allRecipes.Any() ? $"Existing recipes are: \n{string.Join(Environment.NewLine, allRecipes.Select((recipe, index) => $"*****{index + 1}*****\n{recipe}\n"))}" : $"There are no existing recipes to print.");

    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
      if (allRecipes.Any())
      {
        System.Console.WriteLine($"Existing recipes are:\n");

        var allRecipesAsStrings = allRecipes
        .Select((recipe, index) => @$"*****{index + 1}*****
        {recipe}");

        System.Console.WriteLine(string.Join(Environment.NewLine, allRecipesAsStrings));
        System.Console.WriteLine();
      }
    }

  public void PromptToCreateRecipe() => System.Console.WriteLine($"Create a new cookie recipes! Available ingredients are:{string.Join(Environment.NewLine, _ingredientsRegister.All)}");

  public IEnumerable<Ingredient> ReadIngredientsFromUser()
  {
    bool shallStop = false;
    var ingredients = new List<Ingredient>();

    while (!shallStop)
    {
      System.Console.WriteLine("Add an ingredient by its ID,\r\nor type anything else if finished.");

      var userInput = Console.ReadLine();

      if (int.TryParse(userInput, out int id))
      {
        var selectedIngredient = _ingredientsRegister.GetById(id);
        if (selectedIngredient is not null)
        {
          ingredients.Add(selectedIngredient);
        }
      }
      else
      {
        shallStop = true;
      }
    }
    return ingredients;
  }
}
}