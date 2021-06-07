using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    private bool allWindowsClosed = false;
    private bool isWearingHat = false;
    private bool isWearingClothes = false;
    private bool nestComplete = false;
    private bool hasTea = false;
    private bool hasBook = false;
    private bool enteredNest = false;
    
    private GameObject[] windowFrames;
    private GameObject[] hidden;
    private GameObject hatNote;
    private GameObject[] clothingNotes;
    private GameObject blanketNote;
    private GameObject comforterNote;
    private GameObject teaNote;
    private GameObject bookNote;
    private GameObject snuggleNote;
    private GameObject endNote;

    private GameObject cats;
    private GameObject hat;
    private GameObject dresser;
    private GameObject blanketMound;
    private GameObject kettle;
    private GameObject bookStack;
    private GameObject nestBox;
    private GameObject player;
    private GameObject finalForm;

    void Awake()
    {
        windowFrames = GameObject.FindGameObjectsWithTag("windowFrame");
        cats = GameObject.Find("cats");
        hat = GameObject.Find("hat_knit");
        dresser = GameObject.Find("dresser");
        blanketMound = GameObject.Find("blanket_mound");
        kettle = GameObject.Find("electric_kettle");
        bookStack = GameObject.Find("book_stack");
        nestBox = GameObject.Find("nest_box");
        player = GameObject.Find("player");
        finalForm = GameObject.Find("final_form");

        hatNote = GameObject.FindGameObjectsWithTag("hat_note")[0];
        clothingNotes = GameObject.FindGameObjectsWithTag("clothing_note");
        blanketNote = GameObject.FindGameObjectsWithTag("blanket_note")[0];
        comforterNote = GameObject.FindGameObjectsWithTag("comforter_note")[0];
        teaNote = GameObject.FindGameObjectsWithTag("tea_note")[0];
        bookNote = GameObject.FindGameObjectsWithTag("book_note")[0];
        snuggleNote = GameObject.FindGameObjectsWithTag("snuggle_note")[0];
        endNote = GameObject.FindGameObjectsWithTag("end_note")[0];

        // Hide all hidden notes.
        hidden = GameObject.FindGameObjectsWithTag("hidden");
        foreach (GameObject obj in hidden)
        {
            obj.SetActive(false);
        }

        cats.transform.Find("cat_sitting").gameObject.SetActive(true);

        // Hide final form
        finalForm.SetActive(false);

        // Disable scripts
        hat.GetComponent<wearHat>().enabled = false;
        GameObject.Find("blanket").GetComponent<moveBlanket>().enabled = false;
        GameObject.Find("comforter_box").GetComponent<moveComforter>().enabled = false;
        dresser.GetComponent<wearClothes>().enabled = false;
        kettle.GetComponent<makeTea>().enabled = false;
        bookStack.GetComponent<getBook>().enabled = false;
        nestBox.GetComponent<enterNest>().enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        // Check if all windows are closed
        if (!allWindowsClosed)
        {
            bool allClosed = true;
            foreach (GameObject windowFrame in windowFrames)
            {
                if (!windowFrame.GetComponent<toggleWindow>().windowClosed)
                {
                    allClosed = false;
                }
            }
            // If all the windows have just been closed.
            if (allClosed) {
                // show hat note
                hatNote.transform.parent.gameObject.SetActive(true);
                // and enable hat script
                hat.GetComponent<wearHat>().enabled = true;
                // show next cat
                cats.transform.Find("cat_sitting").gameObject.SetActive(false);
                cats.transform.Find("cat_grooming").gameObject.SetActive(true);
            }
            // Update global variable for window state.
            allWindowsClosed = allClosed;
        }

        // Check if player is wearing hat
        // only check if hat script is enabled
        if (hat.GetComponent<wearHat>().enabled)
        {
            if (!isWearingHat)
            {
                bool localIsWearingHat = hat.GetComponent<wearHat>().isWearingHat;
                // if the player just put on the hat.
                if (!isWearingHat && localIsWearingHat)
                {
                    // Show clothing notes
                    foreach (GameObject clothingNote in clothingNotes)
                    {
                        clothingNote.transform.parent.gameObject.SetActive(true);
                    }
                    // and enable clothing script.
                    GameObject.Find("dresser").GetComponent<wearClothes>().enabled = true;

                    // show next cat
                    cats.transform.Find("cat_grooming").gameObject.SetActive(false);
                    cats.transform.Find("cat_walking").gameObject.SetActive(true);
                }
                // Update global variable
                isWearingHat = localIsWearingHat;
            }
        }

        // Check if player is wearing clothes
        // only check if wearClothes script is enabled
        if (dresser.GetComponent<wearClothes>().enabled)
        {
            if (!isWearingClothes)
            {
                bool localIsWearingClothes = dresser.GetComponent<wearClothes>().isWearingClothes;
                // if the player just put on clothes.
                if (localIsWearingClothes)
                {
                    // Show blanket note
                    blanketNote.transform.parent.gameObject.SetActive(true);
                    comforterNote.transform.parent.gameObject.SetActive(true);
                    // and enable move blanket and move comforter script
                    GameObject.Find("blanket").GetComponent<moveBlanket>().enabled = true;
                    GameObject.Find("comforter_box").GetComponent<moveComforter>().enabled = true;

                    // show next cat
                    cats.transform.Find("cat_walking").gameObject.SetActive(false);
                    cats.transform.Find("cat_playing").gameObject.SetActive(true);
                }
                // Update global variable
                isWearingClothes = localIsWearingClothes;
            }
        }

        // Check if nest complete
        if (blanketMound.activeSelf)
        {
            if (!nestComplete)
            {
                // check if local nest complete and show tea note
                bool localNestComplete = blanketMound.GetComponent<makeNest>().nestComplete;
                if (localNestComplete)
                {
                    // Show tea note
                    teaNote.transform.parent.gameObject.SetActive(true);
                    // and enable tea script
                    kettle.GetComponent<makeTea>().enabled = true;

                    kettle.GetComponent<AudioSource>().Play();

                    // show next cat
                    cats.transform.Find("cat_playing").gameObject.SetActive(false);
                    cats.transform.Find("cat_stretching").gameObject.SetActive(true);
                }
                // Update global variable
                nestComplete = localNestComplete;
            }
        }

        // Check if player has tea
        if (kettle.GetComponent<makeTea>().enabled)
        {
            if (!hasTea)
            {
                bool localHasTea = kettle.GetComponent<makeTea>().hasTea;
                if (localHasTea)
                {
                    // Deactivate tea note and blanket note
                    teaNote.transform.parent.gameObject.SetActive(false);
                    blanketNote.transform.parent.gameObject.SetActive(false);

                    // Show book note
                    bookNote.transform.parent.gameObject.SetActive(true);
                    // and enable book script
                    bookStack.GetComponent<getBook>().enabled = true;

                    // show next cat
                    cats.transform.Find("cat_stretching").gameObject.SetActive(false);
                    cats.transform.Find("cat_eating").gameObject.SetActive(true);

                    kettle.GetComponent<AudioSource>().Stop();
                    kettle.GetComponents<AudioSource>()[1].Play();

                }
                // Update global variable
                hasTea = localHasTea;
            }
        }

        // Check if player has book
        if (bookStack.GetComponent<getBook>().enabled)
        {
            if (!hasBook)
            {
                bool localHasBook = bookStack.GetComponent<getBook>().hasBook;
                if (localHasBook)
                {
                    // Show snuggle note
                    snuggleNote.transform.parent.gameObject.SetActive(true);
                    // Enable snuggle script
                    nestBox.GetComponent<enterNest>().enabled = true;
                }
                // Update global variable
                hasBook = localHasBook;
            }
        }

        // Check if player entered nest.
        if (nestBox.GetComponent<enterNest>().enabled)
        {
            if (!enteredNest)
            {
                bool localEnteredNest = nestBox.GetComponent<enterNest>().enteredNest;
                if (localEnteredNest)
                {
                    finalForm.SetActive(true);
                    finalForm.GetComponent<AudioSource>().Play();

                    float delay = finalForm.GetComponent<AudioSource>().clip.length;

                    finalForm.GetComponents<AudioSource>()[1].PlayDelayed(delay);

                    nestBox.GetComponent<enterNest>().enabled = false;
                    Camera.main.GetComponent<followPlayer>().enabled = false;
                    Camera.main.transform.parent = null;
                    player.SetActive(false);
                    blanketMound.SetActive(false);
                    GameObject.Find("comforter_mound").SetActive(false);
                    cats.SetActive(false);
                    

                    // Show final note
                    endNote.transform.parent.gameObject.SetActive(true);

                    enteredNest = true;
                }
                
            }
        }

    } // end of update
} // end of mono behavior
