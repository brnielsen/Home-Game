using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{


    private Rigidbody2D rigidbody;

    [SerializeField]
    private float playerSpeed = 10f;

    public CharacterController controller;

    public  Tilemap tilemap;

    ITilemap iTileMap;

    TileBase tileBase;

    public Tile tileToChange;

    public TileData tileData;
       

    float horizontalMove = 0f;

    


    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            rigidbody.velocity = new Vector3(playerSpeed, 0f, 0f);
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            rigidbody.velocity = new Vector3(-playerSpeed, 0f, 0f);
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (Input.GetAxisRaw("Vertical") > 0f)
        {
            rigidbody.velocity = new Vector3(0f, playerSpeed, 0f);
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            rigidbody.velocity = new Vector3(0f, -playerSpeed, 0f);
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else
        {
            rigidbody.velocity = new Vector3(0, 0, 0);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tile"))
        {
            //tilemap.GetInstantiatedObject(new Vector3Int((int)rigidbody.position.x, (int)rigidbody.position.y, 0));

            //tileBase = tilemap.GetTile(new Vector3Int((int)rigidbody.position.x, (int)rigidbody.position.y, 0));
            Vector3Int playerLocation = tilemap.layoutGrid.LocalToCell(new Vector3(rigidbody.position.x, rigidbody.position.y, 0f));
            tilemap.SetColor(playerLocation, Color.red);

        }
    }

    public void GetTileData(Vector3Int playerLocation, ITilemap tilemap, ref TileData tileData)
    {

    }
}
