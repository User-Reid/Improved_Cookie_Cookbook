using Improved_Cookie_Cookbook.App;
using Improved_Cookie_Cookbook.DataAccess;
using Improved_Cookie_Cookbook.FileAccess;
using Improved_Cookie_Cookbook.Recipes.Ingredients;

const FileFormat Format = FileFormat.Json;

IStringsRepository stringsRepository = Format == FileFormat.Json ? new StringsJsonRepository() : new StringsJsonRepository();

const string FileName = "recipes";
var fileMetaData = new FileMetadata(FileName, Format);

var ingredientsRegister = new IngredientsRegister();

var cookiesRecipesApp = new CookiesRecipesApp(new RecipesRepository(stringsRepository, ingredientsRegister), new RecipesConsoleUserInteraction(ingredientsRegister));

cookiesRecipesApp.Run(fileMetaData.ToPath());