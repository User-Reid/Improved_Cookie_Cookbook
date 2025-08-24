namespace Improved_Cookie_Cookbook.Recipe.Ingredients
{
  public abstract class Ingredient
  {
    public abstract int Id { get; }
    public abstract string Name { get; }
    public virtual string PreperationInstructions => "Add to other ingredients.";
    public override string ToString() => $"{Id}: {Name}";
    }
}