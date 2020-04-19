using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stock
{
    public Stock()
    {
        probability = 0.0f;
        stockIds = new List<int>();
    }

    public Stock(float probability, List<int> stockIds)
    {
        this.probability = probability;
        this.stockIds = stockIds;
    }

    public float probability;
    public List<int> stockIds;
}
