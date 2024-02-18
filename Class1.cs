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
