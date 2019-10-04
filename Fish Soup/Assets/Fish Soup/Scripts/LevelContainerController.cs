public class LevelContainerController
{
    private string[,,] grid = new string[
        (int)LevelGridView.GetInstance().levelSettings.gridSize.x,
        (int)LevelGridView.GetInstance().levelSettings.gridSize.z,
        (int)LevelGridView.GetInstance().levelSettings.gridSize.y
        ];

    public string[,,] GetGridArray()
    {
        return grid;
    }
}
