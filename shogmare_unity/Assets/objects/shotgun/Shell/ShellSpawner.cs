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
    public void SpawnShell()
    {
        GameObject currentShell = Instantiate(shell,
         shellPos1.transform.position, shellPos1.transform.rotation,
         Shells.transform);
        GameObject currentShell2 = Instantiate(shell,
         shellPos2.transform.position, shellPos2.transform.rotation,
         Shells.transform);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SpawnShell();
        }
    }
}
