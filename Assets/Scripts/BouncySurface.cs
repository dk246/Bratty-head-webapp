using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BouncySurface : MonoBehaviour
{

    public Animator anim;
    public float bounceStrength = 1f;
    public AudioSource audioSource;
    public AudioClip sound;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        anim.SetBool("collide", true);
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            audioSource.clip = sound;
            audioSource.Play(0);
            // Apply a force to the ball in the opposite direction of the
            // surface to make it bounce off
            Vector2 normal = collision.GetContact(0).normal;
            ball.rigidbody.AddForce(-normal * bounceStrength, ForceMode2D.Impulse);

            
        }

       
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("collide", false);
    }

}
