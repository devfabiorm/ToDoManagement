﻿using ToDoManagement.Communications.Enums;

namespace ToDoManagement.Communications.Requests;
public class RequestUpdateTaskJson
{
    public required string Name { get; set; }
    public Severity Priority { get; set; }
    public DateOnly Deadline { get; set; }
}
