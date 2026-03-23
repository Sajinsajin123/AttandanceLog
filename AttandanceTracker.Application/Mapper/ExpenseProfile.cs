using AttandanceTracker.Application.Dto;
using AttandanceTracker.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttandanceTracker.Application.Mapper
{
    public class ExpenseProfile:Profile
    {
        public ExpenseProfile() 
        {
            CreateMap<RoleDto, Role>().ReverseMap();
            CreateMap<AttandanceDto, Attendance>().ReverseMap();
        }
    }
}
