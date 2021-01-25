using Microsoft.AspNetCore.Authorization;

namespace Office4U.Articles.ImportExport.Api.Controllers
{
    [Authorize(Policy = "RequireImportArticlesRole")]
    public class ImportController: BaseApiController
    {
        
    }
}