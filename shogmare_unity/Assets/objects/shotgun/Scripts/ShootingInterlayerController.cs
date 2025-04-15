using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ShootingInterlayerController : MonoBehaviour
{
    public static ShootingInterlayerController instance;
    private void Awake()
    {
        instance = this;

    }
    public UnityEvent shot;
    public UnityEvent endOfAnimation;


}
