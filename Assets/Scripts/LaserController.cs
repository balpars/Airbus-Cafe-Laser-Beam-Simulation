using UnityEngine;

public class LaserController : MonoBehaviour
{
    public GameObject laserPrefab; // The laser line prefab
    public GameObject asteroid; // The target asteroid
    public GameObject[] satellites; // The array of satellite objects
    public Color laserColor = Color.red; // Color of the laser
    public float laserDuration = 10f; // Duration before lasers are destroyed

    private GameObject[] laserInstances;
    private float timer = 0f;
    private bool lasersDestroyed = false;

    void Start()
    {
        // Ensure references are assigned
        if (asteroid == null || satellites == null || laserPrefab == null)
        {
            Debug.LogError("Please assign all required references in the Inspector.");
            return;
        }

        // Initialize lasers from each satellite to the asteroid
        laserInstances = new GameObject[satellites.Length];
        for (int i = 0; i < satellites.Length; i++)
        {
            laserInstances[i] = FireLaserFromSatellite(satellites[i]);
        }
    }

    void Update()
    {
        // Start timer and check if the lasers should be destroyed
        timer += Time.deltaTime;
        if (timer >= laserDuration && !lasersDestroyed)
        {
            DestroyLasers();
            lasersDestroyed = true;
        }
    }

    GameObject FireLaserFromSatellite(GameObject satellite)
    {
        // Instantiate a laser line from the satellite
        GameObject laser = Instantiate(laserPrefab);

        // Get the VolumetricLineBehavior component from the laser prefab
        VolumetricLines.VolumetricLineBehavior laserLine = laser.GetComponent<VolumetricLines.VolumetricLineBehavior>();

        // Ensure the laser line component is not null
        if (laserLine != null)
        {
            // Set the start position of the laser to the satellite position
            Vector3 startPos = satellite.transform.position;

            // Set the end position of the laser to the asteroid position
            Vector3 endPos = asteroid.transform.position;

            // Set the start and end positions of the laser line
            laserLine.StartPos = startPos;
            laserLine.EndPos = endPos;

            // Set the color of the laser line
            laserLine.LineColor = laserColor;

            // Force update the material properties to ensure the color is applied
            UpdateLaserMaterialProperties(laserLine);
        }
        else
        {
            Debug.LogWarning("VolumetricLineBehavior component not found on laser prefab.");
        }

        return laser;
    }

    void UpdateLaserMaterialProperties(VolumetricLines.VolumetricLineBehavior laserLine)
    {
        Material laserMaterial = laserLine.GetComponent<Renderer>().material;
        if (laserMaterial != null)
        {
            laserMaterial.color = laserLine.LineColor;
            laserMaterial.SetFloat("_LineWidth", laserLine.LineWidth);
            laserMaterial.SetFloat("_LightSaberFactor", laserLine.LightSaberFactor);
        }
        else
        {
            Debug.LogWarning("Material not found on the laser prefab.");
        }
    }

    void DestroyLasers()
    {
        foreach (var laser in laserInstances)
        {
            if (laser != null)
            {
                Destroy(laser);
            }
        }
    }
}
