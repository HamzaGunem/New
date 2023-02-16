using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<bool> isEnemyList;
    public GameObject[] eneimes;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        SetUpLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Check()
    {
        for (int i = 0; i < eneimes.Length; i++)
        {
            isEnemyList[i] = eneimes[i].GetComponent<Enemy>().shooting;
        }
    }
    public void SetUpLevel()
    {
        eneimes = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < eneimes.Length; i++)
        {
            if (isEnemyList.Count != eneimes.Length)
                isEnemyList.Add(eneimes[i].GetComponent<Enemy>().shooting);
        }
    }
}
