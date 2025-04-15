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
    bool isReadyToShoot = true;
        
    [SerializeField] Animator ShotgunAnimator;
    public void MakeOneShoot()
    {
        if(!isReadyToShoot) return;
         if (isFirstShot)
            {
                ShotgunAnimator.SetTrigger(firstShot);
                isFirstShot = false;
                isReadyToShoot = false;
            }
            else
            {
                ShotgunAnimator.SetTrigger(secondShot);
                isFirstShot = true;
                isReadyToShoot = false;
            }
    }

    public void MakeDoubleShoot()
    {
        if(!isReadyToShoot) return;
        if (isFirstShot)
        {
            ShotgunAnimator.SetTrigger(doubleShot);
            GameplayDoubleShot();
            isReadyToShoot = false;
        }
        else
        {
            ShotgunAnimator.SetTrigger(secondShot);
            isFirstShot = true;
            GameplayShot();
            isReadyToShoot = false;
        }
    }

    public void MakeReload()
    {
        if (!isFirstShot)
            {   
                isReadyToShoot = false;
                isFirstShot = true;
                ShotgunAnimator.SetTrigger(reload);
            }
    }

    public void SetReadyToShootByAnimator()
    {
        isReadyToShoot = true;
    }

    void GameplayShot()
    {

    }

    void GameplayDoubleShot()
    {

    }
}
