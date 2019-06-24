using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class FakeZoneAttack : AttackModel
{
    private void Awake()
    {
        name = "Fake Zone Attack";
        range = new Vector2(5, 5);
        radius = 4f;
    }

    public override void AttackExecute()
    {
        var lifePoint = CharacterLibrary.characterLibrary[indexTarget].GetComponent<Character>().currentHP;
        var appliedDamage = new float();
        var shield = CharacterLibrary.characterLibrary[indexTarget].GetComponent<Character>().currentShield;
        if (shield > 0)
        {
            appliedDamage = shield - damage;
            if (appliedDamage > 0)
            {
                CharacterLibrary.characterLibrary[indexTarget].GetComponent<Character>().currentShield = appliedDamage;
            }
            else
            {
                CharacterLibrary.characterLibrary[indexTarget].GetComponent<Character>().currentShield = 0;
                CharacterLibrary.characterLibrary[indexTarget].GetComponent<Character>().currentHP += appliedDamage;
            }

        }
        else CharacterLibrary.characterLibrary[indexTarget].GetComponent<Character>().currentHP -= damage;

        CharacterLibrary.characterLibrary[indexTarget].GetComponent<Character>().effectsOnPlayer = listEffects;
    }
}