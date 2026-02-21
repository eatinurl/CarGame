  using UnityEngine;

  public class BaseCollider : MonoBehaviour
  {
    private Rigidbody2D rb;

    private void Start()
    {
    var player = GameObject.FindWithTag("Player");
    if (player != null)
        rb = player.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.rigidbody != null && collision.rigidbody == rb)
      {
        Debug.Log("Collided with player" + gameObject.name);
      }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.attachedRigidbody != null && other.attachedRigidbody == rb)
      {
        PlayerStats.Instance.Damage(1f);
        Destroy(gameObject);
      }
    }
  }
