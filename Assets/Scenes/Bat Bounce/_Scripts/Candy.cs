using UnityEngine;

public class Candies : MonoBehaviour
{ // Track the total number of candies collected

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bat")) return;

        gameObject.SetActive(false); // Disable the candy to simulate collection
    }
}

//if bat collides
//collect

//if candy gone
//level win

//candy types

//reg
//upon collect, no effect

//boost
//upon collect, increment boost

//live
//upon collect, increment lives