using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;//������� �����

public class Destructable : MonoBehaviour
{
    public int maxHitPoints;

    [HideInInspector] public UnityEvent Die;//����� ������
    [HideInInspector] public UnityEvent ChangeHitPoints;//����� ���������� �� ����

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

        ChangeHitPoints.Invoke();//�������� ������� ChangeHitPoints
        
    }


    public void ApplyDamage(int damage)
    {
        hitPoints -= damage;

        ChangeHitPoints.Invoke();//�������� ������� ChangeHitPoints

        if (hitPoints <= 0)
        {
            //hitPoints = 0;
            //Die.Invoke();//�������� �����
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

    ////// �������� �� ��. ������� //////
    public int GetHitPoints()
    {
        return hitPoints;
    }

}
