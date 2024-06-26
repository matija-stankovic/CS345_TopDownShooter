using System.Collections;
using UnityEngine;

public class AIDetector : MonoBehaviour
{
    [Range(1, 15)]
    [SerializeField]
    private float viewRadius = 7;
    [SerializeField]
    private float detectionCheckDelay = 0.1f;
    [SerializeField]
    private Transform target = null;
    [SerializeField]
    private LayerMask playerLayerMask;
    [SerializeField]
    private LayerMask visibilityLayer;

    [field: SerializeField]
    public bool TargetVisible { get; private set; }

    public Transform Target
    {
        get => target;
        set
        {
            target = value;
            TargetVisible = false;
        }
    }

    private void Start()
    {
        StartCoroutine(DetectionCoroutine());
    }

    private void Update()
    {
        if (Target != null)
            TargetVisible = CheckTargetVisible();
    }

    private bool CheckTargetVisible()
    {
        var directionToTarget = (Vector2)(Target.position - transform.position);
        var result = Physics2D.Raycast(transform.position, directionToTarget, viewRadius, visibilityLayer);
        if (result.collider != null)
        {
            return (playerLayerMask & (1 << result.collider.gameObject.layer)) != 0;
        }
        return false;
    }

    private void DetectTarget()
    {
        if (Target == null)
            CheckIfPlayerInRange();
        else
            DetectIfOutOfRange();
    }

    private void DetectIfOutOfRange()
    {
        if (Target == null || !Target.gameObject.activeSelf || Vector2.Distance(transform.position, Target.position) > viewRadius + 1)
        {
            Target = null;
        }
    }

    private void CheckIfPlayerInRange()
    {
        Collider2D collision = Physics2D.OverlapCircle(transform.position, viewRadius, playerLayerMask);
        if (collision != null)
        {
            Target = collision.transform;
        }
    }

    private IEnumerator DetectionCoroutine()
    {
        while (true)
        {
            DetectTarget();
            yield return new WaitForSeconds(detectionCheckDelay);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }
}
