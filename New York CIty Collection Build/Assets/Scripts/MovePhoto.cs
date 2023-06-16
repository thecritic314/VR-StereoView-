using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePhoto : MonoBehaviour
{
    // photos for left and right eye
    public GameObject photoLeft;
    public GameObject photoRight;

    // the arrow buttons
    public GameObject moveUp;
    public GameObject moveDown;
    public GameObject moveRight;
    public GameObject moveLeft;

    public float delta;

    Vector3 vectUp;
    Vector3 vectDown;
    Vector3 vectRight;
    Vector3 vectLeft;

    // original position
    Vector3 originalLeftPos;
    Vector3 originalRightPos;

    // boundaries
    private int horizontal = 0;
    private int vertical = 0;

    // Start is called before the first frame update
    void Start()
    {
        vectUp = new Vector3(0, delta, 0);
        vectDown = new Vector3(0, -delta, 0);
        vectRight = new Vector3(-delta, 0, 0);
        vectLeft = new Vector3(delta, 0, 0);

        originalLeftPos = photoLeft.transform.position;
        originalRightPos = photoRight.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void upShift() {
        if (vertical < 3) {
            vertical = vertical + 1;
            photoLeft.transform.position += vectUp;
            photoRight.transform.position += vectUp;
        }
    }

    public void downShift() {
        if (vertical > -3) {
            vertical = vertical - 1;
            photoLeft.transform.position += vectDown;
            photoRight.transform.position += vectDown;
        }
    }

    public void rightShift() {
        if (horizontal < 3) {
            horizontal = horizontal + 1;
            photoLeft.transform.position += vectRight;
            photoRight.transform.position += vectRight;
        }
    }

    public void leftShift() {
        if (horizontal > -3) {
            horizontal = horizontal - 1;
            photoLeft.transform.position += vectLeft;
            photoRight.transform.position += vectLeft;
        }
    }

    public void resetPos() {
        photoLeft.transform.position = originalLeftPos;
        photoRight.transform.position = originalRightPos;
        horizontal = 0;
        vertical = 0;
    }
}
