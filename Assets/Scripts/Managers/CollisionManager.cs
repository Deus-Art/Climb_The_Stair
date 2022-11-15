using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public GameObject centerWood;
    public GameObject centerScoreboard;
    public GameObject podium;



    [SerializeField] GameData data;
    UIManager uiManager;
    

    void Awake() 
    {

        uiManager = GameObject.FindObjectOfType<UIManager>();

    }
    
    void OnTriggerEnter(Collider other) 
    {

        if(other.CompareTag("Stairs"))
        {
            Debug.Log("stair");

            Vector3 stairsPosition = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
            transform.LookAt(stairsPosition);
            
            other.GetComponent<MeshRenderer>().enabled = true;
            data.money_value += data.income_value;
            uiManager.scoreboard_value += 0.5f;
            InstantiateCenterWood();
        }

        if(other.CompareTag("Finish"))
        {
            uiManager.WinPanelActivate();
            transform.position = new Vector3(0f, podium.transform.position.y + 0.5f, podium.transform.position.z);
            Debug.Log("finished");
        }

    }

    void InstantiateCenterWood()
    {
        centerScoreboard.transform.position = new Vector3(0f, transform.position.y, 0f);
        Instantiate(centerWood, new Vector3(0f, transform.position.y, 0f), Quaternion.identity);
    }
}
