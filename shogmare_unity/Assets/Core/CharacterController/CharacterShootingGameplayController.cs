using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShootingGameplayController : MonoBehaviour
{

    [SerializeField] string firstShot = "firstShot";
    [SerializeField] string secondShot = "secondShot";
    [SerializeField] string doubleShot = "doubleShot";
    [SerializeField] string reload = "reloadHalf";
    bool isFirstShot = true;
        
    [SerializeField] Animator ShotgunAnimator;
    public void Shoot()
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
}
