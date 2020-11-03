using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] GameObject ExplosionVFX;
    [SerializeField] Transform parent;
    [SerializeField] int points = 100;
    [SerializeField] int maxHits = 10;
    private void Start()
    {
        AddBoxCollider();
    }

    private void AddBoxCollider()
    {
        gameObject.AddComponent<BoxCollider>();
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        maxHits--;
        if (maxHits <= 0)
            Death();
    }

    private void Death()
    {
        FindObjectOfType<ScoreUI>().AddToScore(points);
       GameObject fx = Instantiate(ExplosionVFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
    
}
