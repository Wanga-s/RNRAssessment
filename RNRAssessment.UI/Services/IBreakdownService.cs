using RNRAssessment.UI.Models;

namespace RNRAssessment.UI.Services
{
    public interface IBreakdownService
    {
        Task<IEnumerable<BreakdownModel>?> GetBreakdownsAsync();
        Task<BreakdownModel?> GetBreakdownAsync(int BreakdownId);
        Task<ExistModel?> BreakdownReferenceExistsAsync(string BreakdownReference);
        Task<BreakdownModel?> CreateBreakdownsAsync(BreakdownModel BreakdownModel);
        Task<BreakdownModel?> UpdateBreakdownsAsync(BreakdownModel breakdownModel);
    }
}
