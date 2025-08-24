namespace Improved_Cookie_Cookbook.Recipe.Ingredients
{

    public class Chocolate : Ingredient
    {
      public override int Id => 4;
      public override string Name => "Chocolate";
      public override string PreperationInstructions => $"Melt in a water bath. {base.PreperationInstructions}";
    }
  
}