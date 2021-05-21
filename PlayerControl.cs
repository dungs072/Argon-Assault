using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControl : MonoBehaviour
{
    [Header("General Set Up Settings")]
    [Tooltip("How far ship moves up and down ")]
    [SerializeField] float controlSpeed = 10f; 
    [Header("Width of screen")]
    [Tooltip("Heigth and width of player ship can reach")]
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 10f;
    [Header("Rotate ship")]
    [Tooltip("sensitive of rotation when you up, down,turn left and turn right")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = -1f;
    [SerializeField] float controlYawFactor = -10f;
    [SerializeField] float positionRollFactor = -2f;
    [Header("Lasers")]
    [Tooltip("add more laser here")]
    [SerializeField] GameObject[] lasers;
    float xThrow,yThrow;
    // Update is called once per frame
    void Update()
    {
       proccessTranslation();
       proccessRotation();
       processFiring();
    }
    void proccessTranslation()
    {
       xThrow = Input.GetAxis("Horizontal");
       Debug.Log(xThrow);
       yThrow = Input.GetAxis("Vertical");
       Debug.Log(yThrow);
       float xOffset = xThrow * Time.deltaTime * controlSpeed;
       float yOffset = yThrow * Time.deltaTime * controlSpeed;
       float rawXPos = transform.localPosition.x + xOffset;
       float newXPos = Mathf.Clamp(rawXPos,-xRange,xRange);

       float rawYPos = transform.localPosition.y + yOffset;
       float newYPos = Mathf.Clamp(rawYPos,-yRange,yRange);
       transform.localPosition = new Vector3 (newXPos,newYPos,transform.localPosition.z); 
    }
    void proccessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yawDueToControlThrow = yThrow * controlYawFactor;
        float roll = xThrow * positionRollFactor;
        float yaw = yawDueToPosition + yawDueToControlThrow;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }
    void processFiring()
    {
        if(Input.GetButton("Fire1"))
        {
            ActiveLasers();
        }
        else
        {
            DeactivateLasers();
        }
    }
    void ActiveLasers()
    {
        foreach (GameObject laser in lasers)
        {        
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = true;
        }
    }
    void DeactivateLasers()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = false;
        }
    }
}