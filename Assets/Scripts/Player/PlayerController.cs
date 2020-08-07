using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Transform playerTransform;

    public LayerMask pathMask;
    public LayerMask npcMask;

    float xAxis;
    float yAxis;
    public float moveSpeed = 5;
    public float surfSpeed = 6;
    public float runSpeed = 8;
    Vector2 inputDirection;
    bool surfing;

    Vector2 facingDirection;
    
    Vector2 
        westFacing, northFacing, eastFacing, southFacing;

    public GameObject dialogOverlay;

    [HideInInspector] public Movement playerMovement;
    [HideInInspector] public DialogHandler dialogController;

    TileClass tileOfType; //
    TileClass npcInWay;

    public PauseController pauseController;
    void Awake()
    {
        playerMovement = GetComponent<Movement>();
        dialogController = GetComponent<DialogHandler>();
        westFacing = new Vector2(-1, 0);
        northFacing = new Vector2(0, 1);
        eastFacing = new Vector2(1, 0);
        southFacing = new Vector2(0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");
        if (xAxis != 0 || yAxis != 0)
        {
            inputDirection = new Vector2(xAxis, yAxis);
            if (inputDirection.x != 0 && inputDirection.y != 0) // Better force of one axis input
            {
                inputDirection.x = 0;
            }
        }
        if (!playerMovement.isMoving && inputDirection != Vector2.zero)
        {
            playerMovement.ChangeFacing(inputDirection);
            tileOfType = playerMovement.CheckCollision(inputDirection, pathMask);
            npcInWay = playerMovement.CheckCollision(inputDirection, npcMask);
            if (tileOfType != null && npcInWay == null)
            {
                if (tileOfType.walkable)
                {
                    StartCoroutine(playerMovement.Move(inputDirection, moveSpeed));
                    switch (tileOfType.type)
                    {
                        case TileClass.tileType.land:
                            //Nothing
                            break;
                        case TileClass.tileType.grass:
                            //Encounter
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        if (Input.GetButtonDown("Action"))
        {
            string facing = playerMovement.GetFacing();
            switch (facing)
            {
                case "west":
                    facingDirection = westFacing;
                    break;
                case "north":
                    facingDirection = northFacing;
                    break;
                case "east":
                    facingDirection = eastFacing;
                    break;
                case "south":
                    facingDirection = southFacing;
                    break;
                default:
                    facingDirection = northFacing; //default facing?
                    break;
            }
            npcInWay = playerMovement.CheckCollision(facingDirection, npcMask);
            if (npcInWay)
            {
                Interact(facingDirection);
            }
        }
        inputDirection = Vector2.zero;
        if (Input.GetButtonDown("Cancel") && playerMovement.isMoving == false)
        {
            pauseController.ActivatePauseMenu();
        }
    }

    void Interact(Vector2 direction)
    {
        Debug.Log("Start npc sequence");
        Vector2 npcPosition = transform.position + (Vector3)direction;
        NPC interactedNpc = GetNPCInfo(npcPosition);
    }

    NPC GetNPCInfo(Vector2 npcPosition)
    {
        NPC npcInfo;
        RaycastHit2D collider = Physics2D.Raycast(npcPosition, Vector2.zero, 0.1f, npcMask);
        npcInfo = collider.collider.gameObject.GetComponent<NPC>();
        return npcInfo;
    }
}
