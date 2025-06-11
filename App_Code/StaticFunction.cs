using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Data;

namespace StaticFunction
{
    public enum DateFormat
    { 
        DD_MM_YYYY,
        MM_DD_YYYY,
        YYYY_MM_DD,
        DD_MM_YY
    }

    public enum TimeFormat
    {
        HH_mm_ss,
        hh_mm_ss,
        hh_mm_ss_tt
    }

    public enum DateTimeFormat
    { 
        DD_MM_YYYY_HH_mm_ss,
        DD_MM_YYYY_hh_mm_ss,
        DD_MM_YYYY_hh_mm_ss_tt,
        MM_DD_YYYY_HH_mm_ss,
        MM_DD_YYYY_hh_mm_ss,
        MM_DD_YYYY_hh_mm_ss_tt,
        YYYY_MM_DD_HH_mm_ss,
        YYYY_MM_DD_hh_mm_ss,
        YYYY_MM_DD_hh_mm_ss_tt,
        YYYY_MM_DD_hh_mm_ss_000,
        YYYY_MM_DD_HH_mm_ss_000
    }

    public enum LanguageFormat:int
    { 
        en_US     = 1033,
        th_TH     = 1054,
    }

    public enum MonthList_ENG { January = 1, February = 2, March = 3, April = 4, May = 5, June = 6, July = 7, August = 8, September = 9, October = 10, November = 11, December = 12 };
    public enum MonthList_THA { มกราคม = 1, กุมภาพันธ์ = 2, มีนาคม = 3, เมษายน = 4, พฤษภาคม = 5, มิถุนายน = 6, กรกฏาคม = 7, สิงหาคม = 8, กันยายน = 9, ตุลาคม = 10, พฤศจิกายน = 11, ธันวาคม = 12 };

    public class SF
    {
        public static bool CompareString(object source, object dest)
        {
            return string.Equals(source, dest);
        }

        public static string GetDateDDMMYYYY(DateTime datetime)
        {
            return datetime.ToString("dd/MM/yyyy", new CultureInfo("en-US"));
        }

        public static string GetDateYYYYMMDD(DateTime datetime)
        {
            return datetime.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
        }

        public static string GetDateTimeFormatToString(DateTime date_time, DateTimeFormat date_time_format, string replace_split_string_date, string replace_split_string_time, LanguageFormat lang)
        {
            string result = string.Empty;

            try
            {
                replace_split_string_date = string.IsNullOrEmpty(replace_split_string_date) ? "-" : replace_split_string_date;
                replace_split_string_time = string.IsNullOrEmpty(replace_split_string_time) ? ":" : replace_split_string_time;

                string format = string.Empty;
                switch (date_time_format)
                { 
                    case DateTimeFormat.DD_MM_YYYY_hh_mm_ss:
                        format = string.Format("dd{0}MM{0}yyyy hh{1}mm{1}ss", replace_split_string_date, replace_split_string_time);
                        break;
                    case DateTimeFormat.DD_MM_YYYY_HH_mm_ss:
                        format = string.Format("dd{0}MM{0}yyyy HH{1}mm{1}ss", replace_split_string_date, replace_split_string_time);
                        break;
                    case DateTimeFormat.DD_MM_YYYY_hh_mm_ss_tt:
                        format = string.Format("dd{0}MM{0}yyyy hh{1}mm{1}ss tt", replace_split_string_date, replace_split_string_time);
                        break;
                    case DateTimeFormat.MM_DD_YYYY_hh_mm_ss:
                        format = string.Format("MM{0}dd{0}yyyy hh{1}mm{1}ss", replace_split_string_date, replace_split_string_time);
                        break;
                    case DateTimeFormat.MM_DD_YYYY_HH_mm_ss:
                        format = string.Format("MM{0}dd{0}yyyy HH{1}mm{1}ss", replace_split_string_date, replace_split_string_time);
                        break;
                    case DateTimeFormat.MM_DD_YYYY_hh_mm_ss_tt:
                        format = string.Format("MM{0}dd{0}yyyy hh{1}mm{1}ss tt", replace_split_string_date, replace_split_string_time);
                        break;
                    case DateTimeFormat.YYYY_MM_DD_hh_mm_ss:
                        format = string.Format("yyyy{0}MM{0}dd hh{1}mm{1}ss", replace_split_string_date, replace_split_string_time);
                        break;
                    case DateTimeFormat.YYYY_MM_DD_HH_mm_ss:
                        format = string.Format("yyyy{0}MM{0}dd HH{1}mm{1}ss", replace_split_string_date, replace_split_string_time);
                        break;
                    case DateTimeFormat.YYYY_MM_DD_hh_mm_ss_tt:
                        format = string.Format("yyyy{0}MM{0}dd hh{1}mm{1}ss tt", replace_split_string_date, replace_split_string_time);
                        break;
                    case DateTimeFormat.YYYY_MM_DD_hh_mm_ss_000:
                        format = string.Format("yyyy{0}MM{0}dd hh{1}mm{1}ss.000", replace_split_string_date, replace_split_string_time);
                        break;
                    case DateTimeFormat.YYYY_MM_DD_HH_mm_ss_000:
                        format = string.Format("yyyy{0}MM{0}dd HH{1}mm{1}ss.000", replace_split_string_date, replace_split_string_time);
                        break;
                }

                result = date_time.ToString(format, new CultureInfo((int)lang));
            }
            catch
            { 
            
            }

            return result;
        }

        public static string GetTimeFormatToString(DateTime time, TimeFormat time_format, string replace_split_string,LanguageFormat lang)
        {
            string result = string.Empty;

            try
            {
                replace_split_string = string.IsNullOrEmpty(replace_split_string) ? ":" : replace_split_string;
                string format = string.Empty;
                switch (time_format)
                { 
                    case TimeFormat.hh_mm_ss:
                        format = string.Format("hh{0}mm{0}ss", replace_split_string);
                        break;
                    case TimeFormat.HH_mm_ss:
                        format = string.Format("HH{0}mm{0}ss", replace_split_string);
                        break;
                    case TimeFormat.hh_mm_ss_tt:
                        format = string.Format("hh{0}mm{0}ss tt", replace_split_string);
                        break;
                }
                result = time.ToString(format, new CultureInfo((int)lang));
            }
            catch
            { 
                
            }

            return result;
        }

        public static string GetDateTimeddMMyyyy_HHmmss(object data)
        {
            string result = string.Empty;
            try
            {
                if (data != null)
                {
                    DateTime d = SF.GetDateTime(data);
                    result = d.ToString("dd/MM/yyyy HH:mm:ss", new CultureInfo("en-US"));
                }
            }
            catch
            { 
                
            }
            return result;
        }

        public static string GetDateFormatToString(DateTime date,DateFormat date_format,string replace_split_string,LanguageFormat lang)
        {
            string result = string.Empty;
            try
            {
                replace_split_string = string.IsNullOrEmpty(replace_split_string) ? "-" : replace_split_string;

                string format = string.Empty;
                switch (date_format)
                { 
                    case DateFormat.DD_MM_YYYY:
                        format = string.Format("dd{0}MM{0}yyyy", replace_split_string);
                        break;
                    case DateFormat.MM_DD_YYYY:
                        format = string.Format("MM{0}dd{0}yyyy", replace_split_string);
                        break;
                    case DateFormat.YYYY_MM_DD:
                        format = string.Format("yyyy{0}MM{0}dd", replace_split_string);
                        break;
                    case DateFormat.DD_MM_YY:
                        format = string.Format("dd{0}MM{0}yy", replace_split_string);
                        break;
                }
                result = date.ToString(format, new CultureInfo((int)lang));
            }
            catch
            {
              
            }
            return result;
        }

        public static DateTime GetDateTime(object data)
        {
            DateTime result = new DateTime();
            try
            {
                result= Convert.ToDateTime(data);
            }
            catch
            {
                
            }
            return result;
        }

        public static Double GetDouble(object data)
        {
            Double result = 0.0;
            try
            {
                result = Convert.ToDouble(data);
            }
            catch
            {
                System.Diagnostics.Trace.TraceWarning(string.Format("Could not convert Double type data is {0}",data));
            }

            return result;

        }

        public static Int64 GetInt64(object data)
        {
            Int64 result=0;
            try
            {   
                result=Convert.ToInt64(data);
            }
            catch
            {
                System.Diagnostics.Trace.TraceWarning(string.Format("Could not convert Int64 type data is {0}", data));
            }

            return result;
        }

        public static Int32 GetInt32(object data)
        {
            Int32 result = 0;

            try
            {
                result = Convert.ToInt32(data);
            }
            catch
            {
                System.Diagnostics.Trace.TraceWarning(string.Format("Could not convert Int32 type data is {0}", data));
            }

            return result;
        }

        public static string GetString(object data)
        {
            string result = string.Empty;
            try
            {
                result = Convert.ToString(data);
            }
            catch
            {
                System.Diagnostics.Trace.TraceWarning(string.Format("Could not convert String type data is {0}", data));
            }

            return result;
        }

        public static bool GetBool(object data)
        {
            bool result = false;
            try
            {
                result = Convert.ToBoolean(data);
            }
            catch
            {
                System.Diagnostics.Trace.TraceWarning(string.Format("Could not convert Boolean type data is {0}", data));
            }

            return result;
        }
        public static bool IsNullOrEmptyDataTable(DataTable dt)
        {
            bool result = true;

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    result = false;
                }
            }

            return result;
        }

        public static string[] GetMonthThaiName()
        {
            return Enum.GetNames(typeof(MonthList_THA));
        }

        public static string[] GetMonthEngName()
        {
            return Enum.GetNames(typeof(MonthList_ENG));
        }

        public static string[] GetDateFormat()
        {
            return Enum.GetNames(typeof(DateFormat));
        }

        public static string[] GetTimeFormat()
        {
            return Enum.GetNames(typeof(TimeFormat));
        }

        public static string[] GetDateTimeFormat()
        {
            return Enum.GetNames(typeof(DateTimeFormat));
        }

        public static string[] GetLanguageFormat()
        {
            return Enum.GetNames(typeof(LanguageFormat));
        }
    }
}
