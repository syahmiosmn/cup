using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private GameObject player;
    private Transform playerPos;

    private GameObject cam;
    private GameObject camChild;
    private Camera fpsCam;

    private GameObject crosshair;

    private bool isAttached;
    private float range = 100f;

    public AudioManager au;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerPos = player.GetComponent<Transform>();

        cam = GameObject.Find("Camera");
        camChild = cam.transform.GetChild(0).gameObject;
        fpsCam = camChild.GetComponent<Camera>();

        crosshair = camChild.transform.GetChild(0).gameObject;

        isAttached = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttached)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("fire");
                Fired();
                au.Play("Shoot");
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            this.gameObject.transform.position = new Vector3(-0.5f + playerPos.position.x, playerPos.position.y, 0.5f + playerPos.position.z);
            this.gameObject.transform.rotation = player.gameObject.transform.rotation;
            this.gameObject.transform.parent = player.gameObject.transform;
            crosshair.SetActive(true);
            isAttached = true;
            
        }
    }

    void Fired()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            TypeOne enemy1 = hit.transform.GetComponent<TypeOne>();

            if(enemy1 != null)
            {
                enemy1.TakeDamage(50f);
                Destroy(this.gameObject);
                crosshair.SetActive(false);
            }
        }
        
            
    }
}
