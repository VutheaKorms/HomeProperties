using AutoMapper;
using HomeProperty.App;
using HomeProperty.DbContexts;
using HomeProperty.EF.App;
using HomeProperty.Error;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeProperty.Repository {
    public class RepositoryBase : IRepositoryBase {
        private const string Ascending = "asc";
        private const string Descending = "desc";

        public Application DefaultApplication {
            get {
                using (var context = new MainDbContext()) {
                    return context.Applications
                        .FirstOrDefault(x => x.Name == HomeProperty.Settings.Constant.Constant.WebApplication
                        && x.IsActive);
                }
            }
        }

        public object Constant { get; private set; }

        public static Language GetCurrentLanguage(string locale) {
            using (var context = new MainDbContext()) {
                return context.Languages.FirstOrDefault(x => string.Compare(x.Locale, locale, true) == 0
                    && x.IsActive);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetMyMethodName() {
            var st = new StackTrace(new StackFrame(1));
            return st.GetFrame(0).GetMethod().Name;
        }

        public Task<Guid> AddErrorLog(Exception ex, string className, Guid applicationId) {
            return AddErrorLogAsync(new ErrorLogView {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                ErrorInfo = string.Format("Class: {0}, Method: {1}",
                className, RepositoryBase.GetMyMethodName()),
                ApplicationId = applicationId
            });
        }

        public Task<Guid> AddErrorLog(Exception ex, string className) {
            return AddErrorLogAsync(new ErrorLogView {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                ErrorInfo = string.Format("Class: {0}, Method: {1}",
                className, RepositoryBase.GetMyMethodName()),
                ApplicationId = DefaultApplication.Id
            });
        }

        public Task<Guid> AddErrorLogAsync(ErrorLogView errorLogView) {
            Mapper.CreateMap<ErrorLogView, ErrorLog>();
            ErrorLog errorLog = Mapper.Map<ErrorLog>(errorLogView);

            return Task.Factory.StartNew(() => {
                using (var context = new MainDbContext()) {
                    context.ErrorLogs.Add(errorLog);
                    context.SaveChanges();
                    return errorLog.Id;
                }
            });
        }

        public Task<List<ErrorLogView>> GetErrorLogsAsync() {
            return Task.Factory.StartNew(() => {
                using (var context = new MainDbContext()) {
                    return context.ErrorLogs
                        .Select(x => new ErrorLogView {
                            Id = x.Id,
                            ErrorInfo = x.ErrorInfo,
                            FileName = x.FileName,
                            LineNumber = x.LineNumber,
                            Application = x.Application,
                            ApplicationId = x.ApplicationId,
                            Message = x.Message,
                            OccuredDate = x.OccuredDate,
                            StackTrace = x.StackTrace,
                            Description = x.Description,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedDate = x.ModifiedDate,
                            IsActive = x.IsActive,
                            IsResolved = x.IsResolved
                        })
                        .ToList();
                }
            });
        }

        public Task<ErrorLogView> GetErrorLogAsync(Guid id) {
            return Task.Factory.StartNew(() => {
                using (var context = new MainDbContext()) {
                    var x = context.ErrorLogs.Find(id);
                    return x != null ? new ErrorLogView {
                        Id = x.Id,
                        ErrorInfo = x.ErrorInfo,
                        FileName = x.FileName,
                        LineNumber = x.LineNumber,
                        Application = x.Application,
                        ApplicationId = x.ApplicationId,
                        Message = x.Message,
                        OccuredDate = x.OccuredDate,
                        StackTrace = x.StackTrace,
                        Description = x.Description,
                        ModifiedBy = x.ModifiedBy,
                        ModifiedDate = x.ModifiedDate,
                        IsActive = x.IsActive,
                        IsResolved = x.IsResolved
                    } : null;
                }
            });
        }

        public Task<int> UpdateErrorLogAsync(ErrorLogView errorLogView) {
            Mapper.CreateMap<ErrorLogView, ErrorLog>();
            ErrorLog errorLog = Mapper.Map<ErrorLog>(errorLogView);

            return Task.Factory.StartNew(() => {
                using (var context = new MainDbContext()) {
                    var e = context.ErrorLogs.Find(errorLog.Id);
                    if (e == null) return 0;
                    e.Message = !string.IsNullOrEmpty(errorLog.Message) ? errorLog.Message : e.Message;
                    e.StackTrace = !string.IsNullOrEmpty(errorLog.StackTrace) ? errorLog.StackTrace : e.StackTrace;
                    e.LineNumber = errorLog.LineNumber > 0 ? errorLog.LineNumber : e.LineNumber;
                    e.ErrorInfo = !string.IsNullOrEmpty(errorLog.ErrorInfo) ? errorLog.ErrorInfo : e.ErrorInfo;
                    e.ModifiedBy = errorLog.ModifiedBy;
                    e.ModifiedDate = DateTime.UtcNow;
                    e.ApplicationId = errorLog.ApplicationId.HasValue ? errorLog.ApplicationId : e.ApplicationId;
                    e.Application = errorLog.Application;
                    e.IsResolved = errorLog.IsResolved;
                    return context.SaveChanges();
                }
            });
        }

        public Task<int> DeleteErrorLogAsync(ErrorLogView errorLogView) {
            Mapper.CreateMap<ErrorLogView, ErrorLog>();
            ErrorLog errorLog = Mapper.Map<ErrorLog>(errorLogView);

            return Task.Factory.StartNew(() => {
                using (var context = new MainDbContext()) {
                    var e = context.ErrorLogs.Find(errorLog.Id);
                    if (e == null) return 0;
                    e.IsActive = false;
                    e.ModifiedDate = DateTime.UtcNow;
                    e.ModifiedBy = errorLog.ModifiedBy;
                    return context.SaveChanges();
                }
            });
        }

        /// <summary>
        /// Parses sorting request through URL in format
        /// ?sort=Col1 asc,Col2 desc
        /// </summary>
        /// <param name="sortExpr">The sorting expression string</param>
        /// <returns>The tuple of two lists: ascList and descList</returns>
        private Tuple<List<String>, List<String>> GetSortingLists(string sortExpr) {
            if (string.IsNullOrEmpty(sortExpr)) return null;
            var sorts = sortExpr.Split(',');
            if (sorts.Length == 0) return null;
            var ascList = new List<string>();
            var descList = new List<string>();
            var texteInfo = new CultureInfo("en-US", false).TextInfo;
            foreach (var sort in sorts) {
                var sortTokens = Regex.Split(sort, @"\s+");
                if (sortTokens.Length == 2) {
                    if (string.Compare(sortTokens[1], Ascending, true) == 0)
                        ascList.Add(texteInfo.ToTitleCase(sortTokens[0]));
                    else if (string.Compare(sortTokens[1], Descending, true) == 0)
                        descList.Add(texteInfo.ToTitleCase(sortTokens[0]));
                }
            }
            return Tuple.Create(ascList, descList);
        }

        /// <summary>
        /// Builds sorting and paging expression 
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity requested</param>
        /// <param name="options">The paging and sorting options</param>
        /// <returns>The sorted and paginated entities in a collection.</returns>
        //protected IQueryable<T> BuildSortingExression<T>(MainDbContext context, QueryParameterBase options) where T : class {
        //    var entity = context.Set<T>();
        //    var lists = GetSortingLists(options.Sort);
        //    if (lists == null || entity == null) return null;
        //    // Ascending list
        //    var stringBuilder = new StringBuilder();
        //    var count = 0;
        //    if (lists.Item1 != null) {
        //        if (lists.Item1.Count() > 0) {
        //            foreach (var field in lists.Item1.ToArray()) {
        //                // Ensure that the requested field is the property of the class
        //                if (typeof(T).GetProperty(field) == null) continue;
        //                if (count == lists.Item1.Count - 1 && stringBuilder.Length == 0)
        //                    stringBuilder.Append(field);
        //                else {
        //                    if (!stringBuilder.ToString().EndsWith(","))
        //                        stringBuilder.Append(",");
        //                    stringBuilder.Append(field + ",");
        //                }
        //                count++;
        //            }
        //        }
        //    }
        //    count = 0;
        //    if (lists.Item2 != null) {
        //        if (lists.Item2.Count() > 0) {
        //            foreach (var field in lists.Item2.ToArray()) {
        //                // Ensure that requested field is the property of the class
        //                if (typeof(T).GetProperty(field) == null) continue;
        //                if (count == lists.Item2.Count - 1 && stringBuilder.Length == 0)
        //                    stringBuilder.AppendFormat("{0} {1}", field, Descending);
        //                else {
        //                    if (!stringBuilder.ToString().EndsWith(","))
        //                        stringBuilder.Append(",");
        //                    stringBuilder.AppendFormat("{0} {1},", field, Descending);
        //                }
        //                count++;
        //            }
        //        }
        //    }
        //    var result = stringBuilder.ToString();

        //    // Remove last character if it is a comma 
        //    if (result.EndsWith(","))
        //        result = result.Substring(0, result.Length - 1);

        //    // Sort the entity using Linq Dynamic extension
        //    var orderedEntity = !string.IsNullOrEmpty(result) ?
        //        entity.OrderBy(result) : entity;

        //    return orderedEntity;
        //}

        /// <summary>
        /// Builds paging expression
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        /// <param name="options">The paging and sorting expression</param>
        /// <returns></returns>
        //protected IQueryable<T> BuildPagingExpression<T>(IQueryable<T> entity, QueryParameterBase options) where T : class {
        //    if (entity == null) return null;
        //    // Apply paging using Skip()...Take()
        //    IQueryable<T> newEntity = entity;
        //    if (options.Page > 0 && options.Size > 0)
        //        newEntity = entity.Skip((options.Page - 1) * options.Size).Take(options.Size);
        //    return newEntity;
        //}



        /// <summary>
        /// Build filter expression by Linq to querystring library
        /// sample: name eq 'cambodia' and locx lt 10 or locx gt  20
        /// document url: http://linqtoquerystring.net/syntax.html
        /// </summary>
        /// <typeparam name="T">The Entity type</typeparam>
        /// <param name="entity">The Entity</param>
        /// <param name="options">The Paging, filtering and Sorting expression</param>
        /// <returns>The filter entities in a collection.</returns>
        //protected IQueryable<T> BuildFilteringExpression<T>(IQueryable<T> entity, QueryParameterBase options) {

        //    if (string.IsNullOrEmpty(options.Filter) || !IsValidFilterExpression(options.Filter)) return entity;

        //    try {
        //        entity = entity.LinqToQuerystring(string.Format("$filter={0}", options.Filter));
        //    } catch (Exception ex) {
        //        throw new ArgumentException(ex.Message);
        //    }
        //    return entity;
        //}

        private bool IsValidFilterExpression(string filterExp) {
            var pattern = @"\$select|\$filter|\$inlinecount|\$skip|\$top|\$orderby|^\?";
            return !Regex.IsMatch(filterExp, pattern, RegexOptions.IgnoreCase);
        }

        //protected ResourceWrapper BuildResourceWrapper<S, T>(S parameter, int totalRecords, IEnumerable<T> records)
        //    where S : QueryParameterBase
        //    where T : View.Hypermedia.Resource {
        //    Mapper.CreateMap<S, ResourceWrapper>();
        //    ResourceWrapper wrapper = Mapper.Map<ResourceWrapper>(parameter);
        //    wrapper.ApplicationType = parameter.ApplicationType;
        //    wrapper.RecordType = typeof(T);
        //    wrapper.Records = records;
        //    wrapper.TotalRecords = totalRecords;

        //    return wrapper;
        //}

        /// <summary>
        /// Customizes paging and sorting options for presentation.
        /// </summary>
        /// <param name="options">The paging and sorting options</param>
        /// <param name="totalRecords">The total records</param>
        /// <returns></returns>
        //protected FlexibleView CustomizeOptions(FlexibleView options, int totalRecords) {
        //    if (options == null) {
        //        options = new FlexibleView {
        //            Page = "0",
        //            Size = totalRecords,
        //            Sort = string.Empty,
        //            IsFirstPage = true,
        //            IsLastPage = false,
        //            TotalPages = 0,
        //            TotalRecords = 0
        //        };
        //    }
        //    options.TotalRecords = totalRecords;
        //    return options;
        //}
    }
}
