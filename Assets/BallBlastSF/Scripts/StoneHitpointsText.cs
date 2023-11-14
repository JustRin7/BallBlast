using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Destructable))]
public class StoneHitpointsText : MonoBehaviour
{
    [SerializeField] private Text hitpointText;
    private Destructable destructable;

    private void Awake()
    {
        destructable = GetComponent<Destructable>();
        destructable.ChangeHitPoints.AddListener(OnChangeHitPoints);
    }

    private void OnDestroy()
    {
        destructable.ChangeHitPoints.RemoveListener(OnChangeHitPoints);
    }

    private void OnChangeHitPoints()
    {
        int hitPoints = destructable.GetHitPoints();

        if (hitPoints >= 1000)
        {
            hitpointText.text = hitPoints / 1000 + "K";
        }
        else
            hitpointText.text = hitPoints.ToString();
    }
}
