using UnityEngine;

public class Tripot : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void FixedUpdate()
    {
        Vector3 targetPos = Vector3.Lerp(transform.position, target.position, 0.2f);
        transform.position = new Vector3(targetPos.x, targetPos.y, transform.position.z);
    }
}