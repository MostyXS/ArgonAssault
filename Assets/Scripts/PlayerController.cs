using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{   [Header("General")]
    [SerializeField]float Speed = 40f;
    [SerializeField] float xLimiter = 10f;
    [SerializeField] float yLimiter = 5f;
    [SerializeField] GameObject[] guns;

    [Header("PositionBased")]
    [SerializeField] float positionPitchFactor = -2.5f;
    [SerializeField] float positionYawFactor = -2.5f;
    [Header("controlBased")]
    [SerializeField] float controlRollFactor = 2.5f;
    [SerializeField] float controlPitchFactor = -5f;
    public bool invincibility = true;
    float yThrow, xThrow;
    bool controlsEnabled = true;
    

    
  
    void Update()
    {
        if (controlsEnabled)
        {
            Control();
            ProcessFiring();
        }
    }

    private float GetHorizontalPosition()
    {
        
        float xOffset = xThrow * Time.deltaTime * Speed;
        float newXPosition = transform.localPosition.x + xOffset;
        return Mathf.Clamp(newXPosition, -xLimiter, xLimiter);
        
    }
    private float GetVerticalPosition()
    {
        
        float yOffset = Speed * yThrow * Time.deltaTime;
        float newYPosition = transform.localPosition.y + yOffset;
        return Mathf.Clamp(newYPosition, -yLimiter, yLimiter);
        

    }
    public void OnPlayerDeath() // called by string reference
    {
        Debug.Log("ControlsFrozen");
        
        controlsEnabled = false;
    }
    
    private void Control()
    {
        ThrowsGetter();
        ProcessPosition();
        ProcessRotation();
    }

    private void ThrowsGetter()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
    }
   
    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor; 
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToControlThrow + pitchDueToPosition;//назад вперёд(наклон)(тангаж)
        float yaw=transform.localPosition.x*positionYawFactor; //Влево вправо (Поворот)(рыскание)
        float roll=xThrow*controlRollFactor; //Влево вправо(наклон)(крен)
    


        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessPosition()
    {
        transform.localPosition = new Vector3(GetHorizontalPosition(), GetVerticalPosition(), transform.localPosition.z);
    }
    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
       
            
            {
                ActivateGuns();
            }
            else
            {
                DeactivateGuns();
            }
        
    }

    private void DeactivateGuns()
    {
        
        foreach (GameObject gun in guns)
        {
            gun.GetComponent<ParticleSystem>().Stop();
        }
    }

    private void ActivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            if (!gun.GetComponent<ParticleSystem>().isPlaying)
                gun.GetComponent<ParticleSystem>().Play();
        }
    }
}
