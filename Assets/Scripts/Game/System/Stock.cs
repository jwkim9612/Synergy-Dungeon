using System.Collections.Generic;

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

    public float probability { get; set; }
    public List<int> stockIds { get; set; }
}
