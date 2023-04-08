using UnityEngine;

public class ChopOptionHandler : MonoBehaviour{
    public float distance = 1;

    private PlayerApproach playerApproach;

    public void handleClick(){
        playerApproach.approach(transform.position, distance);
    }

    void Start(){
        playerApproach = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerApproach>();
    }
}
