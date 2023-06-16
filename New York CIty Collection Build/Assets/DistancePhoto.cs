using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistancePhoto : MonoBehaviour
{

    // photo holders
    public GameObject photoLeft;
    public GameObject photoRight;

    // position delta
    public float scale;
    Vector3 positionChange;


    private int count = 0;

    // original position
    Vector3 originalPositionLeft;
    Vector3 originalPositionRight;

    // Start is called before the first frame update
    void Start()
    {
        positionChange = new Vector3(0,  0, scale);
        originalPositionLeft = photoLeft.transform.localPosition;
        originalPositionRight = photoRight.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void moveCloser()
    {
        if (count < 7) {
            count = count + 1;
            photoLeft.transform.localPosition += positionChange;
            photoRight.transform.localPosition += positionChange;
        }

    }

    public void moveFurther()
    {
        if (count > -7) {
            count = count - 1;
            photoLeft.transform.localPosition -= positionChange;
            photoRight.transform.localPosition -= positionChange;
        }
    }

    public void resetDist()
    {
        count = 0;
    }

    public void OnSliderValueChanged(float value)
    {
        Vector3 newPositionChange = new Vector3(0,  0, value);
        photoLeft.transform.localPosition = originalPositionLeft + newPositionChange;
        photoRight.transform.localPosition = originalPositionRight + newPositionChange;
    }
}
