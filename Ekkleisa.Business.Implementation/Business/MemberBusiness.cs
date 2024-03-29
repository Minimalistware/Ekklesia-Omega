﻿using AutoMapper;
using Ekkleisa.Business.Contract.IBusiness;
using Ekkleisa.Business.Implementation.Validations;
using Ekkleisa.Repository.Contract.IRepositories;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Microsoft.Extensions.Logging;
using System;

namespace Ekkleisa.Business.Implementation.Business
{
    public class MemberBusiness : BusinessCrud<Member, MemberDTO>, IMemberBusiness, IDisposable
    {
        public MemberBusiness(IMemberRepository memberRepository, IMapper mapper, MemberValidation validations, ILogger<MemberBusiness> logger) :
            base(memberRepository, mapper, validations, logger)
        {
        }

        public void Dispose()
        {

        }
    }
}
