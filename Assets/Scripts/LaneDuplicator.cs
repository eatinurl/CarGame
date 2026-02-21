using UnityEngine;
using System.Linq;
using System;
using System.Collections.Generic;

public class LaneDuplicator : MonoBehaviour
{
    public GameObject LanesPrefab;
    private float distMeasure = 38.4f;
    private float distMeasureR = -38.4f;
    private GameObject leftmost;
    private GameObject rightmost;
    private List<GameObject> lanes;


    private void Update()
    {
        lanes = GameObject.FindGameObjectsWithTag("Lanes").OrderBy(obj => obj.transform.position.x).ToList();
        leftmost = lanes[0];
        rightmost = lanes[lanes.Count - 1];
        if (transform.position.x - 38.4f <= leftmost.transform.position.x)
        {
            distMeasure = leftmost.transform.position.x - 38.4f;
            Instantiate(LanesPrefab, new Vector3(distMeasure, 0, 0), Quaternion.identity);
            Destroy(rightmost);  
        }
        if (transform.position.x + 38.4f >= rightmost.transform.position.x)
        {
            distMeasureR = rightmost.transform.position.x + 38.4f;
            Instantiate(LanesPrefab, new Vector3(distMeasureR, 0, 0), Quaternion.identity);
            Destroy(leftmost);
        }
    }
}
