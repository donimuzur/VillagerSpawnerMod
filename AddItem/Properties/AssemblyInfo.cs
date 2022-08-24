using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(AddItemMod.BuildInfo.Description)]
[assembly: AssemblyDescription(AddItemMod.BuildInfo.Description)]
[assembly: AssemblyCompany(AddItemMod.BuildInfo.Company)]
[assembly: AssemblyProduct(AddItemMod.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + AddItemMod.BuildInfo.Author)]
[assembly: AssemblyTrademark(AddItemMod.BuildInfo.Company)]
[assembly: AssemblyVersion(AddItemMod.BuildInfo.Version)]
[assembly: AssemblyFileVersion(AddItemMod.BuildInfo.Version)]
[assembly: MelonInfo(typeof(AddItemMod.AddItemMod), AddItemMod.BuildInfo.Name, AddItemMod.BuildInfo.Version, AddItemMod.BuildInfo.Author, AddItemMod.BuildInfo.DownloadLink)]
[assembly: MelonColor()]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]