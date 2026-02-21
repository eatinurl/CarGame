using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private SpriteRenderer spriteRenderer;
    private float movementX;
    private float movementY;
    private Vector2 movementVector;
    public float speed;
    public float topspeed;
    public float turnSpeed;
    public float topturnspeed;
    public float stopspeed;
    private bool isDodging = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnJump(InputValue context)
    {
        if (context.isPressed)
        {
            StartCoroutine(DodgeRoutine());
        }
    }
    public void OnMove(InputValue movementValue)
    {
        movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    public IEnumerator DodgeRoutine()
    {
        if (isDodging) yield break;
        isDodging = true;
        if (col != null) col.enabled = false;
        spriteRenderer.color = new Color32(255, 105, 0, 255);
        yield return new WaitForSeconds(1f);
        if (col != null) col.enabled = true;
        spriteRenderer.color = new Color32(173, 105, 35, 255);
        isDodging = false;
    }
    void FixedUpdate()
    {
        if ((movementX > 0 && rb.linearVelocityX < topspeed) || (movementX < 0 && rb.linearVelocityX > -topspeed))
        {
            rb.AddForce(new Vector2(movementX * speed, 0));
        }
        if ((movementY > 0 && rb.linearVelocityY < topturnspeed) || (movementY < 0 && rb.linearVelocityY > -topturnspeed))
        {
            rb.AddForce(new Vector2(0, movementY * turnSpeed));
        }
        if (movementVector == new Vector2(0,0))
        {
            rb.linearVelocity *= 1/stopspeed;
        }
    }


}
