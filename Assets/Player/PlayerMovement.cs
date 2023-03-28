using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
	public float moveSpeed = 5f;
	public Rigidbody2D rb;
	public Animator animator;

	Vector2 movement;

	void Update(){
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		animator.SetFloat("Horizontal", movement.x);
		animator.SetFloat("Vertical", movement.y);

		animator.SetBool("Movement", movement.x != 0 || movement.y != 0);
	}

	void FixedUpdate(){
		rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
	}
}
