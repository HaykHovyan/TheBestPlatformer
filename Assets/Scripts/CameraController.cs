using UnityEngine;

public class CameraController: MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    Transform leftBottomBorder;
    [SerializeField]
    Transform rightTopBorder;
    [SerializeField]
    float offset;
    [SerializeField]
    float smoothSpeed;

    float desiredPositionZ;

    private void FixedUpdate()
    {
        desiredPositionZ = target.position.z + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, desiredPositionZ), smoothSpeed);
        transform.position = smoothedPosition;

        transform.position = CheckPosition();
    }


    Vector3 CheckPosition()
    { 
        float posx = Mathf.Clamp(transform.position.x, leftBottomBorder.position.x, rightTopBorder.position.x);
        float posy = Mathf.Clamp(transform.position.y, leftBottomBorder.position.y, rightTopBorder.position.y);
        return new Vector3(posx, posy, transform.position.z);
    }
}
