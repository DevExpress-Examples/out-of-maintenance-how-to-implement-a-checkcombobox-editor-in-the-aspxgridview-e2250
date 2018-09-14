using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

public class GridDataHelper {
    public static List<GridDataModel> GetData() {
        return Enumerable.Range(0, 100).Select(x => new GridDataModel {
            ID = x,
            Browsers = (x % 5) != 4 ? GetBrowserNameByID(x) + ";" + GetBrowserNameByID(x + 1) :
            GetBrowserNameByID(x + 1) + ";" + GetBrowserNameByID(x)
        }).ToList();
    }
    private static string GetBrowserNameByID(int id) {
        return (id % 5) == 0 ? "Chrome" :
            (id % 5) == 1 ? "Firefox" :
            (id % 5) == 2 ? "IE" :
            (id % 5) == 3 ? "Opera" : "Safari";
    }
    public static void UpdateRow(OrderedDictionary keys, OrderedDictionary newValues, List<GridDataModel> dataSource) {
        dataSource.Find(x => x.ID == (int)keys[0]).Browsers = (string)newValues["Browsers"];
    }
    public static void InsertRow(OrderedDictionary newValues, List<GridDataModel> dataSource) {
        var newKey = dataSource.Max(x => x.ID) + 1;
        dataSource.Add(new GridDataModel() {
            ID = newKey,
            Browsers = (string)newValues["Browsers"]
        });
    }
    public static void DeleteRow(OrderedDictionary keys, List<GridDataModel> dataSource) {
        var item = dataSource.Find(x => x.ID == (int)keys[0]);
        dataSource.Remove(item);
    }
}
public class GridDataModel {
    public int ID { get; set; }
    public string Browsers { get; set; }
}