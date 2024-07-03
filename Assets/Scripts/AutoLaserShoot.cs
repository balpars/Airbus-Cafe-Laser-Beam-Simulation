using UnityEngine;

public class AutoLaserShoot : MonoBehaviour
{
    public GameObject laserPrefab;  // Laser Prefab
    public Transform shootPoint;    // Punkt, von dem der Laser abgeschossen wird
    public float shootForce = 10f;  // Kraft des Laser-Schusses
    public float detectionRadius = 20f;  // Radius zur Erkennung von Weltraumschrott
    public LayerMask debrisLayer;  // Layer des Weltraumschrotts
    public float fireRate = 1f;  // Feuerrate in Sekunden

    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            DetectAndShootDebris();
        }
    }

    void DetectAndShootDebris()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, debrisLayer);
        if (hitColliders.Length > 0)
        {
            nextFireTime = Time.time + fireRate;
            ShootLaser();
        }
    }

    void ShootLaser()
    {
        GameObject laser = Instantiate(laserPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = laser.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
