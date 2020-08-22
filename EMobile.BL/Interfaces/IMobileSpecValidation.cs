using EMobile.BL.Dtos.MobileSpecDtos;
using EMobile.BL.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMobile.BL.Interfaces
{
    public interface IMobileSpecValidation
    {
        Result ValidateCreateModel(MobileSpecCreateDto dto);
    }
}
