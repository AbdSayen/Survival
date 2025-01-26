using System.Collections;
using UnityEngine;

public class ItemMover : MonoBehaviour
{
    public static void Move(GameObject obj, Vector3 pos, float duration)
    {
        CoroutineRunner.Instance.StartCoroutine(MoveCoroutine());

        IEnumerator MoveCoroutine()
        {
            float elapsedTime = 0f;
            Vector3 startPos = obj.transform.position;

            while (elapsedTime < duration)
            {
                obj.transform.position = Vector3.Lerp(startPos, pos, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            obj.transform.position = pos;
        }
    }
}