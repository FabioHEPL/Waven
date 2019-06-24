using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Ability : MonoBehaviour
{
    public abstract float Range { get; set; }    

    public virtual void AssignToCharacter(Character character)
    {
        this.transform.position = character.transform.position;
    }
}
