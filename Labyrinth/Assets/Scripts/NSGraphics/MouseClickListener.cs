﻿using Labyrinth;
using NSGraphics;
using UnityEngine;

public class MouseClickListener : MonoBehaviour
{
    public event TileClickHandler TileClicked;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Vector3 position;
            if (Physics.Raycast(ray, out hit, 100))
            {
                position = hit.transform.gameObject.transform.parent.gameObject.transform.position;
                if (TileClicked != null)
                    TileClicked(new IntVector2((int) position.x, (int) position.z));
            }
        }
    }
}