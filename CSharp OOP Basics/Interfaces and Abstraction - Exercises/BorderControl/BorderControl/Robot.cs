public class Robot : ICitizen
{
    private string model;
    private string id;

    public Robot(string model, string id)
    {
        this.Model = model;
        this.Id = id;
    }

    public string Model
    {
        get { return model; }
        private set { model = value; }
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
