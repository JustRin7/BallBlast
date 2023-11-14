using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;//префаб пули
    [SerializeField] private Transform shootPoint;//позиця стрельбы
    [SerializeField] private float fireRate;//скорострельность
    [SerializeField] private int damage;//дамаг
    [SerializeField] public int projectileAmount;//кол-во пуль
    [SerializeField] private float projectileInterval;//расстояние между пулями
    [SerializeField] private new AudioSource audio;//выбор звука выстрела, пишем new, чтобы не было конфликтов

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

    private void SpavnProjectile()//создание пули
    {
        float startPosX = shootPoint.position.x - projectileInterval * (projectileAmount - 1) * 0.5f;//стартовая позиция первой пули
        //заданная позиция - интервал между пулями * (кол-во пуль - 1) // -1 -это интервал от первой до ост. пуль //  * 0.5f - т. к. пули находятся слева и справа от первой пули

        for( int i = 0; i < projectileAmount; i++)//спавн пуль
        {
            // Instantiate(projectilePrefab, shootPoint.position, transform.rotation);            
            Projectile projectile = Instantiate( projectilePrefab, new Vector3(startPosX + i * projectileInterval, shootPoint.position.y, shootPoint.position.z ), transform.rotation );
            audio.Play();//воспроизводит звук
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
