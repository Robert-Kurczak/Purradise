using UnityEngine;

public class ChopOptionHandler : MonoBehaviour{
    public float approachDistance = 1;
    public TreeDestroyer treeDestroyer;

    private PlayerApproach playerApproach;
    private PlayerAnimation playerAnimation;

    private void chopTree(){
        treeDestroyer.destroy();
    }

    private void performChopAction(Vector2 direction){
        playerAnimation.OnChoppingEnd += chopTree;

        if(direction.x < 0) playerAnimation.chopLeft(5);
        else                playerAnimation.chopRight(5);
    }

    //Caled by UIButton
    public void handleClick(){
        playerApproach.OnReachedTarget += performChopAction;
        playerApproach.approach(transform.position, approachDistance);
    }

    void OnDestroy(){
        //Removing listeners
        playerAnimation.OnChoppingEnd -= chopTree;
        playerApproach.OnReachedTarget -= performChopAction;
    }

    void Start(){
        //TODO change to singleton
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        playerApproach = player.GetComponent<PlayerApproach>();
        playerAnimation = player.GetComponent<PlayerAnimation>();
    }
}
