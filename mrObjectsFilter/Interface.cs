#pragma warning disable SA1600 // Elements should be documented
namespace mrObjectsFilter
{
    using System.Collections.Generic;
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

        public List<ViewType> ViewTypes => new List<ViewType> { ViewType.View3D, ViewType.Level, ViewType.Assembly };

        public bool IsAddingToMenuBySelf => false;

        public string LName => "Фильтр";

        public string Description => "Фильтр выбранных элементов по категории";

        public string Author => "Пекшев Александр aka Modis";

        public string Price => "0";

        public string FullDescription => string.Empty;
    }
}
#pragma warning restore SA1600 // Elements should be documented