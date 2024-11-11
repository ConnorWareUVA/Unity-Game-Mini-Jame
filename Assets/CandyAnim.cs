using UnityEngine;

public class CandyAnim : MonoBehaviour
{
    public Animator batAnimator; // Reference to the bat's Animator
    public AudioSource collectSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Candy"))
        {
            // Trigger the bat's animation when candy is collected
            collectSound.Play();
            batAnimator.SetTrigger("CollectCandy");
            
        }
    }
}