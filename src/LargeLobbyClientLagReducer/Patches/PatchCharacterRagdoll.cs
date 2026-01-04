using System;
using System.Collections.Generic;
using System.Text;
using AsmResolver.PE.DotNet.ReadyToRun;
using HarmonyLib;
using Photon.Pun;
using UnityEngine;

namespace LargeLobbyClientLagReducer.Patches
{
    [HarmonyPatch(typeof(CharacterRagdoll))]
    internal class PatchCharacterRagdoll
    {
        [HarmonyPatch(nameof(CharacterRagdoll.FixedUpdate))]
        [HarmonyPrefix]
        [HarmonyPriority(Priority.First+1000)]
        private static bool CancelPhysUpdates(ref Character character)
        {
            return Helper.isNotCulled(character);
        }
    }
}
