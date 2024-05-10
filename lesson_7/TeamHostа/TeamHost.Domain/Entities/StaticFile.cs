using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities
{
    /// <summary>
    /// Файл
    /// </summary>
    public class StaticFile : BaseAuditableEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="path">Путь</param>
        /// <param name="name">Имя</param>
        public StaticFile(string path, string name)
        {
            Path = path;
            Name = name;
            Extension = name.Split('.').LastOrDefault();
        }

        public StaticFile()
        {
            
        }
        
        /// <summary>
        /// Путь
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Размер в КБ
        /// </summary>
        public int? Size { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Расширение
        /// </summary>
        public string? Extension { get; private set; }
        
        /// <summary>
        /// Игра
        /// </summary>
        public Game? Game { get; set; }
        
        public int? GameId { get; set; }
      
        public Chats? Chats { get; set; }
        
        public int? ChatId { get; set; }
        public Platform? Platform { get; set; }
        
        
    }
}
