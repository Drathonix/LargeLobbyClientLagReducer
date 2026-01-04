using System;
using System.Collections.Generic;
using System.Text;
using AsmResolver.PE.DotNet.ReadyToRun;
using HarmonyLib;
using Photon.Pun;
using UnityEngine;

namespace LargeLobbyClientLagReducer.Patches
{
    [HarmonyPatch(typeof(Character))]
    internal class PatchCharacter
    {
        [HarmonyPatch(nameof(Character.FixedUpdate))]
        [HarmonyPrefix]
        public static bool CancelPhysUpdates(ref PhotonView ___view, ref Vector3 ___Center, ref CharacterData ___data)
        {
            return Helper.isNotCulled(___view, ___Center, ___data);
        }
    }
}
