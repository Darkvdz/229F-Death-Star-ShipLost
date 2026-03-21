using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    
    public float distance = 8f; 
    public float height = 3f;    
    public float smoothSpeed = 5f; 

    void LateUpdate()
    {
        if (target == null) return;
        
        Vector3 cameraPosition = target.position - (target.forward * distance) + (Vector3.up * height);
        transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothSpeed * Time.deltaTime);
        
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
    }
}