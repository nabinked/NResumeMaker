using DbPortal;
using ResumeMaker.Data.Models.Core;

namespace ResumeMaker.Data.DbExtensions
{
    public static class DbEntityExtensions
    {
        public static string GetGenderName(this int genderId)
        {
            return new DbTransactions<Gender>().Get(genderId)?.GenderName;
        }
    }
}
