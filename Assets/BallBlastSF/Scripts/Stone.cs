using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StoneMovement))]
public class Stone : Destructable
{
    public enum Size
    {
        Small,
        Normal,
        Big,
        Huge
    }

    [SerializeField] private Size size;//выбор р-ра камн€
    [SerializeField] private float spawnUpForce;//префаб камн€

    [SerializeField] private GameObject impactEffect;//ссылаемс€ на скрипт impactEffect

    private StoneMovement movement;

    private void Awake()
    {
        movement = GetComponent<StoneMovement>();

        Die.AddListener(OnStoneDestroyed);

        SetSize(size);
    }

    private void OnDestroy()
    {
        Die.RemoveListener(OnStoneDestroyed);
    }

    private void OnStoneDestroyed()//разрушение большого камн€
    {
        if(size != Size.Small)
        {
            SpawnStones();
        }        
        Destroy(gameObject);

        int rnd = Random.Range(0, 2);
        if(rnd == 1)
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }
        
    }

    private void SpawnStones()
    {
        for(int i = 0; i < 2; i++) 
        {
            Stone stone = Instantiate(this, transform.position, Quaternion.identity);//можно вместо this написать stoneOgject или gameObject
            
            stone.SetSize(size - 1);
            stone.maxHitPoints = Mathf.Clamp(maxHitPoints / 2, 1, maxHitPoints);
            stone.movement.AddVerticalVelocity(spawnUpForce);
            stone.movement.SethorizontalDirection( (i % 2 * 2) - 1 );
        }        
    }

    public void SetSize(Size size)//получение р-ра камн€
    {
        if (size < 0) return;

        transform.localScale = GetVectorFromSize(size);
        this.size = size;
    }

    private Vector3 GetVectorFromSize(Size size)//задание размера камн€
    {
        if (size == Size.Huge) return new Vector3(1, 1, 1);
        if (size == Size.Big) return new Vector3(0.7f, 0.7f, 0.7f);
        if (size == Size.Normal) return new Vector3(0.6f, 0.6f, 0.6f);
        if (size == Size.Small) return new Vector3(0.4f, 0.4f, 0.4f);

        return Vector3.one;
    }

}
