using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartInputControl : MonoBehaviour
{
    [SerializeField] private Cart cart;//������ �� ������ Cart
    [SerializeField] private Turret turret;//������ �� ������ Turret

    private void Update()
    {
        cart.SetMovementTarget( Camera.main.ScreenToWorldPoint(Input.mousePosition) );//ScreenToWorldPoint - �������� ���������� � �������
        //������ � ����� main
        
        if( Input.GetMouseButtonDown(0) == true )
        {
            
            turret.Fire();
        }
    }
}
