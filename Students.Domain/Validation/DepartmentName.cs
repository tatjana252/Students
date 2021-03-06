﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Students.Domain.Validation
{
    public class DepartmentName : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string s)
            {
                if(s.Length < 3)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
