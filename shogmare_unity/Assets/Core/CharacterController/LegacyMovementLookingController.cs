using UnityEngine;

public class LegacyMovementLookingController : MonoBehaviour
{
    [SerializeField]
    Animator ShotgunAnimator;
    [Header("Animator Triggers")]
    [SerializeField] string firstShot = "firstShot";
    [SerializeField] string secondShot = "secondShot";
    [SerializeField] string doubleShot = "doubleShot";
    [SerializeField] string reload = "reloadHalf";
    [SerializeField] string walk = "isWalk";
    [Space]
    [Header("Moving Controller")]
    [SerializeField] CharacterController characterController;
    [SerializeField] float MoveSpeed = 5f;
    [SerializeField] float GravityMovingSpeedModifier = 2f;
    bool isFirstShot = true;
    [Header("Mouse Sensivity")]
    [SerializeField]
    float mouseSensivity = 5f;
    const float mouseSensivityConst = 1f;
    Transform mainCamera;
    void Update()
    {
        //ShootingInput();
        MovingInput();
        CameraInput(new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")));
    }


    void ShootingInput()
    {
        //shooting input
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isFirstShot)
            {
                ShotgunAnimator.SetTrigger(firstShot);
                isFirstShot = false;
            }
            else
            {
                ShotgunAnimator.SetTrigger(secondShot);
                isFirstShot = true;
            }

        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (isFirstShot)
            {
                ShotgunAnimator.SetTrigger(doubleShot);
            }
            else
            {
                ShotgunAnimator.SetTrigger(secondShot);
                isFirstShot = true;
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            if (!isFirstShot)
            {
                isFirstShot = true;
                ShotgunAnimator.SetTrigger(reload);
            }
        }

    }
    void MovingInput()
    {
        Vector3 moving = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            moving.z = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moving.z = -1;
        }
        else moving.z = 0;
        if (Input.GetKey(KeyCode.A))
        {
            moving.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moving.x = 1;
        }
        else moving.x = 0;
        moving.Normalize();
        ShotgunAnimator.SetBool(walk, moving != Vector3.zero);
        Vector3 finalMoving =
        transform.forward * moving.z +
        transform.right * moving.x;
        if(!characterController.isGrounded)
        {
            finalMoving.y -= GravityMovingSpeedModifier;
        }
        characterController.Move(finalMoving * Time.deltaTime * MoveSpeed);
    }
    void CameraInput(Vector2 lookVector)
    {
        //float x = Input.GetAxisRaw("Mouse X") * mouseSensivity * mouseSensivityConst;
        //characterController.transform.Rotate(Vector3.up, x);
        //
        //float vertical = Input.GetAxisRaw("Mouse Y") * mouseSensivity * mouseSensivityConst;
        //Debug.Log(vertical);
        //float currentY = mainCamera.transform.localEulerAngles.x - vertical;
        //mainCamera.transform.localEulerAngles = new Vector3(currentY, 0f, 0f);
        //float currentVertical = mainCamera.transform.localRotation.x - vertical;
        //mainCamera.transform.localRotation = Quaternion.Euler(currentVertical, 0f, 0f);

        var lookHor = transform.rotation.eulerAngles.y;
        var lookVert = mainCamera.transform.localEulerAngles.x;
        lookVert = lookVert > 180f ? lookVert - 360f : lookVert;

        lookHor += lookVector.x * mouseSensivity * mouseSensivityConst;
        WeaponInertAnimation(lookVector.x * mouseSensivity * mouseSensivityConst);
        lookVert += lookVector.y * mouseSensivity * mouseSensivityConst * -1f;
        lookVert = Mathf.Clamp(lookVert, -90, 90);

        transform.rotation = Quaternion.Euler(0, lookHor, 0);
        mainCamera.transform.localRotation = Quaternion.Euler(lookVert, 0, 0);
    }

    //shotgun innertion procedural animation
    [Space]
    [SerializeField]
    Transform WeaponCamera;
    [SerializeField]
    float maxInputDelta = 5f, maxAngleDelta = 5f, lerpSpeed = 3f;
    [SerializeField] float testBeforeLerp, testAfterLerp;
    void WeaponInertAnimation(float deltaAngle)
    {
        var inputDelta = Mathf.Clamp(deltaAngle, -maxInputDelta, maxInputDelta);
        var interpolated01 = inputDelta + maxInputDelta / (2 * maxInputDelta);
        var targetLocalWeaponRotationAngleY = Mathf.Lerp(-maxAngleDelta, maxAngleDelta, interpolated01);
        var y = WeaponCamera.localRotation.eulerAngles.y;
        var fix360rot = y > 180 ? y - 360 : y;
        var rotationY = Mathf.Lerp(fix360rot, targetLocalWeaponRotationAngleY, Time.deltaTime * lerpSpeed);
        testBeforeLerp = y;
        testAfterLerp = rotationY;
        WeaponCamera.localRotation = Quaternion.Euler(0f, rotationY, 0f);
    }
    private void FixedUpdate()
    {

    }
    private void Start()
    {
        isFirstShot = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mainCamera = Camera.main.transform;

    }
}
