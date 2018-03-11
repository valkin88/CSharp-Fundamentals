using System;

public class Mission
{
    private string codeName;
    private string state;

    public Mission(string codeName, string state)
    {
        this.CodeName = codeName;
        this.State = state;
    }

    public string CodeName
    {
        get { return codeName; }
        private set { codeName = value; }
    }

    public string State
    {
        get { return state; }
        private set { state = value; }
    }
}
