﻿namespace PropertyManagementSystem.Models.DTO
{
    public class RequestCreateDto
    {
        public int TenandId { get; set; }
        public int PropertyId { get; set; }
        public DateTime MoveIn { get; set; }
        public DateTime MoveOut { get; set; }
        public int IsAccepted { get; set; }
    }
}
