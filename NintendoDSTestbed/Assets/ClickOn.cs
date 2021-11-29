using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickOn : MonoBehaviour, IDSTapListener
{
    bool IsPressed = false;
    Button thisbutton;





    // Start is called before the first frame update
    void Start()
    {
        thisbutton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnScreenTapDown(Vector2 tapPosition)
    {
        if (DSTapRouter.RectangleContainsDSPoint(GetComponent<RectTransform>(), tapPosition))
        {
            IsPressed = true;
            //GetComponent<Button>().onClick;
            thisbutton.onClick.Invoke();
            Debug.Log("I've been clicked!");
            
        }
    }

    public void OnScreenDrag(Vector2 tapPosition)
    {
    }

    public void OnScreenTapUp(Vector2 tapPosition)
    {
        if (IsPressed)
        {
            IsPressed = false;

            Debug.Log("I've been released!");
        }
    }
}
