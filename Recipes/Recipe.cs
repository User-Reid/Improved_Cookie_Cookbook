namespace Improved_Cookie_Cookbook.Recipe
{
  public partial class Recipe
  {
    public IEnumerable<Ingredient> Ingredients { get; }

    public Recipe(IEnumerable<Ingredient> ingredients)
    {
      Ingredients = ingredients;
    }
  }
}