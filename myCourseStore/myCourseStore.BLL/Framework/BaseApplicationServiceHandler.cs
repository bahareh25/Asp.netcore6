﻿using MediatR;
using myCourseStore.DAL.DBContexts;
using myCourseStore.Model.Framework;

namespace myCourseStore.BLL.Framework
{
    public abstract class BaseApplicationServiceHandler<TRequest, TResult> : IRequestHandler<TRequest, ApplicationServiceResponse<TResult>>
        where TRequest : IRequest<ApplicationServiceResponse<TResult>>

    {
        protected readonly CourseStoreDbContext _courseStoreDbContext;
        private ApplicationServiceResponse<TResult> _response = new ApplicationServiceResponse<TResult>();

        public BaseApplicationServiceHandler(CourseStoreDbContext courseStoreDbContext)
        {
            _courseStoreDbContext = courseStoreDbContext;
        }

        public async Task<ApplicationServiceResponse<TResult>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request, cancellationToken);
            return _response;
        }

        protected abstract Task HandleRequest(TRequest request, CancellationToken cancellationToken);
        public void AddError(string error)
        {
            _response.AddError(error);
        }
        public void AddResult(TResult result)=>
            _response.Result = result;
    }
}
