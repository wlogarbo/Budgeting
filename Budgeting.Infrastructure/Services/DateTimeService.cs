using Budgeting.Application.Common.Interfaces;
using System;

namespace Budgeting.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
