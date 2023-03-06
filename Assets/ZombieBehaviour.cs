using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        //Vector3 playerDirection = transform.position - player.transform.position;
        
        transform.Translate(Vector3.forward * Time.deltaTime);
    }
}
