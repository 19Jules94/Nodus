namespace Nodus.Domain.Entities;

public class Document
{
    public string IdDocument {get; set;}
    public int NumberPages {get; set;}
    public string Name {get; set;}
    public string Content {get; set;}
    public string Path {get; set;}
}