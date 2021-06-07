using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBlanket : MonoBehaviour
{
    public GameObject blanketMound;
    public GameObject player;

    private Collider2D playerCollider;
    private Collider2D blanketCollider;

    // Start is called before the first frame update
    void Awake()
    {
        playerCollider = player.GetComponent<Collider2D>();
        blanketCollider = gameObject.GetComponent<Collider2D>();
        blanketMound.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up") && blanketCollider.IsTouching(playerCollider))
        {
            
            blanketMound.SetActive(true);
            blanketMound.transform.localPosition = new Vector3(-2.76f, -3.68f, -1);
            gameObject.SetActive(false);
        }
    }
}
