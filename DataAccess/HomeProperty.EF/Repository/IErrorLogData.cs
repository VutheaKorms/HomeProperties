using HomeProperty.Error;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeProperty.Repository {
    public interface IRepositoryBase {
        Task<Guid> AddErrorLog(Exception ex, string className, Guid applicationId);
        Task<Guid> AddErrorLog(Exception ex, string className);
        Task<Guid> AddErrorLogAsync(ErrorLogView errorLogView);
        Task<List<ErrorLogView>> GetErrorLogsAsync();
        Task<ErrorLogView> GetErrorLogAsync(Guid id);
        Task<int> UpdateErrorLogAsync(ErrorLogView errorLogView);
        Task<int> DeleteErrorLogAsync(ErrorLogView errorLogView);
    }
}
