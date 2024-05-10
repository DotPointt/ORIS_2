using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities
{
    /// <summary>
    /// Разработчик
    /// </summary>
    public class Company : BaseAuditableEntity
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        
        
        /// <summary>
        /// Navigation Prop
        /// </summary>
        
        public int CountryId { get; set; }
        
        /// <summary>
        /// Страна
        /// </summary>
        public Country Country { get; set; }

        public List<Game> Games { get; set; } = new List<Game>();

    }
}
