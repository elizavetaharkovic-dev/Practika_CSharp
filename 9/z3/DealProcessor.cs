class DealProcessor
{
    public Deal FindMostProfitableDeal(List<Deal> deals)
    {
        Deal deal = deals[0];

        for (int i = 1; i < deals.Count; i++)
        {
            if (deals[i].Revenue > deal.Revenue) deal = deals[i];
        }
        return deal;
    }
    public Deal FindDealById(List<Deal> deals, int id)
    {
        foreach (Deal deal in deals)
        {
            if (deal.Id == id) return deal;
        }
        return null;
    }
    public List<Deal> FilterByRevenue(List<Deal> deals, float minRevenue)
    {
        List<Deal> result = new List<Deal>();
        
        foreach (Deal deal in deals)
        {
            if (deal.Revenue > minRevenue) result.Add(deal);
        }
        return result;
    }
    public void SortByRevenueDesc(List<Deal> deals)
    {
        for (int j = 0; j < deals.Count; j++)
        { 
            for (int i = j + 1; i < deals.Count; i++)
            {
                if (deals[i].Revenue < deals[j].Revenue)
                {
                    Deal temp = deals[i];
                    deals[i] = deals[j];
                    deals[j] = temp;
                }
            }
        }
    }
}