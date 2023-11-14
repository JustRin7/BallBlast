using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMovement : MonoBehaviour
{
    [SerializeField] private float gravity;//����������
    [SerializeField] private float reboundlSpeed;//������� ��� ��������������� � ���������
    [SerializeField] private float horisontslSpeed;//�������������� �������
    [SerializeField] private float rotationSpeed;//������� ��������
    [SerializeField] private float gravityOffset;//�����, ����� ������� ������ ������ � ������

    private bool UseGravity;//���-���� ����������

    private Vector3 velocity;//�������� ������


    private void Awake()
    {
        velocity.x = -Math.Sign(transform.position.x) * horisontslSpeed;
    }


    private void Update()
    {
        TryEnableGravity();
        Move();
    }


    private void TryEnableGravity()//����� ���-���� ����������
    {
        if(Math.Abs(transform.position.x) <= Math.Abs(LevelBoundary.Instance.LeftBorder) - gravityOffset)//Math.Abs() - ���������� �������� (����� ��� ������)
        {
            UseGravity = true;
        }
    }


    private void Move()
    {
        if(UseGravity == true)
        {
            velocity.y -= gravity * Time.deltaTime;//�������� ����
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        
        velocity.x = Math.Sign(velocity.x) * horisontslSpeed;
        transform.position += velocity * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        LevelEdge levelEdge = collision.GetComponent<LevelEdge>();

        if(levelEdge != null)
        {

            if(levelEdge.Type == EdgeType.Botom)
            {

                velocity.y = reboundlSpeed;
            }

            if (levelEdge.Type == EdgeType.Left && velocity.x < 0 || levelEdge.Type == EdgeType.Right && velocity.x > 0)
            {
                velocity.x *= -1;
            }

        }

    }


    public void AddVerticalVelocity(float velocity)
    {
        this.velocity.y += velocity;
    }

    public void SethorizontalDirection(float direction)
    {
        velocity.x = Math.Sign(direction) * horisontslSpeed;// Math.Sign ����� ���� ����� direction
    }


}
