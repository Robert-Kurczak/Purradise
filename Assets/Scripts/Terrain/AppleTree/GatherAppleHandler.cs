using UnityEngine;

public class GatherAppleHandler: MonoBehaviour{
	public float approachDistance = 1;
	public AppleTreeOptionsToggler optionsToggler;
	public AppleGatherer appleGatherer;

	private PlayerApproach playerApproach;
	private PlayerAnimation playerAnimation;

	void Start(){
		GameObject player = PlayerSingleton.Instance.gameObject;

		playerApproach = player.GetComponent<PlayerApproach>();
		playerAnimation = player.GetComponent<PlayerAnimation>();
	}

	private void showGatherButton(){
		optionsToggler.showGatherButton();
		appleGatherer.OnApplesRegrow -= showGatherButton;
	}

	private void performGatherAction(Vector2 direction){
		appleGatherer.gather();
		optionsToggler.hideGatherButton();
		appleGatherer.OnApplesRegrow += showGatherButton;
	}

	//Called by UIButton
	public void handleClick(){
		playerApproach.approach(transform.position, approachDistance, performGatherAction);
	}
}
