using UnityEngine;

public class computerPaddleScript : paddleScript {
  public Rigidbody2D ballRB;

  // Picks a direction for the computer controlled paddle to move in
  void Update(){
    // Ball is moving towards the computer paddle
    if (ballRB.linearVelocity.x > 0.0F){
      // Moves up or down to match the ball's position
      if (ballRB.position.y > this.transform.position.y){
        move = Vector2.up;
      } else if (ballRB.position.y < this.transform.position.y){
        move = Vector2.down;
      } else {
        move = Vector2.zero;
      }
    } else { // Ball is moving away, so move paddle back to center
      if (this.transform.position.y > 0.5){
        move = Vector2.down;
      } else if (this.transform.position.y < -0.5){
        move = Vector2.up;
      } else { // Paddle is close enough to center to not need to move
        move = Vector2.zero;
      }
    }
  }

}
