using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum TeamEnum
{
    Team1,
    Team2
}

public abstract class Character : MonoBehaviour
{

    #region Settings
    public int indexPlayer;
    public float currentHP;
    public string name, description;
    //public Enum Team;
    public TeamEnum Team;
    public Vector2 positionReminder;
    public string type;
    public int initBonus;
    public int currentAp;
    public bool isDead;
    // 
    public float currentShield;
    public int currentAgility;
    public int currentTackle;
    public int currentMobility;
    // the abilities
    public Dictionary<int,AttackModel> attackLibrary;
    // the effects applied on the player
    public List<Effects> effectsOnPlayer;
    protected virtual void Awake()
    {
        
        //distribution du bonus d'initiative auto
        switch (type)
        {
            case "Rogue":
                initBonus = 15;
                break;
            case "Mage":
                initBonus = 10;
                break;
            case "Warrior":
                initBonus = 5;
                break;
            default:
                initBonus = 0;
                break;
        }
      
           if( currentHP <=0)
            currentHP = 100f;

         //currentAp = DataContainer.singleton.globalAP.apInfo.maxAp;


      
        
            //AttackModel coupDeGriffe = new AttackModel("coupDeGriffe", 1, Vector2.zero, 3f, 5);
            //coupDeGriffe.AddEffect(new Effects(0, 3, 0, 0, 30, 1));
            //GetAttacks()
        

    }
    private void Update()
    {
        OnHpCheck(new OnHpCheckEventArgs { HP = currentHP });
        OnApCheck(new OnApCheckEventArgs { AP = currentAp });
        if (currentHP <= 0)
        {
            OnDeath(new OnDeathEventArgs { Death = isDead });
            OnDeath(new OnDeathEventArgs { index =  indexPlayer});
        }
    }
    
    public GameObject prefabCharacter;
    #endregion
    #region Events
    public class OnHpCheckEventArgs : EventArgs
    {
        public float HP;
    }
    public event EventHandler<OnHpCheckEventArgs> onHpCheck;
    private void OnHpCheck(OnHpCheckEventArgs args)
    {
        if (onHpCheck != null)
            onHpCheck(this, args);
    }
    public void HpCheck()
    {
        OnHpCheck(new OnHpCheckEventArgs(){ HP= currentHP});
    }

    public class OnApCheckEventArgs : EventArgs
    {
        public int AP;
    }
    public event EventHandler<OnApCheckEventArgs> onApCheck;
    private void OnApCheck(OnApCheckEventArgs args)
    {
        if (onApCheck != null)
            onApCheck(this, args);
    }
    public void ApCheck()
    {
        OnApCheck(new OnApCheckEventArgs() { AP = currentAp });
    }

    public class OnDeathEventArgs : EventArgs
    {
        public int index;
        public bool Death;
       
    }
    public event EventHandler<OnDeathEventArgs> onDeath;

    private void OnDeath(OnDeathEventArgs args)
    {
        if (onDeath != null)
            onDeath(this, args);
    }
    public void Death()
    {
        OnDeath(new OnDeathEventArgs() { index = indexPlayer, Death = isDead });
    }

    //not used yet
    public class OnAttackingEventArgs : EventArgs
    {
        public bool isAttacking;
    }
    public event EventHandler<OnAttackingEventArgs> onAttacking;

    private void OnAttacking(OnAttackingEventArgs args)
    {
        if (onAttacking != null)
            onAttacking(this, args);
    }


    //not used yet
    public class OnJumpEventArgs : EventArgs
    {
        public bool isJumping;
    }
    public event EventHandler<OnJumpEventArgs> onJump;

    private void OnJump(OnJumpEventArgs args)
    {
        if (onJump != null)
            onJump(this, args);
    }

    public class OnEffectsCheckEventArgs : EventArgs
    {
        public List <Effects> Buffs;
    }
    public event EventHandler<OnEffectsCheckEventArgs> onEffectsCheck;

    private void OnEffectsCheck(OnEffectsCheckEventArgs args)
    {
        if (onEffectsCheck != null)
            onEffectsCheck(this, args);
    }
    public void EffectCheck()
    {
        OnEffectsCheck(new OnEffectsCheckEventArgs() { Buffs = effectsOnPlayer });
    }

    public class OnFlyEventArgs : EventArgs
    {
        public bool isFlying;
    }
    public event EventHandler<OnFlyEventArgs> onFly;
    private void OnFly(OnFlyEventArgs args)
    {
        if (onFly != null)
            onFly(this, args);
    }
    public void StartTurn()
    {

    }
    public void EndTurn()
    {

    }

    #endregion
    #region Subscribe

    #endregion
    #region Methods
    #region Attacks Generation

    public virtual void GetAttacks(List<AttackModel> attacksFromData)
    {
        if (attacksFromData.Count>=1)
        for (int i = 0; i < attacksFromData.Count-1; i++)
        {
                attackLibrary.Add(i, attacksFromData[i]);
        }
    }



    #endregion

    #endregion
}
