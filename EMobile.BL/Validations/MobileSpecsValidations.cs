using EMobile.BL.Dtos.MobileSpecDtos;
using EMobile.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EMobile.BL.Validations
{
    public class MobileSpecsValidations : IMobileSpecValidation
    {
        public Result ValidateCreateModel(MobileSpecCreateDto dto)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(dto.Base64Image);
                MemoryStream fileStream = new MemoryStream(bytes);
            }
            catch (Exception e)
            {
                return new Result { IsValid = false, ErrorMessage = e.Message};
            }
            return new Result { IsValid = true};
        }
    }
}
