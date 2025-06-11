using UnityEngine;

public class bulletManerger : MonoBehaviour
{
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0.0f,0.0f,speed*Time.deltaTime,Space.Self);
    }
}
