using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }
    private GameObject player;
    public float Health { get; set; } = 5f;
    public float maxHealth { get; set; } = 5f;

    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        player = GameObject.FindWithTag("Player");
    }


    public void Damage(float damageAmount)
    {
        Health -= damageAmount;
        if (Health <= 0)
        {
            Health = 0;
            Die();
        }
    }

    public void Die()
    {
        Time.timeScale = 0f;
        Debug.Log("Player has died!");
        player.IsDestroyed();
    }

}
