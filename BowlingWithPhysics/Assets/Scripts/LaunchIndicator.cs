using Unity.Cinemachine;
using UnityEngine;

public class LaunchIndicator : MonoBehaviour
{
    [SerializeField] private CinemachineCamera freeLookCamera;



    void Update()
   {
    if (freeLookCamera == null)
    {
        Debug.LogWarning("freeLookCamera is not assigned!");
        return;
    }
    transform.forward = freeLookCamera.transform.forward;
    transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
}
}

