using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;//события юнити

public class Destructable : MonoBehaviour
{
    public int maxHitPoints;

    [HideInInspector] public UnityEvent Die;//эвент смерть
    [HideInInspector] public UnityEvent ChangeHitPoints;//эвент обновления хп бара

    private int hitPoints;

    private bool isDie = false;

    private void Start()
    {
        hitPoints = maxHitPoints;

        ChangeHitPoints.Invoke();
    }



    public void ApplyHill(int hill)
    {
        if (hitPoints < maxHitPoints)
        {
            hitPoints += hill;
            if(hitPoints > maxHitPoints)
            {
                hitPoints = maxHitPoints;
            }
        }
        else return;        

        ChangeHitPoints.Invoke();//вызываем событие ChangeHitPoints
        
    }


    public void ApplyDamage(int damage)
    {
        hitPoints -= damage;

        ChangeHitPoints.Invoke();//вызываем событие ChangeHitPoints

        if (hitPoints <= 0)
        {
            //hitPoints = 0;
            //Die.Invoke();//вызываем эвент
            Kill();
        }
    }

    public void Kill()
    {
        if (isDie == true) return;

        hitPoints = 0;
        isDie = true;

        ChangeHitPoints.Invoke();
        Die.Invoke();
    }

    ////// Передача хп др. скрипту //////
    public int GetHitPoints()
    {
        return hitPoints;
    }

}
