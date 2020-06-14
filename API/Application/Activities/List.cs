using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.Domain;
using API.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _dataContext;
            private readonly ILogger<List> _logger;
            public Handler(DataContext dataContext, ILogger<List> logger)
            {
                _logger = logger;
                _dataContext = dataContext;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {

                // try
                // {
                //     for (int i = 0; i < 10; i++)
                //     {
                //         cancellationToken.ThrowIfCancellationRequested();
                //         await Task.Delay(1500, cancellationToken);
                //         _logger.LogInformation($"Task {i} has completed");
                //     }
                // }
                // catch (Exception ex) when (ex is TaskCanceledException)
                // {
                //     _logger.LogInformation("Task was cancelled");
                // }

                return await _dataContext.Activities.ToListAsync(cancellationToken);
            }
        }
    }
}