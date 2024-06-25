using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TeamTaskManagment.Models;

[Table("Taskd")]
public partial class Taskd
{
    [Key]
    [Column("taskID")]
    public Guid TaskId { get; set; }

    [Column("taskName")]
    [StringLength(100)]
    public string? TaskName { get; set; }

    [Column("taskDueDate", TypeName = "datetime")]
    public DateTime TaskDueDate { get; set; }

    [Column("CategoryID")]
    public int CategoryId { get; set; }

    [Column("StatusID")]
    public int StatusId { get; set; }

    [Column("taskDescription")]
    [StringLength(550)]
    public string? TaskDescription { get; set; }
}
