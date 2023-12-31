using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] private ProductObjectSO productObjectSO;

    public override void Interact(Player player)
    {
        int currentProduct = GetComponent<ProductStockUI>().currentStock;
        if (!player.HasProductObject() && currentProduct >= 1)
        {
            // Player is not caryying anything
            ProductObject.SpawnProductObject(productObjectSO, player);
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
            GetComponent<ProductStockUI>().ReduceStock();
        }
    }
}
