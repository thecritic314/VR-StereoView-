using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    //next arrow photo button
    public GameObject arrowRight;
    //previous arrow photo button
    public GameObject arrowLeft;

    //the folder menu scene name
    public string folderName = "gallery";

    //Left Sprite
    private string leftFolder= "left";
    public SpriteRenderer spriteRendLeft;
    private Sprite[] spritesL;

    //Right Sprite
    private string rightFolder = "right";
    public SpriteRenderer spriteRendRight;
    private Sprite[] spritesR;


    //Background Sprite
    private string backFolder = "back";
    private Sprite[] spritesB;
    private bool backFlag = false;


    public GameObject firstSlide;
    public GameObject lastSlide;

    // current ind: -1 welcome page, 0 <-> sprLen-1 images, sprLen endPage
    int index = 0;

    // length
    int sprLen = 0;

    // script to access hiding the menu
    public HideShow hide_show_script;


    // text reverse
    public TextMesh reverseText;

    // info panel show/hide TextMesh
    // info text block
    private bool infoPanelFlag;
    public GameObject infoPanel;
    public GameObject infoText;
    public string[] information;



    // Start is called before the first frame update
    void Start()
    {
        index = -1;

        leftFolder = folderName + "/" + leftFolder;
        rightFolder = folderName + "/" + rightFolder;
        backFolder = folderName + "/" + backFolder;

        Debug.Log(leftFolder);

        spritesL = Resources.LoadAll<Sprite>(leftFolder);
        spritesR = Resources.LoadAll<Sprite>(rightFolder);
        spritesB = Resources.LoadAll<Sprite>(backFolder);

        sprLen = spritesL.Length;

        Debug.Log("sprLen: " + sprLen);

        firstSlide.SetActive(true);

        hide_show_script = hide_show_script.GetComponent<HideShow>();

        infoPanelFlag = false;
    }

    public void leftClick()
    {
        Debug.Log("LEFT Index before: " + index);
        index = index - 1;
        Debug.Log("Index after: " + index);
        if (index == -1) { // index is -1, welcome page
            firstSlide.SetActive(true);
            spriteRendLeft.gameObject.SetActive(false);
            spriteRendRight.gameObject.SetActive(false);

            hide_show_script.hideWithEye();
        }
        else if (index == -2) {
            index = sprLen;

            firstSlide.SetActive(false);
            lastSlide.SetActive(true);


            hide_show_script.hideWithEye();
        }
        else {
            lastSlide.SetActive(false);
            spriteRendLeft.gameObject.SetActive(true);
            spriteRendRight.gameObject.SetActive(true);
            spriteRendLeft.sprite = spritesL[index];
            spriteRendRight.sprite = spritesR[index];


            hide_show_script.TurnOn();
        }
    }

    public void rightClick()
    {
        Debug.Log("RIGHT Index before: " + index);
        index = index + 1;
        Debug.Log("Index after: " + index);
        if (index == sprLen) {
            spriteRendLeft.gameObject.SetActive(false);
            spriteRendRight.gameObject.SetActive(false);
            lastSlide.SetActive(true);


            hide_show_script.hideWithEye();
        }
        else if (index == sprLen + 1) {
            index = -1;
            lastSlide.SetActive(false);
            firstSlide.SetActive(true);
            hide_show_script.hideWithEye();
        }
        else {
            firstSlide.SetActive(false);
            spriteRendLeft.gameObject.SetActive(true);
            spriteRendRight.gameObject.SetActive(true);
            spriteRendLeft.sprite = spritesL[index];
            spriteRendRight.sprite = spritesR[index];

            hide_show_script.TurnOn();
        }
    }

    private void getFront() {
        spriteRendLeft.sprite = spritesL[index];
        spriteRendRight.sprite = spritesR[index];
    }

    private void getBack() {
        spriteRendLeft.sprite = spritesB[index];
        spriteRendRight.sprite = spritesB[index];
    }

    public void toggleBack() {
        if (index >= 0 && index < sprLen) {
            if (backFlag) {
                getFront();
                backFlag = false;
                reverseText.text = "BACK";
            }
            else {
                getBack();
                backFlag = true;
                reverseText.text = "FRONT";
            }
        }
    }

    public void goToFirst()
    {
        index = -1;

        spriteRendLeft.gameObject.SetActive(false);
        spriteRendRight.gameObject.SetActive(false);
        lastSlide.SetActive(false);
        firstSlide.SetActive(true);
    }


    public void showInfoText() {
        infoPanel.SetActive(true);
        infoText.SetActive(true);

        if (index == -1 || index == sprLen) {
            infoText.GetComponent<TextMesh>().text = information[sprLen].Replace("\\n", "\n");
        }
        else {
            infoText.GetComponent<TextMesh>().text = information[index].Replace("\\n", "\n");
        }
    }

    public void hideInfoText() {
        infoPanel.SetActive(false);
        infoText.SetActive(false);
        infoPanelFlag = false;
    }

    public void toggleInfoText() {
        if (infoPanelFlag) {
            hideInfoText();
            infoPanelFlag = false;
        }
        else {
            showInfoText();
            infoPanelFlag = true;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
