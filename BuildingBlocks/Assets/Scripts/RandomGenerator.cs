using UnityEngine;
using System.Collections;

public class RandomGenerator : MonoBehaviour
{

    public Vector3[] positions;
    GameObject currentPoint;
    int index;

    // Use this for initialization
    void Start()
    {
        int randomNumber = Random.Range(0, positions.Length);
        transform.position = positions[randomNumber];


    }
}
