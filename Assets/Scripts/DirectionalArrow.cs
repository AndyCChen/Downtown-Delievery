using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Transform arrowTransform;
    public float rotationSpeed;

    private void Start()
    {
        arrowTransform = transform.GetChild(0);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 targetDirection = target.position - arrowTransform.position;

        // only rotate around y axis
        targetDirection.y = 0.0f;

        arrowTransform.rotation = Quaternion.RotateTowards(arrowTransform.rotation, Quaternion.LookRotation(targetDirection), rotationSpeed * Time.deltaTime);
    }

    public void SetTarget(Transform rotationTarget)
    {
        target = rotationTarget;
    }
}
