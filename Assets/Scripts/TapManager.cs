using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapManager : MonoBehaviour
{

    private TappableObj _previouslyTapped;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Desktop
        {
            handleTap(Input.mousePosition);
        }
        else if (Input.touchCount > 0) // Mobile
        {
            handleTap(Input.GetTouch(0).position);
        }
    }

    void handleTap(Vector3 screenPosition)
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
        {
            position = screenPosition
        };

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);
        foreach (RaycastResult result in raycastResults)
        {
            TappableObj tappable = result.gameObject.GetComponentInParent<TappableObj>();
            if (tappable != null)
            {
                if (_previouslyTapped != null) {
                    _previouslyTapped.reset();
                }
                tappable.tap();
                _previouslyTapped = tappable;
                break; // Handle only the first mouse/finger
            }
        }
    }
}
