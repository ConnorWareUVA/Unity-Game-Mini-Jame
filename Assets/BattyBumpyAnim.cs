using UnityEngine;

public class BattyBumpAnim : MonoBehaviour
{
    public Animator guyAnim; // Reference to the bat's Animator
    public AudioSource guySound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bat"))
        {
            // Trigger the bat's animation when candy is collected
            guySound.Play();
            guyAnim.SetTrigger("BatBump");
            
        }
    }
}
