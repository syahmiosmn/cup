using UnityEngine;

public class MoveCamera : MonoBehaviour {

    private GameObject player;
    private Transform playerPos;

    void Start()
    {

        player = GameObject.Find("Player");
        playerPos = player.GetComponent<Transform>();
    }
    void Update() {

        transform.position = playerPos.transform.position;
    }
}
