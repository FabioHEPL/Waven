using System;
using System.Collections.Generic;
using UnityEngine;

//public abstract class Character : MonoBehaviour
//{
//    public abstract Dictionary<int, AttackModel> attackLibrary { get; }
//}

//public abstract class AttackModel
//{
//    public enum AttackType
//    {
//        Position,
//        Self,
//        Ally,
//        Enemy,
//        Zone
//    }

//    public abstract Dictionary<AttackType, bool> Matrix { get; } 
//    public abstract Vector2 range { get; }
//    public abstract float radius { get; }
//}

//public static class CharacterLibrary
//{
//    static CharacterLibrary()
//    {
//        // 
//        characterLibrary = new Dictionary<int, GameObject>();
        
//    }  

//    public static Dictionary<int, GameObject> characterLibrary;
//}

public abstract class CombatManger : MonoBehaviour
{
    public abstract event EventHandler<SwitchTurnEventArgs> onSwitchTurn;

    public abstract class SwitchTurnEventArgs
    {
        public int IdentityPlayer { get; protected set; }
    }
}