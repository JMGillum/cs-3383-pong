using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class paddleScript : MonoBehaviour {
  public Rigidbody2D myRigidBody;
  InputAction moveAction;
  private float movement_speed = 5.0F;
  private float initial_x_position;
  public Vector2 move; // Stores the direction the player wishes to move in

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start() {
    myRigidBody = GetComponent<Rigidbody2D>();
    moveAction = InputSystem.actions.FindAction("Move"); // All the different inputs for moving
    this.initial_x_position = this.transform.position.x;
  }

  // Gets input from the user for their move
  void Update() {
    this.move = moveAction.ReadValue<Vector2>();
  }
  
  // Moves the paddle
  void FixedUpdate() {
    // Ensures that the move was only up or down
    if(move.x == 0){
      myRigidBody.AddForce(this.movement_speed * move);
    }
  }

  // Resets the horizontal position of the paddle after a collision
  void OnCollisionExit2D(Collision2D c){
    //Debug.Log("Paddle stopped colliding with " + c.collider.gameObject.name);

    // Resets the x position after a collision (the ball tends to push the paddle back)
    this.transform.position = new Vector2(this.initial_x_position,this.transform.position.y);
  }
}
