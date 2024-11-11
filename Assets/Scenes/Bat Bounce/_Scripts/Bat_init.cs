using UnityEngine;

public class Bat_init : MonoBehaviour
{
    private Rigidbody2D rb { get; set; }
    public float speed = 500f;

    public void Spawn()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Invoke(nameof(SetRandomTrajectory), 1f);
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1;
        
        rb.AddForce(force.normalized * speed);
    }
}
//bat begins in bucket
//based on info given from launcher logic,
//spawn with velocity at angle