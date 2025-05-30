using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseCharacter : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;

    public Text labelNameStory;
    public Text labelNameMultiStory;
    public Text labelNameChallenge;
    public Text labelNameMultiChallenge;
    public TMPro.TMP_InputField nameStory;
    public TMPro.TMP_InputField nameChallenge;

    public void Start()
    {
        characters = new GameObject[22];
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i] = gameObject.transform.GetChild(i).gameObject;
            characters[i].SetActive(false);
        }
        selectedCharacter = 0;

        labelNameMultiStory.text = characters[selectedCharacter].name;
        labelNameStory.text = characters[selectedCharacter].name;
        labelNameMultiChallenge.text = characters[selectedCharacter].name;
        labelNameChallenge.text = characters[selectedCharacter].name;
    }

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);

        labelNameMultiStory.text = characters[selectedCharacter].name;
        labelNameStory.text = characters[selectedCharacter].name;
        labelNameMultiChallenge.text = characters[selectedCharacter].name;
        labelNameChallenge.text = characters[selectedCharacter].name;
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);

        labelNameMultiStory.text = characters[selectedCharacter].name;
        labelNameStory.text = characters[selectedCharacter].name;
        labelNameMultiChallenge.text = characters[selectedCharacter].name;
        labelNameChallenge.text = characters[selectedCharacter].name;
    }

    public void StartGame()
    {
        nameStory.text = GameObject.FindGameObjectWithTag("nick").GetComponent<TMPro.TMP_InputField>().text;
        nameChallenge.text = GameObject.FindGameObjectWithTag("nick").GetComponent<TMPro.TMP_InputField>().text;

        if(nameStory.text != null)
            PlayerPrefs.SetString("namePlayer", nameStory.text.ToString());
        else if (nameChallenge != null)
            PlayerPrefs.SetString("namePlayer", nameChallenge.text.ToString());

        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
    }
}
