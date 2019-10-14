public interface IProperties
{
    string GetLabel();
    void SetLabel(string label);
    IHealthController GetHealthController();
}