using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities
{
    /// <summary>
    /// Страна
    /// </summary>
    public class Country : BaseEntity
    {
        /// <summary>
        /// числовой код страны
        /// </summary>
        public uint Code { get; set; }

        /// <summary>
        /// короткое название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// полное название страны
        /// </summary>
        public string? Fullname { get; set; }

        /// <summary>
        /// 2х-буквенный код
        /// </summary>
        public string? Aplha2 { get; set; }

        /// <summary>
        /// 3х-буквенный код
        /// </summary>
        public string? Aplha3 { get; set; }

        public List<Company> Companies { get; set; } = new List<Company>();
        
        public List<UserInfo> Users { get; set; } = new List<UserInfo>();


        public Country(){}

        public Country(int id, uint code, string name, string fullname, string aplha2 , string aplha3)
        {
            Id = id;
            Code = code;
            Name = name;
            Fullname = fullname;
            Aplha2 = aplha2;
            Aplha3 = aplha3;
        }
    }
}
