using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

public class FindTrashAI : MonoBehaviour
{
    public NavMeshAgent navmeh;
    public GameObject goToTrash;

    // Start is called before the first frame update
    void Start()
    {
        navmeh.enabled = true;
        Debug.Log(navmeh.enabled);
    }

    // Update is called once per frame
    void Update()
    {
        navmeh.destination = goToTrash.transform.position;
    }
}
