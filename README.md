#Since this addon is still in the works as i try to search for more efficient methods of ravenscript API, please build it yourself and give feedbacks

Addon structure:
UniformADS
|Dependencies(all bepInEX core files must be referenced)
|Class1.cs
|YourPatchClass.cs

#1 UniformADS.csproj 
 ```
 <Project Sdk="Microsoft.NET.Sdk">

	<PropertyGroup>
		<TargetFramework>net8.0</TargetFramework>
		<ImplicitUsings>enable</ImplicitUsings>
		<Nullable>enable</Nullable>
	</PropertyGroup>

	<ItemGroup>
		<PackageReference Include="Harmony" Version="2.0.1" />
		<!-- Use a version that is available on NuGet and compatible with net8.0 -->
	</ItemGroup>

	<ItemGroup>
		<Reference Include="0Harmony20">
		  <HintPath>D:\SteamLibrary\steamapps\common\Ravenfield\BepInEx\core\0Harmony20.dll</HintPath>
		</Reference>
		<Reference Include="BepInEx">
			<HintPath>D:\SteamLibrary\steamapps\common\Ravenfield\BepInEx\core\BepInEx.dll</HintPath>
		</Reference>
		<Reference Include="BepInEx.Harmony">
			<HintPath>D:\SteamLibrary\steamapps\common\Ravenfield\BepInEx\core\BepInEx.Harmony.dll</HintPath>
		</Reference>
		<Reference Include="BepInEx.Preloader">
			<HintPath>D:\SteamLibrary\steamapps\common\Ravenfield\BepInEx\core\BepInEx.Preloader.dll</HintPath>
		</Reference>
		<Reference Include="HarmonyXInterop">
			<HintPath>D:\SteamLibrary\steamapps\common\Ravenfield\BepInEx\core\HarmonyXInterop.dll</HintPath>
		</Reference>
		<Reference Include="Mono.Cecil">
			<HintPath>D:\SteamLibrary\steamapps\common\Ravenfield\BepInEx\core\Mono.Cecil.dll</HintPath>
		</Reference>
		<Reference Include="Mono.Cecil.Mdb">
			<HintPath>D:\SteamLibrary\steamapps\common\Ravenfield\BepInEx\core\Mono.Cecil.Mdb.dll</HintPath>
		</Reference>
		<Reference Include="Mono.Cecil.Pdb">
			<HintPath>D:\SteamLibrary\steamapps\common\Ravenfield\BepInEx\core\Mono.Cecil.Pdb.dll</HintPath>
		</Reference>
		<Reference Include="Mono.Cecil.Rocks">
			<HintPath>D:\SteamLibrary\steamapps\common\Ravenfield\BepInEx\core\Mono.Cecil.Rocks.dll</HintPath>
		</Reference>
		<Reference Include="MonoMod.RuntimeDetour">
			<HintPath>D:\SteamLibrary\steamapps\common\Ravenfield\BepInEx\core\MonoMod.RuntimeDetour.dll</HintPath>
		</Reference>
		<Reference Include="MonoMod.Utils">
			<HintPath>D:\SteamLibrary\steamapps\common\Ravenfield\BepInEx\core\MonoMod.Utils.dll</HintPath>
		</Reference>
		<Reference Include="UnityEngine">
			<HintPath>D:\SteamLibrary\steamapps\common\Ravenfield\ravenfield_Data\Managed\UnityEngine.dll</HintPath>
		</Reference>
		<Reference Include="UnityEngine.CoreModule">
			<HintPath>D:\SteamLibrary\steamapps\common\Ravenfield\ravenfield_Data\Managed\UnityEngine.CoreModule.dll</HintPath>
		</Reference>
	</ItemGroup>

</Project>
 ```
#HARMONY PREFIX:
```
// YourPatchClass.cs
using BepInEx;
using HarmonyLib;

namespace UniformADS
{
    [HarmonyPatch(typeof(SomeOtherClass))] // Replace SomeOtherClass with the actual class handling sensitivity or controls
    [HarmonyPatch("SomeMethod")] // Replace SomeMethod with the method responsible for sensitivity
    class YourPatchClass
    {
        [HarmonyPrefix]
        static void Prefix(ref float ___originalSensitivity) // Capture the original sensitivity
        {
            // Set mouseSensitivity as the primary sensitivity modifier
            ___originalSensitivity = mouseSensitivity.value; // Replace mouseSensitivity with the actual class/variable
        }
    }
}

// Class1.cs
using BepInEx;
using HarmonyLib;

[BepInPlugin("com.example.UniformADS", "Uniform ADS Plugin", "1.0.0")]
public class UniformADSPlugin : BaseUnityPlugin
{
    void Awake()
    {
        // Use the specific version of Harmony that works with your project
        HarmonyLib.Harmony harmony = new HarmonyLib.Harmony("com.example.UniformADS");
        harmony.PatchAll();
    }

    [HarmonyLib.HarmonyPatch(typeof(mouseSensitivity), "YourMethod")] // Replace YourMethod with the actual method for normal sensitivity
    [HarmonyLib.HarmonyPostfix]
    private static void YourMethodPostfix()
    {
        // Your patch logic
    }
}
```

#Mainsolution(Class1.cs)
```
using BepInEx;
using HarmonyLib;

[BepInPlugin("com.example.UniformADS", "Uniform ADS Plugin", "1.0.0")]
public class UniformADSPlugin : BaseUnityPlugin
{
    void Awake()
    {
        // Use the specific version of Harmony that works with your project
        HarmonyLib.Harmony harmony = new HarmonyLib.Harmony("com.example.UniformADS");
        harmony.PatchAll();
    }

    [HarmonyLib.HarmonyPatch(typeof(YourClass), "YourMethod")]
    [HarmonyLib.HarmonyPostfix]
    private static void YourMethodPostfix()
    {
        // Your patch logic
    }
}
```

Please note that everything should be compiled to bepinex plugin.dll using nuget 
Requires: .NET(8.0)
HarmonyLib(2.0.1.0)
Any code compiler

Thanks for using and please give feedbacks. Expect updates as im trying to find a less buggy and more efficient way to manipulate ADSsens


