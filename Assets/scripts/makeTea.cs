using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeTea : MonoBehaviour
{
    public GameObject player;
    public GameObject teaCup;

    public bool hasTea = false;

    private Collider2D playerCollider;
    private Collider2D objectCollider;

    private SpriteRenderer playerSpriteRenderer;
    private SpriteRenderer teaSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        Color redish = new Color(0.9245283f, 0.5276f, 0.5276789f, 1f);
        Renderer m_renderer = GetComponent<Renderer>();
        m_renderer.material.SetVector("_EmissionColor", redish);

        playerCollider = player.GetComponent<Collider2D>();
        objectCollider = gameObject.GetComponent<Collider2D>();

        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        teaSpriteRenderer = teaCup.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasTea && Input.GetKeyDown("up") && objectCollider.IsTouching(playerCollider))
        {

            teaCup.transform.parent = player.transform;
            Renderer m_renderer = GetComponent<Renderer>();
            m_renderer.material.SetVector("_EmissionColor", Color.white);
            hasTea = true;
        }
        if (hasTea)
        {
            // render teacup in player hand
            float xoffset = 1.77f;
            float yoffset = -0.76f;
            float zoffset = -3f;
         
            if (playerSpriteRenderer.flipX)
            {
                teaSpriteRenderer.flipX = false;
                teaCup.transform.position = new Vector3((float)player.transform.position.x - xoffset, (float)player.transform.position.y + yoffset, zoffset);
            }
            else
            {
                teaSpriteRenderer.flipX = true;
                teaCup.transform.position = new Vector3((float)player.transform.position.x + xoffset, (float)player.transform.position.y + yoffset, zoffset);
            }

        }

    }
}
