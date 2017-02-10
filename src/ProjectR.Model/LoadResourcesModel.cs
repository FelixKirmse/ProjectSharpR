using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class LoadResourcesModel : ILoadResourcesModel
    {
        public LoadResourcesModel()
        {
            CurrentAction = "Loading Game";
            OverarchingAction = "Setting Up Game";
            CurrentProgress = 0;
            TotalProgress = 1;
        }

        public string CurrentAction { get; set; }
        public string OverarchingAction { get; set; }
        public int CurrentProgress { get; set; }
        public int TotalProgress { get; set; }
    }
}