namespace Improved_Cookie_Cookbook.Recipe
{
  public partial class Recipe
  {
    public class CocoaPowder : Ingredient
    {
      public override int Id => 8;
      public override string Name => "Cocoa Powder";
      public override string PreperationInstructions => base.PreperationInstructions;
    }
  }
}