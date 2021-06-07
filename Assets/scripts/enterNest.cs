using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterNest : MonoBehaviour
{
    public GameObject player;
    public Sprite sitSprite;
    public Sprite sackSprite;
    public Sprite openBookSprite;
    public bool enteredNest = false;

    private Collider2D playerCollider;
    private Collider2D objectCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = player.GetComponent<Collider2D>();
        objectCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!enteredNest && Input.GetKeyDown("up") && objectCollider.IsTouching(playerCollider))
        {
            enteredNest = true;
        }
    }
}
