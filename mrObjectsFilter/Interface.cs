namespace mrObjectsFilter
{
    using ModPlusAPI.Interfaces;

    public class Interface : IModPlusFunctionForRenga
    {
        public SupportedProduct SupportedProduct => SupportedProduct.Renga;

        public string Name => "mrObjectsFilter";

        public RengaProduct RengaProduct => RengaProduct.Any;

        public FunctionUILocation UiLocation => FunctionUILocation.ContextMenu;

        public string ActionButtonViewType => string.Empty;

        public bool IsAddingToMenuBySelf => false;

        public string LName => "Фильтр";

        public string Description => "Фильтр выбранных элементов по категории";

        public string Author => "Пекшев Александр aka Modis";

        public string Price => "0";

        public string FullDescription => string.Empty;

        public string ToolTipHelpImage => string.Empty;
    }
}
