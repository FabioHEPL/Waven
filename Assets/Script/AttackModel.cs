using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackModel : MonoBehaviour
{
    public string name, description;
    public int damage;
    public Vector2 range;
    public float radius;
    public int APCost;
    public int indexTarget;
    List<Effects> listEffects; 	

    public AttackModel()
    {

    }

    public AttackModel(string setName,
     int setDamage, Vector2 setRange, float setRadius, int setAPCost)
    {
        name = setName;
        damage = setDamage;
        range = setRange;
        radius = setRadius;
        APCost = setAPCost;
    }
    public void ChangeDescription(string AttackDescrip, string keyName)
    {
        if (name == keyName)
        {
            description = AttackDescrip;
        }
    }

    public abstract void AssignToCharacter(Character character);    

    public virtual void Execute()
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

    public void AddEffect(Effects e)
    {
        listEffects.Add(e);
    }

    protected Character[] GetCharacters()
    {
        int characterCount = CharacterLibrary.characterLibrary.Count;

        Character[] characters = new Character[characterCount];
        for (int i = 0; i < characterCount; i++)
        {
            characters[i] = CharacterLibrary.characterLibrary[i].GetComponent<Character>();
        }

        return characters;
    }
 }

class test 
{
}

