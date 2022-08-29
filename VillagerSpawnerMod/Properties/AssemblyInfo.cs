using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(VillagerSpawnerMod.BuildInfo.Description)]
[assembly: AssemblyDescription(VillagerSpawnerMod.BuildInfo.Description)]
[assembly: AssemblyCompany(VillagerSpawnerMod.BuildInfo.Company)]
[assembly: AssemblyProduct(VillagerSpawnerMod.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + VillagerSpawnerMod.BuildInfo.Author)]
[assembly: AssemblyTrademark(VillagerSpawnerMod.BuildInfo.Company)]
[assembly: AssemblyVersion(VillagerSpawnerMod.BuildInfo.Version)]
[assembly: AssemblyFileVersion(VillagerSpawnerMod.BuildInfo.Version)]
[assembly: MelonInfo(typeof(VillagerSpawnerMod.VillagerSpawnerMod), VillagerSpawnerMod.BuildInfo.Name, VillagerSpawnerMod.BuildInfo.Version, VillagerSpawnerMod.BuildInfo.Author, VillagerSpawnerMod.BuildInfo.DownloadLink)]
[assembly: MelonColor()]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]