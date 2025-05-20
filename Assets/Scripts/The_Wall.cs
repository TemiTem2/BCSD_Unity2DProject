using UnityEngine;

public class The_Wall : MonoBehaviour
{
    private float Speed;
    void Start()
    {
        Speed = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    { 
        Speed = Speed + Time.deltaTime*0.001f;
        transform.Translate(new Vector2(Speed, 0));
    }
}
