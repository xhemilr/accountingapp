using AccountingApp.Application.Interfaces.Services;
using System;

namespace AccountingApp.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}