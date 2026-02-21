using UnityEngine;

public class Ramp : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
            rb = player.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.attachedRigidbody != null && other.attachedRigidbody == rb)
      {
        StartCoroutine(player.GetComponent<PlayerController>().DodgeRoutine());
      }
    }
}
