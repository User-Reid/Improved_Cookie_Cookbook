namespace Improved_Cookie_Cookbook.DataAccess
{
  public abstract class StringsRepository : IStringsRepository
{
  protected abstract List<string> TextToStrings(string fileContents);
  protected abstract string StringsToText(List<string> strings);
    public List<string> Read(string filePath) => File.Exists(filePath) ? TextToStrings(File.ReadAllText(filePath)) : new List<string>();

  public void Write(string filePath, List<string> strings) => File.WriteAllText(filePath, StringsToText(strings));
}
}
