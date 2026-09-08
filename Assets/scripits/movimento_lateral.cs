using UnityEngine;

public class movimento_lateral : MonoBehaviour
{
    public float speed = 5f;
    public float horizontal;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        transform.position += Vector3.right * horizontal * speed * Time.deltaTime;
        
        

    }
}
