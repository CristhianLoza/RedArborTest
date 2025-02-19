﻿using System;
using System.Collections.Generic;

namespace ms_source_put.Infraestructure.Entities.Employee
{
    public partial class Employee
    {
        public int UserId { get; set; }
        public int? CompanyId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? Email { get; set; }
        public int? Fax { get; set; }
        public string? Name { get; set; }
        public DateTime? Lastlogin { get; set; }
        public string? Password { get; set; }
        public int? PortalId { get; set; }
        public int? RoleId { get; set; }
        public int? StatusId { get; set; }
        public int? Telephone { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? Username { get; set; }
    }
}
