using Microsoft.AspNetCore.Authorization;

namespace Office4U.Articles.ImportExport.Api.Controllers
{
    [Authorize(Policy = "RequireExportArticlesRole")]
    public class ExportController: BaseApiController
    {
        
    }
}