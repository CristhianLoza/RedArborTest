﻿using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TableAttribute = Dapper.Contrib.Extensions.TableAttribute;

namespace ms_source_get.Domain.Dto
{
    [Table("Employee")]
    public partial class Employee
    {
        [ExplicitKey]
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
