using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemPickUp : MonoBehaviour
{
    private Vector3 dragOffset;

    private void OnMouseDown()
    {
        dragOffset = this.transform.position - GetMousePosition();
    }

    private void OnMouseDrag()
    {
        this.transform.position = GetMousePosition() + dragOffset;
    }

    private Vector3 GetMousePosition()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }
}
