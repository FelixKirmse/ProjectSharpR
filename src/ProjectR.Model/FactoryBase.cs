using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class FactoryBase
    {
        protected IModel Model { get; set; }

        protected void UpdateModel(string actiontext, int currentCount, int maxCount)
        {
            Model.LoadResourcesModel.CurrentAction = actiontext;
            Model.LoadResourcesModel.CurrentProgress = currentCount;
            Model.LoadResourcesModel.TotalProgress = maxCount;
        }
    }
}