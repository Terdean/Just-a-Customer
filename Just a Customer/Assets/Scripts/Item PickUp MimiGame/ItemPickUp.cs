using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemPickUp : MonoBehaviour
{
    private Vector3 dragOffset;
    public ItemPickUpWalls walls;
    public GameObject center;

    private void OnMouseDown()
    {
        if (!walls.isObjectTouchedWall) dragOffset = this.transform.position - GetMousePosition();
        else if (walls.isObjectTouchedWall) transform.position = Vector3.MoveTowards(transform.position, center.transform.position, 1f);
    }

    private void OnMouseDrag()
    {
        if (!walls.isObjectTouchedWall) this.transform.position = GetMousePosition() + dragOffset;
        else if (walls.isObjectTouchedWall) transform.position = Vector3.MoveTowards(transform.position, center.transform.position, 1f);
    }

    private Vector3 GetMousePosition()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }
}
