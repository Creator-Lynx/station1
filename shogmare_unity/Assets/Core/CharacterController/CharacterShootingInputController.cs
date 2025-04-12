using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterShootingInputController : MonoBehaviour
{

    [SerializeField] InputAction shotAction;
    [SerializeField] InputAction doubleShotAction;
    [SerializeField] InputAction reloadAction;
    void Awake()
    {
        shotAction.performed += ctx => { OnShot(ctx); };
        doubleShotAction.performed += ctx => { OnDoubleShot(ctx); };
        reloadAction.performed += ctx => { OnReload(ctx); };
    }


    void Update()
    {
        
    }



    void OnShot(InputAction.CallbackContext context)
    {
        //shot code here
    }
    void OnDoubleShot(InputAction.CallbackContext context)
    {
        //doubleshot code here
    }
    void OnReload(InputAction.CallbackContext context)
    {
        //reload code here
    }


    void OnEnable()
    {
        shotAction.Enable();
        doubleShotAction.Enable();
        reloadAction.Enable();
    }
    void OnDisable()
    {
        shotAction.Disable();
        doubleShotAction.Disable();
        reloadAction.Disable();
    }
}
