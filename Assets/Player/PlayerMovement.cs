using UnityEngine;

public class PlayerMovement : MonoBehaviour{
	public float moveSpeed = 5;

	public PlayerAnimation playerAnimation;
	public Rigidbody2D rb;
	Vector2 movement;

	void Update(){
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		movement.Normalize();

		playerAnimation.setMovementAnimation(movement);
	}

	void FixedUpdate(){
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
	}
}
