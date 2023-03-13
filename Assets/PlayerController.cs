using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float hp = 10;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20;
    public float playerSpeed = 2;
    Vector2 movementVector;
    Transform bulletSpawn;
    public GameObject hpBar;
    Scrollbar hpScrollBar;

    // Start is called before the first frame update
    void Start()
    {
        movementVector = Vector2.zero;
        bulletSpawn = transform.Find("BulletSpawn");
        hpScrollBar = hpBar.GetComponent<Scrollbar>();
    }

    // Update is called once per frame
    void Update()
    {
        //obrót wokó³ osi Y o iloœæ stopni równ¹ wartosci osi X kontrolera
        transform.Rotate(Vector3.up * movementVector.x);
        //przesuniêcie do przodu (transform.forward) o wychylenie osi Y kontrolera w czasie jednej klatki
        transform.Translate(Vector3.forward * movementVector.y * Time.deltaTime * playerSpeed);
    }
    
    void OnMove(InputValue inputValue) 
    {
        movementVector = inputValue.Get<Vector2>();

        //Debug.Log(movementVector.ToString());
    }

    void OnFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn);
        bullet.transform.parent = null;
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward*bulletSpeed, ForceMode.VelocityChange);
        Destroy(bullet, 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
   
            hp--;
            if(hp <= 0) Die();
            hpScrollBar.size = hp / 10;
            Vector3 pushVector = collision.gameObject.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(pushVector.normalized*5, ForceMode.Impulse);
        }
    }
    void Die()
    {
        GetComponent<BoxCollider>().enabled = false;
        transform.Translate(Vector3.up);
        transform.Rotate(Vector3.right * -90);
        
        //Time.timeScale = 0;
    }
}
