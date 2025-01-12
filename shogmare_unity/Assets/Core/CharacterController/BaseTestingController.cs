using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseTestingController : MonoBehaviour
{
    [SerializeField]
    Animator ShotgunAnimator;
    [Header("Animator Triggers")]
    [SerializeField] string firstShot = "firstShot";
    [SerializeField] string secondShot = "secondShot";
    [SerializeField] string doubleShot = "doubleShot";
    [SerializeField] string reload = "reloadHalf";

    bool isFirstShot = true;
    void Update()
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isFirstShot)
            {
                isFirstShot = true;
                ShotgunAnimator.SetTrigger(reload);
            }
        }

    }
    private void Start()
    {
        isFirstShot = true;
    }
}
