using UnityEngine;
using System;

public class ballScript : MonoBehaviour {
  public Rigidbody2D myRigidBody;
  private bool random_direction = true;
  private float initial_speed = 3.0F;
  private float speed_increase_per_bounce = 0.2F;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start() {
    setDirection();
  }

  // Resets the ball to (0,0)
  void resetBall(){
    this.transform.position = new Vector2(0,0);
  }

  // Sets the ball's velocity to default or picks a random direction
  void setDirection(){
    if (!random_direction){
      myRigidBody.linearVelocity = Vector2.left * this.initial_speed;
    } else {
      System.Random rnd = new System.Random();
      int angle = rnd.Next(1,360);
      float yVelocity = (float) Math.Sin(angle);
      float xVelocity = (float) Math.Cos(angle);
      Vector2 direction = new Vector2(rnd.Next(-1000,1000),rnd.Next(-1000,1000));
      myRigidBody.linearVelocity = direction.normalized * this.initial_speed;
    }
  }

  // Nudges the ball if needed
  void FixedUpdate(){
    // If the ball is moving too slowly horizontally, then push it to the left
    if (Math.Abs(myRigidBody.linearVelocity.x) < 0.05F){
      System.Random rnd = new System.Random();
      Debug.Log("Changing horizontal velocity to " + 1.0F);
      myRigidBody.linearVelocity = new Vector2(1.0F,myRigidBody.linearVelocity.y);
    }
    // If the ball is moving too slowly vertically, then push it
    // either up or down (random)
    if (Math.Abs(myRigidBody.linearVelocity.y) < 0.05F){
      System.Random rnd = new System.Random();
      float temp_speed = 0.1F;
      if (rnd.Next(2) == 1){
        temp_speed *= -1;
      }
      Debug.Log("Changing vertical velocity to " + temp_speed);
      myRigidBody.linearVelocity = new Vector2(myRigidBody.linearVelocity.x,temp_speed);
    }
  }

  // Used for detecting if a goal was scored
  void OnTriggerEnter2D(Collider2D c){
    bool scored_goal = false;
    if (c.tag == "player_goal"){
      // Goal was scored on the player
      Debug.Log("Goal scored by computer");
      scored_goal = true;
    } else if (c.tag == "computer_goal"){
      // Goal was scored on the computer
      Debug.Log("Goal scored by player");
      scored_goal = true;
    }

    if (scored_goal){
      // Resets the ball to the center and gives it a direction
      resetBall();
      setDirection();
    }
  }


  void OnCollisionExit2D(Collision2D c){
    //Debug.Log("Ball stopped colliding with " + c.collider.gameObject.name);

    // Increases the speed of the ball after every bounce
    Vector2 lv = myRigidBody.linearVelocity;
    myRigidBody.linearVelocity = lv.normalized * (lv.magnitude+this.speed_increase_per_bounce);
  }
}
