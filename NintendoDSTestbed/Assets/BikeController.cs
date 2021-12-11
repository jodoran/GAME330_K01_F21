using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BikeController : MonoBehaviour
{
    public GameManager gameManager;
    bool onGround;
    public int maxAngle;
    public int jumpHeight;
    public Transform StartPosition;
    //Public Variables
    [Header("Wheel Colliders")]
    public WheelCollider FL;

    public WheelCollider BL;


    [Header("Wheel Transforms")]
    public Transform Fl;
    public Transform Bl;

    [Header("Wheel Transforms Rotations")]
    public Vector3 FL_Rotation;
    public Vector3 BL_Rotation;

    [Header("Car Settings")]
    public float Motor_Torque = 100f;
    public float Max_Steer_Angle = 20f;
    public float BrakeForce = 150f;

    [Space(3)]

    //These are the speeds for each gear
    //The Brake and Reverse gears appear automatically so don't worry about those
    //The Speeds MUST be in kph
    public List<int> Gears_Speed;

    [Space(3)]

    public float handBrakeFrictionMultiplier = 2;
    private float handBrakeFriction = 0.05f;
    public float tempo;

    [Header("Boost Settings")]
    public float Boost_Motor_Torque = 300f;
    public float Motor_Torque_Normal = 100f;

    [Header("Audio Settings (Beta)")]
    public bool Enable_Audio;
    public AudioSource Engine_Sound;
    public AudioSource Idle_Sound;
    public AudioSource Crash_Sound;
    public AudioClip engine;
    public AudioClip idle;
    public AudioClip crash;
    

    [Header("Drift Settings")]
    public bool Set_Drift_Settings_Automatically = true;
    public float Forward_Extremium_Value_When_Drifting;
    public float Sideways_Extremium_Value_When_Drifting;

    [Header("Light Setting(s)")]

    [Header("Lights (With Light Settings)")]
    public bool Enable_Headlights_Lights;
    public bool Enable_Brakelights_Lights;
    public bool Enable_Reverselights_Lights;

    public Light[] HeadLights;
    public Light[] BrakeLights;
    public Light[] ReverseLights;

    [Space(4)]

    [Header("Light (With MeshRenderer")]
    public bool Enable_Headlights_MeshRenderers;
    public bool Enable_Brakelights_MeshRenderers;
    public bool Enable_Reverselights_MeshRenderers;

    public MeshRenderer[] HeadLights_MeshRenderers;
    public MeshRenderer[] BrakeLights_MeshRenderers;
    public MeshRenderer[] ReverseLights_MeshRenderers;

    [Header("Particle System(s) Settings")]
    public bool Use_Particle_Systems;
    public ParticleSystem[] Car_Smoke_From_Silencer;//Sorry, couldn't think of a better name :P

    /*[Header("UI Settings")]
    public bool Use_TMP;
    public bool Use_Default_UI;

    [Space(3)]

    public bool Show_Speed_In_KPH;
    public Text Speed_Text_UI;
    public TextMeshProUGUI Speed_Text_TMPPro;

    [Space(3)]

    public Text Gear_Text;
    public TextMeshProUGUI Gear_TMPro;*/

    [Header("Other Settings")]
    public Transform Center_of_Mass;
    public float frictionMultiplier = 3f;
    public Rigidbody Car_Rigidbody;

    [Header("Debug")] //These are variables that are read only so dont chnage them, they are only there if u wanna use them for UI like speed or RPM;
    public float RPM_FL;
    public float RPM_BL;

    [Space(8)]

    public float Car_Speed_KPH;
    public float Car_Speed_MPH;

    [Space(4)]

    public string Current_Gear;
    public int Current_Gear_num;

    //private Variables
    private Rigidbody rb;
    private float Brakes = 0f;
    private WheelFrictionCurve FLforwardFriction, FLsidewaysFriction;
    private WheelFrictionCurve FRforwardFriction, FRsidewaysFriction;
    private WheelFrictionCurve BLforwardFriction, BLsidewaysFriction;
    private WheelFrictionCurve BRforwardFriction, BRsidewaysFriction;

    //Debug Values in Int Form
    int Car_Speed_In_KPH;
    int Car_Speed_In_MPH;

    

    public Transform myTransformGO;
    public float returnSpeed=0.1f;

    //private Rigidbody rb;
    //Hidden Variables
    [HideInInspector] public float currSpeed;

    public float NumberJumps = 0f;
    public float MaxJumps = 2;

    void Start()
    {
        Crash_Sound.volume = 0;
        Crash_Sound.clip = crash;
        Engine_Sound.clip = engine;
        Idle_Sound.clip = idle;

        Engine_Sound.Play();
        Idle_Sound.Play();

        Engine_Sound.volume = 0;
        Idle_Sound.volume = 0;


        //To Prevent The Car From Toppling When Turning Too Much
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Center_of_Mass.localPosition;

        //Play Car Particle System
        if (Use_Particle_Systems)
        {
            foreach (ParticleSystem P in Car_Smoke_From_Silencer)
            {
                P.Play();
            }
        }

        //Set the current gear to 0
        Current_Gear = "0";
        Current_Gear_num = 0;

        //Here we just set the lights to turn on and off at play.

        //We turn the headlights on here
        if (Enable_Headlights_Lights)
        {
            foreach (Light H in HeadLights)
            {
                H.enabled = true;
            }
        }

        if (Enable_Headlights_MeshRenderers)
        {
            foreach (MeshRenderer HM in HeadLights_MeshRenderers)
            {
                HM.enabled = true;
            }
        }

        //Here we turn the reverse light(s) off
        if (Enable_Reverselights_Lights)
        {
            foreach (Light R in ReverseLights)
            {
                R.enabled = false;
            }
        }

        if (Enable_Reverselights_MeshRenderers)
        {
            foreach (MeshRenderer RM in ReverseLights_MeshRenderers)
            {
                RM.enabled = false;
            }
        }

        //Here we turn off the brakelights
        if (Enable_Brakelights_Lights)
        {
            foreach (Light B in BrakeLights)
            {
                B.enabled = false;
            }
        }

        if (Enable_Brakelights_MeshRenderers)
        {
            foreach (MeshRenderer BM in BrakeLights_MeshRenderers)
            {
                BM.enabled = true;
            }
        }
    }

    public void FixedUpdate()
    {
        //Changing Gears
        if (Gears_Speed[Current_Gear_num] < Car_Speed_KPH && Current_Gear_num != Gears_Speed.Count)
        {
            Current_Gear_num++;
            Current_Gear = (Current_Gear_num + 1).ToString();
        }

        if (Gears_Speed[Current_Gear_num] > Car_Speed_KPH && Current_Gear_num != 0)
        {
            Current_Gear_num--;
            Current_Gear = (Current_Gear_num + 1).ToString();
        }

        if (Car_Speed_In_KPH == 0)
        {
            Current_Gear = "0";
        }

        //Setting the gear text to the current gear
        /*if (Use_TMP)
        {
            Gear_TMPro.SetText(Current_Gear);
        }

        if (Use_Default_UI)
        {
            Gear_Text.text = Current_Gear;
        }*/

        //Making The Car Move Forward or Backward
        BL.motorTorque = Input.GetAxis("Vertical") * Motor_Torque;
        FL.motorTorque = Input.GetAxis("Vertical") * Motor_Torque;


        //Making The Car Turn
        FL.steerAngle = Input.GetAxis("Horizontal") * Max_Steer_Angle;
        //BL.steerAngle = Input.GetAxis("Horizontal") * Max_Steer_Angle;


        //Showing the RPM for the wheels
        RPM_FL = FL.rpm;
        RPM_BL = BL.rpm;

        //Changing speed of the car
        Car_Speed_KPH = Car_Rigidbody.velocity.magnitude * 1f;
        Car_Speed_MPH = Car_Rigidbody.velocity.magnitude * 2.237f;

        Car_Speed_In_KPH = (int)Car_Speed_KPH;
        Car_Speed_In_MPH = (int)Car_Speed_MPH;

        

        
            //Setting The Motor Torque Back To Normal;
            Motor_Torque = Motor_Torque_Normal;
        

        //Make Car Drift
        /*
        WheelHit wheelHit1;
        WheelHit wheelHit3;

        FL.GetGroundHit(out wheelHit1);
        BL.GetGroundHit(out wheelHit3);

        if (wheelHit1.sidewaysSlip < 0)
            tempo = (1 + -Input.GetAxis("Horizontal")) * Mathf.Abs(wheelHit1.sidewaysSlip * handBrakeFrictionMultiplier);

        if (tempo < 0.5) tempo = 0.5f;

        if (wheelHit1.sidewaysSlip > 0)
            tempo = (1 + Input.GetAxis("Horizontal")) * Mathf.Abs(wheelHit1.sidewaysSlip * handBrakeFrictionMultiplier);

        if (tempo < 0.5) tempo = 0.5f;

        if (wheelHit1.sidewaysSlip > .99f || wheelHit1.sidewaysSlip < -.99f)
        {
            //handBrakeFriction = tempo * 3;
            float velocity = 0;
            handBrakeFriction = Mathf.SmoothDamp(handBrakeFriction, tempo * 3, ref velocity, 0.1f * Time.deltaTime);
        }



        if (wheelHit3.sidewaysSlip < 0)
            tempo = (1 + -Input.GetAxis("Horizontal")) * Mathf.Abs(wheelHit3.sidewaysSlip * handBrakeFrictionMultiplier);

        if (tempo < 0.5) tempo = 0.5f;

        if (wheelHit3.sidewaysSlip > 0)
            tempo = (1 + Input.GetAxis("Horizontal")) * Mathf.Abs(wheelHit3.sidewaysSlip * handBrakeFrictionMultiplier);

        if (tempo < 0.5) tempo = 0.5f;

        if (wheelHit3.sidewaysSlip > .99f || wheelHit3.sidewaysSlip < -.99f)
        {
            //handBrakeFriction = tempo * 3;
            float velocity = 0;
            handBrakeFriction = Mathf.SmoothDamp(handBrakeFriction, tempo * 3, ref velocity, 0.1f * Time.deltaTime);
        }



        else
        {
            handBrakeFriction = tempo;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //Change gear to "R"
            Current_Gear = "R";

            //Enable reverse lights when car is reversing
            if (Enable_Reverselights_Lights)
            {
                foreach (Light RL in ReverseLights)
                {
                    RL.enabled = true;
                }
            }

            if (Enable_Reverselights_MeshRenderers)
            {
                foreach (MeshRenderer RM in ReverseLights_MeshRenderers)
                {
                    RM.enabled = true;
                }
            }
        }

        if (!Input.GetKey(KeyCode.S))
        {
            if (Enable_Reverselights_Lights)
            {
                foreach (Light Rl in ReverseLights)
                {
                    Rl.enabled = false;
                }
            }

            if (Enable_Reverselights_MeshRenderers)
            {
                foreach (MeshRenderer RM in ReverseLights_MeshRenderers)
                {
                    RM.enabled = false;
                }
            }
        }*/
    }

    public void Update()
    {
        if (NumberJumps > MaxJumps - 1)
        {
            onGround = false;
        }

        if (onGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector3.up * jumpHeight);
                NumberJumps += 1;
            }
        }

        float angleX = myTransformGO.rotation.eulerAngles.x;
        float angleY = myTransformGO.rotation.eulerAngles.y;
        float angleZ = myTransformGO.rotation.eulerAngles.z;

        if (Input.GetButtonDown("Fire3"))
        {
            Debug.Log("GetUp");
            transform.rotation = Quaternion.Euler(0, angleY, 0);
        }

        if (-30 <=angleZ || angleZ <30)
        {

        }

        if (angleZ>=maxAngle)
        {
            transform.Rotate(0, 0, -returnSpeed);
        }

        if (angleZ<-maxAngle)
        {
            transform.Rotate(0, 0, returnSpeed);
        }

        if (angleX >= 0)
        {
            transform.Rotate(-returnSpeed, 0, 0);
        }

        if (angleX < 0)
        {
            transform.Rotate(returnSpeed, 0, 0);
            Debug.Log("to 0");
        }

        if (-maxAngle <= angleZ || angleZ < maxAngle)
        {

        }

        //Rotating The Wheels So They Don't Slide
        var pos = Vector3.zero;
        var rot = Quaternion.identity;

        FL.GetWorldPose(out pos, out rot);
        Fl.position = pos;
        Fl.rotation = rot * Quaternion.Euler(FL_Rotation);


        BL.GetWorldPose(out pos, out rot);
        Bl.position = pos;
        Bl.rotation = rot * Quaternion.Euler(BL_Rotation);


        //Make Car Brake
        if (Input.GetKey(KeyCode.Space) == true)
        {
            
        

            //Drifting and changing wheel collider values
            if (Set_Drift_Settings_Automatically)
            {
                FLforwardFriction = FL.forwardFriction;
                FLsidewaysFriction = FL.sidewaysFriction;

                FLforwardFriction.extremumValue = FLforwardFriction.asymptoteValue = ((currSpeed * frictionMultiplier) / 300) + 1;
                FLsidewaysFriction.extremumValue = FLsidewaysFriction.asymptoteValue = ((currSpeed * frictionMultiplier) / 300) + 1;

                BLforwardFriction = BL.forwardFriction;
                BLsidewaysFriction = BL.sidewaysFriction;

                BLforwardFriction.extremumValue = BLforwardFriction.asymptoteValue = ((currSpeed * frictionMultiplier) / 300) + 1;
                BLsidewaysFriction.extremumValue = BLsidewaysFriction.asymptoteValue = ((currSpeed * frictionMultiplier) / 300) + 1;
            }

            if (!Set_Drift_Settings_Automatically)
            {
                //Variables
                FLforwardFriction = FL.forwardFriction;
                FLsidewaysFriction = FL.sidewaysFriction;


                BLforwardFriction = BL.forwardFriction;
                BLsidewaysFriction = BL.sidewaysFriction;




                //Setting The Extremium values to the ones that the user defined
                FLforwardFriction.extremumValue = Forward_Extremium_Value_When_Drifting;
                FLsidewaysFriction.extremumValue = Sideways_Extremium_Value_When_Drifting;


                BLforwardFriction.extremumValue = Forward_Extremium_Value_When_Drifting;
                BLsidewaysFriction.extremumValue = Sideways_Extremium_Value_When_Drifting;

            }
        }

        else
        {
            Brakes = 0f;
        }

        FL.brakeTorque = Brakes;

        BL.brakeTorque = Brakes;


        if (!Input.GetKey(KeyCode.Space))
        {
            
            /*//Turn off brake lights
            if (Enable_Brakelights_Lights)
            {
                foreach (Light L in BrakeLights)
                {
                    L.enabled = false;
                }
            }

            if (Enable_Brakelights_MeshRenderers)
            {
                foreach (MeshRenderer BM in BrakeLights_MeshRenderers)
                {
                    BM.enabled = false;
                }
            }*/
        }




        //Play Car Audio
        if ((Input.GetAxis("Vertical")>0.0f || Input.GetAxis("Vertical") < 0.0f) &&gameManager.watchActive==true)
        {
            
            
            Engine_Sound.volume = Engine_Sound.volume + 0.1f;
            Idle_Sound.volume = Idle_Sound.volume - 0.2f;


        }

        if (Input.GetAxis("Vertical") == 0 && gameManager.watchActive==true)
        {
            
            
            Engine_Sound.volume = Engine_Sound.volume - 0.2f;
            Idle_Sound.volume = Idle_Sound.volume + 0.1f;
        }
        
        if (gameManager.watchActive==true)
        {
            Crash_Sound.volume = 1;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Ground")
        {
            onGround = true;
            NumberJumps = 0;
        }

        if (collision.gameObject.tag != "Ground"&&gameManager.watchActive==true)
        {
            Crash_Sound.PlayOneShot(crash);
        }
    }

    void OnCollisionExit(Collision other)
    {

    }
    public void StartButtonOn()
    {
        
        Debug.Log("StartGame");
        transform.rotation = Quaternion.Euler(0, 180, 0);
        transform.position = StartPosition.position;
        
    }

}