
namespace TeamHost.Application.Features.Games.DTOs
{
    public class GetAllGamesResponse
    {
        /// <summary>
        /// Кол-во
        /// </summary>
        public int TotalCount { get; set; }
        
        /// <summary>
        /// Игры
        /// </summary>
        public List<GetGamesItemDto> Games { get; set; }
    }
}
