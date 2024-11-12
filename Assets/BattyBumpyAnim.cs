using UnityEngine;

//general consultation from chatgpt
public class BattyBumpAnim : MonoBehaviour
{
    public Animator guyAnim; 
    public AudioSource guySound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bat"))
        {
            
            guySound.Play();
            guyAnim.SetTrigger("BatBump");
            
        }
    }
}
