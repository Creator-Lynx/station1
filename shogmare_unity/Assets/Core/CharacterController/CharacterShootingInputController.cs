using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterShootingGameplayController))]
public class CharacterShootingInputController : MonoBehaviour
{

    [SerializeField] InputAction shotAction;
    [SerializeField] InputAction doubleShotAction;
    [SerializeField] InputAction reloadAction;
    CharacterShootingGameplayController shootingGameplayController;
    void Awake()
    {
        shotAction.performed += ctx => { OnShot(ctx); };
        doubleShotAction.performed += ctx => { OnDoubleShot(ctx); };
        reloadAction.performed += ctx => { OnReload(ctx); };
        shootingGameplayController = GetComponent<CharacterShootingGameplayController>();
    }


    void Update()
    {
        
    }



    void OnShot(InputAction.CallbackContext context)
    {
        shootingGameplayController.MakeOneShoot();
    }
    void OnDoubleShot(InputAction.CallbackContext context)
    {
        shootingGameplayController.MakeDoubleShoot();
    }
    void OnReload(InputAction.CallbackContext context)
    {
        shootingGameplayController.MakeReload();
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
