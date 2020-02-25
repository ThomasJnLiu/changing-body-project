using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampName : MonoBehaviour
{
    public DragObject dragobject;
    public Text drawingLabel, musicLabel, prayerLabel;
    public Slider drawingSlider, musicSlider, prayerSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
            musicLabel.transform.position = namePos + new Vector3(0, 60f, 0f);
            drawingLabel.transform.position = namePos + new Vector3(0, 40f, 0f);
            prayerLabel.transform.position = namePos + new Vector3(0, 20f, 0f);

            drawingSlider.transform.position = namePos + new Vector3(70f, 50f, 0f);
            musicSlider.transform.position = namePos + new Vector3(70f, 70f, 0f);
            prayerSlider.transform.position = namePos + new Vector3(70f, 30f, 0f);

            drawingSlider.value = dragobject.drawingBar/100;
            musicSlider.value = dragobject.violinBar/100;
            prayerSlider.value = dragobject.prayerBar/100;
    }
}
