using System.Collections.Generic;

public class Quest : Milestone
{
    private List<Objective> objectives = new List<Objective>();

    public Quest(int id)
    {
        this.id = id;
    }

    public List<Objective> GetObjectives()
    {
        return objectives;
    }

    public void AddObjective(Objective objective)
    {
        objectives.Add(objective);
    }

    public void SetObjectives(List<Objective> objectives)
    {
        this.objectives = objectives;
    }
}