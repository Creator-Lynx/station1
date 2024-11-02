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
    [SerializeField] GameObject shell;
    GameObject Shells;
    public void SpawnShell()
    {
        GameObject currentShell = Instantiate(shell, Shells.transform);

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
