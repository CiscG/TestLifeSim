using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInteractions : MonoBehaviour
{
    // Start is called before the first frame update
    //variables to access the UI components that show the posisble interactions
    public GameObject e, t, text;

    //variables to activate the UI for store and for wardrobe;
    public GameObject store, wardrobe;

    //to say if the message box is active to use the timer for that
    public bool textActive = false;

    //timer variables
    float timeLeft, totalTime = 5;
    // Update is called once per frame

    private void Update()
    {
        #region timer
        //timer for the messages in the hud
        if (textActive && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            textActive = false;
            text.SetActive(false);
        }
        #endregion
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //This part just show in the UI the objects that the player can interact and what kinds of interactions are possible
        if(collision.tag == "Clothes" || collision.tag == "Wardrobe" || collision.tag == "Door")
        {
            e.SetActive(true);
        }
        else if (collision.tag == "Cash")
        {
            e.SetActive(true);
            t.SetActive(true);
        }        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        #region interactions
        // This are the interactions with some items and where the store UI and the Wardrobe UI are called
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collision.tag == "Clothes")
            {
                Debug.Log("Clothes");
                text.GetComponent<Text>().text = "I think those clothes doesn't fit my style";
                text.SetActive(true);
                timeLeft = totalTime;
                textActive = true;
            }
            if (collision.tag == "Wardrobe")
            {
                Debug.Log("Wardrobe");
                GetComponent<Movement>().enabled = false;
                wardrobe.SetActive(true);
                e.SetActive(false);
                t.SetActive(false);

            }
            if (collision.tag == "Door")
            {
                Debug.Log("Door");
                text.GetComponent<Text>().text = "You can't leave now";
                text.SetActive(true);
                timeLeft = totalTime;
                textActive = true;
            }
            if (collision.tag == "Cash")
            {
                Debug.Log("Cash");
                GetComponent<Movement>().enabled = false;
                store.SetActive(true);
                e.SetActive(false);
                t.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            //Here is where the chat with the shopkeeper is called
            if (collision.tag == "Cash")
            {
                Debug.Log("Cash");
                text.GetComponent<Text>().text = "If you need help come and ask";
                text.SetActive(true);
                timeLeft = totalTime;
                textActive = true;              
            }
        }
        #endregion

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //this part call out the UI messengers of interaction
        e.SetActive(false);
        t.SetActive(false);
    }
}
