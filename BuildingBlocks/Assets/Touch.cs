using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {

    public GameObject point;
    private void OnTriggerEnter()
    {
        point.SetActive(true);
    }
}
