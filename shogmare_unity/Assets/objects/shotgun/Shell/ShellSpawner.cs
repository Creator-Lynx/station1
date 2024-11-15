using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Shells = GameObject.Find("SHELLS"); //find
        if (!Shells)
        {
            Debug.LogError("Need to create 'SHELLS' empty object to grouping dropped shells");
        }
    }
    [SerializeField] GameObject shell, shellPos1, shellPos2;
    GameObject Shells;
    [SerializeField] float ExtructionForce = 2f, ExtructionTorque = 2;
    GameObject currentShell1, currentShell2;
    Rigidbody rig1, rig2;
    public void SpawnShell()
    {
        currentShell1 = Instantiate(shell,
         shellPos1.transform.position, shellPos1.transform.rotation,
         shellPos1.transform);
        currentShell2 = Instantiate(shell,
         shellPos2.transform.position, shellPos2.transform.rotation,
         shellPos2.transform);
        /*this block needs to convert scale of prebab and shotgun, when using new Shotgun fbx
        you need to revert this two lines*/
        currentShell1.transform.localScale = 0.01f * Vector3.one;
        currentShell2.transform.localScale = 0.01f * Vector3.one;
        //=======================================
        rig1 = currentShell1.GetComponent<Rigidbody>();
        rig2 = currentShell2.GetComponent<Rigidbody>();
        rig1.useGravity = false;
        rig2.useGravity = false;
        mass = rig1.mass;
    }
    float mass;
    public void UnconnectShell()
    {
        rig1.AddRelativeForce(Vector3.left * ExtructionForce, ForceMode.Impulse);
        rig2.AddRelativeForce(Vector3.left * ExtructionForce, ForceMode.Impulse);
        currentShell1.transform.SetParent(Shells.transform);
        currentShell2.transform.SetParent(Shells.transform);

        rig1.useGravity = true;
        rig2.useGravity = true;

        rig1.AddForce(transform.forward * ExtructionForce * 0.35f, ForceMode.Impulse);
        rig2.AddForce(transform.forward * ExtructionForce * 0.35f, ForceMode.Impulse);


        rig1.AddTorque(Random.onUnitSphere * ExtructionTorque, ForceMode.Impulse);
        rig2.AddTorque(Random.onUnitSphere * ExtructionTorque, ForceMode.Impulse);
    }
}
