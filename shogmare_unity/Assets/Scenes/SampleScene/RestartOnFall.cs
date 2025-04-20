using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartOnFall : MonoBehaviour
{

    [SerializeField]
    Image BlackScreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            StartCoroutine(FallDeathAnimation());
            
        }
    }

    IEnumerator FallDeathAnimation()
    {   
        Color c = Color.black;
        c.a = 0;
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.005f);
            c.a = i * 0.01f;
            BlackScreen.color = c;
        }
        yield return new WaitForSeconds(3f);
        ReloadLevel();
    }


    void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
