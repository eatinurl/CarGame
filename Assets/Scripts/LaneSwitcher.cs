using UnityEngine;

public class LaneSwitcher : MonoBehaviour
{
    public float laneWidth = 2.4f; // Distance between lanes
    public float switchSpeed = 5f; // Speed of lane switching
    private int currentLane = 0; // -1 for left, 0 for center, 1 for right
    private int roll;
    private float timer;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
        timer = 0f;
        roll = 0;
    }

    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= 3f)
        {
            Roll();
            timer = 0f;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * switchSpeed);
    }
    
    void Roll()
    {
        roll = Random.Range(-1, 2); // Randomly choose -1, 0, or 1
        if (roll == -1 && currentLane > -2)
        {
            currentLane--;
            UpdateTargetPosition();
        }
        else if (roll == 1 && currentLane < 2)
        {
            currentLane++;
            UpdateTargetPosition();
        }
        roll = 0;
    }
    void UpdateTargetPosition()
    {
        targetPosition = new Vector3(transform.position.x, currentLane * laneWidth, transform.position.z);
    }
}
