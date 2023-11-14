using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoneSpawner : MonoBehaviour
{

    [Header("Spawn")]
    [SerializeField] private Stone stonePrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate;//скорость спавна

    [Header("Balance")]
    [SerializeField] private Turret turret;//туррель
    [SerializeField] private int amount;//кол-во камней    
    [SerializeField] [Range(0.0f, 1.0f)] private float minHitpointsPercentage;//процент минимального кол-ва хп
    [SerializeField] private float maxHitPointsRate;//каэфициент хп

    [Space(5)] public UnityEvent Completed;

    private float timer;
    private float amountSpawned;//кол-во заспамленных камней
    private int stoneMaxHitPoints;//максимальное кол-во хп
    private int stoneMinHitPoints;//минимальное кол-во хп

    private void Start()
    {
        int damagePerSecon = (int) ( (turret.Damage * turret.ProjectileAmount) * (1 / turret.FireRate) );

        stoneMaxHitPoints = (int) (damagePerSecon * maxHitPointsRate);
        stoneMinHitPoints = (int) (stoneMaxHitPoints * minHitpointsPercentage);

        timer = spawnRate;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            Spawn();

            timer = 0;
        }

        if(amountSpawned == amount)
        {
            enabled = false;

            Completed.Invoke();
        }

    }

    public void Spawn()
    {
        float red = Random.Range(0.5f, 1.1f);
        float green = Random.Range(0.5f, 1.1f);
        float blue = Random.Range(0.5f, 1.1f);

        Stone stone = Instantiate(stonePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        stone.GetComponentInChildren<SpriteRenderer>().color = new Color (red, green, blue, 1f); // 1f - alpha
        stone.SetSize( (Stone.Size) Random.Range(1, 4) );
        stone.maxHitPoints = Random.Range(stoneMinHitPoints, stoneMaxHitPoints + 1);

        amountSpawned++;
    }

}
