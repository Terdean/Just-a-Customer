using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemPickUp : MonoBehaviour
{
    private Vector3 dragOffset;
    public ItemPickUpWalls walls;

    private void OnMouseDown()
    {
        if(!walls.isObjectTouchedWall) dragOffset = this.transform.position - GetMousePosition();
    }

    private void OnMouseDrag()
    {
        if (!walls.isObjectTouchedWall) this.transform.position = GetMousePosition() + dragOffset;
    }

    private Vector3 GetMousePosition()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }
}
