using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;//������ ����
    [SerializeField] private Transform shootPoint;//������ ��������
    [SerializeField] private float fireRate;//����������������
    [SerializeField] private int damage;//�����
    [SerializeField] public int projectileAmount;//���-�� ����
    [SerializeField] private float projectileInterval;//���������� ����� ������
    [SerializeField] private new AudioSource audio;//����� ����� ��������, ����� new, ����� �� ���� ����������

    public static int currentprojectileAmount;
    public static int currentDamage;
    public static float currentFireRate;

    private void Start()
    {
        currentprojectileAmount = projectileAmount;
        currentDamage = damage;
        currentFireRate = fireRate;
    }


    public int Damage => damage;
    public int ProjectileAmount => projectileAmount;
    public float FireRate => fireRate;

    private float timer;

    private void Update()
    {
        projectileAmount = currentprojectileAmount;
        damage = currentDamage;
        fireRate = currentFireRate;

        timer += Time.deltaTime;
    }

    private void SpavnProjectile()//�������� ����
    {
        float startPosX = shootPoint.position.x - projectileInterval * (projectileAmount - 1) * 0.5f;//��������� ������� ������ ����
        //�������� ������� - �������� ����� ������ * (���-�� ���� - 1) // -1 -��� �������� �� ������ �� ���. ���� //  * 0.5f - �. �. ���� ��������� ����� � ������ �� ������ ����

        for( int i = 0; i < projectileAmount; i++)//����� ����
        {
            // Instantiate(projectilePrefab, shootPoint.position, transform.rotation);            
            Projectile projectile = Instantiate( projectilePrefab, new Vector3(startPosX + i * projectileInterval, shootPoint.position.y, shootPoint.position.z ), transform.rotation );
            audio.Play();//������������� ����
            projectile.SetDamage(damage);
        }
        
    }

    public void Fire()
    {
        if(timer >= fireRate)
        {
            SpavnProjectile();
            
            timer = 0;
        }
    }

}
