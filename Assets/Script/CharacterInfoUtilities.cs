using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Assets.scripts;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
public class CharacterInfoUtilities : MonoBehaviour
{
    public static CharacterInfoUtilities CharacterInfoUtility;
   

    private void Awake()
    {
        if(CharacterInfoUtility != null)
        {
            Destroy(this);

        }
        else
        {
            CharacterInfoUtility = this;
        }

        //GetCharacterInfo(1);
    }
    public CharacterTempInfo ReadXML(int id)// for testing
    {
       

        var doc = GetDocument("Characters").GetElementsByTagName("Character").Item(id - 1);

        var character = new CharacterTempInfo();
       
            character.Description = doc.ChildNodes[0].InnerText;
            character.Name = doc.Attributes.Item(1).InnerText;
        try
        {
            character.Passif = /*doc.ChildNodes[2].Attributes.Item(0).InnerText + " :" + */ doc.ChildNodes[2].Attributes.Item(1).InnerText;
            character.PassifName = doc.ChildNodes[2].Attributes.Item(0).InnerText ;
        }
        catch
        {
            character.Passif = "vide";
        }
        List<Spell> spells = new List<Spell>();
            for (var s = 0; s < 8; s++)
            {
                spells.Add(new Spell());
            }
            for (var i = 0; i < spells.Count; i++)
            {
                spells[i].Description = doc.ChildNodes[1].ChildNodes[i].Attributes.Item(2).InnerText;
                spells[i].Name = doc.ChildNodes[1].ChildNodes[i].Attributes.Item(1).InnerText;
            }

            character.Spells = spells;
        
        return character;
    }
    public static XmlDocument GetDocument(string GetFile)
    {
        TextAsset text = (TextAsset)Resources.Load(GetFile);
        XmlDocument Doc = new XmlDocument();
        Doc.LoadXml(text.text);
        return Doc;
    }
    public CharacterTempInfo GetCharacterInfo(int characterNr)
    {
       var r = ReadXML(characterNr);
        
        return r;
    }
    public class passif
    {
        public string Name, Description;
    }
    public class CharacterTempInfo
    {
        public string Name, Description, Passif,PassifName;
        public List<Spell> Spells;
    }

    public class Spell
    {
        public string Name, Description;
    }
}
