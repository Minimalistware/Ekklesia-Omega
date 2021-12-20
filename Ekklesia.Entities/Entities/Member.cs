﻿namespace Ekklesia.Entities.Entities
{
    public class Member : BaseModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public Role Role { get; set; }

        public override bool Equals(object obj)
        {
            Member member = obj as Member;

            if (member == null)
            {
                return false;
            }
            return this.Id.Equals(member.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
