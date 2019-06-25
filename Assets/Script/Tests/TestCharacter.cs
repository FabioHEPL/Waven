using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharacter : Character
{
    [Header("Testing")]
    [SerializeField]
    private AttackModel[] attacks;

    protected override void Awake()
    {
        attackLibrary = new Dictionary<int, AttackModel>();

        for (int i = 0; i < attacks.Length; i++)
        {
            attackLibrary.Add(i+1, attacks[i]);
        }
    }
}