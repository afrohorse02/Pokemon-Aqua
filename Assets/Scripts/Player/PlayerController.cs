using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Transform playerTransform;

    public LayerMask pathMask;
    public LayerMask blockMask;
    public LayerMask grassMask;
    public LayerMask npcMask;

    float xAxis;
    float yAxis;
    bool walkingOnGrass = false;
    public float moveSpeed = 5;
    Vector2 inputDirection;

    public GameObject dialogOverlay;

    [HideInInspector] public Movement playerMovement;
    [HideInInspector] public DialogHandler dialogController;
    void Awake()
    {
        int npc = 1 << LayerMask.NameToLayer("NPC");
        int wall = 1 << LayerMask.NameToLayer("Wall");
        blockMask = npc | wall;
        playerMovement = GetComponent<Movement>();
        dialogController = GetComponent<DialogHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("Battle", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("SampleScene");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("Battle");
        }

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
            playerMovement.changeFacing(inputDirection);
            if (playerMovement.CheckCollision(inputDirection, pathMask) && !playerMovement.CheckCollision(inputDirection, blockMask))
            {
                walkingOnGrass = false;
                StartCoroutine(playerMovement.Move(inputDirection, moveSpeed, walkingOnGrass));
            }
            if (playerMovement.CheckCollision(inputDirection, grassMask) && !playerMovement.CheckCollision(inputDirection, blockMask))
            {
                walkingOnGrass = true;
                StartCoroutine(playerMovement.Move(inputDirection, moveSpeed, walkingOnGrass));
            }
        }
        inputDirection = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Grass"))
        {
            
            //ENCOUNTER CHANCE
        }
    }
}
