using System.Collections;
using UnityEngine;

public class SelfDestruction : MonoBehaviour
{
    [SerializeField] private float delay;

    private void Start()
    {
        StartCoroutine(SelfDestruction());

        IEnumerator SelfDestruction()
        {
            yield return new WaitForSeconds(delay);
            Destroy(gameObject);
        }
    }
}