namespace G24W1501WPFDataGrid;

public class GundamModel
{
    public GundamModel(string name, string model, string party) =>
        (Name, Model, Party) = (name, model, party);

    public string Name { get; }
    public string Model { get; }
    public string Party { get; }
    // public string ImageUri { get; } // 텀 프로젝트 시 추가할 것
}
