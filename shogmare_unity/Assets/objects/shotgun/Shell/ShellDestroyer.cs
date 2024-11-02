using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellDestroyer : MonoBehaviour
{
    Material material;
    [SerializeField] float Lifetime = 20f, Fadetime = 5f;
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        StartCoroutine(ShellLifetime(Lifetime, Fadetime));
    }

    IEnumerator ShellLifetime(float lifetime, float fadetime)
    {
        yield return new WaitForSeconds(lifetime);
        float fadetimer = fadetime;
        Color color = material.color;
        while (fadetimer > 0)
        {
            yield return new WaitForEndOfFrame();
            fadetimer -= Time.deltaTime;
            float alpha = fadetimer / fadetime;
            alpha = Mathf.Clamp01(alpha);
            color.a = alpha;
            material.color = color;
        }
        Destroy(gameObject);
    }


}
