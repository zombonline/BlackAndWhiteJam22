using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    private Vector3 cameraOffset = new Vector3(0, 0, -16);
    private float smoothSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position + cameraOffset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = player.transform.position + cameraOffset;



        // in case of borders
        //desiredPosition.x = Mathf.Clamp(desiredPosition.x, westEdge + cameraXOffset, eastEdge - cameraXOffset);
        //desiredPosition.y = Mathf.Clamp(desiredPosition.y, southEdge + cameraYOffset, northEdge - cameraYOffset);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }
}
