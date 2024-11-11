using UnityEngine;
using UnityEngine.SceneManagement;

public class GReset : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Bat")) return;
        SceneManager.LoadScene("MainGame");
    }
}

//when all chances are lost, level restarts with 3 lives
//reset all bricks
//reload current level
//increment lives counter