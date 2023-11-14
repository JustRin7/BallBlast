using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartInputControl : MonoBehaviour
{
    [SerializeField] private Cart cart;//ссылка на скрипт Cart
    [SerializeField] private Turret turret;//ссылка на скрипт Turret

    private void Update()
    {
        cart.SetMovementTarget( Camera.main.ScreenToWorldPoint(Input.mousePosition) );//ScreenToWorldPoint - экранные координаты в мировые
        //камера с тэгом main
        
        if( Input.GetMouseButtonDown(0) == true )
        {
            
            turret.Fire();
        }
    }
}
