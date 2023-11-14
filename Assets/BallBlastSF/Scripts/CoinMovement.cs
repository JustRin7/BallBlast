using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    [SerializeField] private float gravity;//гравитация
    [SerializeField] private float reboundlSpeed;//сорость при соприкосновении с триггером
    [SerializeField] private float horisontslSpeed;//горизонтальная сорость
    [SerializeField] private float rotationSpeed;//сорость вращения
    [SerializeField] private float gravityOffset;//время, через которое камень упадет в начале

    private bool UseGravity;//вкл-выкл графитации

    private Vector3 velocity;//скорость камней


    private void Awake()
    {
        velocity.x = -Math.Sign(transform.position.x) * horisontslSpeed;
    }


    private void Update()
    {
        TryEnableGravity();
        Move();
    }


    private void TryEnableGravity()//метод вкл-выкл гравитации
    {
        if (Math.Abs(transform.position.x) <= Math.Abs(LevelBoundary.Instance.LeftBorder) - gravityOffset)//Math.Abs() - абсолютное значение (число без знаков)
        {
            UseGravity = true;
        }
    }


    private void Move()
    {
        if (UseGravity == true)
        {
            velocity.y -= gravity * Time.deltaTime;//движение вниз
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }

        if (reboundlSpeed == 1)
        {
            enabled = false;
        }

            velocity.x = Math.Sign(velocity.x) * horisontslSpeed;
        transform.position += velocity * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        LevelEdge levelEdge = collision.GetComponent<LevelEdge>();

        if (levelEdge != null)
        {

            if (levelEdge.Type == EdgeType.Botom)
            {

                velocity.y = reboundlSpeed;
                reboundlSpeed--;
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
        velocity.x = Math.Sign(direction) * horisontslSpeed;// Math.Sign берем знак числа direction
    }


}
