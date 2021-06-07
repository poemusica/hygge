using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wearHat : MonoBehaviour
{
    public GameObject player;
    public GameObject note;

    private Renderer note_Renderer;
    private SpriteRenderer playerSpriteRenderer;
    private SpriteRenderer hatSpriteRenderer;
    private Collider2D playerCollider;
    private Collider2D objectCollider;
    public bool isWearingHat;
    private Quaternion newRotation;

    // Start is called before the first frame update
    void Awake()
    {
        isWearingHat = false;
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        hatSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        note_Renderer = note.GetComponent<Renderer>();
        playerCollider = player.GetComponent<Collider2D>();
        objectCollider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up") && objectCollider.IsTouching(playerCollider))
        {
            GetComponent<AudioSource>().Play();
            isWearingHat = true;
            transform.localScale = new Vector3(0.2f, 0.15f, 1f);
            gameObject.transform.parent = player.transform;
        }
        if (isWearingHat)
        {
            if (!note_Renderer.IsVisibleFrom(Camera.main))
            {
                // deactivate note
                note.transform.parent.gameObject.SetActive(false);
            }

            float xoffset = 1f;
            float yoffset = 3.2f;
            float zoffset = -2f;

            
            if (playerSpriteRenderer.flipX)
            {
                hatSpriteRenderer.flipX = true;
                transform.position = new Vector3((float)player.transform.position.x - xoffset, (float)player.transform.position.y + yoffset, zoffset);

            }
            else
            {
                hatSpriteRenderer.flipX = false;
                transform.position = new Vector3((float)player.transform.position.x + xoffset, (float)player.transform.position.y + yoffset, zoffset);

            }
        } 
    }
}
