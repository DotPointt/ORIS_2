using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities
{
    public class Game : BaseAuditableEntity
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Короткое описание
        /// </summary>
        public string? ShortDescription { get; set; }
        
        /// <summary>
        /// Рейтинг
        /// </summary>
        public float Rating { get; set; }
        
        /// <summary>
        /// Дата релиза
        /// </summary>
        public DateTime ReleaseDate { get; set; }
        
        /// <summary>
        /// Компания-разработчик
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Компания
        /// </summary>
        public Company Company { get; set; } = default!;

        /// <summary>
        /// Главное изображение
        /// </summary>
        public int? MainFileId { get; set; }

        /// <summary>
        /// Изображения
        /// </summary>
        public List<StaticFile>? Images { get; set; } = default!;

        /// <summary>
        /// Категория
        /// </summary>
        public List<Category> Category { get; set; }

        /// <summary>
        /// Платформа
        /// </summary>
        public List<Platform> Platforms { get; set; }
    }
}
