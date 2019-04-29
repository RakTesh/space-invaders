using System.Collections;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif 

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 6f;
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;
    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    Vector3 movement;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLenght = 100f;
    float ver = 0;
    float hor = 0;

    float xStick = 0;
    float yStrick = 0;

    void Awake() {

        playerRigidbody = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");
        //Debug.Log(floorMask);
    }

    void FixedUpdate() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");//Dash
        //float d = Input.GetAxisRaw("Dash");
        ver = v;
        hor = h;
        Move(h, v, 1);
        Turning(h, v);
        //Animating(h,v);

        if (Input.GetKeyDown(KeyCode.Escape)) {

            #if UNITY_EDITOR
                        EditorApplication.isPlaying = false;
            #else
                            Application.Quit();
            #endif
        }
    }
    //Movimiento personaje
    void Move(float h, float v, float d) {
        movement.Set(0f, v, h);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
        
    }
    //Giro con el raton del personaje
    void Turning(float h, float v) {
        if (Input.GetJoystickNames().Length > 0 && Input.GetJoystickNames()[0] == "Wireless Controller") {

            if (Input.GetAxisRaw("R-Stick-X") != 0 || Input.GetAxisRaw("R-Stick-Y") != 0) {
                xStick = Input.GetAxisRaw("R-Stick-X");
                yStrick = Input.GetAxisRaw("R-Stick-Y");
            }


            Vector3 lookDirection = new Vector3(0, yStrick, xStick);
            transform.rotation = Quaternion.LookRotation(lookDirection);

           // Animating2(h, v, lookDirection);

        }
        else {


            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane ground = new Plane(Vector3.left, transform.position);
            float rayLength;
            if (ground.Raycast(cameraRay, out rayLength))//If the ray comming from the camera hits the playerGround Plane
            {
                Vector3 PointToLook = cameraRay.GetPoint(rayLength); //Get the intersection point
                Debug.DrawLine(cameraRay.origin, PointToLook, Color.red);
                transform.LookAt(PointToLook);

            }

        }
    }

}
