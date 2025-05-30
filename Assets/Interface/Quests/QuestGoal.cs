using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;
    //public health_and_damageIA enemy;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void EnemyKilled()
    {
        if (goalType == GoalType.Kill && requiredAmount!=currentAmount)
            //if(enemy.slider.value <= 0) //revisar
                currentAmount++;
    }
    public void ItemCollected()
    {
        if (goalType == GoalType.Gathering && requiredAmount!=currentAmount)
            currentAmount++;
    }

    public enum GoalType
    {
        Kill,
        Gathering,
        Find
    }
}
