namespace mrObjectsFilter
{
    using ModPlusAPI.Interfaces;

    public class Interface : IModPlusFunctionForRenga
    {
        private static Interface _instance;

        public static Interface GetInstance()
        {
            return _instance ?? (_instance = new Interface());
        }

        public SupportedProduct SupportedProduct => SupportedProduct.Renga;

        public string Name => "mrObjectsFilter";

        public RengaProduct RengaProduct => RengaProduct.Any;

        public FunctionUILocation UiLocation => FunctionUILocation.ContextMenu;

        public ContextMenuShowCase ContextMenuShowCase => ContextMenuShowCase.Selection;

        public ViewType ViewType => ViewType.View3D;

        public string ActionButtonViewType => string.Empty;

        public bool IsAddingToMenuBySelf => false;

        public string LName => "Фильтр";

        public string Description => "Фильтр выбранных элементов по категории";

        public string Author => "Пекшев Александр aka Modis";

        public string Price => "0";

        public string FullDescription => string.Empty;
    }
}
