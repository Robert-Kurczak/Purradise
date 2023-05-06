using UnityEngine;
using UnityEngine.Events;

public class GatherHandler : MonoBehaviour{
	public float approachDistance = 1;
	public UnityEvent<Vector2> gatherEvent;

	private PlayerApproach playerApproach;
	private PlayerAnimation playerAnimation;

	void Start(){
		GameObject player = PlayerSingleton.Instance.gameObject;

		playerApproach = player.GetComponent<PlayerApproach>();
		playerAnimation = player.GetComponent<PlayerAnimation>();
	}

	public void handleClick(){
		playerApproach.approach(
			transform.position,
			approachDistance,
			(Vector2 directon) => gatherEvent.Invoke(directon)
		);
	}
}
