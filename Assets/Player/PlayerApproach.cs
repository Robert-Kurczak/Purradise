using UnityEngine;

public class PlayerApproach : MonoBehaviour{
    public PlayerMovement playerMovement;
    public PlayerAnimation playerAnimation;

    private bool isApproaching;
    private Vector2 targetPosition;
    private float minDistanceSqr;

    public void approach(Vector2 target, float distance){
        isApproaching = true;
        playerMovement.enabled = false;
        
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
                playerMovement.enabled = true;
                isApproaching = false;
            }
        }
    }
}
