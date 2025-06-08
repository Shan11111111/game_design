using UnityEngine;

public class ChickenManerger : MonoBehaviour
{
    public Transform TargetTerms;
    public GameObject firebullet;
    public GameObject fireposition;
    float shootingtime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TargetTerms = GameObject.Find("Main Camera").transform;
        shootingtime = Time.time + 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(TargetTerms);
        if (Time.time>shootingtime) {
            Instantiate(firebullet, fireposition.transform.position, fireposition.transform.rotation);
            shootingtime = Time.time + 2.0f;
        }
    }
    void OnMouseDown()
    {
        // Destroy the gameObject after clicking on it
        Destroy(gameObject);
        Destroy(firebullet);
    }
}//Git測試
