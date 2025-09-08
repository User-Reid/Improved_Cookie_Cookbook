using Improved_Cookie_Cookbook.Recipes.Ingredients;

namespace Improved_Cookie_Cookbook.Recipes
{
  public class Recipe
  {
    public IEnumerable<Ingredient> Ingredients { get; }

    public Recipe(IEnumerable<Ingredient> ingredients) => Ingredients = ingredients;

    // public override string ToString() => string.Join(Environment.NewLine, Ingredients.Select(ingredient => $"{ingredient.Name}. {ingredient.PreperationInstructions}").ToList());

    public override string ToString()
    {
      var steps = Ingredients.Select(ingredient => $"{ingredient.Name}. {ingredient.PreperationInstructions}");

      return string.Join(Environment.NewLine, steps);
    }
  }
}