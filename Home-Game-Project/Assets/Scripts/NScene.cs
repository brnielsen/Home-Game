using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NScene : MonoBehaviour {
   [SerializeField]
   public player player;

    [SerializeField]
    private string currentSceneName;

    void Start()
    {
        //player = GetComponent<player>();
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName(currentSceneName)))
            if (player.health <= 0)
                SceneManager.LoadScene("LOSS");
    }
    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (player.cont && collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("WIN");
            Debug.Log("Being Changed");
        }
        
    }

   
}
