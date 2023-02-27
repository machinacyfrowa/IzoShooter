using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 movementVector;

    // Start is called before the first frame update
    void Start()
    {
        movementVector = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //obr�t wok� osi Y o ilo�� stopni r�wn� wartosci osi X kontrolera
        transform.Rotate(Vector3.up * movementVector.x);
        //przesuni�cie do przodu (transform.forward) o wychylenie osi Y kontrolera w czasie jednej klatki
        transform.Translate(Vector3.forward * movementVector.y * Time.deltaTime);
    }
    
    void OnMove(InputValue inputValue) 
    {
        movementVector = inputValue.Get<Vector2>();

        Debug.Log(movementVector.ToString());
    }
}
