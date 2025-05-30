using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    public GameObject player;
    public int indexPlayer;

    public Quest quest;
    public GameObject questWindow;
    public Text titleBox;
    public Text descriptionBox;
    public Text descriptionBoxExtra1;
    public Text descriptionBoxExtra2;
    public GameObject completeMision;
    public bool active;

    public GameObject loadingScreen;
    public GameObject questGiver;
    public GameObject cameraBase;
    public GameObject savedPersons;
    public GameObject music;
    public GameObject canvas;

    public GameObject theSyringe;
    public GameObject theChronometer;
    public GameObject lights;
    public GameObject mainScientist;
    public GameObject guardScientist;
    public GameObject theEnemies;
    public int zombiesCountNormal;
    public int zombiesCountBoss;
    public Image barraVida, imageDamage;
    public float munitionDose;
    public GameObject interfaceDisplay;

    public GameObject endGameText;
    public GameObject timeOver;
    public GameObject successGame;
    public WhenComplete complete;
    public Color temp;
    public float startTime;
    public float timer = 0f;

    //Checkpoint
    public GameObject buttonCheckpoint;
    public GameObject buttonCheckpointTime;
    //public Transform lastCheckpoint;

    public GameObject mutant;
    public Animator anim;

    public bool onlyonetime4 = false;
    public bool onlyonetime5 = false;
    public bool usingChronometer = false;
    public bool blockedFourMission;
    public bool onlyOneTimeIntro = false;
    public bool onlyOneTimeLoad = false;
    public bool onlyOneTimeLoadScene = false;
    public bool onlyOneTimeFinal = false;
    public bool onlyOneTimeAdvise = false;
    public bool onlyOneTimeRememberAdds = false;
    private void Awake()
    {
        if (manager == null)
        {
            manager = this;

            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        if (cameraBase == null)
            Instantiate(cameraBase, new Vector3(0, 0, 0), Quaternion.identity);
        if(savedPersons == null)
            Instantiate(savedPersons, new Vector3(0, 0, 0), Quaternion.identity);
        if(music == null)
            Instantiate(music, new Vector3(0, 0, 0), Quaternion.identity);
        if(canvas == null)
            Instantiate(canvas, new Vector3(0, 0, 0), Quaternion.identity);
        if (startTime == 240)
            timer = startTime;

        loadingScreen = GameObject.FindGameObjectWithTag("loading");
        successGame = GameObject.Find("/Canvas/EndSuccessGame");
        successGame.SetActive(false);
        endGameText = GameObject.Find("/Canvas/EndGameText");
        endGameText.SetActive(false);
        timeOver = GameObject.Find("/Canvas/TextEndTime");
        timeOver.SetActive(false);
        anim = GetComponent<Animator>();
        lights = GameObject.FindGameObjectWithTag("Lights");
        mainScientist = GameObject.FindGameObjectWithTag("mainscientist");
        guardScientist = GameObject.FindGameObjectWithTag("guardscientist");
        theEnemies = GameObject.FindGameObjectWithTag("Enemies");
        theSyringe = GameObject.FindGameObjectWithTag("Syringe");
        questWindow = GameObject.Find("/Canvas/RememberQuest");
        titleBox = GameObject.FindGameObjectWithTag("titleQuest").GetComponent<Text>();
        descriptionBox = GameObject.FindGameObjectWithTag("descriptionQuest").GetComponent<Text>();
        descriptionBoxExtra1 = GameObject.FindGameObjectWithTag("descriptionQuestExtra1").GetComponent<Text>();
        descriptionBoxExtra2 = GameObject.FindGameObjectWithTag("descriptionQuestExtra2").GetComponent<Text>();
        completeMision = GameObject.Find("/Canvas/ButtonsTalk/textComplete");
        interfaceDisplay = GameObject.Find("/Canvas/LifeAndMunition");
        imageDamage = GameObject.Find("/Canvas/ImageDamage").GetComponent<Image>();
        theChronometer = GameObject.Find("/Canvas/Chronometer");

        //Checkpoint
        buttonCheckpoint = canvas.transform.GetChild(7).gameObject.transform.GetChild(0).gameObject;
        buttonCheckpointTime = canvas.transform.GetChild(8).gameObject.transform.GetChild(0).gameObject;

        //GameObject.Find("/Canvas/EndGameText/ReintentarButton");
        //buttonCheckpointTime = GameObject.Find("/Canvas/TextEndTime/ReintentarButton");
        mutant = GameObject.Find("/Enemies/ADDSmutantpersons (1)");

        //Cargando el personaje seleccionado
        indexPlayer = PlayerPrefs.GetInt("selectedCharacter");
        player = GameObject.FindGameObjectWithTag("characters").transform.GetChild(indexPlayer).gameObject;
        Debug.Log(GameObject.FindGameObjectWithTag("characters").transform.GetChild(indexPlayer).gameObject);
        
        questWindow.SetActive(false);
        theEnemies.SetActive(false);
        theChronometer.SetActive(false);
        theSyringe.transform.gameObject.SetActive(false);

        interfaceDisplay.transform.GetChild(0).gameObject.SetActive(false);
        interfaceDisplay.transform.GetChild(1).gameObject.SetActive(false);

        barraVida = interfaceDisplay.transform.GetChild(3).gameObject.GetComponent<Image>();
    }

    void Update()
    {
        loadQuestBox();
        loadElements();
        if (quest.isActive)
            questWindow.SetActive(true);
        else questWindow.SetActive(false);

        /**Checkpoint
        secondsCounter += Time.deltaTime;
        Debug.Log(secondsCounter);
        if (secondsCounter >= secondsToCount && barraVida.fillAmount < 1)
        {
            secondsCounter = 0;
            lastCheckpoint = GameObject.FindGameObjectWithTag("Player").transform;
        }**/
    }
    public String GetToTextQuest()
    {
        return quest.title;
    }
    public void loadQuestBox()
    {
        if (questWindow == null)
        {
            questWindow = GameObject.Find("/Canvas/RememberQuest");
            titleBox = GameObject.FindGameObjectWithTag("titleQuest").GetComponent<Text>();
            descriptionBox = GameObject.FindGameObjectWithTag("descriptionQuest").GetComponent<Text>();
            descriptionBoxExtra1 = GameObject.FindGameObjectWithTag("descriptionQuestExtra1").GetComponent<Text>();
            descriptionBoxExtra2 = GameObject.FindGameObjectWithTag("descriptionQuestExtra2").GetComponent<Text>();

            titleBox.text = quest.title;

            descriptionBox.text = quest.description;
            descriptionBoxExtra1.text = quest.descriptionExtra1;
            descriptionBoxExtra2.text = quest.descriptionExtra2;
        }
    }
    public void loadElements()
    {
        if (loadingScreen == null)
            loadingScreen = GameObject.FindGameObjectWithTag("loading");

        if (interfaceDisplay == null)
        {
            completeMision = GameObject.Find("/Canvas/ButtonsTalk/textComplete");
            interfaceDisplay = GameObject.Find("/Canvas/LifeAndMunition");
        }

        if (imageDamage == null)
            imageDamage = GameObject.Find("/Canvas/ImageDamage").GetComponent<Image>();

        if (barraVida == null)
            barraVida = interfaceDisplay.transform.GetChild(3).gameObject.GetComponent<Image>();

        if (barraVida.fillAmount >= 1 && GameObject.FindGameObjectWithTag("Player") != null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health_and_Damage>().GameOver();
        }

        barraVida.fillAmount = Health_and_Damage.converted / 100;
        imageDamage.color = temp;

        if (theEnemies == null)
            theEnemies = GameObject.FindGameObjectWithTag("Enemies");

        if (quest == null)
        {
            theEnemies.SetActive(false);
            theSyringe.transform.gameObject.SetActive(false);
        }
        
        if (savedPersons == null)
            savedPersons = GameObject.FindGameObjectWithTag("SavedPersons");

        if (endGameText == null)
        {
            endGameText = GameObject.Find("/Canvas/EndGameText");
            endGameText.SetActive(false);
        }

        if (timeOver == null)
        {
            timeOver = GameObject.Find("/Canvas/TextEndTime");
            timeOver.SetActive(false);
        }

        if (successGame == null)
        {
            successGame = GameObject.Find("/Canvas/EndSuccessGame");
            successGame.SetActive(false);
        }

        if (theChronometer == null)
            theChronometer = GameObject.Find("/Canvas/Chronometer");

        if (buttonCheckpoint == null)
            buttonCheckpoint = canvas.transform.GetChild(7).gameObject.transform.GetChild(0).gameObject;
        //buttonCheckpoint = GameObject.Find("/Canvas/EndGameText/ReintentarButton");

        if (buttonCheckpointTime == null)
            buttonCheckpointTime = canvas.transform.GetChild(8).gameObject.transform.GetChild(0).gameObject;
        //buttonCheckpointTime = GameObject.Find("/Canvas/TextEndTime/ReintentarButton");

        if (mutant == null)
            mutant = GameObject.Find("/Enemies/ADDSmutantpersons (1)");

        if (lights == null)
            lights = GameObject.FindGameObjectWithTag("Lights");
        
        if (theSyringe == null)
            theSyringe = GameObject.FindGameObjectWithTag("Syringe");

        if (questGiver == null)
            questGiver = GameObject.Find("/QuestGiver");

        //Comprobando si estamos en la escena del respawn y reestablecemos el personaje
        if (SceneManager.GetActiveScene().name == "SegundaPlanta" && GameObject.FindGameObjectWithTag("Player") == null && barraVida.fillAmount >= 1)
        {
            indexPlayer = PlayerPrefs.GetInt("selectedCharacter");
            player = GameObject.FindGameObjectWithTag("characters").transform.GetChild(indexPlayer).gameObject;
            Debug.Log(GameObject.FindGameObjectWithTag("characters").transform.GetChild(indexPlayer).gameObject);
            lifeAgain();
        }
        if (SceneManager.GetActiveScene().name == "SegundaPlanta" && GameObject.FindGameObjectWithTag("Player") == null && timer == 0)
        {
            indexPlayer = PlayerPrefs.GetInt("selectedCharacter");
            player = GameObject.FindGameObjectWithTag("characters").transform.GetChild(indexPlayer).gameObject;
            Debug.Log(GameObject.FindGameObjectWithTag("characters").transform.GetChild(indexPlayer).gameObject);
            timeAgain();
        }

        /** MISSION 2 **/
        if (GetToTextQuest() == "Terror en el MIC" && !onlyOneTimeAdvise)
        {
            onlyOneTimeAdvise = true;
            GameObject.FindGameObjectWithTag("loading").transform.GetChild(2).gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("loading").transform.GetChild(2).gameObject.GetComponent<AudioSource>().Play();
            Debug.Log(GameObject.FindGameObjectWithTag("loading").transform.GetChild(2).gameObject);
        }

        if (SceneManager.GetActiveScene().name == "EXTERIORCASIFINAL" && (GetToTextQuest() == "Terror en el MIC" || GetToTextQuest() == "Sin luz y sin defensas"))
        {
            GameObject.FindGameObjectWithTag("door").transform.position = GameObject.FindGameObjectWithTag("doorOpen").transform.position;
            GameObject.FindGameObjectWithTag("door").transform.rotation = GameObject.FindGameObjectWithTag("doorOpen").transform.rotation;
            GameObject.FindGameObjectWithTag("door").transform.localScale = GameObject.FindGameObjectWithTag("doorOpen").transform.localScale;
        }

        /** MISSION 3 **/
        //we arrived to the mission that activate adds?
        if (quest.activateAdds)
        {

            interfaceDisplay.transform.GetChild(2).gameObject.GetComponent<Image>().enabled = true;
            interfaceDisplay.transform.GetChild(3).gameObject.GetComponent<Image>().enabled = true;
            interfaceDisplay.transform.GetChild(4).gameObject.GetComponent<Image>().enabled = true;

            theEnemies.SetActive(true);
        }
        else
        {
            interfaceDisplay.transform.GetChild(0).gameObject.SetActive(false);
            interfaceDisplay.transform.GetChild(1).gameObject.SetActive(false);
            interfaceDisplay.transform.GetChild(2).gameObject.GetComponent<Image>().enabled = false;
            interfaceDisplay.transform.GetChild(3).gameObject.GetComponent<Image>().enabled = false;
            interfaceDisplay.transform.GetChild(4).gameObject.GetComponent<Image>().enabled = false;
            theEnemies.SetActive(false);
        }

        /** MISSION 4 **/
        //we arrived to the chronometer quest?
        if (quest.activateChronometer && !usingChronometer)
        {
            usingChronometer = true;
            Debug.Log("Quest con cronómetro activada.");
            theChronometer.SetActive(true);
            theChronometer.GetComponent<CountDownTimer>().BeginChronometer();
        }
        if (!quest.activateChronometer)
            theChronometer.SetActive(false);

        //activating counter of light and vacune
        if (quest.title == "Sin luz y sin defensas" && quest.goal.currentAmount == 0)
        {
            //reset health bar and color damage
            /**if (!onlyonetime4)
            {
                onlyonetime4 = true;
                barraVida.fillAmount = 0;
                temp = imageDamage.color;
                temp.a = 0f;
                imageDamage.color = temp;
            }**/

            lights.SetActive(false);
            interfaceDisplay.transform.GetChild(0).gameObject.SetActive(false);
            interfaceDisplay.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (quest.title == "Sin luz y sin defensas" && quest.goal.currentAmount == 1)
        {
            descriptionBoxExtra1.text = "1/1   Activa la corriente del MIC";
            lights.SetActive(true);
        }
        else if (quest.title == "Sin luz y sin defensas" && quest.goal.currentAmount >= 2)
        {
            descriptionBoxExtra1.enabled = false;
            descriptionBoxExtra2.enabled = false;
            descriptionBox.text = "Completado. Vuelve con el científico de guardia";
            lights.SetActive(true);
        }

        /** MISSION 5 **/
        //we arrived to the syringe mission?
        if (quest.activateSyringe)
        {
            if (!onlyonetime5)
            {
                onlyonetime5 = true;
                zombiesCountBoss = 0;
                zombiesCountNormal = 0;

                descriptionBoxExtra1.enabled = true;
                descriptionBoxExtra2.enabled = true;
            }

            if (SceneManager.GetActiveScene().name == "EXTERIORCASIFINAL" && !onlyOneTimeRememberAdds)
            {
                onlyOneTimeRememberAdds = true;
                descriptionBoxExtra1.text = zombiesCountNormal + "/10   Mutantes sanados";
                descriptionBoxExtra2.text = zombiesCountBoss + "/1   Quinto paciente sanado";
            }

            if (GameObject.FindGameObjectWithTag("mainscientist") != null)
            {
                GameObject.FindGameObjectWithTag("mainscientist").transform.localPosition = new Vector3(-45.27f, 0.1f, -8.6f);
                GameObject.FindGameObjectWithTag("mainscientist").GetComponent<Animator>().Play("Idle");
            }

            descriptionBoxExtra1.text = zombiesCountNormal + "/10   Mutantes sanados";
            descriptionBoxExtra2.text = zombiesCountBoss + "/1   Quinto paciente sanado";

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            usingChronometer = false;
            theSyringe.SetActive(true);
            theSyringe.GetComponent<syringe>().canShoot = true;

            interfaceDisplay.transform.GetChild(0).gameObject.SetActive(true);
            interfaceDisplay.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            interfaceDisplay.transform.GetChild(0).gameObject.SetActive(false);
            interfaceDisplay.transform.GetChild(1).gameObject.SetActive(false);
        }

        /** MISSION 6 **/
        //we arrived to the final mission and we talked with the scientific? go to final scene
        if (quest.title == "Héroe sin capa" && !onlyOneTimeLoadScene)
        {
            onlyOneTimeLoadScene = true;
            SceneManager.LoadScene("FINALSCENE");
        }

        if (GameObject.FindGameObjectWithTag("finalposition") != null && !onlyOneTimeFinal)
        {
            onlyOneTimeFinal = true;
            GameObject finalpos = GameObject.FindGameObjectWithTag("finalposition");
            Debug.Log(finalpos);

            if (GameObject.FindGameObjectWithTag("Player"))
            {
                MainController.instance.transform.position = finalpos.transform.position;
                MainController.instance.transform.rotation = finalpos.transform.rotation;
                MainController.instance.transform.localScale = finalpos.transform.localScale;
                Debug.Log("finalposition");
            }

            GetComponent<AudioSource>().volume = 0;
            GetComponent<AudioSource>().enabled = false;
            Debug.Log("audiosource" + GetComponent<AudioSource>());
            GameObject.FindGameObjectWithTag("mainInterface").SetActive(false);
            interfaceDisplay.SetActive(false);
            usingChronometer = false;
            theSyringe.SetActive(false);

            temp = imageDamage.color;
            temp.a = 0f;
            imageDamage.color = temp;
        }
    }
    public void textCompleted()
    {
        StartCoroutine(textCronometer());
    }
    IEnumerator textCronometer()
    {
        completeMision.GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(2f);
        completeMision.GetComponent<Text>().enabled = false;
    }

    public void resetTime()
    {
        timer = 300;
    }

    public void endSuccessGame()
    {
        Debug.Log("Felicidades, has completado el juego."); 
        successGame.SetActive(true);
        GameObject.Find("/Canvas/EndSuccessGame").SetActive(true);
        Time.timeScale = 0;
    }

    /** CHECKPOINT **/
    public void goCheckpoint()
    {
        Debug.Log("estamos en el checkpoint");
        if (barraVida.fillAmount >= 1)
            buttonCheckpoint.GetComponent<Button>().onClick.AddListener(() => lifeAgain());

        if (timer == 0)
            buttonCheckpointTime.GetComponent<Button>().onClick.AddListener(() => timeAgain());
    }
    public void lifeAgain()
    {
        //Activamos el personaje
        if (SceneManager.GetActiveScene().name != "SegundaPlanta")
        {
            Debug.Log("NO estamos en la segunda"); 
            StartCoroutine(LoadAsynchronously("SegundaPlanta"));
        }
        else
        {
            Debug.Log("SI estamos en la segunda");
            player.gameObject.SetActive(true);
            MainController.instance.transform.position = GameObject.Find("Respawn").transform.position;
            MainController.instance.transform.rotation = GameObject.Find("Respawn").transform.rotation;
            MainController.instance.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

            //Reiniciamos municion
            munitionDose = 150;

            //Reiniciamos barra de vida
            Health_and_Damage.converted = 0;
            barraVida.fillAmount = 0;

            //Reiniciamos imagen de daño
            temp = imageDamage.color;
            temp.a = 0f;
            imageDamage.color = temp;


            quest.goal.currentAmount = 0;
            zombiesCountBoss = 0;
            zombiesCountNormal = 0;
            Debug.Log("entramooooos");
            //Movemos el personaje al checkpoint
            //player.transform.position = lastCheckpoint.position;

            //Reiniciamos cronometro
            resetTime();

            //Quitamos interfaz
            endGameText.SetActive(false);

            //Reactivamos cursor
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;

            Debug.Log("Checkpoint RENACER completado.");

            Time.timeScale = 1;
        }    
    }
    private void timeAgain()
    {
        //Activamos el personaje
        if (SceneManager.GetActiveScene().name != "SegundaPlanta")
        {
            Debug.Log("NO estamos en la segunda"); 
            StartCoroutine(LoadAsynchronously("SegundaPlanta"));
        }
        else
        {
            Debug.Log("SI estamos en la segunda");
            player.gameObject.SetActive(true);
            MainController.instance.transform.position = GameObject.Find("Respawn").transform.position;
            MainController.instance.transform.rotation = GameObject.Find("Respawn").transform.rotation;
            MainController.instance.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

            //Reiniciamos municion
            munitionDose = 150;

            //Reiniciamos barra de vida
            Health_and_Damage.converted = 0;
            barraVida.fillAmount = 0;

            //Reiniciamos imagen de daño
            temp = imageDamage.color;
            temp.a = 0f;
            imageDamage.color = temp;

            quest.goal.currentAmount = 0;
            zombiesCountBoss = 0;
            zombiesCountNormal = 0;
            //Movemos el personaje al checkpoint
            //player.transform.position = lastCheckpoint.position;

            //Reiniciamos cronometro
            resetTime();

            //Quitamos interfaz
            timeOver.SetActive(false);

            //Reactivamos cursor
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;

            Debug.Log("Checkpoint RESTART TIME completado.");

            Time.timeScale = 1;
        }
    }

    IEnumerator LoadAsynchronously(String sceneToLoad)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            /**GameManager.manager.loadingScreen.transform.GetChild(1).GetComponent<Slider>().value = progress;
            Debug.Log(progress);
            GameManager.manager.loadingScreen.transform.GetChild(1).GetComponent<Text>().text = progress * 100f + "%";**/
            yield return null;
        }
        Debug.Log("cambiando a escena de respawn");
    }
}