using Improved_Cookie_Cookbook.App;
using Improved_Cookie_Cookbook.DataAccess;
using Improved_Cookie_Cookbook.FileAccess;
using Improved_Cookie_Cookbook.Recipes.Ingredients;

try
{

  const FileFormat Format = FileFormat.Json;

  IStringsRepository stringsRepository = Format == FileFormat.Json ? new StringsJsonRepository() : new StringsJsonRepository();

  const string FileName = "recipes";
  var fileMetaData = new FileMetadata(FileName, Format);

  var ingredientsRegister = new IngredientsRegister();

  var cookiesRecipesApp = new CookiesRecipesApp(new RecipesRepository(stringsRepository, ingredientsRegister), new RecipesConsoleUserInteraction(ingredientsRegister));

  cookiesRecipesApp.Run(fileMetaData.ToPath());
}
catch (Exception ex)
{
  System.Console.WriteLine($"Sorry! The application experienced\r\nan unexpected error and will have to be closed\r\nThe error message:\r\n{ex.Message}");

  System.Console.WriteLine("Press any key to close.🙁");
  Console.ReadKey();
}