using System.Collections;
using UnityEngine;
//made with consulation from chatgpt and https://www.youtube.com/watch?v=fyaJQpBRk2U
public class pumpkinpaddle : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 dir;
    private float speed = 25f;
    private bool upshift = false;
    private Vector3 ogpos;
    private float bumpheight = 3f;
    private float bumpdur = 0.2f;
    public Animator guyAnim;
    public AudioSource guySound;
    private Camera mainCamera; // To reference the main camera
    private float paddleWidth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main; // Get the main camera
        paddleWidth = GetComponent<Collider2D>().bounds.size.x;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector2.right;
        }
        else
        {
            dir = Vector2.zero;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && !upshift)
        {
            StartCoroutine(paddlebounce()); // Start the bump coroutine
            guySound.Play();
            guyAnim.SetTrigger("BatBump");
        }
        
    }

    void FixedUpdate()
    {
        if (dir != Vector2.zero)
        {
            Vector3 newPosition = rb.position + dir * speed * Time.fixedDeltaTime;

            // Calculate the left and right screen boundaries
            float leftBoundary = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + paddleWidth / 2;
            float rightBoundary = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - paddleWidth / 2;

            // Clamp the paddle's position within the screen boundaries
            newPosition.x = Mathf.Clamp(newPosition.x, leftBoundary, rightBoundary);

            // Apply the clamped position
            rb.MovePosition(newPosition);
        }
    }
//made with consultation from chat and https://www.youtube.com/watch?v=fyaJQpBRk2U as a base
    private IEnumerator paddlebounce()
    {
        upshift = true;
        Vector3 ogpos = transform.position;
        Vector3 bumpUpPosition = ogpos + new Vector3(0, bumpheight, 0);

        float elapsedTime = 0f;
        while (elapsedTime < bumpdur)
        {
            transform.position = Vector3.Lerp(ogpos, bumpUpPosition, elapsedTime / bumpdur);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = bumpUpPosition; // Ensure it reaches the exact bump height

        // Pause briefly at the top of the bump
        yield return new WaitForSeconds(0.05f);

        // Move the paddle back down to the original position
        elapsedTime = 0f;
        while (elapsedTime < bumpdur)
        {
            transform.position = Vector3.Lerp(bumpUpPosition, ogpos, elapsedTime / bumpdur);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = ogpos;
        upshift = false;

    }
}