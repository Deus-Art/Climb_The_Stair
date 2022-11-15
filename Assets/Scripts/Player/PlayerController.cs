using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour
{
    public PathCreator pathCreator;
    public GameObject playerPop, playerSweat;
    [SerializeField] GameData data;
    

    public bool _isPlayerActing, _isWon;
    float distanceTravelled;
    Animator _animator;

    
    void Update()
    {
        Move();
        PlayerPops();
        PlayerSweats();
    }

    void Move()
    {
        if(Input.GetMouseButtonDown(0) && !IsMouseOverUI())
        {

            _isPlayerActing = true;
            _animator.SetBool("isMoving", true);

        }

        if(_isPlayerActing == true)
        {
            distanceTravelled += data.speed_value * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            //transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);

            data.stamina_value -= 0.005f;
            
            if(data.stamina_value <= 0)
            {
                data.stamina_value = 0;
            }

        }

        if(Input.GetMouseButtonUp(0) && !IsMouseOverUI())
        {

            _isPlayerActing = false;
            _animator.SetBool("isMoving", false);

        }

        if(_isPlayerActing == false)
        {
            data.stamina_value += 0.005f;

            if(data.stamina_value >= data.maxStamina_value)
            {
                data.stamina_value = data.maxStamina_value;
            }
        }

    }

    void PlayerSweats()
    {
        if(data.stamina_value < 1.5f && data.stamina_value >= 0)
        {
            playerSweat.SetActive(true);
        }
        if(data.stamina_value <= 1 && data.stamina_value >= 0)
        {
            this.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.red;
        }
        else if(data.stamina_value > 1)
        {
            this.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.white;
            playerSweat.SetActive(false);
        }
    }

    void PlayerPops()
    {
        if(data.stamina_value == 0)
        {
            //KILL THE PLAYER (add pop animation)
            _isPlayerActing = false;
            this.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            Instantiate(playerPop, transform.position, transform.rotation);
            
        }
    }

    public void PlayerOnFinish()
    {
        _isWon = true;

        if(_isWon == true)
        {
            _isPlayerActing = false;
            _animator.SetBool("isFinish", true);
        }
    }

    void Awake() 
    {
        data.stamina_value = data.maxStamina_value;
        _animator = GetComponent<Animator>();
    }

    public bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
