using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TeamTaskManagment.Models;

[Table("TaskHistory")]
public partial class TaskHistory
{
    [Key]
    [Column("taskHistoryID")]
    public int TaskHistoryId { get; set; }

    [Column("taskID")]
    public int? TaskId { get; set; }

    [Column("taskName")]
    [StringLength(100)]
    public string? TaskName { get; set; }

    [Column("taskDueDate", TypeName = "datetime")]
    public DateTime? TaskDueDate { get; set; }

    [Column("CategoryID")]
    public int? CategoryId { get; set; }

    [Column("StatusID")]
    public int? StatusId { get; set; }

    [Column("taskDescription")]
    [StringLength(550)]
    public string? TaskDescription { get; set; }

    [Column("taskHDateTime", TypeName = "datetime")]
    public DateTime? TaskHdateTime { get; set; }
}
