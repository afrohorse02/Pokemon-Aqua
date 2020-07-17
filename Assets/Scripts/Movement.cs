using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject grassEffect;
    public bool isMoving;
    public enum Directions
    {
        north,
        west,
        east,
        south
    }
    public Directions facing;
    public IEnumerator Move(Vector2 direction, float speed, bool grass)
    {
        //grass effect
        isMoving = true;
        Vector3 targetPosition = new Vector3(Mathf.Round(transform.position.x + direction.x), Mathf.Round(transform.position.y + direction.y), 0);
        while (transform.position != targetPosition) //Maybe has a better way of checking position
        {
            this.transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
        if (grass)
        {
            GameObject tempEffect = Instantiate(grassEffect, targetPosition, Quaternion.Euler(0, 0, 0));
            Destroy(tempEffect, 0.4f);  //particle effect instead of instantiating
        }
        //if (grass) StartCoroutine(encounterChance);
        yield return 0;
    }

    public IEnumerator Jump(Vector2 direction, float speed)
    {
        isMoving = true;
        isMoving = false;
        yield return 0;
    }

    public bool CheckCollision(Vector2 direction, LayerMask checkMask)
    {
        bool blockFound = false;
        Vector2 overlapBoxSize = new Vector2(0.5f, 0.5f);
        Vector3 offset = new Vector3(0.5f, 0.5f, 0);
        Vector3 overlapBoxCenter = this.transform.position + new Vector3(direction.x, direction.y, 0) + offset;
        Collider2D objectInWay = Physics2D.OverlapBox(overlapBoxCenter, overlapBoxSize, 0, checkMask);
        if (objectInWay != null)
        {
            blockFound = true;
        }
        return blockFound;
    }

    public void changeFacing (Vector2 direction)
    {
        int xFacing;
        int yFacing;
        xFacing = Mathf.RoundToInt(direction.x);
        yFacing = Mathf.RoundToInt(direction.y);
        if (xFacing != 0)
        {
            switch (xFacing)
            {
                case -1:
                    facing = Directions.west;
                    break;
                case 1:
                    facing = Directions.east;
                    break;
            }
        }
        if (yFacing != 0)
        {
            switch (yFacing)
            {
                case -1:
                    facing = Directions.south;
                    break;
                case 1:
                    facing = Directions.north;
                    break;
            }
        }
    }
}
