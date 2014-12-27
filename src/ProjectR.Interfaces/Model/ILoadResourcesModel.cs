namespace ProjectR.Interfaces.Model
{
    public interface ILoadResourcesModel
    {
        string CurrentAction { get; set; }

        string OverarchingAction { get; set; }

        int CurrentProgress { get; set; }

        int TotalProgress { get; set; }
    }
}