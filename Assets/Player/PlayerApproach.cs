using UnityEngine;
using System;

public class PlayerApproach : MonoBehaviour{
    public PlayerMovement playerMovement;
    public PlayerAnimation playerAnimation;
    public event Action<Vector2> OnReachedTarget;

    private bool isApproaching;
    private Vector2 targetPosition;
    private float minDistanceSqr;

    public void approach(Vector2 target, float distance){
        playerMovement.enabled = false;
        isApproaching = true;

        targetPosition = target;
        minDistanceSqr = distance * distance;
    }

    void FixedUpdate(){
        if(isApproaching){
            //Move towards target
            if(Vector2.SqrMagnitude(targetPosition - (Vector2)transform.position) > minDistanceSqr){
                Vector2 direction = targetPosition - (Vector2)transform.position;
                playerAnimation.setMovementAnimation(direction.normalized);

                transform.position = Vector2.MoveTowards(transform.position, targetPosition, playerMovement.moveSpeed * Time.deltaTime);
            }
            //Target reached
            else{
                //Making sure player walking animation is stopped
                playerAnimation.setMovementAnimation(new Vector2(0, 0));

                playerMovement.enabled = true;
                isApproaching = false;

                //Notify that player reached choosen target
                OnReachedTarget?.Invoke(targetPosition - (Vector2)transform.position);
            }
        }
    }
}
