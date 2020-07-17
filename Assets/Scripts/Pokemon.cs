using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pokemon")]

public class NewBehaviourScript : ScriptableObject
{
    public enum type
    {
        normal,
        flying,
        water,
        fire,
        grass,
        rock,
        steel,
        ground,
        electric,
        ice,
        dragon,
        bug,
        psychic,
        fighting,
        fairy,
        poison,
        dark,
        ghost,
        none //use as secondary if pokemon is monotype
    }

    public enum eggGroup
    {
        monster,
        wateri,
        bug,
        flying,
        field,
        fairy,
        grass,
        humanlike,
        wateriii,
        mineral,
        amorphous,
        waterii,
        ditto,
        dragon,
        undiscovered
    }

    public enum expRate
    {
        erratic,
        fast,
        mediumfast,
        mediumslow,
        slow,
        fluctuating
    }

    [SerializeField] int id;
    public string pkName = "Default";
    public int natDexNumber;

    public int catchRate = 80;
    public float height = 1.5f; //metres
    public float weight = 40; //kilogrammes
    public int baseExpYield = 100;

    public int baseFriendship = 0;
    public expRate levelRate = expRate.fast;
    public eggGroup group = eggGroup.monster;

    int level;

    //public MegaStone megaStone = none;
    //Ability ability = magicguard;
    //Move[] move = {}; 
}
