using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMove2 : MonoBehaviour {

    [SerializeField]
    Transform room1, room2, room3;
    //List<Transform> rooms = new List<Transform>();
    //public Transform[] rooms; 
    NavMeshAgent _navMeshAgent;
    
    Rigidbody rb;
    Collider col;
    public float AIMoveSpeed;
    //public GameObject witch;
    public GameObject player;
    private Vector3 witchPosition;
    private Vector3 playerCurrentPosition;
    private Vector3 Vroom1, Vroom2, Vroom3;
    bool witchMoved = false;

    #region

    //Vector3 witchStartingPosition = witch.transform.position.Vector3(0,0,0);
    //witchStartingPosition = new Vector3(-9,1,6);
    //if currentiwtchposition = position of room1/room2/room3

    //if (col.bounds.Contains(playerCurrentPosition)) //if player is within witch's trigger
    //{
    //    print("uhhh");
    //}
    //col = this.GetComponent<Collider>();

    #endregion

    void Start()
    {
        witchPosition = this.transform.position; //this = witch
        playerCurrentPosition = player.transform.position;
        print("witch sp" + witchPosition);
        print("player cp" + playerCurrentPosition);


        _navMeshAgent = this.GetComponent<NavMeshAgent>(); //finds navmshagent component of object the code is attached to
       
        rb = this.GetComponent<Rigidbody>();

        if (_navMeshAgent == null)
        {
            print("no NavMeshAgent attached");
        }
        else
        {
            print("NavMeshAgent attached -all good");
        }

    }

    public void OnTriggerStay(Collider other)
    {

        witchMoved = false; 

        if (other.tag == "Player")
        {

            setDestination(room1);
            print("works");
            
           

            witchMoved = true;

            //if (witchPosition == targetLocation)
            //{
            //    print("stage 2");
            //    targetLocation = room2.transform.position * AIMoveSpeed * Time.deltaTime;
            //    _navMeshAgent.SetDestination(targetLocation);
            //}

        }

        else
        {
            print("No player found");
        }
    }

    //onexittrigger set stuff to false?
    //public void MoveYo(Collider other)
    //{


    //    if (other.tag == "Player")
    //    {
    //        Vector3 targetLocation = room1.transform.position * AIMoveSpeed * Time.deltaTime;
    //        _navMeshAgent.SetDestination(targetLocation);
    //        print("new position is" + playerCurrentPosition);
    //        print("yo");
    //    }



    //    //if (playerCurrentPosition == witchStartingPosition) //that won't work
    //    //{
    //    //    Vector3 targetLocation = room1.transform.position * AIMoveSpeed * Time.deltaTime;
    //    //    _navMeshAgent.SetDestination(targetLocation);
    //    //    playerCurrentPosition = Vroom1;
    //    //    print("new position is" + playerCurrentPosition);
    //    //}
    //    //else if (playerCurrentPosition == Vroom1)
    //    //{
    //    //    Vector3 targetLocation = room2.transform.position * AIMoveSpeed * Time.deltaTime;
    //    //    playerCurrentPosition = Vroom2;
    //    //    print("player is room 2 now");
    //    //}
    //    //else if (playerCurrentPosition == Vroom2)
    //    //{
    //    //    Vector3 targetLocation = room3.transform.position * AIMoveSpeed * Time.deltaTime;

    //    //}

    //     else 
    //    {
    //      print("player not in trigger radius");
    //    }
    //}


    private void setDestination(Transform transform)
    {
        // if playeer within x units from witch


        if (transform != null)
        {
            print("setdestination triggered");
            Vector3 targetLocation = transform.transform.position * AIMoveSpeed * Time.deltaTime;
            this.GetComponent<Animation>().CrossFade("Walking");
            _navMeshAgent.SetDestination(targetLocation);
            print("new witch position is" + witchPosition);
            print("target position is" + targetLocation);

        }
    }
}
