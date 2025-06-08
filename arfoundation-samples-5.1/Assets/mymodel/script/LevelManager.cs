using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject chicken;
    public float minDistance = 2f;
    public float maxDistance = 4f;
    public float viewAngle = 45f; // �i�����׽d��
    //public int spawnCount = 1;
    public int HP = 4;

    float shootingtime;
    // �n�ͦ��X�ӼĤH
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Instantiate(chicken);
        shootingtime = Time.time + 2.0f;

    }

    // Update is called once per frame
    void Update()
    {
         
        if (Time.time > shootingtime)
        {
            SpawnEnemies();
            shootingtime = Time.time + 2.0f;
        }
    }

    void Hurted()
    {
        HP = HP - 1;
        Debug.Log("HP:" + HP);
    }

    void SpawnEnemies()
    {
        Camera cam = Camera.main;
        Vector3 camPosition = cam.transform.position;
        Vector3 camForward = cam.transform.forward;

        float angle = Random.Range(-viewAngle, viewAngle);
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        Vector3 direction = rotation * camForward;

        float distance = Random.Range(minDistance, maxDistance);
        Vector3 spawnPosition = camPosition + direction.normalized * distance;

        // �קK�ĤH�X�{�b�Ӱ��ΤӧC����m�]��ܻP��v�����פ@�P�Ϋ��w���ס^
        spawnPosition.y = camPosition.y;

        
        Instantiate(chicken, spawnPosition, Quaternion.identity);
        
    }
}
