namespace Improved_Cookie_Cookbook.Recipes.Ingredients
{

    public abstract class Flour : Ingredient
    {
      public override string PreperationInstructions => $"Sieve. {base.PreperationInstructions}";
    }
  
}