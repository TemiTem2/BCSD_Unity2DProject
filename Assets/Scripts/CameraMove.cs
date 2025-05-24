using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    private Transform mytransform;
    void Start()
    {
       mytransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            gameObject.transform.position = new Vector3(target.position.x, 0, mytransform.position.z);
        }
        
    }
}
