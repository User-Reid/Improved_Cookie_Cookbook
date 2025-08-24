namespace Improved_Cookie_Cookbook.Recipe
{
  public partial class Recipe
  {
    public abstract class Flour : Ingredient
    {
      public override string PreperationInstructions => $"Sieve. {base.PreperationInstructions}";
    }
  }
}