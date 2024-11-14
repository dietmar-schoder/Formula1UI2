using Microsoft.AspNetCore.Components;

namespace Formula1UI2.Pages;

public partial class Home : ComponentBase
{
    private readonly string apiUrl = $"https://formula1openapi.azurewebsites.net/scalar/v1";

    private readonly List<(string Label, string Path)> menuItems =
    [
        ("Seasons", "/seasons"),
        ("Grand Prix", "/grandprix"),
        ("Drivers", "/drivers"),
        ("Constructors", "/constructors"),
        ("Circuits", "/circuits"),
        ("Races", "/races"),
        ("Sessions", "/sessions"),
        ("Results", "/results"),
        ("Session Types", "/sessiontypes")
    ];
}
