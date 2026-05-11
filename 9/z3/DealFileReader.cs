class DealFileReader
{
    public List<Deal> ReadDeals()
    {
        string listJson = File.ReadAllText("file.data");
        List<Deal> listDeals = new List<Deal>();
        listJson = listJson.Trim('[', ']');
        string[] list = listJson.Split("},{");

        foreach (string str in list)
        {
            string cleaned = str.Trim('{', '}');
            string[] pairs = cleaned.Split(',');
            int id = 0;
            float revenue = 0;

            foreach (string pair in pairs)
            {
                string[] kv = pair.Split(':');
                string key = kv[0].Trim().Trim('"');
                string value = kv[1].Trim().Trim('"').Replace('.', ',');

                if (key == "Id") id = int.Parse(value);
                else if (key == "Revenue") revenue = float.Parse(value);
            }
            listDeals.Add(new Deal { Id = id, Revenue = revenue });
        }
        return listDeals;
    }
}