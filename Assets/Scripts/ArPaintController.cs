using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArPaintController : MonoBehaviour
{
    public GameObject paintTrailPrefab;

    GameObject paintTrailInstance;

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0) // If at least one finger touch screen
        {
            Vector2 screenTouchPos = Input.GetTouch(0).position; // Determine where on screen finger is placed

            Vector3 worldPos = Camera.current.ScreenToWorldPoint(new Vector3(screenTouchPos.x, screenTouchPos.y, 2f));

            if(paintTrailInstance == null) // If nmot created paint yet
            {
                paintTrailInstance = Instantiate(paintTrailPrefab, worldPos, paintTrailPrefab.transform.rotation); // creating the paint
            }

            paintTrailInstance.transform.position = worldPos; // Keep updating (moving) pos of paint as we move our finger/phone
        }
        else
        {
            paintTrailInstance = null;
        }
    }
}
