using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class follower : MonoBehaviour {
    public Rigidbody2D follow;
    public Tilemap map;
    public int NumberHammers = 5;
    public Rigidbody2D player;
    public Rigidbody2D[] followers = new Rigidbody2D[10];
	// Use this for initialization
	void Start () {
		for(int i=0; i<NumberHammers; i++)
        {
            followers[i] = Instantiate(follow);
            followers[i].transform.position = 0.9f * (new Vector3(Random.value * (map.localBounds.max.x - map.localBounds.min.x) + map.localBounds.min.x,
                Random.value * (map.localBounds.max.y - map.localBounds.min.y) + map.localBounds.min.y, 0));
        }
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = Vector3.Normalize(player.transform.position - follow.transform.position)*10;
        follow.AddForce(new Vector2(direction.x, direction.y));
        for (int i = 0; i < NumberHammers; i++)
        {
            direction = Vector3.Normalize(player.transform.position - followers[i].transform.position)*10;
            followers[i].AddForce(new Vector2(direction.x, direction.y));
        }
	}
}
