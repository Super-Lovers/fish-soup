public abstract class Milestone
{
    protected int id = 0;
    protected string status = string.Empty;
    protected string goal = string.Empty;

    public string GetStatus()
    {
        return status;
    }

    public void SetStatus(string status)
    {
        this.status = status;
    }

    public int GetID()
    {
        return id;
    }

    public void SetID(int id)
    {
        this.id = id;
    }

    public string GetGoal()
    {
        return goal;
    }
}