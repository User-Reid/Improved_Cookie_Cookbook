namespace Improved_Cookie_Cookbook.Recipe
{
  public partial class Recipe
  {
    public class Sugar : Ingredient
    {
      public override int Id => 5;
      public override string Name => "Sugar";
      public override string PreperationInstructions => base.PreperationInstructions;
    }
  }
}