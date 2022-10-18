using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class MyFirstPersonController : MonoBehaviour
{
    [Serializable]
    public class MovementSettings
    {
        public float ForwardSpeed = 8.0f;
        public float BackwardSpeed = 4.0f;
        public float StrafeSpeed = 4.0f;
        public float RunMultiplier = 2.0f;
        public KeyCode RunKey = KeyCode.LeftShift;
        // public float JumpForce = 30f;
        [HideInInspector]
        public float CurrentTargetSpeed = 8f;

        private bool m_Running;

        public bool Running
        {
            get { return m_Running; }
        }
    }

    public Camera cam;
    public MovementSettings movementSettings = new MovementSettings();
    public MouseLook mouseLock = new MouseLook();

    Rigidbody m_RigidBody;
    CapsuleCollider m_Capsule;
    float m_YRotation;


    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        m_Capsule = GetComponent<CapsuleCollider>();
        mouseLock.Init(transform, cam.transform);
    }

    void Update()
    {
        // 카메라와 오브젝트 회전 시키기
        RotateView();
    }
    
    void FixedUpdate()
    {
        Vector2 input = GetInput();
        
        Vector3 getVel = new Vector3(input.x, 0, input.y) * movementSettings.CurrentTargetSpeed;
        m_RigidBody.MovePosition(transform.position + getVel * Time.deltaTime);
        
    }

    Vector2 GetInput()
    {
        Vector2 input = new Vector2
        {
            x = -Input.GetAxisRaw("Horizontal"),
            y = -Input.GetAxisRaw("Vertical")
        };
        return input;
    }

    void RotateView()
    {
        // float oldYRotation = transform.eulerAngles.y;

        mouseLock.LookRotation(transform, cam.transform);

        // Quaternion velRotation = Quaternion.AngleAxis(transform.eulerAngles.y - oldYRotation, Vector3.up);
        // m_RigidBody.velocity = velRotation * m_RigidBody.velocity;
        
        // 바라보는 방향으로 이동이 안됨
    }

    [Serializable]
    public class MouseLook
    {
        public float XSensitivity = 2f;
        public float YSensitivity = 2f;
        public bool clampVerticalRotation = true;
        public float MinimumX = -90f;
        public float MaximumX = 90f;
        public bool lockCursor = true;

        Quaternion m_CharacterTargetRot;
        Quaternion m_CameraTargetRot;
        bool m_cursorIsLocked = false; // default true

        public void Init(Transform character, Transform camera)
        {
            m_CharacterTargetRot = character.localRotation;
            m_CameraTargetRot = camera.localRotation;
        }

        public void LookRotation(Transform character, Transform camera)
        {
            float yRot = Input.GetAxis("Mouse X") * XSensitivity;
            float xRot = Input.GetAxis("Mouse Y") * YSensitivity;

            m_CharacterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
            m_CameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);

            if(clampVerticalRotation)
            {
                m_CameraTargetRot = ClampRotationAroundXAxis(m_CameraTargetRot);
            }

            if(m_cursorIsLocked)
            {
                character.localRotation = m_CharacterTargetRot;
                camera.localRotation = m_CameraTargetRot;
            }

            UpdateCursorLock();
        }

        public void SetCursorLock(bool value)
        {
            lockCursor = value;
            if(!lockCursor)
            {
                // 사용자가 커서 잠금을 비활성화 하면 강제로 커서를 잠금 해제 시킵니다.
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        public void UpdateCursorLock()
        {
            // 사용자가 lookCursor를 설정하면 커서 확인 후 커서를 잠금니다.
            if(lockCursor)
                InternalLockUpdate();
        }

        public void InternalLockUpdate()
        {
            if(Input.GetKeyUp(KeyCode.Escape))
            {
                m_cursorIsLocked = false;
            }
            else if(Input.GetMouseButtonUp(0))
            {
                m_cursorIsLocked = true;
            }

            if(m_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else if (!m_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

            angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);

            q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }
    }
}
