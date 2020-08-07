using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
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

    [Flags] public enum eggGroup
    {
        none = 0,
        wateri = 1,
        bug = 2,
        flying = 4,
        field = 8,
        fairy = 16,
        grass = 32,
        humanlike = 64,
        wateriii = 128,
        mineral = 256,
        amorphous = 512,
        waterii = 1024,
        ditto = 2048,
        dragon = 4096,
        undiscovered = 8192,
        monster = 16384
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

    public enum evolutionStage
    {
        stage0,
        stage1,
        stage2,
        eevee,
        eeveelution
    }

    [SerializeField] int id;
    public string pkName = "Default";
    public int natDexNumber;
    //Regular
    public Sprite spriteFront = null;
    public Sprite spriteBack = null;
    public Sprite icon = null;
    //Shiny
    public Sprite spriteFrontS = null;
    public Sprite spriteBackS = null;
    public Sprite iconS = null;

    public Color pokedexColor;
    public int catchRate = 80;
    public float height = 1.5f; //metres
    public float weight = 40; //kilogrammes
    public int baseExpYield = 100;

    public int baseFriendship = 0;
    public expRate levelRate = expRate.fast;
    public eggGroup group = eggGroup.none;
    public evolutionStage stage;

    public type primaryType = type.normal;
    public type secondaryType = type.none;

    int level;

    //public MegaStone megaStone = none;
    //Ability[] ability = {magicguard, oblivious};
    //Ability hiddenAbility = sturdy;
    //Move[] move = {}; 
}
