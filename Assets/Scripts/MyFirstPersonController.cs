using UnityEngine;

public class MyFirstPersonController : MonoBehaviour
{
    public Camera cam;

    public float moveSpeed = 8.0f;

    public bool cursorLockVisible = true;
    float mx, my;
    public float rotSpeed = 1000.0f;
    public float minX = -60;
    public float maxX = 60;

    void Start()
    {
        if(cursorLockVisible)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        // Camera Rot
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        mx += x * rotSpeed * Time.deltaTime;
        my += y * rotSpeed * Time.deltaTime;

        Vector3 angle = new Vector3(-my, mx, 0);

        angle.x = Mathf.Clamp(angle.x, minX, maxX);

        cam.transform.eulerAngles = angle;

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (cursorLockVisible)
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                cursorLockVisible = false;
            }
        }else if(Input.GetMouseButtonUp(0))
        {
            if (!cursorLockVisible)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                cursorLockVisible = true;
            }
        }
    }
    void FixedUpdate()
    {
        // Move
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v).normalized;

        dir = cam.transform.TransformDirection(dir);

        transform.position += dir * moveSpeed * Time.deltaTime;
    }
}
