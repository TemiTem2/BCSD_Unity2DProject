using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    void Start()
    {
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            gameObject.transform.position = new Vector3(target.position.x, 0, -10);
        }
        
    }
}
