using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float rotSpeed = 180f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        /*
        // Rotate the ship

        // Grab the rotation quaterion
        Quaternion rot = transform.rotation;

        // Grab the Z euler angle
        float z = rot.eulerAngles.z;

        // Change the Z angle based on input
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

        // Feed the quaterion into our rotation
        transform.rotation = Quaternion.Euler(0, 0, z);
        */

        // Move the ship horizontally

        Vector3 hPos = transform.position;

        Vector3 hPosChange = new Vector3(Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime, 0, 0);

        hPos += hPosChange;

        transform.position = hPos;

        // Move the ship vertically
        Vector3 pos = transform.position;

        Vector3 posChange = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);

        pos += posChange;

        transform.position = pos;
    }
}
