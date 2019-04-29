using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlayerDraggedMovement : MonoBehaviour
{ 
    [SerializeField] [Range(150f, 300f)] float spaceshipSpeed = 200f;

    Rigidbody playerRigidbody;
    Vector3 movement;

    float xStick = 0f;
    float yStrick = 0f;

    void Awake() {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Move(direction.x, direction.y);
        Turning(direction.x, direction.y);

        if (Input.GetKeyDown(KeyCode.Escape)) {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
        }
    }

    //Movimiento personaje
    void Move(float h, float v) {
        movement.Set(0f, v, h);
        movement = movement.normalized * spaceshipSpeed * Time.deltaTime;
        playerRigidbody.AddForce(movement, ForceMode.Acceleration);
    }

    //Giro del personaje
    void Turning(float h, float v) {
        if (Input.GetJoystickNames().Length > 0 && Input.GetJoystickNames()[0] == "Wireless Controller") {
            if (Input.GetAxisRaw("R-Stick-X") != 0 || Input.GetAxisRaw("R-Stick-Y") != 0) {
                xStick = Input.GetAxisRaw("R-Stick-X");
                yStrick = Input.GetAxisRaw("R-Stick-Y");
            }
            Vector3 lookDirection = new Vector3(0, yStrick, xStick);
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
        else {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane ground = new Plane(Vector3.left, transform.position);
            float rayLength;
            if (ground.Raycast(cameraRay, out rayLength)) {
                Vector3 PointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, PointToLook, Color.red);
                transform.LookAt(PointToLook);
            }
        }
    }
}
