namespace Nodus.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentController :ControllerBase
{
    private readonly IDocumentService _documentService;

    public DocumentController(IDocumentService documentService)
    {
        _documentService = documentService;
    }

    [HttpPost("upload")]
    [Consumes("multipart/form-data")]
    public ActionResult GetTextDocument(IFormFile file)
    {
        using Stream stream = file.OpenReadStream();
       
        var result =  _documentService.GetDocument(stream, pathDocument: file.FileName);

        return Ok(result);
    }
    
}