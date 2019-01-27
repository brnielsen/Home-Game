using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NScene : MonoBehaviour {
   [SerializeField]
   public player player;

    void Start()
    {
        //player = GetComponent<player>();
    }

    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (player.cont && collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("level2_REMOTE_9208");
            Debug.Log("Being Changed");
        }
        
    }

   
}
