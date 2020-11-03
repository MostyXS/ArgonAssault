using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject Explosions;
    [SerializeField] bool invincibility = true;
    private void OnCollisionEnter(Collision collision)
    {
        StartDeathSequence();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        StartDeathSequence();
    }
    private void StartDeathSequence()
    {
        Debug.Log("Player dying");
        if (!invincibility) 
        {
            Explosions.SetActive(true);
            SendMessage("OnPlayerDeath");
            StartCoroutine(SceneLoader.Reloading());
        }
    }

}
