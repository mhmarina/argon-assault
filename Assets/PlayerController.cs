using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float controlSpeed = 25f;
    public float xRange = 10f;
    public float yRange = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        float xThrow =  Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float newX = transform.localPosition.x + xOffset;
        float clampedX = Mathf.Clamp(newX, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float newY = transform.localPosition.y + yOffset;
        float clampedY = Mathf.Clamp(newY, -yRange, yRange);

        transform.localPosition = new Vector3(clampedX, 
                                              clampedY,
                                              transform.localPosition.z);
    }
}
