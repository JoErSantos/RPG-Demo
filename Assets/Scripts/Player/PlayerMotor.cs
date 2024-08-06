using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Tilemap ground;
    [SerializeField]
    private Tilemap collisions;
    [SerializeField]
    private PlayerPointerLogic pointerLogic;
    public Transform movePoint;
    public float speed = 5f;
    public LayerMask enemyLayer;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(pointerLogic.canMoveToPointer)
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
    }

    public void Move(Vector2 direction)
    {
        
        if(CanMove(direction) && Vector3.Distance(transform.position, movePoint.position) == 0f && pointerLogic.canMoveToPointer)
        {
            pointerLogic.lastValidPosition = movePoint.position;
            if(Mathf.Abs(direction.x) == 1f)
            {
                movePoint.position += (Vector3)direction;
            }
            if(Mathf.Abs(direction.y) == 1f)
            {
                movePoint.position += (Vector3)direction;
            }
        }
        if(!pointerLogic.canMoveToPointer)
            pointerLogic.GoBackToPlayer();
    }

    private bool CanMove(Vector2 direction)
    {
        Vector3Int gridPosition = ground.WorldToCell(transform.position + (Vector3)direction);

        if(collisions.HasTile(gridPosition))
            return false;

        return true;

    }

}
