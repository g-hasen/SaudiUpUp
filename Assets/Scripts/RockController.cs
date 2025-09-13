using UnityEngine;

public class RockController : MonoBehaviour
{
    public Vector3 hiddenPosition;
    public float moveSpeed = 3f;
    private Vector3 startPosition;
    private bool isOpen = false;

    void Start() { 
        startPosition = transform.position; 
    }

    void Update()
    {
        Vector3 target = isOpen ? hiddenPosition : startPosition;
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }

    public void SetOpen(bool open) { 
        isOpen = open; 
    }
}
