using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharacterLibrary : MonoBehaviour
{
    public Character[] characters;
    //public AttackModel testAbilities;

    private void Awake()
    {
        CharacterLibrary.characterLibrary = new Dictionary<int, GameObject>();

        for (int i = 0; i < characters.Length; i++)
        {
            CharacterLibrary.characterLibrary.Add(i+1, characters[i].gameObject);            
        }        


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
