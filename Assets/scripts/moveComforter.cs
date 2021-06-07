using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveComforter : MonoBehaviour
{
    public GameObject player;
    public GameObject comforter;
    public GameObject bundle;
    public GameObject note;


    public bool holdingBundle = false;

    private Collider2D playerCollider;
    private Collider2D objectCollider;

    private Renderer noteRenderer;
    private SpriteRenderer playerSpriteRenderer;
    private SpriteRenderer bundleSpriteRenderer;


    // Start is called before the first frame update
    void Awake()
    {
        playerCollider = player.GetComponent<Collider2D>();
        objectCollider = gameObject.GetComponent<Collider2D>();
        noteRenderer = note.GetComponent<Renderer>();
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        bundleSpriteRenderer = bundle.GetComponent<SpriteRenderer>();
        bundle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!holdingBundle)
        {
            if (Input.GetKeyDown("up") && objectCollider.IsTouching(playerCollider))
            {
                GetComponent<AudioSource>().Play();
                holdingBundle = true;
                bundle.SetActive(true);
                bundle.transform.parent = player.transform;
                bundle.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -5);
                comforter.SetActive(false);
            }
        }
        
        if (holdingBundle)
        {
            bundleSpriteRenderer.flipX = playerSpriteRenderer.flipX;

            if (!noteRenderer.IsVisibleFrom(Camera.main))
            {
                // deactivate note
                note.transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
