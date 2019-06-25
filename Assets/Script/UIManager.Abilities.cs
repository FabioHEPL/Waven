using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public partial class UIManager : MonoBehaviour, IPointerClickHandler
{
    //[SerializeField]
    //private GameObject _abilityFactory;

    //private void InputManager_ActiveAbilitySelected(object sender, InputManager.ActiveAbilitySelectedArgs args)
    //{



    //    //Ability ability = CreateAbility(args.AttackModel);
    //    //ability.AssignToCharacter(_character);

    //    // CreateAbility(AttackModel) -> Ability (Script)
    //    // ability.AssignToCharacter(_character);
    //    // ability.Cancel();
    //}

    //// FACTORY METHOD
    //private Ability CreateAbility(AttackModel attackModel)
    //{
    //    // TODO : switch attackmodel, checker quel type d'attaque instancier
    //    // TODO: check si existe déjà
    //    GameObject abilityGO = new GameObject("TestAbility");
    //    abilityGO.transform.parent = _abilityFactory.transform;
    //    FakeDashAbility ability = abilityGO.AddComponent<FakeDashAbility>();
    //    ability.Range = 50;

    //    return ability;
    //}

    public UICircle CreateCircle(float radius, Vector2 position)
    {
        GameObject circleGO = Instantiate(_circlePrefab, position, Quaternion.identity);

        UICircle circle = circleGO.GetComponent<UICircle>();
        circle.Radius = radius;

        
        circle.GetComponent<SpriteRenderer>().sortingOrder = _circleCount;


        // increase depth
        circle.transform.position = new Vector3(
            circle.transform.position.x,
            circle.transform.position.y,
            -(float)_circleCount / 100);

        Debug.Log(circle.transform.position);
        Debug.Log(_circleCount);
        _circleCount++;

        return circle;
    }

    private int _circleCount = 0;

    [SerializeField]
    private GameObject _circlePrefab;
}