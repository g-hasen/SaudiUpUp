using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public RockController rock;
    public int requiredCount = 1;
    public LayerMask whoCanPress;

    [Header("Visual Plate")]
    public Transform plateVisual;
    public float pressDepth = 0.1f;
    public float pressSpeed = 5f;

    private int inside = 0;
    private Vector3 startPos;
    private Vector3 targetPos;

    void Start()
    {
        if (plateVisual != null)
        {
            startPos = plateVisual.localPosition;
            targetPos = startPos;
        }
    }

    void Update()
    {
        if (plateVisual != null)
        {
            plateVisual.localPosition = Vector3.MoveTowards(
                plateVisual.localPosition,
                targetPos,
                pressSpeed * Time.deltaTime
            );
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & whoCanPress) == 0)
            return;

        inside++;
        if (plateVisual != null)
            targetPos = startPos + Vector3.down * pressDepth;

        rock.SetOpen(inside >= requiredCount);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & whoCanPress) == 0) 
            return;

        inside = Mathf.Max(0, inside - 1);
        if (inside == 0 && plateVisual != null)
            targetPos = startPos;

        rock.SetOpen(inside >= requiredCount);
    }
}
