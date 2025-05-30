using UnityEngine;

[System.Serializable]
public class Quest
{
    public string title;
    public string description;
    public string descriptionExtra1, descriptionExtra2;
    public string npc;

    public QuestGoal goal;

    public bool isActive;
    public bool complete;

    public bool activateAdds; //quest3
    public bool activateChronometer; //quest4
    public bool activateSyringe; //quest5
    //public int reward;

    public void Complete(Quest quest)
    {
      
        quest.complete = true;
        quest.isActive = false;
        GameObject.Find("/Canvas/RememberQuest").SetActive(false);
    }

    
}