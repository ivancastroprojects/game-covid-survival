using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using TMPro;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public TMP_Text[] label;
    public Transform spawnPoint;
    public static LoadCharacter instance;

    void Start ()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        Debug.Log(selectedCharacter);


        GameObject prefab = characterPrefabs[selectedCharacter];
        prefab.SetActive(true);
        Debug.Log(prefab);
        
        if(PlayerPrefs.GetString("namePlayer") != null)
            label[selectedCharacter].text = PlayerPrefs.GetString("namePlayer");
        //else label[selectedCharacter].text = prefab.name;

        //label[selectedCharacter].rectTransform.rotation.y = 0f;
    }
}