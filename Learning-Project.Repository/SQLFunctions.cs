using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Learning_Project.Repository
{
    public static class SQLFunctions
    {
        public static bool DbLike(this string selectedProperty, string pattern)
        {
            return EF.Functions.Like(selectedProperty, EF.Constant(pattern));
        }
        
        public static bool DbEquals<T>(this T selectedProperty, T value)
        {
            return selectedProperty != null && selectedProperty.Equals(EF.Constant(value));
        }
        
        public static bool DbStringContains(this string selectedProperty, string value)
        {
            return EF.Functions.Contains(selectedProperty, value);
        }
        
        public static double DbRandom(double multiplier)
        {
            return EF.Functions.Random();
        }
    }
}
