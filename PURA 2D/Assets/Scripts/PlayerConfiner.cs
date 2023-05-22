using Cinemachine;
using UnityEngine;

public class PlayerConfiner : MonoBehaviour
{
    private CinemachineConfiner2D confiner;

    private void Start()
    {
        // Get the CinemachineConfiner component
        confiner = GetComponent<CinemachineConfiner2D>();
    }

    private void Update()
    {
        // Constrain the player's position within the confiner bounds
        Vector3 clampedPosition = new Vector3(Mathf.Clamp(transform.position.x, -13, 13), transform.position.y, 0);
        transform.position = clampedPosition;
    }
}
