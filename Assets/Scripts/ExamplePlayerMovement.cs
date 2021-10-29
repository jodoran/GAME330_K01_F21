using UnityEngine;
using UnityEngine.UI;

public class ExamplePlayerMovement : MonoBehaviour {

    public float turnSpeed = 120.0f;
    public float moveSpeed = 8.0f;

    private Text myScore;
    private float timeCount = 0;
    private int getCount = 0;
    private int finish = 1;

    private void Start()
    {
        myScore = GameObject.Find("Score1").GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        if(finish == 0)
        {
            timeCount += Time.deltaTime;
            SetCountText();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target(T)"))
        {
            other.gameObject.SetActive(false);
            getCount += 1;
        }
    }

    void SetCountText()
    {
        myScore.text = "[Get Count]:" + getCount.ToString() + "[Time]:" + timeCount.ToString();
        if (getCount >= 3)
        {
            myScore.text = "Victory!" + "[Time]:" + timeCount.ToString();
            finish = 1;
        }
    }
    // Update is called once per frame
    void Update () 
    {
        // Rotate the player by pressing left or right
        if (FigmentInput.GetButton(FigmentInput.FigmentButton.LeftButton))
            //how to make player move only to the left>
        {
            //transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            var vel = GetComponent<Rigidbody>().velocity;
            vel.x = -1.0f * moveSpeed;
            GetComponent<Rigidbody>().velocity = vel;
        }
        //how to make player move only to the right>

        else if (FigmentInput.GetButton(FigmentInput.FigmentButton.RightButton))
        {
            //transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            var vel = GetComponent<Rigidbody>().velocity;
            vel.x = moveSpeed;
            GetComponent<Rigidbody>().velocity = vel;
        }
        else
        {
            var vel = GetComponent<Rigidbody>().velocity;
            vel.x = 0.0f;
            GetComponent<Rigidbody>().velocity = vel;
        }

        // If we press the action button, move forward
        //how to transform Player to playable brick??
        if (FigmentInput.GetButton(FigmentInput.FigmentButton.ActionButton))
        {
            //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            var vel = GetComponent<Rigidbody>().velocity;
            vel.x = 2 * moveSpeed;
            GetComponent<Rigidbody>().velocity = vel;
        }
    }
}
