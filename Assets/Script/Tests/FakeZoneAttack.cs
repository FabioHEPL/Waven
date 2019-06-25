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
        range = new Vector2(2.5f, 2.5f);
        radius = 1f;
        _uiManager = FindObjectOfType<UIManager>();
    }

    public override void AssignToCharacter(Character character)
    {
        _character = character;
        //base.AssignToCharacter(character);
    }

    public override void Execute()
    {
        _attackRange = _uiManager.CreateCircle(range.magnitude, _character.transform.position);
        _attackRange.Color = Color.red;

        UICircle attackRadiusCircle = _uiManager.CreateCircle(radius, _character.transform.position);
        attackRadiusCircle.Color = Color.green;
        attackRadiusCircle.SetBounds(_attackRange);

        _attackRadius = attackRadiusCircle.gameObject.AddComponent<AttackRadius>();
        _attackRadius.Selected += AttackRadius_Selected;            
    }

    private void AttackRadius_Selected(object sender, AttackRadius.SelectedArgs e)
    {
        List<Character> targets = Filter(e.Collided);

        if (targets.Count > 0)
        {
            Validate();
            //Execute();
        }
    }

    public void Validate()
    {
        Debug.Log("dealing damage to targets");
    }

    // Filtre les targets selon friendly fire
    protected List<Character> Filter(List<GameObject> targets)
    {
        List<Character> filtered = new List<Character>();

        for (int i = 0; i < targets.Count; i++)
        {
            Character character;
            // Checker si c'est un player
            if (targets[i].CompareTag("Player"))
            {          
                character = targets[i].GetComponent<Character>();
                if (character == null)
                    continue;
            }
            else
            {
                continue;
            }

            if (AreAllies(_character, character) && !_friendlyFire)
            {
                continue;
            }

            Debug.Log(character.gameObject.name);
            filtered.Add(character);
        }

        return filtered;
    }   



    private bool AreAllies(Character a, Character b)
    {
        return a.Team == b.Team;
    }

    private void AttackRadius_Clicked(object sender, UICircle.ClickedArgs e)
    {
        
    }


    [SerializeField]
    private bool _friendlyFire = false;

    private UICircle _attackRange;
    private AttackRadius _attackRadius;
    private Character _character;
    private UIManager _uiManager;
}