using System;
using System.Collections.Generic;

namespace WebAppMenu.Models
{
    public class Table_Access
    {
        public Table_Access()
        {
            this.Table_Access1 = new HashSet<Table_Access>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string MenuName { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> Status { get; set; }

        public virtual ICollection<Table_Access> Table_Access1 { get; set; }
        public virtual Table_Access Parent { get; set; }
    }
}
