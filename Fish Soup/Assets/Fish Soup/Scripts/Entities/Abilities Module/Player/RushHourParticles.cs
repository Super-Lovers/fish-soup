using System.Collections;
using UnityEngine;

public class RushHourParticles : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Destroy());
    }

    void Update()
    {
        Vector3 scale = transform.localScale;
        scale.x += 0.02f;
        scale.y += 0.02f;
        scale.z += 0.02f;
        transform.localScale = scale;
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
