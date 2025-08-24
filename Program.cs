using Improved_Cookie_Cookbook.Recipe;
using Improved_Cookie_Cookbook.Recipe.Ingredients;

var ingredientsRegister = new IngredientsRegister();

var cookiesRecipesApp = new CookiesRecipesApp(new RecipesRepository(new StringsTextualRepository(), ingredientsRegister), new RecipesConsoleUserInteraction(ingredientsRegister));
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

    _recipesUserInteraction.PromptToCreateRecipe();

    var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

    if (ingredients.Count() > 0)
    {
      var recipe = new Recipe(ingredients);
      allRecipes.Add(recipe);
      _recipesRepository.Write(filePath, allRecipes);

      _recipesUserInteraction.ShowMessage("Recipe added:");
      _recipesUserInteraction.ShowMessage(recipe.ToString());
    }
    else
    {
      _recipesUserInteraction.ShowMessage("No ingredients have been selected.\n Recipe will not be saved.");
    }

    _recipesUserInteraction.Exit();
  }
}

public interface IRecipesUserInteraction
{
  void ShowMessage(string message);
  void Exit();
  void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
  void PromptToCreateRecipe();
  IEnumerable<Ingredient> ReadIngredientsFromUser();
}

public interface IRecipesRepository
{
  List<Recipe> Read(string filePath);
  void Write(string filePath, List<Recipe> allRecipes);
}

public interface IIngredientsRegister
{
  IEnumerable<Ingredient> All { get; }
  Ingredient GetById(int id);
}

public class IngredientsRegister : IIngredientsRegister
{
  public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
  {
    new WheatFlour(),
    new CoconutFlour(),
    new Butter(),
    new Chocolate(),
    new Sugar(),
    new Cardamom(),
    new Cinnamon(),
    new CocoaPowder()
  };

  public Ingredient GetById(int id)
  {
    foreach (Ingredient ingredient in All)
    {
      if (ingredient.Id == id)
      {
        return ingredient;
      }
    }
    return null;
  }
}

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

public class RecipesRepository : IRecipesRepository
{
  private readonly IStringsRepository _stringsRepository;
  private readonly IIngredientsRegister _ingredientsRegister;
  private const string Seperator = ",";

  public RecipesRepository(IStringsRepository stringsRepository, IIngredientsRegister ingredientsRegister)
  {
    _stringsRepository = stringsRepository;
    _ingredientsRegister = ingredientsRegister;
  }
  public List<Recipe> Read(string filePath)
  {
    List<string> recipesFromFile = _stringsRepository.Read(filePath);
    var recipes = new List<Recipe>();

    foreach (var recipeFromFile in recipesFromFile)
    {
      var recipe = RecipeFromString(recipeFromFile);
      recipes.Add(recipe);
    }
    return recipes;
  }

  private Recipe RecipeFromString(string recipeFromFile)
  {
    var textualIds = recipeFromFile.Split(Seperator);
    var ingredients = new List<Ingredient>();

    foreach (var textualId in textualIds)
    {
      var id = int.Parse(textualId);
      var ingredient = _ingredientsRegister.GetById(id);
      ingredients.Add(ingredient);
    }

    return new Recipe(ingredients);
  }

  public void Write(string filePath, List<Recipe> allRecipes)
  {
    var recipesAsStrings = new List<string>();
    foreach (var recipe in allRecipes)
    {
      var allIds = new List<int>();
      foreach (var ingredient in recipe.Ingredients)
      {
        allIds.Add(ingredient.Id);
      }
      recipesAsStrings.Add(string.Join(Seperator, allIds));
    }
    _stringsRepository.Write(filePath, recipesAsStrings);
  }
}

public interface IStringsRepository
{
  List<string> Read(string filePath);
  void Write(string filePath, List<string> strings);
}

class StringsTextualRepository : IStringsRepository
{
  private static readonly string Seperator = Environment.NewLine;

  public List<string> Read(string filePath)
  {
    if (File.Exists(filePath))
    {
      var fileContents = File.ReadAllText(filePath);
      return fileContents.Split(Seperator).ToList();
    }
    return new List<string>();
  }

  public void Write(string filePath, List<string> strings)
  {
    File.WriteAllText(filePath, string.Join(Seperator, strings));
  }
}