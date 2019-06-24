using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EffectsLibrary : MonoBehaviour
{

    static Dictionary<string, Effects> effectList;
    private void Awake()
    {
        effectList.Add("Dot", new Effects(12, "DotTest"));

    }
}

public class Effects : MonoBehaviour
{
    public string nameEffect;
    public int ChangeHP, ChangeAP, ChangeMobility, ChangeAgility, ChangeShield, counter;
    public Vector2 position, destination;
    public int timer;

    public Effects()
    {

    }

    public Effects(int myChangeHP, int myChangeAP, int myChangeMobility, int myChangeAgility, int myChangeShield, int mycounter)
    {
        ChangeHP = myChangeHP;
        ChangeAP = myChangeAP;
        ChangeMobility = myChangeMobility;
        ChangeAgility = myChangeAgility;
        ChangeShield = myChangeShield;
        counter = mycounter;
    }
    private void Awake()
    {
        timer = counter;
    }
    public Effects(int Pdv)
    {
        ChangeHP = Pdv;
    }
    public Effects(int pdv, string newName)
    {
        ChangeHP = pdv;
        nameEffect = newName;
    }

    public void ExecuteEffect(int indexPlayer)
    {
        if (timer > 0)
            if (ChangeHP != 0)
            {
                CharacterLibrary.characterLibrary[indexPlayer].GetComponent<Character>().currentHP += ChangeHP;
            }
        if (ChangeAP != 0)
        {
            CharacterLibrary.characterLibrary[indexPlayer].GetComponent<Character>().currentAp += ChangeAP;
        }
        if (ChangeMobility != 0)
        {
            CharacterLibrary.characterLibrary[indexPlayer].GetComponent<Character>().currentMobility += ChangeMobility;
        }
        if (ChangeAgility != 0)
        {
            CharacterLibrary.characterLibrary[indexPlayer].GetComponent<Character>().currentAgility += ChangeAgility;
        }
        if (ChangeShield != 0)
        {
            CharacterLibrary.characterLibrary[indexPlayer].GetComponent<Character>().currentShield += ChangeShield;
        }
        timer -= 1;
    }
}








