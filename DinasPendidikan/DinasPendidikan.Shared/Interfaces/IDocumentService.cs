using DinasPendidikan.Shared.DTOs;

namespace DinasPendidikan.Shared.Interfaces
{
    public interface IDocumentService
    {
        Task<IEnumerable<DocumentDto>> GetAllDocumentsAsync();
        Task<DocumentDto> GetDocumentByIdAsync(int id);
        Task<DocumentDto> CreateDocumentAsync(DocumentCreateDto documentDto);
        Task UpdateDocumentAsync(int id, DocumentUpdateDto documentDto);
        Task DeleteDocumentAsync(int id);
    }
}
