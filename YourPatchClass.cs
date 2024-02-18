using HarmonyLib;

namespace UniformADS
{
    [HarmonyPatch(typeof(YourClass))] // Replace YourClass with the actual class you are targeting
    [HarmonyPatch("YourMethod")] // Replace YourMethod with the actual method you are targeting
    class YourPatchClass
    {
        [HarmonyPostfix]
        static void Postfix()
        {
            // Your patch code here
            UnityEngine.Debug.Log("Patch applied!"); // Example log message
        }
    }
}
