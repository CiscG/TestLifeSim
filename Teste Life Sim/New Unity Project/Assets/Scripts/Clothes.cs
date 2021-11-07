using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clothes : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject player;
    ToggleGroup toggles;
    void Start()
    {
        toggles = GetComponent<ToggleGroup>();

    }
    // Update is called once per frame
    void Update()
    {
        //the button to close the wardrobe hud
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            player.GetComponent<Movement>().enabled = true;
            this.transform.parent.gameObject.SetActive(false);
        }

        //here the player wear the clothe he selected
        foreach(Toggle toggle in toggles.ActiveToggles())
        {
            if(toggle.isOn)
            {
                player.GetComponent<SpriteRenderer>().color = toggle.gameObject.transform.GetChild(2).GetComponent<Image>().color;
            }
        }

    }
}
