using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch1 : MonoBehaviour
{
    public GameObject door;
    public GameObject ui;
    public AudioManager au;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            ui.SetActive(true);
        }

        if (Input.GetKey(KeyCode.E))
        {
            Destroy(door);
            au.Play("Door Open"); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            ui.SetActive(false);
        }
    }
}
