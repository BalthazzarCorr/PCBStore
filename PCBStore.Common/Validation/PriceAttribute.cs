namespace PCBStore.Common.Validation
{
   using System;
   using System.ComponentModel.DataAnnotations;

   [AttributeUsage(AttributeTargets.Property)]
   public class PriceAttribute : ValidationAttribute
   {
      public override bool IsValid(object value)
      {
         decimal price = 0;

         if (value is null || !decimal.TryParse(value.ToString(), out price))
         {
            return false;
         }

         return price > 0m;
      }
   }
}
