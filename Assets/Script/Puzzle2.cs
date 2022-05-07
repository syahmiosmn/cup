using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2 : MonoBehaviour
{
    public GameObject door;
    public GameObject box;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == box)
        {
            Destroy(door);
        }
    }
}
