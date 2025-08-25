namespace Improved_Cookie_Cookbook.Recipes.Ingredients
{
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
}