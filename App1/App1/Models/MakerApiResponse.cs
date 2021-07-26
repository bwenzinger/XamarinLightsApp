using System.Collections.Generic;

public class MakerApiResponse
{
    public string id { get; set; }
    public string name { get; set; }
    public string label { get; set; }
    public List<MakerApiAttribute> attributes { get; set; }
    public object[] capabilities { get; set; }
    public string[] commands { get; set; }
}

public class MakerApiAttribute
{
    public string name { get; set; }
    public object currentValue { get; set; }
    public string dataType { get; set; }
    public string[] values { get; set; }
}
