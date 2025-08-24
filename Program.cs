using Improved_Cookie_Cookbook.Recipe;
using Improved_Cookie_Cookbook.Recipe.Ingredients;

var cookiesRecipesApp = new CookiesRecipesApp(new RecipesRepository(), new RecipesConsoleUserInteraction());
cookiesRecipesApp.Run("recipes.txt");

public class CookiesRecipesApp
{
  private readonly IRecipesRepository _recipesRepository;
  private readonly IRecipesUserInteraction _recipesUserInteraction;

  public CookiesRecipesApp(IRecipesRepository recipesRepository, IRecipesUserInteraction recipesUserInteraction)
  {
    _recipesRepository = recipesRepository;
    _recipesUserInteraction = recipesUserInteraction;
  }

  public void Run(string filePath)
  {
    var allRecipes = _recipesRepository.Read(filePath);
    _recipesUserInteraction.PrintExistingRecipes(allRecipes);

    // _recipesUserInteraction.PromptToCreateRecipe();

    // var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

    // if (ingredients.Count > 0)
    // {
    //   var recipes = new Recipe(ingredients);
    //   allRecipes.Add(recipe);
    //   _recipesRepository.Write(filePath, allRecipes);

    //   _recipesUserInteraction.ShowMessage("Recipe added:");
    //   _recipesUserInteraction.ShowMessage(recipe.ToString());
    // }
    // else
    // {
    //   _recipesUserInteraction.ShowMessage("No ingredients have been selected.\n Recipe will not be saved.");
    // }

    _recipesUserInteraction.Exit();
  }
}

public interface IRecipesUserInteraction
{
  void ShowMessage(string message);
  void Exit();
  void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
}

public interface IRecipesRepository
{
  public List<Recipe> Read(string filePath);
}

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
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
}

public class RecipesRepository : IRecipesRepository
{
  public List<Recipe> Read(string filePath)
  {
    return new List<Recipe>
    {
      new Recipe(new List<Ingredient> {
        new WheatFlour(),
        new Butter(),
        new Sugar()
      }), new Recipe(new List<Ingredient> {
        new CocoaPowder(),
        new CoconutFlour(),
        new Cinnamon()
      })
    };
  } 
}