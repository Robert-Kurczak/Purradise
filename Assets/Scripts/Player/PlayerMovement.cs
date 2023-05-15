using UnityEngine;

public class PlayerMovement : MonoBehaviour{
	public float moveSpeed = 5;

	public PlayerAnimation playerAnimation;
	public Rigidbody2D rb;
	public Joystick joystick;
	Vector2 movement;

	void FixedUpdate(){
		movement.x = joystick.Horizontal;
		movement.y = joystick.Vertical;

		movement.Normalize();

		playerAnimation.setMovementAnimation(movement);
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
	}
}
