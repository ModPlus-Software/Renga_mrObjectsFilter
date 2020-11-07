namespace mrObjectsFilter
{
    using System.Collections.Generic;
    using ModPlusAPI.Abstractions;
    using ModPlusAPI.Enums;

    /// <inheritdoc/>
    public class ModPlusConnector : IModPlusPluginForRenga
    {
        private static ModPlusConnector _instance;

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static ModPlusConnector Instance => _instance ?? (_instance = new ModPlusConnector());

        /// <inheritdoc/>
        public SupportedProduct SupportedProduct => SupportedProduct.Renga;

        /// <inheritdoc/>
        public string Name => "mrObjectsFilter";

        /// <inheritdoc/>
        public RengaFunctionUILocation UiLocation => RengaFunctionUILocation.ContextMenu;

        /// <inheritdoc/>
        public RengaContextMenuShowCase ContextMenuShowCase => RengaContextMenuShowCase.Selection;

        /// <inheritdoc/>
        public List<RengaViewType> ViewTypes => new List<RengaViewType>
        {
            RengaViewType.View3D, RengaViewType.Level, RengaViewType.Assembly
        };

        /// <inheritdoc/>
        public bool IsAddingToMenuBySelf => false;

        /// <inheritdoc/>
        public string LName => "Фильтр";

        /// <inheritdoc/>
        public string Description => "Фильтр выбранных элементов по категории";

        /// <inheritdoc/>
        public string Author => "Пекшев Александр aka Modis";

        /// <inheritdoc/>
        public string Price => "0";

        /// <inheritdoc/>
        public string FullDescription => string.Empty;
    }
}
