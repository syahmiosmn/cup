using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    public GameObject box;
    public GameObject puzzle;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == box)
        {
            Debug.Log("wworking");
            puzzle.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == box)
        {
            Debug.Log("wworking");
            puzzle.SetActive(false);
        }
    }
}
