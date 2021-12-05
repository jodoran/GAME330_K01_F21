using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapButton : MonoBehaviour, IDSTapListener
{
    public void OnScreenTapDown(Vector2 tapPosition)
    {
        if (DSTapRouter.RectangleContainsDSPoint(GetComponent<RectTransform>(), tapPosition))
        {
            GetComponent<Button>().onClick.Invoke();
        }
    }

    public void OnScreenDrag(Vector2 tapPosition)
    {
    }

    public void OnScreenTapUp(Vector2 tapPosition)
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
