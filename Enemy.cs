using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerhit = 15;
    [SerializeField] int healthEnemy = 100;
    GameObject parentGameObject;
    int score;
    ScoreBoard scoreBoard;
   void Start() {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("spawnAtRuntime");
        AddRigidBody();
   }
   void AddRigidBody()
   {
       Rigidbody rb = gameObject.AddComponent<Rigidbody>();
       rb.useGravity = false;
   }
    void OnParticleCollision(GameObject other) {
        proccessHit();
        hitPoint();
    }
    void proccessHit()
    {
    //     score += scorePerhit;
    //    Debug.Log($"your score is {score}");
          GameObject vfx =  Instantiate(hitVFX,transform.position,Quaternion.identity);
          vfx.transform.parent = parentGameObject.transform;
          
    }
    void hitPoint()
    {
         healthEnemy -= scorePerhit;
         if(healthEnemy <= 0)
         {
             KillEnemy();
         }
    }
    
    void KillEnemy()
    {
        scoreBoard.IncreaseScore(scorePerhit);
        GameObject fx =  Instantiate(deathFX,transform.position,Quaternion.identity);
        fx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
        
    }
    
}
