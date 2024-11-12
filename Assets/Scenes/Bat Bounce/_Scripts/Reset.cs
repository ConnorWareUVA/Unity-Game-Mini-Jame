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