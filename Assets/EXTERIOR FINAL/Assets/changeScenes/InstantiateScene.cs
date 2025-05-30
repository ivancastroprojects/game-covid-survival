using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantiateScene : MonoBehaviour
{
    public GameObject player;
    public GameObject respawn;
    private void Start()
    {
        respawn = GameObject.Find(respawn.name);
        Debug.Log(respawn);
        Instantiate(player, respawn.transform.position, respawn.transform.rotation);
    }
}