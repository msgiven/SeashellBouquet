using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using NUnit.Framework;
public class ClearDust : MiniGameBase
{
    [SerializeField] private List<RawImage> nets;
    [SerializeField] private MoveUIItem brush;

    private void Update()
    {
        if (nets.Count == 0)
        {
            seashell.interactable = true;
            return;
        }

        for (int i = nets.Count-1; i >= 0; i--) {
            
            if (nets[i] != null) {
                if (Vector3.Distance(brush.RectTransform.localPosition, nets[i].rectTransform.localPosition) <= 150 && brush.isMoving)
                {
                    Color color = nets[i].color;
                    color.a -= Time.deltaTime;
                    nets[i].color = color;
                
                    if (color.a <= 0)
                    {
                        RawImage netToDestroy = nets[i];
                        nets.Remove(nets[i]);
                        Destroy(netToDestroy.gameObject);
                    }
                }
            }
        }
    }

    public void TakeSeashell()
    {
        Destroy(seashell.gameObject);
    }
}
