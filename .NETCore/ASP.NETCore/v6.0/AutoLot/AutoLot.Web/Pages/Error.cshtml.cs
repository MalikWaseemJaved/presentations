using System.Diagnostics;

namespace AutoLot.Web.Pages;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel : PageModel
{
    private readonly IAppLogging<ErrorModel> _appLogging;
    public string RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);


    public ErrorModel(IAppLogging<ErrorModel> appLogging)
    {
        _appLogging = appLogging;
    }

    public void OnGet()
    {
        _appLogging.LogAppDebug("Entered On Get");
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
    }
}

