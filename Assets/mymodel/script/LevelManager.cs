using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject chicken;
    public float minDistance = 1f;
    public float maxDistance = 2f;
    public float viewAngle = 30f; // �i�����׽d��
    //public int spawnCount = 1;
    public int HP = 4;
    int status = 0; //狀態值

    public GameObject UI_play;
    public GameObject UI_GameOver;
    float shootingtime;
    public Text HP_text; 
    
    // �n�ͦ��X�ӼĤH
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Instantiate(chicken);
        shootingtime = Time.time + 2.0f;
        UI_GameOver.SetActive(false);
        HP_text.enabled = false;
        HP_text.text = "HP:" + HP;
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case 0:  //起始畫面
                break;
            case 1:  //遊戲中
                //  每隔一段時間，生成子彈
                if (Time.time > shootingtime)
                {
                    SpawnEnemies();
                    shootingtime = Time.time + 3.0f;
                }
                if (HP <= 0)
                {
                    UI_GameOver.SetActive(true);
                    GameObject[] destoryObj = GameObject.FindGameObjectsWithTag("destory_gameobject");

                    foreach (GameObject obj in destoryObj)
                    {
                        Destroy(obj);
                        
                    }
                    HP_text.enabled = false;
                    status = 2;
                }
                break;
            case 2:  //GameOver
                break;
        }





        //if(status==1){
        //    if (HP > 0)
        //    {
        //    //  每隔一段時間，生成子彈
        //        if (Time.time > shootingtime)
        //        {
        //        SpawnEnemies();
        //        shootingtime = Time.time + 3.0f;
        //        }

        //    }
        //    else
        //    {
        //        UI_GameOver.SetActive(true);
        //    }
        //}
    }

    public void StartGame(){
        UI_play.SetActive(false);
        HP_text.enabled = true;
        HP_text.text = "HP:" + HP;
        status =1;
    }


    public void ReastartGame()
    {
        UI_play.SetActive(false);
        UI_GameOver.SetActive(false);
        shootingtime = Time.time + 3.0f;
        HP_text.enabled = true;
        HP = 4;
        HP_text.text = "HP:" + HP;
        status = 1;
    }

    void Hurted()
    {
        HP = HP - 1;
        HP_text.text = "HP:" + HP;
        Debug.Log("HP:" + HP);
    }

    // 生成敵人
    public void SpawnEnemies()
    {
        Camera cam = Camera.main;
        Vector3 camPosition = cam.transform.position;
        Vector3 camForward = cam.transform.forward;

        float angle = Random.Range(-viewAngle / 2f, viewAngle / 2f);  // 這樣範圍會是對稱的

        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        Vector3 direction = rotation * camForward;

        float distance = Random.Range(minDistance, maxDistance);
        Vector3 spawnPosition = camPosition + direction.normalized * distance;

        spawnPosition.y = camPosition.y;


        Instantiate(chicken, spawnPosition, Quaternion.identity);

    }
}
