public class LevelContainer
{
    private string[,,] grid = new string[
        (int)LevelGrid.GetInstance().levelSettings.gridSize.x,
        (int)LevelGrid.GetInstance().levelSettings.gridSize.z,
        (int)LevelGrid.GetInstance().levelSettings.gridSize.y
        ];

    public string[,,] GetGridArray()
    {
        return grid;
    }
}
