using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    public Transform Target; // The target object to rotate around
    public float RotationSpeed = 30f; // Speed of rotation around the target
    public float OrbitDistance = 5f; // Distance from the target object
    public bool Pause = false; // Control whether the rotation is paused

    private void Update()
    {
        if (!Pause && Target != null)
        {
            // Calculate the new position
            float angle = RotationSpeed * Time.deltaTime;
            OrbitAroundTarget(angle);
        }
    }

    void OrbitAroundTarget(float angle)
    {
        // Determine the position relative to the target
        Vector3 orbitDirection = transform.position - Target.position;
        orbitDirection = Quaternion.Euler(0, angle, 0) * orbitDirection;
        transform.position = Target.position + orbitDirection;

        // Optionally, look at the target continuously
        transform.LookAt(Target);
    }
}
