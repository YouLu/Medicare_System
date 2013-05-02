using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;


namespace MedicalSystem.Pf.Component.Validation
{
    public class MedicalSystemValidation
    {
        
        //验证是否为整数
        public static bool IntegerValidation(object value)
        {
            string strVal = value as string;

            if (strVal == null)
            {
                return false;
            }

            if (strVal.Equals(String.Empty))
            {
                return true;
            }

            Regex regex = new Regex("^[0-9]+$");
            if (!regex.IsMatch(strVal))
            {
                return false;
            }



            return true;
        }


        //小数验证
        public static bool DecimalValidation(object value)
        {
            string strVal;

            try
            {
                if (value != null)
                {
                    strVal = value as string;

  
                    if (strVal.Equals(String.Empty))
                    {
                        return true;
                    }

                    Regex regex = new Regex("^[\\+\\-]?\\d*\\.?\\d+$");
                    if (!regex.IsMatch(strVal))
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }



            return true;
        }



        //是否是全角字符验证   
        public static bool FullWidthCharValidation(object value)
        {

            string strVal;
            Encoding encoding;

            try
            {
                if (value != null)
                {
                    strVal = value as string;

                    if (strVal.Equals(String.Empty))
                    {
                        return true;
                    }

                    encoding = Encoding.GetEncoding("utf-8");

                    int byteCount = encoding.GetByteCount(strVal);

                    if (strVal.Length * 3 != byteCount)
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }



            return true;
        }



        //半角字符验证

     
        public static bool EngNumHalfWidthCharValidation(object value)
        {
           

            string strVal;

            try
            {
                if (value != null)
                {
                    strVal = value as string;

                  
                    if (strVal.Equals(String.Empty))
                    {
                        return true;
                    }

                 
                    Regex regex = new Regex("^[a-zA-Z0-9]+$");
                    if (!regex.IsMatch(strVal))
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }

         

            return true;
        }



        //半角字符和符号验证

       
        public static bool EngNumHalfWidthCharAndSymbolValidation(object value)
        {
          

            string strVal;

            try
            {
                if (value != null)
                {
                    strVal = value as string;

   
                    if (strVal.Equals(String.Empty))
                    {
                        return true;
                    }

       
                    Regex regex = new Regex("^[!-~]+$");
                    if (!regex.IsMatch(strVal))
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }

 

            return true;
        }



        //数值长度验证
        public static bool LengthValidation(object value, int minLength, int maxLength)
        {
     

            string strVal;

            if (value != null)
            {
                strVal = value as string;

                if (value.ToString().Length < minLength)
                {
                    return false;
                }
                else if (value.ToString().Length > maxLength)
                {
                    return false;
                }
            }
            return true;

        }

 
        //小数值范围验证
        public static bool ThresholdValidation(object value, decimal minValue, decimal maxValue)
        {
     

            decimal decimalValue;
            string strVal;

            try
            {
                if (value != null)
                {
                    strVal = value as string;


                    if (strVal.Equals(string.Empty))
                    {
                        return true;
                    }

                    decimalValue = Convert.ToDecimal(value);


                    if (decimalValue < minValue || decimalValue > maxValue)
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }

;

            return true;
        }

    

       //整数值范围验证
        public static bool ThresholdValidation(object value, int minValue, int maxValue)
        {
  

            int intValue;
            string strVal;

            try
            {
                if (value != null)
                {
                    strVal = value as string;

                    if (strVal.Equals(string.Empty))
                    {
                        return true;
                    }

                    intValue = Convert.ToInt32(strVal);

                    if (intValue < minValue || intValue > maxValue)
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }


            return true;
        }

    

        //日期长度验证
        public static bool DateLengthValidation(object value)
        {


            if (value.ToString().Length != 0 &&
                value.ToString().Length != 2 &&
                value.ToString().Length != 4 &&
                value.ToString().Length != 6 &&
                value.ToString().Length != 8)
            {
                return false;
            }

            return true;
        }

        //日期转换验证  
        public static bool DateConvertValidation(object value)
        {
         


            DateTime dateTime;

            String format = null;
            switch (value.ToString().Length)
            {
                case 2:
                    format = "dd";
                    break;
                case 4:
                    format = "MMdd";
                    break;
                case 6:
                    format = "yyMMdd";
                    break;
                case 8:
                    format = "yyyyMMdd";
                    break;
                default:
                    break;
            }

            if (format != null)
            {
                if (!DateTime.TryParseExact(value.ToString(), format, null, DateTimeStyles.AllowLeadingWhite, out dateTime))
                {
                    return false;
                }
            }



            return true;
        }



        //日期范围验证  
        public static bool DateRangeValidation(object value, int minValue, int maxValue)
        {


            int intVal;
            string strVal;
            bool retVal = true;

            try
            {
                if (value != null)
                {
                    strVal = value as string;
             
                    if (strVal.Equals(string.Empty))
                    {
                        retVal = true;
                    }
                    else
                    {
      
                        intVal = Convert.ToInt32(strVal);

                        if (intVal < minValue || intVal > maxValue)
                        {
                            retVal = false;
                        }
                        else
                        {
                            retVal = true;
                        }
                    }
                }
            }
            catch
            {
                retVal = false;
            }
            finally
            {
                
            }

            return retVal;
        }




    }
}
