namespace Improved_Cookie_Cookbook.Recipe
{
  public partial class Recipe
  {
    public abstract class Ingredient
    {
      public abstract int Id { get; }
      public abstract string Name { get; }
      public virtual string PreperationInstructions => "Add to other ingredients.";
    }
  }
}