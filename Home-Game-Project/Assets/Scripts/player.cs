using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;


public class player : MonoBehaviour
{
    Rigidbody2D playerObject;
    public Sprite replace;
    Tile TReplace;
    public Text HealthText;
    public Light EndLight;
    public float health = 50;
    public SpriteRenderer healthSprite;
    public Tilemap tilemap;
    public SpriteRenderer redgreen;
    public Tilemap colliding;
    public Sprite check;
    public bool cont;
    public float currenthealthlevel;
    [SerializeField]
    int moveSpeed = 5;
    bool EndlightRotate = false;
    private float time = 0;

    public GameObject nextLevelLight;
    // Use this for initialization

    void Start()
    {
        TReplace = ScriptableObject.CreateInstance<Tile>();
        playerObject = GetComponent<Rigidbody2D>();
        TReplace.sprite = replace;
        currenthealthlevel = health;
        EndLight.color = new Color(0, 0, 0, 0);

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("in trig");
        if (other.collider.CompareTag("hammer"))
        {
            float hammer_speed = (float)(other.otherCollider.GetComponentInParent<Rigidbody2D>().velocity.magnitude / 12);
            Debug.Log("hit hammer");
            currenthealthlevel -= hammer_speed;
            if (currenthealthlevel < health / 3)
                HealthText.color = new Color(255, 0, 0);
            healthSprite.transform.localScale = new Vector3((currenthealthlevel < 0) ? 0 : map(currenthealthlevel, health, 50, 0), healthSprite.transform.localScale.y);
        }
    }
    float map(float num, float max, float high, float low)
    {
        return num / max * (high - low) + low;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
            playerObject.velocity = new Vector2(-moveSpeed, 0);
        else if (Input.GetAxisRaw("Horizontal") > 0)
            playerObject.velocity = new Vector2(moveSpeed, 0);
        else if (Input.GetAxisRaw("Vertical") < 0)
            playerObject.velocity = new Vector2(0, -moveSpeed);
        else if (Input.GetAxisRaw("Vertical") > 0)
            playerObject.velocity = new Vector2(0, moveSpeed);

        Vector3Int pos = tilemap.layoutGrid.WorldToCell(new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, 0));
        for (int j = pos.x - 2; j < pos.x + 3; j++)
        {
            for (int i = pos.y - 2; i < pos.y + 3; i++)
            {
                if (!colliding.GetSprite(new Vector3Int(j, i, 0)).Equals(check))
                {
                    tilemap.SetTile(new Vector3Int(j, i, 0), TReplace);
                    //tilemap.SetColor(new Vector3Int(j, i, 0), new Color(194, 194, 194, 139));
                }
            }
        }
        cont = true;
        for (float posx = tilemap.localBounds.min.x; posx < tilemap.localBounds.max.x; posx += tilemap.layoutGrid.cellSize.x)
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
            time += Time.deltaTime;
            if (time % 1 < .25)
            {
                nextLevelLight.SetActive(true);
                redgreen.color = new Color(0, 1, 0, 255f);
                EndLight.color = new Color(0, 1, 0, 255f);
            }
            else
            {
                EndLight.color = new Color(0, 0, 0, 0);

                redgreen.color = new Color(0, 1, 0, 0);
            }
        }
    }
}
