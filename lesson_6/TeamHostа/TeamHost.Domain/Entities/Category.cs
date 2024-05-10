using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities
{
    /// <summary>
    /// Категория
    /// </summary>
    public class Category : BaseAuditableEntity
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        public List<Game> Games { get; set; } = new List<Game>();
    }
}
