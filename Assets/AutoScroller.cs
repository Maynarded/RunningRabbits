using UnityEngine;

public class AutoScroller : MonoBehaviour
{
    public float scrollSpeed = 0.5f;

    void Update()
    {
        transform.position += Vector3.right * scrollSpeed * Time.deltaTime;
    }
}
