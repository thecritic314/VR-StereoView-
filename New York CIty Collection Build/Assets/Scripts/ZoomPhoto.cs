using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomPhoto : MonoBehaviour
{
    public GameObject photoLeft;
    public GameObject photoRight;

    public GameObject zoomInBtn;
    public GameObject zoomOutBtn;

    // scale delta
    public float scale;
    Vector3 scaleChange;

    private int count = 1;

    // original scale
    Vector3 originalScaleLeft;
    Vector3 originalScaleRight;

    bool reversed=false;

    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(scale,  scale, 0);
        originalScaleLeft = photoLeft.transform.localScale;
        originalScaleRight = photoRight.transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void zoomIn() {
        if (count < 4) {
            count = count + 1;
            photoLeft.transform.localScale += scaleChange;
            photoRight.transform.localScale += scaleChange;
        }
    }

    public void zoomOut() {
        if (count > -1) {
            count = count - 1;
            photoLeft.transform.localScale -= scaleChange;
            photoRight.transform.localScale -= scaleChange;
        }
    }

    public void resetZoom() {
        count = 1;
        photoLeft.transform.localScale = originalScaleLeft;
        photoRight.transform.localScale = originalScaleRight;
    }
    public void zoomAllOut(){
        zoomOut();
        zoomOut();
        zoomOut();
        zoomOut();
    }
    public void toogleReverseZoom(){
        if(!reversed){
            zoomAllOut();
            reversed=true;
        }
        else{
            resetZoom();
            reversed = false;
        }
    }
}
