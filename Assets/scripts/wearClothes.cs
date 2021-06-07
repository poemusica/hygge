using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wearClothes : MonoBehaviour
{
    public GameObject player;

    private Collider2D playerCollider;
    private Collider2D objectCollider;
    public bool isWearingClothes = false; // accessed by gameManager script
    private bool clothingNotesVisible = true;
    private GameObject[] clothingNotes;

    private GameObject sweater;
    private GameObject woolies;
    private SpriteRenderer playerSpriteRenderer;
    private SpriteRenderer sweaterSpriteRenderer;
    private SpriteRenderer wooliesSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = player.GetComponent<Collider2D>();
        objectCollider = gameObject.GetComponent<Collider2D>();
        clothingNotes = GameObject.FindGameObjectsWithTag("clothing_note");

        sweater = GameObject.Find("sweater");
        woolies = GameObject.Find("woolies");

        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        sweaterSpriteRenderer = sweater.GetComponent<SpriteRenderer>();
        wooliesSpriteRenderer = woolies.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWearingClothes && Input.GetKeyDown("up") && objectCollider.IsTouching(playerCollider))
        {
            GetComponent<AudioSource>().Play();
            isWearingClothes = true;
            sweater.transform.parent = player.transform;
            sweater.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -2f);

            woolies.transform.parent = player.transform;
            sweater.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -2f);
        }
        if (isWearingClothes)
        {
            // woolies offsets
            float xoffset = -0.9360313f;
            float yoffset = -2.861794f;
            float zoffset = -2f;


            if (playerSpriteRenderer.flipX)
            {
                sweaterSpriteRenderer.flipX = true;
                wooliesSpriteRenderer.flipX = true;

                woolies.transform.position = new Vector3((float)player.transform.position.x - xoffset, (float)player.transform.position.y + yoffset, zoffset);
            }
            else
            {
                sweaterSpriteRenderer.flipX = false;
                wooliesSpriteRenderer.flipX = false;

                woolies.transform.position = new Vector3((float)player.transform.position.x + xoffset, (float)player.transform.position.y + yoffset, zoffset);
            }
        }
        // If a note is visible and player is wearing clothes
        if (clothingNotesVisible && isWearingClothes)
        { 
            bool allInactive = true;
            
            foreach (GameObject clothingNote in clothingNotes)
            {
                // if the note is not visible and the note is active
                if (!clothingNote.GetComponent<Renderer>().IsVisibleFrom(Camera.main) && clothingNote.activeSelf)
                {
                    allInactive = false;
                    // deactivate it
                    clothingNote.transform.parent.gameObject.SetActive(false);
                }
            }
            clothingNotesVisible = !allInactive;
        }
    }
}
