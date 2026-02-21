using System.Linq;
using UnityEngine;

public class ChaseCar : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform playerTransform;
    private float chaser;
    public float timingAmount = 5f;
    private Vector2 targetposition;
    private bool hit = false;
    private void Start()
    {
    var player = GameObject.FindWithTag("Player");
    if (player != null)
        rb = player.GetComponent<Rigidbody2D>();
        playerTransform = player.transform;
    }

    private void FixedUpdate()
    {
        Debug.Log(chaser);
        SetPosition();
        float speed = Mathf.Abs(playerTransform.position.x - transform.position.x + chaser) * Time.fixedDeltaTime * 3f;
        transform.position = Vector2.MoveTowards(transform.position, targetposition, speed);
        GetComponent<SpriteRenderer>().color = new Color32((byte)(chaser * 255/7), 0, 0, 255);
    }

    private void SetPosition()
    {
        if (chaser < 7f)
        {
            chaser += Time.fixedDeltaTime * 7/timingAmount;
            targetposition = new Vector2(playerTransform.position.x, playerTransform.position.y + 2.8f);
        }
        if (chaser >= 7f)
        {
            Crash();
        }
    }
    private void Crash()
    {
        targetposition = new Vector2(playerTransform.position.x, playerTransform.position.y);
        chaser = 7f;
        Invoke("HitCheck", 0.4f);
    }

    private void HitCheck()
    {
        if (!hit)
        {
            //Debug.Log("No Crash");
            ResetCar();
            return;
        }
        else
        {
            //Debug.Log("Crash!");
            ResetCar();
            Invoke("ResetHit", 0.5f);
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody != null && collision.rigidbody == rb)
        {
            hit = true;
            Invoke("ResetCar", 0.2f);
        }
    }
    private void ResetCar()
    {
        chaser = -4f;
    }
    private void ResetHit()
    {
        hit = false;
    }
}
