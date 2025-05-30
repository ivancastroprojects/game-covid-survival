using UnityEngine;

public class WhenComplete : MonoBehaviour
{

    public void GoQuest()
    {
        //barraDeVida.fillAmount -= 1;
        //experience += 2;
        //gold += 5;

        if (GameManager.manager.quest.isActive)
        {

            GameManager.manager.quest.goal.EnemyKilled();
            //GameManager.manager.quest.goal.ItemCollected();
            
            if (GameManager.manager.quest.goal.IsReached())
            {
                if (!GameManager.manager.active)
                {
                    GameManager.manager.textCompleted();
                    GameManager.manager.active = true;
                }
                    
                GameManager.manager.quest.Complete(GameManager.manager.quest);
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }
}
