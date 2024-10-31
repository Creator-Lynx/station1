using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ShootingController : MonoBehaviour
{
    public static ShootingController instance;
    private void Start()
    {
        instance = this;

    }
    public UnityEvent shot;


}
