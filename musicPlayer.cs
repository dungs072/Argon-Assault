using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour
{
  void Awake() {
      int numMusicPlayer = FindObjectsOfType<musicPlayer>().Length;
      
      if(numMusicPlayer > 1)
       {
           
           Destroy(gameObject);
       }
      else
      {
          
          DontDestroyOnLoad(gameObject);
      }
  }
}
