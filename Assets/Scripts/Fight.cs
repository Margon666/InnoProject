using System.Collections;
using UnityEngine;
using System.Runtime;

public class Fight : MonoBehaviour
{
    public GameObject[] npctypes = new GameObject[5];
    public GameObject[] Walls = new GameObject[4];
    public GameObject player;
    private bool spawn = false;
    private bool end = false;
    public GameObject[] npcs;
    public float roomLength=5;
    public GameObject[] check;
    void Start()
    {
    }

    void Update()
    {
        if (!spawn && Mathf.Abs(transform.position.x - player.transform.position.x) <=  4 &&
            Mathf.Abs(transform.position.z - player.transform.position.z) <=  4)
        {
            //Debug.Log("kskslwo");
            spawn = true;
            StartCoroutine(WallsUp());
            check = new GameObject[npcs.Length];
            // string s1 = "",s2="";
            // int cnt = 0;
            // for (int i = 0; i < npcs.Length; i++)
            // {
            //     Debug.Log(npcs[i]);
            // }
            // if(cnt == npcs.Length && cnt>0)
            // {
            //     WallsDown();
            // }
        }
        bool npcscheck = true;
        for (int i = 0; i < npcs.Length; i++)
        {
            if (npcs[i] != null)
            {
                npcscheck = false;
            }
        }
        if(!end && npcscheck && spawn)
        {
            Debug.Log("end");
            end = true;
            StartCoroutine(WallsDown());
        }
    }
    public void StartFight()
    {
        //Debug.Log("StartFight");
        npcs = SpawnNPC();
    }

    public GameObject[] SpawnNPC()
    {
        GameObject[] npcs = new GameObject[Random.Range(1, 6)];
        //заспавнить npc
        for (int i = 0; i < npcs.Length; i++)
        {
            //Debug.Log("NPC");
            GameObject npc = Instantiate(npctypes[Random.Range(0,5)],
                new Vector3(Random.Range(transform.position.x - 4, transform.position.x +  4), 0.3f,
                    Random.Range(transform.position.z -  4, transform.position.z +  4)),
                Quaternion.identity); // добавить защиту от одной позиции разных ботов
            npcs[i] = npc;
        }
        return npcs;
    }
    IEnumerator WallsDown()
    {
        while (Walls[0].transform.position.y >-3.9f)
        {
            for (int i = 0; i < Walls.Length; i++)
            {
                GameObject wall = Walls[i];
                wall.transform.position = Vector3.Lerp(wall.transform.position, new Vector3(wall.transform.position.x,-4,wall.transform.position.z),
                    Time.deltaTime*2f);
            }
            yield return null;
        }
    }
    IEnumerator WallsUp()
    {
        StartFight();
        while (Walls[0].transform.position.y < -0.1f)
        {
            //Debug.Log("WallsUp");
            for (int i = 0; i < Walls.Length; i++)
            {
                GameObject wall = Walls[i];
                wall.transform.position = Vector3.Lerp(wall.transform.position, new Vector3(wall.transform.position.x,0,wall.transform.position.z),
                    Time.deltaTime*2f);
            }
            yield return null;
        }
    }
}