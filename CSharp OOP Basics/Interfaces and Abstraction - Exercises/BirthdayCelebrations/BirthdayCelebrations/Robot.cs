public class Robot
{
    private string id;
    private string model;

    public Robot(string model, string id)
    {
        this.Model = model;
        this.Id = id;
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public string Id
    {
        get { return id; }
        private set { id = value; }
    }

    public override string ToString()
    {
        return $"{this.Id}";
    }
}
