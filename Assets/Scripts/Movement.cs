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
    public IEnumerator Move(Vector2 direction, float speed)
    {
        isMoving = true;
        Vector3 targetPosition = new Vector3(Mathf.Round(transform.position.x + direction.x), Mathf.Round(transform.position.y + direction.y), 0);
        while (transform.position != targetPosition) //Maybe has a better way of checking position
        {
            this.transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
        yield return 0;
    }

    public IEnumerator Jump(Vector2 direction, float speed)
    {
        isMoving = true;
        isMoving = false;
        yield return 0;
    }

    public TileClass CheckCollision(Vector2 direction, LayerMask collisionMask)
    {
        Vector3 direction3D = new Vector3 (direction.x, direction.y, 0);
        RaycastHit2D collider = Physics2D.Raycast(transform.position + direction3D, Vector2.zero, 0.1f, collisionMask);
        if (collider)
        {
            GameObject colliderObject = collider.collider.gameObject;
            TileClass objectInfo = colliderObject.GetComponent<TileClass>();
            return objectInfo;
        }
        else
        {
            return null;
        }
    }

    public void ChangeFacing (Vector2 direction)
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
    
    public string GetFacing()
    {
        return facing.ToString();
    }
}
