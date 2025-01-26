using System.Collections;
using UnityEngine;

public class ClipPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Cleanup());
    }

    public IEnumerator Cleanup()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
