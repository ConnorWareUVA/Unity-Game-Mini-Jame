using UnityEngine;

public class blockSound : MonoBehaviour
{
    public AudioSource blockbit;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object colliding with the block is the ball (assuming it’s tagged "Ball")
        if (collision.gameObject.CompareTag("Bat"))
        {
            // Play the audio clip when the block is hit
            blockbit.Play();
        }
    }
}