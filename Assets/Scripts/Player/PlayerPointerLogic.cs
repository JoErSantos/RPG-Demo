using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointerLogic : MonoBehaviour
{
    public bool canMoveToPointer = true;
    public Vector3 lastValidPosition = Vector3.zero;
    [SerializeField]
    private BattleController battleController;

    private GameObject enemy;
   
    void OnTriggerEnter2D(Collider2D other){
        canMoveToPointer = false;
        enemy = other.gameObject;
    }

    void OnTriggerExit2D(Collider2D other){
        canMoveToPointer = true;
        enemy = null;
    }

    public void GoBackToPlayer()
    {
        if(!canMoveToPointer)
        {
            battleController.StartBattle(enemy,true);
            transform.position = lastValidPosition;
        }
    }
    
}
