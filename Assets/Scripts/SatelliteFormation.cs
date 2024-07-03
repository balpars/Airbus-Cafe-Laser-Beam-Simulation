using UnityEngine;

public class SatelliteFormation : MonoBehaviour
{
    public Transform[] satellites;  // Array of satellite transforms
    public float spacing = 2f;  // Spacing between satellites

    void Start()
    {
        ArrangeSatellitesInLine();
    }

    void ArrangeSatellitesInLine()
    {
        for (int i = 0; i < satellites.Length; i++)
        {
            satellites[i].position = new Vector3(i * spacing, 0, 0);
        }
    }
}
