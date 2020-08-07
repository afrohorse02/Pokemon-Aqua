using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileClass : MonoBehaviour
{
    public bool walkable;
    public bool interactable;
    public enum tileType
    {
        grass,
        land,
        water,
        rampDown,
        rampUp,
        rampLeft,
        rampRight,
        npc
    }
    
    public tileType type;

    public TileClass() { }
}
