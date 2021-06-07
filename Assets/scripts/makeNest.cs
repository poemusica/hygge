using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeNest : MonoBehaviour
{

    public GameObject player;
    public GameObject comforterBundle;
    public GameObject comforterMound;

    private Collider2D playerCollider;
    private Collider2D blanketMoundCollider;

    public bool nestComplete = false;

    // Start is called before the first frame update
    void Awake()
    {
        playerCollider = player.GetComponent<Collider2D>();
        blanketMoundCollider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isBundleActive = comforterBundle.activeSelf;
        if (Input.GetKeyDown("up") && blanketMoundCollider.IsTouching(playerCollider) && isBundleActive)
        {
            // add comforterMound to pile
            comforterMound.GetComponent<AudioSource>().Play();
            comforterBundle.SetActive(false);
            comforterMound.transform.localPosition = new Vector3(-3f, -3.54f, -1);
            nestComplete = true;
        }
    }
}
