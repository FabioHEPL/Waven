using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Partie chargée des abilités
public partial class InputManager : MonoBehaviour
{
    public event EventHandler<ActiveAbilitySelectedArgs> ActiveAbilitySelected;
    public class ActiveAbilitySelectedArgs
    {
        private int _abilityNumber;

        public int AbilityNumber
        {
            get { return _abilityNumber; }
            set { _abilityNumber = value; }
        }

        public ActiveAbilitySelectedArgs(int abilityNumber)
        {
            this._abilityNumber = abilityNumber;
        }
    }

    private void OnActiveAbilitySelected(int abilityNumber)
    {
        ActiveAbilitySelected?.Invoke(this, new ActiveAbilitySelectedArgs(abilityNumber));
    }

}