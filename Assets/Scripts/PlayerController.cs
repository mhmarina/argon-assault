using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float controlSpeed = 25f;
    public float xRange = 10f;
    public float yRange = 5f;
    public float posPitchFactor = -2f;
    public float controlPitchFactor = -10f;
    public float posYawFactor = -5f;
    public float controlRollFactor = 5f;

    float yThrow;
    float xThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

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

    private void ProcessRotation() {
        float pitch = transform.localPosition.y * posPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * posYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll); 
    }
}
