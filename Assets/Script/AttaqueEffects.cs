using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaqueEffects : MonoBehaviour
{
    private static int index = FindObjectOfType<Character>().indexPlayer;
    private static int indexTarget;
    // Start is called before the first frame update
    void Awake()
    {
        //AttackModel attack1 = new AttackModel("le sboui", 666, Vector2.zero, 0f, 666);
        //attack1.AddEffect(new Effects());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static float Dot(float currentHP,float ChangeHP) // dégats
    {       
        return currentHP+=ChangeHP;
    }


    public static void ChangePosition(int index, Vector2 destination) // changement de position
    {
       
    }

    public static void Snare(int index, int Mobility) // immobilise
    {
        
    }

   //public static void AP(int ChangeAP) // enlève des PA
   // {
   //     FindObjectOfType<Character>().currentAp += ChangeAP;
   // }
     
   // public static void Agility(int ChangeAgility, int CurrentAgility) // enlève de l'agilité
   // {
   //     FindObjectOfType<Character>().currentAgility += ChangeAgility;        
   // }

   // public static void Mobility(int ChangeMobility, int CurrentMobility) // change la mobilité
   // {
   //     FindObjectOfType<Character>().currentMobility += ChangeMobility;
   // }

   // public static void Shield(int ChangeShield, int CurrentShield) // change le shield
   // {       
   //     FindObjectOfType<Character>().currentShield += ChangeShield;
   // }


   
    
}



