using Photon.Pun;
using UnityEngine;

namespace LargeLobbyClientLagReducer;

public class Helper
{
    public static bool isNotCulled(Character character)
    {
        return isNotCulled(character.view, character.Center,character.data);
    }

    public static bool isNotCulled(PhotonView view, Vector3 center, CharacterData data)
    {
        if (view.IsMine)
        {
            return true;
        }
        return data.isCarried
               || Vector3.Distance(Character.localCharacter.Center, center) < 10
               || !(Vector3.Angle(data.lookDirection, center - Character.localCharacter.Center) > 60f);
    }
}