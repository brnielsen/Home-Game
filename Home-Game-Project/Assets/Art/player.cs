using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class player : MonoBehaviour {
    Rigidbody2D playerObject;
    public Sprite replace;
    Tile TReplace;
    public Tilemap tilemap;
   	// Use this for initialization

	void Start () {
        TReplace = ScriptableObject.CreateInstance<Tile>();
        playerObject = GetComponent<Rigidbody2D>();
        TReplace.sprite = replace;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Horizontal") < 0)
            playerObject.velocity = new Vector2(-1, 0);
        else if (Input.GetAxisRaw("Horizontal") > 0)
            playerObject.velocity = new Vector2(1, 0);
        else if (Input.GetAxisRaw("Vertical") < 0)
            playerObject.velocity = new Vector2(0, -1);
        else if (Input.GetAxisRaw("Vertical") > 0)
            playerObject.velocity = new Vector2(0, 1);

        Vector3Int pos = tilemap.layoutGrid.WorldToCell(new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, 0));
        Debug.Log(playerObject.position);
        Debug.Log(pos);
        tilemap.SetTile(pos, TReplace);
    }
}
