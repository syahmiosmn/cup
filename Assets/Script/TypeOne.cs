using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TypeOne : MonoBehaviour
{
    private float health = 50f;
    
    private GameObject player;
    private Transform playerPos;
    private float moveSpeed;
    public Animation ani;
    public AnimationClip ani1;
    public AnimationClip ani2;
    public AnimationClip ani3;
    private bool run;

    void Start()
    {
        moveSpeed = 4.1f;
        player = GameObject.Find("Player");
        playerPos = player.GetComponent<Transform>();
        ani.AddClip(ani1, "run");
        ani.AddClip(ani2, "die");
        ani.AddClip(ani3, "idle");

    }

    // prints "close" if the z-axis of this transform looks
    // almost towards the target

    void Update()
    {
        Vector3 targetDir = playerPos.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);

        Vector3 targetPos = new Vector3(playerPos.position.x,
                           this.transform.position.y,
                           playerPos.position.z);

        if (angle < 5.0f)
        {
            //Debug.Log("close");
            this.transform.LookAt(targetPos);
            this.gameObject.transform.LookAt(playerPos);
            
            this.gameObject.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            run = true;
        }
        else
        {
            run = false;
        }

        if (run)
        {
            ani.Play("run");
        }

        if (!run)
        {
            ani.Play("idle");
        }

        if (health <= 0f)
        {
            ani.Play("die");
            ani.Stop();
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(4);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        moveSpeed = 0f;

        Debug.Log(this.gameObject.name);
    }
}
