using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target; 
    
    [SerializeField] private Vector3 offset = new Vector3(0, 3f, -8f); 
    [SerializeField] private float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target ==null) return;
        
        Vector3 cameraPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothSpeed * Time.deltaTime); 

        Quaternion cameraRotation = Quaternion.LookRotation(target.position - transform.position); 
        transform.rotation = Quaternion.Lerp(transform.rotation, cameraRotation, smoothSpeed * Time.deltaTime); 
    }
}