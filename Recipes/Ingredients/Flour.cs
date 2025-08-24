namespace Improved_Cookie_Cookbook.Recipe.Ingredients
{

    public abstract class Flour : Ingredient
    {
      public override string PreperationInstructions => $"Sieve. {base.PreperationInstructions}";
    }
  
}