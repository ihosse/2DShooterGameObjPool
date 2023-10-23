using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private Vector3 direction;

    [SerializeField]
    private float speed = 45f;

    void Update()
    {
        transform.Rotate(direction * speed * Time.deltaTime);
    }
}
