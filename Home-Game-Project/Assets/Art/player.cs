﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class player : MonoBehaviour {
    Rigidbody2D playerObject;
    public Sprite replace;
    Tile TReplace;
    public Tilemap tilemap;
    public Tilemap colliding;
    public Sprite check;
    [SerializeField]
    int moveSpeed = 5;
   	// Use this for initialization

	void Start () {
        TReplace = ScriptableObject.CreateInstance<Tile>();
        playerObject = GetComponent<Rigidbody2D>();
        TReplace.sprite = replace;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Horizontal") < 0)
            playerObject.velocity = new Vector2(-moveSpeed, 0);
        else if (Input.GetAxisRaw("Horizontal") > 0)
            playerObject.velocity = new Vector2(moveSpeed, 0);
        else if (Input.GetAxisRaw("Vertical") < 0)
            playerObject.velocity = new Vector2(0, -moveSpeed);
        else if (Input.GetAxisRaw("Vertical") > 0)
            playerObject.velocity = new Vector2(0, moveSpeed);

        Vector3Int pos = tilemap.layoutGrid.WorldToCell(new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, 0));
        for(int j=pos.x-2; j<pos.x+2; j++)
        {
            for (int i = pos.y - 2; i < pos.y + 2; i++)
            {
                if (!colliding.GetSprite(new Vector3Int(j, i, 0)).Equals(check))
                {
                    tilemap.SetTile(new Vector3Int(j, i, 0), TReplace);
                }
            }
        }

    }
}
