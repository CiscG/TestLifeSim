using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;

public class Store : MonoBehaviour
{
    public List<string> clothes = new List<string>();
    GameObject clotheNow;
    GameObject wardrobe;
    public GameObject prefab;
    public GameObject player;
    public ToggleGroup toggles;
    // Start is called before the first frame update
    void Start()
    {
        #region listCreation
        //the creation of the list of items it can be more complex the hud for the items accept all needed for it
        clothes.Add("red");
        clothes.Add("green");
        clothes.Add("blue");
        clothes.Add("black");
        clothes.Add("grey");
        clothes.Add("magenta");
        clothes.Add("yellow");
        #endregion
        //this points where the UI object is and put inside a variable
        wardrobe = transform.parent.parent.GetChild(2).GetChild(0).gameObject;

        #region togglesCreationforstore
        //Intance the items in the store hud in the game
        foreach (string clothe in clothes)
        {
            clotheNow = Instantiate (prefab, transform);
            clotheNow.gameObject.transform.GetChild(1).GetComponent<Text>().text = clothe;
            clotheNow.GetComponent<Toggle>().group = GetComponent<ToggleGroup>();

            //this script transform the string to become acceptable to become a variable color
            Color myColor = Color.clear;
            ColorUtility.TryParseHtmlString(clothe, out myColor);
            clotheNow.gameObject.transform.GetChild(2).GetComponent<Image>().color = myColor;
        }
        toggles = GetComponent<ToggleGroup>();
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            player.GetComponent<Movement>().enabled = true;
            this.transform.parent.gameObject.SetActive(false);
        }
    }

    public void ItemsPurchase()
    {
        #region storeSystem
        foreach (Toggle toggle in toggles.ActiveToggles())
        {
            if(toggle.isOn && (player.GetComponent<Movement>().cash >= Convert.ToSingle(toggle.gameObject.transform.GetChild(1).GetChild(0).GetComponent<Text>().text)))
            {
                player.GetComponent<Movement>().cash -= Convert.ToSingle(toggle.gameObject.transform.GetChild(1).GetChild(0).GetComponent<Text>().text);
                player.GetComponent<Movement>().money.GetComponent<Text>().text = player.GetComponent<Movement>().cash.ToString();
                string color = toggle.gameObject.transform.GetChild(1).GetComponent<Text>().text;
                clothes.Remove(color);
                clotheNow = Instantiate(prefab, wardrobe.transform);
                clotheNow.transform.GetChild(1).GetComponent<Text>().text = color;

                //this script transform the string to become acceptable to become a variable color
                Color myColor = Color.clear;
                ColorUtility.TryParseHtmlString(color, out myColor);
                clotheNow.gameObject.transform.GetChild(2).GetComponent<Image>().color = myColor;

                //set the price off in the hud
                clotheNow.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
                clotheNow.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
                clotheNow.GetComponent<Toggle>().group = wardrobe.GetComponent<ToggleGroup>();
                Destroy(toggle.gameObject);

            }
        }
        #endregion
    }
}
