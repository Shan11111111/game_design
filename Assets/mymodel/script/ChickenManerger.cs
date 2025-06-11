using UnityEngine;

public class ChickenManerger : MonoBehaviour
{
    public Transform TargetTerms;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(TargetTerms);
    }
}
