namespace ProjectR.View
{
    public class LoadResourcesView : InitializeableModelStateWithConsole
    {
        public LoadResourcesView()
            : base(50, 5)
        {
        }

        public override void Run()
        {
            Clear();
            PrintString(0, 0, Model.LoadResourcesModel.OverarchingAction);
            PrintString(0, 2, Model.LoadResourcesModel.CurrentAction);
            PrintString(0, 4,
                string.Format("{0} / {1}", Model.LoadResourcesModel.CurrentProgress,
                    Model.LoadResourcesModel.TotalProgress));
            RConsole.RootConsole.Blit(this, Bounds, 10, 10);
        }
    }
}