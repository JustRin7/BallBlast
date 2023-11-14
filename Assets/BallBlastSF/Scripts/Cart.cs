using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cart : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float vehicleWidth;//ширина повозки

    [Header("Wheels")]
    [SerializeField] private Transform[] wheels;//массив ссылок на колеса
    [SerializeField] private float wheelRadius;//радиус колеса

    [HideInInspector] public UnityEvent CollisionStone;

    private Vector3 movementTarget;//точка перемещения повозки

    private float deltaMovement;//deltaMovement -сколько было пройдено
    private float lastPositionX;


    private void Start()
    {
        movementTarget = transform.position;//точка равна месту повозки
    }

    private void Update()
    {
        Move();
        RoteteWheel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Stone stone = collision.transform.root.GetComponent<Stone>();

        if(stone != null)
        {
            CollisionStone.Invoke();
        }
        
    }

    private void Move()
    {
        lastPositionX = transform.position.x;

        transform.position = Vector3.MoveTowards(transform.position, movementTarget, movementSpeed * Time.deltaTime);//перемещение от transform.position к movementSpeed со скоростью movementSpeed

        deltaMovement = transform.position.x - lastPositionX;
    }

    private void RoteteWheel()//метод вращения колес
    {
        float angle = (180 * deltaMovement) / (Mathf.PI * wheelRadius * 2);// Mathf.PI * wheelRadius * 2 -диаметр
    
        for(int i = 0; i < wheels.Length; i++)//поворот колес
        {
            wheels[i].Rotate(0, 0, -angle);
        }

    }

    public void SetMovementTarget(Vector3 target)
    {
        movementTarget = ClampMovementTarget(target);
    }

    private Vector3 ClampMovementTarget(Vector3 target)//ограничение координат перемещения
    {
        float leftBorder = LevelBoundary.Instance.LeftBorder + vehicleWidth * 0.5f;
        float rightBorder = LevelBoundary.Instance.RightBorder - vehicleWidth * 0.5f;

        Vector3 moveTarget = target;
        moveTarget.z = transform.position.z;
        moveTarget.y = transform.position.y;

        if(moveTarget.x < leftBorder)
        {
            moveTarget.x = leftBorder;
        }

        if (moveTarget.x > rightBorder)
        {
            moveTarget.x = rightBorder;
        }

        return moveTarget;

    }


#if UNITY_EDITOR //код не будет выполняться в билде игры
    private void OnDrawGizmosSelected()//линия для отрисовка габаритов повозки
    //OnDrawGizmosSelected Гизмо будет срабатывать только при выделении объекта
    //OnDrawGizmos Гизмо будет срабатывать всегда
    {
        Gizmos.color = Color.black;//выбрать цвет объекта
        Gizmos.DrawLine( transform.position - new Vector3(vehicleWidth * 0.5f, 0.5f, 0), transform.position + new Vector3(vehicleWidth * 0.5f, -0.5f, 0));// в скобказ 2 координаты
    }
#endif

}
