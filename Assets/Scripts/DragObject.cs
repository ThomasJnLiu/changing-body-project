using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public Material inactiveMaterial;
    private Vector3 mOffset;

    private float mZCoord;

    public GameObject drawing, violin, prayer;

    public float drawingBar = 100f, violinBar = 100f, prayerBar = 100f;

    public int touching = 0;

    [SerializeField]
    public bool canDrag = true; 

    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponentInChildren<Renderer>();
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    // Update is called once per frame
    void Update()
    {
        switch(touching){
            case 0:
                drawingBar -= 0.1f;
                violinBar -= 0.1f;
                prayerBar -= 0.1f;
                break;

            //touching drawing
            case 1:
                if(drawingBar <= 100){
                    drawingBar += 0.3f;
                }
                
                violinBar -= 0.1f;
                prayerBar -= 0.1f;
                break;

            //touching violin
            case 2:
            if(violinBar <= 100){
                violinBar += 0.3f;
            }
                drawingBar -= 0.1f;
                prayerBar -= 0.1f;
                break;

            //touching prayer
            case 3:
            if(prayerBar <= 100){
                prayerBar += 0.3f;
            }
                drawingBar -= 0.1f;
                violinBar -= 0.1f;
                break;
        }

        if(prayerBar <= 0 || violinBar <= 0 || drawingBar<=0){
            canDrag = false;   
            rend.material = inactiveMaterial; 
        }
    }

    void OnCollisionEnter(Collision platform){
        switch(platform.gameObject.name){
            case "Drawing":
            Debug.Log("drawing");
            touching = 1;
                break;
            case "Violin":
            Debug.Log("Violin");
            touching = 2;
                break;
            case "Prayer":
            Debug.Log("Prayer");
            touching = 3;
                break;
        }
    }
    void OnMouseDown(){
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }
    void OnMouseDrag(){
        if(canDrag){
            transform.position = GetMouseWorldPos() + mOffset;
        }
    }

    private Vector3 GetMouseWorldPos(){
        //pixel coordinates
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
