using Improved_Cookie_Cookbook.Recipes.Ingredients;
using Improved_Cookie_Cookbook.Recipes;

namespace Improved_Cookie_Cookbook.App
{
  public interface IRecipesUserInteraction
{
  void ShowMessage(string message);
  void Exit();
  void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
  void PromptToCreateRecipe();
  IEnumerable<Ingredient> ReadIngredientsFromUser();
}
}