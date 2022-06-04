﻿using Ekklesia.Entities.Entities;

namespace Ekklesia.Entities.DTOs
{
    public class ExpenseDTO
    {
        public string Receipt { get; set; }
        public string Description { get; set; }
        public MemberDTO Responsable { get; set; }

        public ExpenseDTO()
        {
            this.Receipt = string.Empty;
            this.Description = string.Empty;
            this.Responsable = new MemberDTO();
        }
        public Expense ToEntity(params string[] props)
        {
            return new Expense()
            {
                Receipt = this.Receipt,
                Description = this.Description,
                Responsable = this.Responsable.ToEntity(nameof(MemberDTO.Name), nameof(MemberDTO.Id))
            };
        }
    }
}
