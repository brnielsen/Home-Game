using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class player : MonoBehaviour {
    Rigidbody2D playerObject;
    public Sprite replace;
    Tile TReplace;
    public Tilemap tilemap;
    public SpriteRenderer redgreen;
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
        for(int j=pos.x-2; j<pos.x+3; j++)
        {
            for (int i = pos.y - 2; i < pos.y + 3; i++)
            {
                if (!colliding.GetSprite(new Vector3Int(j, i, 0)).Equals(check))
                {
                    tilemap.SetTile(new Vector3Int(j, i, 0), TReplace);
                }
            }
        }
        bool cont = true;
        for(float posx = tilemap.localBounds.min.x; posx< tilemap.localBounds.max.x; posx+=tilemap.layoutGrid.cellSize.x)
        {
            for (float posy = tilemap.localBounds.min.y; posy < tilemap.localBounds.max.y; posy += tilemap.layoutGrid.cellSize.y)
            {
                if (!tilemap.GetSprite(tilemap.layoutGrid.LocalToCell(new Vector3(posx, posy, 0))).Equals(replace))
                {
                    cont = false;
                    break;
                }
            }
        }
        //cont = true;
        if (cont)
        {
            redgreen.color = new Color(0, 1, 0);
        }
    }
}
