using UnityEngine;

public class ChopHandler : MonoBehaviour{
	public float approachDistance = 1;
	public TreeDestroyer treeDestroyer;

	private PlayerApproach playerApproach;
	private PlayerAnimation playerAnimation;
	private PlayerMovement playerMovement;

	void Start(){
		GameObject player = PlayerSingleton.Instance.gameObject;

		playerApproach = player.GetComponent<PlayerApproach>();
		playerAnimation = player.GetComponent<PlayerAnimation>();
		playerMovement = player.GetComponent<PlayerMovement>();
	}

	private void choppingEnds(){
		//Enabling player movement
		playerMovement.enabled = true;
		treeDestroyer.destroy();
	}

	private void performChopAction(Vector2 direction){
		//Disabling player movement
		playerMovement.enabled = false;

		playerAnimation.OnChoppingEnd += choppingEnds;

		if(direction.x < 0) playerAnimation.chopLeft(5);
		else                playerAnimation.chopRight(5);
	}

	//Called by UIButton
	public void handleClick(){
		playerApproach.OnReachedTarget += performChopAction;
		playerApproach.approach(transform.position, approachDistance);
	}

	void OnDestroy(){
		//Removing listeners
		playerAnimation.OnChoppingEnd -= choppingEnds;
		playerApproach.OnReachedTarget -= performChopAction;
	}
}
