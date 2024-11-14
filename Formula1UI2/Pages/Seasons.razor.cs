using MatBlazor;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Formula1UI2.Pages;

public partial class Seasons : ComponentBase
{
    [Inject] private HttpClient Http { get; set; }
    private SeasonsPaginatedDto seasonsPaginated = new([], 1, 15, 0);

    protected override async Task OnInitializedAsync()
    {
        seasonsPaginated = await Http.GetFromJsonAsync<SeasonsPaginatedDto>(
            $"https://localhost:7277/api/seasons?pageNumber={seasonsPaginated.PageNumber}&pageSize={seasonsPaginated.PageSize}");
    }

    private async Task OnPage(MatPaginatorPageEvent e)
    {
        seasonsPaginated.PageSize = e.PageSize;
        seasonsPaginated.PageNumber = e.PageIndex + 1;
        await OnInitializedAsync();
    }

    public class SeasonsPaginatedDto(List<SeasonDto> seasons, int pageNumber, int pageSize, int totalCount)
    {
        public List<SeasonDto> Seasons { get; set; } = seasons;
        public int PageNumber { get; set; } = pageNumber;
        public int PageSize { get; set; } = pageSize;
        public int TotalCount { get; set; } = totalCount;
    }

    public record SeasonDto(int Year, string WikipediaUrl);
}
