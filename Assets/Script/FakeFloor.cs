using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeFloor : MonoBehaviour
{
    private GameObject player;
    public GameObject fakeFloor;

    void Start()
    {
        player = GameObject.Find("Player");
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            Destroy(fakeFloor);
        }
    }
}
