using NetArchTest.Rules;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace BrewUp.Warehouses.Architecture.Tests;

[ExcludeFromCodeCoverage]
public class WarehousesArchitectureTests
{
	[Fact]
	public void WarehousesProjects_Should_Having_Namespace_StartingWith_BrewUp_Warehouses()
	{
		var purchaseModulePath = Path.Combine(VisualStudioProvider.TryGetSolutionDirectoryInfo().FullName, "Warehouses");
		var subFolders = Directory.GetDirectories(purchaseModulePath);

		var netVersion = Environment.Version;

		var purchasesAssemblies = (from folder in subFolders
								   let binFolder = Path.Join(folder, "bin", "Debug", $"net{netVersion.Major}.{netVersion.Minor}")
								   let files = Directory.GetFiles(binFolder)
								   let folderArray = folder.Split(Path.DirectorySeparatorChar)
								   select files.FirstOrDefault(f => f.EndsWith($"{folderArray[folderArray!.Length - 1]}.dll"))
			into assemblyFilename
								   where !assemblyFilename!.Contains("Test")
								   select Assembly.LoadFile(assemblyFilename!)).ToList();

		var warehousesTypes = Types.InAssemblies(purchasesAssemblies);
		var warehousesResult = warehousesTypes
			.Should()
			.ResideInNamespaceStartingWith("BrewUp.Warehouses")
			.GetResult();

		Assert.True(warehousesResult.IsSuccessful);
	}

	private static class VisualStudioProvider
	{
		public static DirectoryInfo TryGetSolutionDirectoryInfo(string? currentPath = null)
		{
			var directory = new DirectoryInfo(
				currentPath ?? Directory.GetCurrentDirectory());
			while (directory != null && !directory.GetFiles("*.sln").Any())
			{
				directory = directory.Parent;
			}
			return directory;
		}
	}
}