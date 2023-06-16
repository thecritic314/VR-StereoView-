using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class HideShow : MonoBehaviour
{
    // hide/show button
    public GameObject hideShowButton;

    // buttons to hide
    public GameObject[] buttons;

    // boolean hide/show toggle flag
    bool hide = false;

    // text reverse
    public TextMesh hideShowText;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("TurnOff", 1);
    }

    public void toggleButtons() {
        if (hide) {
            TurnOn();
            hideShowText.text = "HIDE MENU";

        }
        else {
            hide = true;
            TurnOff();
            hideShowText.text = "SHOW MENU";
        }
    }

    public void TurnOn()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(true);
        }
        hideShowButton.SetActive(true);
        hide = false;
    }

    public void TurnOff()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
    }

    public void hideWithEye()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
        hideShowButton.SetActive(false);
        hide = true;
    }

    // // Update is called once per frame
    // void Update()
    // {
    // }
    // public void OnPointerEnter(PointerEventData eventData)
    // {
    //     Debug.Log("OnPointerEnter");
    //     Debug.Log(hide);
    // }


    // public void OnPointerExit(PointerEventData eventData)
    // {
    //     Debug.Log("hoho");
    // }
    // public void OnPointerClick(PointerEventData pointerEventData)
    // {
    //     Debug.Log("fefe");
    // }
}
