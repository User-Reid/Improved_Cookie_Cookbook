namespace Improved_Cookie_Cookbook.Recipe
{
  public partial class Recipe
  {
    public class Butter : Ingredient
    {
      public override int Id => 3;
      public override string Name => "Butter";
      public override string PreperationInstructions => $"Melt on low heat. {base.PreperationInstructions}";
    }
  }
}