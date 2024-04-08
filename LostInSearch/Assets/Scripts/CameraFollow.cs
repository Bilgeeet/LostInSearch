using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float smoothSpeed = 0.125f;
	public Vector3 offset;
	public float rotationSpeed = 5f; 
	public float additionalRotation = 45f;

	void FixedUpdate ()
	{
	       Vector3 desiredPosition = target.position + offset;
           Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
           transform.position = smoothedPosition;

           Vector3 directionToTarget = (target.position - transform.position).normalized;

           Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);

           Quaternion additionalRotationQuaternion = Quaternion.Euler(additionalRotation, 0f, 0f);
           lookRotation *= additionalRotationQuaternion;

         transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
	}

}
