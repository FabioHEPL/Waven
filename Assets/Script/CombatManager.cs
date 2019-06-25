using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CombatManager : MonoBehaviour
{
    int randomBoostValue = 10;
    int playerId;
	List<Character> IdentityPlayer;
    private void Awake()
   
    {
        //FindObjectOfType<TeamManager>().onTeamInitialised += OnTeamInisiativeEventHandler;
    }

    public class UIUpdateEventArgs : EventArgs
    {
        public int PlayerID;
    }
    public event EventHandler<UIUpdateEventArgs> onUIUpdatePlayer;
    private void OnUIUpdatePlayerInfoEventHandler(UIUpdateEventArgs args)
    {
        if(onUIUpdatePlayer != null)
        {
            onUIUpdatePlayer(this, args);
        }
    }
    public class PlayerDeathEventArgs : EventArgs
    {
        public int IdentityPlayer;
    }
    public event EventHandler<PlayerDeathEventArgs> onPlayerDeath;

    private void OnPlayerDeath(PlayerDeathEventArgs e)
    {
        if (onPlayerDeath != null)
			onPlayerDeath(this, e);
    }

    public class SwitchTurnEventArgs : EventArgs
    {
        public int IdentityPlayer;
    }

    public event EventHandler<SwitchTurnEventArgs> onSwitchTurn;

	protected void OnSwitchTurn(SwitchTurnEventArgs e)
	{
		if (onSwitchTurn != null)
			onSwitchTurn(this, e);
	}

	private void OnDeathEventHandler(object sender, Character.OnDeathEventArgs e)
	{
		OnPlayerDeath(new PlayerDeathEventArgs() { IdentityPlayer = e.index });
	}


 //   private void OnTeamInisiativeEventHandler(object sender, TeamManager.OnTeamEventArg e)
 //   {
 //   //   List<Character> Listejoueur = new List<Character>();
	////	foreach(GameObject g in e.IntanceTeam1)
	////	{
	////		Listejoueur.Add(g.GetComponent<Character>());
	////	}
	////	foreach (GameObject g in e.IntanceTeam2)
	////	{
	////		Listejoueur.Add(g.GetComponent<Character>());
	////	}
	////
 //   //   Listejoueur.Sort((characterA, characterB) =>
 //   //   {
 //   //       return characterA.initBonus - characterB.initBonus;
	////
 //   //   });
	////	foreach(Character c in Listejoueur)
	////	{
	////		c.onDeath += OnDeathEventHandler;
	////	}
 //   //   IdentityPlayer = Listejoueur;
	////	StartTurn();
 //   }
    private void OnSwitchTurnPlayerEventHandler (object sender, SwitchTurnEventArgs e)
    {
        
        do
        {
        playerId++;
        if (playerId == IdentityPlayer.Count)
            playerId = 0;
        }while(IdentityPlayer[playerId].isDead);
		StartTurn();
        OnUIUpdatePlayerInfoEventHandler(new UIUpdateEventArgs { PlayerID = IdentityPlayer[playerId].indexPlayer });
    }
	private void StartTurn()
	{

		IdentityPlayer[playerId].StartTurn();
		OnSwitchTurn(new SwitchTurnEventArgs() { IdentityPlayer = playerId });
	}
}
