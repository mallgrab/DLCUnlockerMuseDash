using System.Reflection;
using HarmonyLib;
using MelonLoader;
using UnityEngine;
using Il2CppSystem;
using Steamworks;
using Type = System.Type;

public class MyMod : MelonMod
{
    [HarmonyPatch(typeof(Steamworks.SteamApps),  nameof(Steamworks.SteamApps.BIsDlcInstalled))]
    public class Patch
    {
        static bool Prefix(ref bool __result, Steamworks.AppId_t appID)
        {
            MelonLogger.Msg("Dlc installed called: " + appID.ToString());

            __result = true;
            return false;
        }
    }
    
    public override void OnApplicationStart()
    {
        var harmony = this.HarmonyInstance;
    }
}