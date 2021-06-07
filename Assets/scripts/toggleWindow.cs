using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleWindow : MonoBehaviour {

    public Sprite sprite_closed, sprite_open;
    public GameObject note;
    private SpriteRenderer sr;
    private Renderer noteRenderer;

    public GameObject player;

    private Collider2D playerCollider;
    private Collider2D objectCollider;

    public bool windowClosed = false;

    void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        noteRenderer = note.GetComponent<Renderer>();
        playerCollider = player.GetComponent<Collider2D>();
        objectCollider = gameObject.GetComponent<Collider2D>();
    }

	// Update is called once per frame
	void Update ()
    {
        if (windowClosed && !noteRenderer.IsVisibleFrom(Camera.main)) 
        {
            // deactivate note
            note.transform.parent.gameObject.SetActive(false);
        }
        
        if (!windowClosed && Input.GetKeyDown("up") && objectCollider.IsTouching(playerCollider))
        {
            GetComponent<AudioSource>().Play();
            sr.sprite = sprite_closed;
            windowClosed = true;
            GetComponents<AudioSource>()[1].volume = 0.1f;
        }
    }
}