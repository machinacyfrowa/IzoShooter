using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    int hp = 10;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(hp> 0)
        {
            transform.LookAt(player.transform.position);
            //Vector3 playerDirection = transform.position - player.transform.position;

            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            hp--;
            if(hp <= 0)
            {
                transform.Translate(Vector3.up);
                transform.Rotate(Vector3.right * -90);
                GetComponent<BoxCollider>().enabled = false;
                Destroy(transform.gameObject, 10);
            }
        }
    }
}
