using UnityEngine;
using UnityEngine.UI;
using TMPro;

//made with general consulation from chatgpt
public class CandyManager : MonoBehaviour
{
    public TextMeshProUGUI winText; // Drag the "You Win!" Text element into this slot in the Inspector

    void Start()
    {
        // Make sure the win text is initially hidden
        if (winText != null)
        {
            winText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Check if there are any candies remaining
        if (CheckForRemainingCandies() == 0)
        {
            winText.gameObject.SetActive(true);
        }
    }

    // Function to check if there are any candies with the "Candy" tag in the scene
    private int CheckForRemainingCandies()
    {
        GameObject[] candies = GameObject.FindGameObjectsWithTag("Candy");
        return candies.Length;
    }
}
