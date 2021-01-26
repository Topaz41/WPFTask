using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace Task
{
    enum Position
    {
        JuniorEmployee,
        MiddleEmployee,
        SeniorEmployee,
        Manager,
        ProjectManager
    }

    public class positionEnumValueConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumVal = ((Employees)value).Position;
            switch (enumVal)
            {
                case Position.JuniorEmployee: return "Junior";
                case Position.MiddleEmployee: return "Middle";
                case Position.SeniorEmployee: return "Senior";
                case Position.Manager: return "Manager";
                case Position.ProjectManager: return "PM";
                default: return "Unknown Value";
            }
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }
    }
}
