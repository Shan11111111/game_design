using System.Threading;
using UnityEngine;

public class bulletManerger : MonoBehaviour
{
    public float speed;
    public float maxlifetime = 5f;
    private float timer = 0f;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0.0f,0.0f,speed*Time.deltaTime,Space.Self);
        timer += Time.deltaTime;
        if (timer >= maxlifetime)
        {
            Destroy(gameObject);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Camera")
        {
            //Debug.Log("¥´¨ì¤F~"+other);
            GameObject.Find("Level").SendMessage("Hurted");
        }
    }
}
