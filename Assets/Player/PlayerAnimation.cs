using UnityEngine;

public class PlayerAnimation : MonoBehaviour{
	public Animator animator;

    public void setMovementAnimation(Vector2 direction){
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetBool("Movement", direction.x != 0 || direction.y != 0);
    }
}
