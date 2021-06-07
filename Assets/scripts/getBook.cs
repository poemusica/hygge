using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getBook : MonoBehaviour
{
    public GameObject player;
    public GameObject book;
    public GameObject note;

    public bool hasBook = false;

    private Collider2D playerCollider;
    private Collider2D objectCollider;

    private SpriteRenderer playerSpriteRenderer;
    private SpriteRenderer bookSpriteRenderer;

    private Renderer note_Renderer;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = player.GetComponent<Collider2D>();
        objectCollider = GetComponent<Collider2D>();


        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        bookSpriteRenderer = book.GetComponent<SpriteRenderer>();

        note_Renderer = note.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasBook && Input.GetKeyDown("up") && objectCollider.IsTouching(playerCollider))
        {
            book.transform.parent = player.transform;
            GetComponent<AudioSource>().Play();
            hasBook = true;
        }
        if (hasBook)
        {
            if (!note_Renderer.IsVisibleFrom(Camera.main))
            {
                // deactivate note
                note.transform.parent.gameObject.SetActive(false);
            }

            // render book on player hand
            float xoffset = -1.005f;
            float yoffset = -0.315f;
            float zoffset = -3f;
            float zrotation = 24.733f;
            Quaternion newRotation;

            if (playerSpriteRenderer.flipX)
            {
                bookSpriteRenderer.flipX = true;
                book.transform.position = new Vector3((float)player.transform.position.x - xoffset, (float)player.transform.position.y + yoffset, zoffset);
                newRotation = Quaternion.Euler(0, 0, -zrotation);
                book.transform.rotation = newRotation;
            }
            else
            {
                bookSpriteRenderer.flipX = false;
                book.transform.position = new Vector3((float)player.transform.position.x + xoffset, (float)player.transform.position.y + yoffset, zoffset);
                newRotation = Quaternion.Euler(0, 0, zrotation);
                book.transform.rotation = newRotation;
            }
        }
    }
}
