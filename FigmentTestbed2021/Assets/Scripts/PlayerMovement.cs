using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8.0f;

    // Update is called once per frame
    void Update()
    {
        // Move the player by pressing left or right
        if (FigmentInput.GetButton(FigmentInput.FigmentButton.LeftButton))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else if (FigmentInput.GetButton(FigmentInput.FigmentButton.RightButton))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        // If we press the action button, interact with objects
        if (FigmentInput.GetButton(FigmentInput.FigmentButton.ActionButton))
        {
            //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

    }
}
