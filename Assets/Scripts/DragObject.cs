using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;

    private float mZCoord;

    public GameObject drawing, violin, prayer;

    public float drawingBar = 100f, violinBar = 100f, prayerBar = 100f;

    public int touching = 0;
    // Start is called before the first frame update
    void Start()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    // Update is called once per frame
    void Update()
    {
        switch(touching){
            case 0:
                drawingBar -= 0.5f;
                violinBar -= 0.5f;
                prayerBar -= 0.5f;
                break;

            case 1:
                drawingBar += 0.5f;
                violinBar -= 0.5f;
                prayerBar -= 0.5f;
                break;

            case 2:
                drawingBar -= 0.5f;
                violinBar += 0.5f;
                prayerBar -= 0.5f;
                break;

            case 3:
                drawingBar -= 0.5f;
                violinBar -= 0.5f;
                prayerBar += 0.5f;
                break;
        }
    }

    void OnCollision(){
        
    }
    void OnMouseDown(){
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }
    void OnMouseDrag(){
        transform.position = GetMouseWorldPos() + mOffset;
    }

    private Vector3 GetMouseWorldPos(){
        //pixel coordinates
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
