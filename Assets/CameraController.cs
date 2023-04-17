using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 playerOffset;
    public float smoothTime = 0.3f;
    private GameObject player;
    private Vector3 velocity;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = player.transform.position + playerOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
