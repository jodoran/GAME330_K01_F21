using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTapPrinter : MonoBehaviour, IDSTapListener
{
    public Camera screenCamera;
    private bool CanDrop = true;
    public SpriteRenderer PlayerRenderer;
    public Color disabledColor = Color.cyan;

    public void OnScreenTapDown(Vector2 tapPosition)
    {
        Debug.Log("ScreenTapDown at " + tapPosition);

        if (CanDrop == true)
        {
            GetWorldInfo(tapPosition);
            CanDrop = false;
            PlayerRenderer.color = disabledColor;
            Invoke("EnableDrop", 1f);
        }

    }

    void EnableDrop()
    {
        CanDrop = true;
        PlayerRenderer.color = Color.white;
    }

    public GameObject ball;

    private void GetWorldInfo(Vector2 tapPosition)
    {
        // Points from tapPosition are in screen space (0,0) to (Screen.width, Screen.height)
        // To work with these points in the world we need to convert it, using a camera as a reference
        Vector3 worldPos = screenCamera.ScreenToWorldPoint(tapPosition);
        print("World Space: " + worldPos);

        // To detect collisions from a mouse click, we can use Raycasts (in both 2d and 3d)
        RaycastHit info;

        // There are many different raycast functions, explore them all!
        if (Physics.Raycast(worldPos, screenCamera.transform.forward, out info))
        {
            print("Hit: " + info.transform.gameObject.name);

            Instantiate(ball, info.point, Quaternion.identity);
        }
    }

    public void OnScreenDrag(Vector2 tapPosition)
    {
        Debug.Log("OnScreenDrag: " + tapPosition);
        if (CanDrop == true)
        {
            GetWorldInfo(tapPosition);
            CanDrop = false;
            PlayerRenderer.color = disabledColor;
            Invoke("EnableDrop", 1f);
        }

    }

    public void OnScreenTapUp(Vector2 tapPosition)
    {
        Debug.Log("ScreenTapUp at " + tapPosition);
        if (CanDrop == true)
        {
            GetWorldInfo(tapPosition);
            CanDrop = false;
            PlayerRenderer.color = disabledColor;
            Invoke("EnableDrop", 1f);
        }
    }
}
