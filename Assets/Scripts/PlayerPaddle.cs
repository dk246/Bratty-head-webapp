using UnityEngine;

public class PlayerPaddle : Paddle
{
    public Vector2 direction { get; private set; }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)|| SimpleInput.GetAxis("Horizontal") >0) {
            direction = Vector2.up;
        } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)|| SimpleInput.GetAxis("Horizontal") < 0) {
            direction = Vector2.down;
        } else {
            direction = Vector2.zero;
        }
    }

    public void Up() {
       
    }
    private void FixedUpdate()
    {
        if (direction.sqrMagnitude != 0) {
            rigidbody.AddForce(direction * speed);
        }
    }

}
