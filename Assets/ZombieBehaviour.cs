using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieBehaviour : MonoBehaviour
{
    public float sightRange = 15f;
    int hp = 10;

    GameObject player;
    NavMeshAgent agent;

    private bool playerVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //sprawdz czy "widzimy" gracza
        //jeœli twoje zombiaki maj¹wspó³rzêdn¹ y = 0 to musisz wzi¹æ poprawkê na wysokoœæ wzroku
        Vector3 raySource = transform.position + Vector3.up * 1.8f;
        Vector3 rayDirection = player.transform.position - transform.position;
        //Debug.DrawRay(raySource, rayDirection);
        //deklarujemy zmienn¹ na to w co trafi raycast
        RaycastHit hit;
        if(Physics.Raycast(raySource, rayDirection, out hit, sightRange))
        {
            Debug.Log(hit.transform.gameObject.name.ToString());
            //uruchomi siê wtedy i tylko wtedy jeœli raycast cokolwiek trafi
            if (hit.transform.CompareTag("Player"))
                playerVisible = true;
            else 
                playerVisible = false;
        }

        //jeœli widzi gracza to idzie
        agent.isStopped = !playerVisible;
        if(hp > 0)
        {
            //transform.LookAt(player.transform.position);
            //Vector3 playerDirection = transform.position - player.transform.position;

            //transform.Translate(Vector3.forward * Time.deltaTime);

            agent.destination = player.transform.position;
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
                Die();
            }
        }
    }
    private void Die()
    {
        agent.speed = 0;
        transform.Translate(Vector3.up);
        transform.Rotate(transform.right * -90);
        GetComponent<BoxCollider>().enabled = false;
        Destroy(transform.gameObject, 5);
    }
}
