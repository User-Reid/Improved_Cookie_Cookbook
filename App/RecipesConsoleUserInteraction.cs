using Improved_Cookie_Cookbook.Recipes.Ingredients;
using Improved_Cookie_Cookbook.Recipes;

namespace Improved_Cookie_Cookbook.App
{
  public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
  private readonly IIngredientsRegister _ingredientsRegister;
  public RecipesConsoleUserInteraction(IIngredientsRegister ingredientsRegister)
  {
    _ingredientsRegister = ingredientsRegister;
  }
  public void ShowMessage(string message)
  {
    System.Console.WriteLine(message);
  }
  public void Exit()
  {
    Console.WriteLine("Press any key to close.");
    Console.ReadKey();
  }
  public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
  {
    if (allRecipes.Count() > 0)
    {
      System.Console.WriteLine($"Existing recipes are: \n");

      var counter = 1;
      foreach (var recipe in allRecipes)
      {
        System.Console.WriteLine($"*****{counter}*****");
        System.Console.WriteLine(recipe);
        System.Console.WriteLine();
        ++counter;
      }
    }
    else
    {
      System.Console.WriteLine("There are no exisiting recipes to print.");
    }
  }
  public void PromptToCreateRecipe()
  {
    System.Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
    foreach (var ingredient in _ingredientsRegister.All)
    {
      System.Console.WriteLine(ingredient);
    }
  }

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