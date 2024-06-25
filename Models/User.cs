using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TeamTaskManagment.Models;

public partial class User
{
    [Key]
    [Column("User_ID")]
    public int UserId { get; set; }

    [Column("User_FName")]
    [StringLength(50)]
    public string? UserFname { get; set; }

    [Column("User_LName")]
    [StringLength(50)]
    public string? UserLname { get; set; }

    [Column("User_UN")]
    [StringLength(50)]
    public string? UserUn { get; set; }

    [Column("User_PW")]
    [StringLength(50)]
    public string? UserPw { get; set; }

    [Column("User_AccessType")]
    public int? UserAccessType { get; set; }

    [Column("User_EMail")]
    [StringLength(50)]
    public string? UserEmail { get; set; }
}
