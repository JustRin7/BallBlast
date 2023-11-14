using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelState : MonoBehaviour
{
    [SerializeField] private StoneSpawner spawner;
    [SerializeField] private Cart cart;
    [SerializeField] private LevelProgress level;


    [Space(5)]
    public UnityEvent Passed;
    public UnityEvent Defeat;

    private float timer;
    private bool chekPassed;

    private void Awake()
    {
        spawner.Completed.AddListener(OnSpawnCompleted);//�������� �� �������
        cart.CollisionStone.AddListener(OnCartCollisionStone);
    }


    private void OnDestroy()
    {
        spawner.Completed.RemoveListener(OnSpawnCompleted);//������� �� �������
        cart.CollisionStone.RemoveListener(OnCartCollisionStone);
    }


    private void OnCartCollisionStone()
    {
        Defeat.Invoke();
    }


    private void OnSpawnCompleted()
    {
        chekPassed = true;
    }


    private void Update()
    {
        timer += Time.deltaTime;
                
        if(timer > 0.5f)
        {
            if (chekPassed == true)
            {
                if (FindObjectsOfType<Stone>().Length == 0)
                {                
                    Passed.Invoke();
                }
            }            

            timer = 0;
        }

        //GameObject.FindObjectsOfType<Stone>();//����� ������� �� ���� ������ ����

        //Cart cart = FindObjectOfType<Cart>();//����� ������ �� ����
        //Cart[] carts = FindObjectsOfType<Cart>();//����� ������ �������� �� ����
        //GameObject.Find("Cube");//����� ������ �� �����
        //Stone stones = GameObject.FindGameObjectWithTag("Stone");//����� ������ �� ����
        //Stone[] stones = GameObject.FindGameObjectsWithTag("Stone");//����� ������ �������� �� ����
    }

}
