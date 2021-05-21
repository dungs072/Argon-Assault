using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] ParticleSystem crash;
    [SerializeField] float timeLoadLevel = 1f;
   void OnTriggerEnter(Collider other) {
       StartConsequence();
        
   }
   void StartConsequence()
   {

       crash.Play();
       GetComponent<MeshRenderer>().enabled = false;
       GetComponent<PlayerControl>().enabled = false;
       GetComponent<BoxCollider>().enabled = false;
       
       Invoke("nextLevel",timeLoadLevel);
      
   }

   void nextLevel()
   {
       int CurrentScene = SceneManager.GetActiveScene().buildIndex;
       SceneManager.LoadScene(CurrentScene);
   }
}
