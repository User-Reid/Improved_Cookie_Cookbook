namespace Improved_Cookie_Cookbook.Recipe
{
  public partial class Recipe
  {
    public abstract class Spice : Ingredient
    {
      public override string PreperationInstructions => $"Take half a teaspoon. {base.PreperationInstructions}";
    }
  }
}