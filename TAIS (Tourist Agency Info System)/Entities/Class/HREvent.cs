using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAIS__Tourist_Agency_Info_System_.Entities.Interfaces;
using TAIS__Tourist_Agency_Info_System_.Entities.Enums;

namespace TAIS__Tourist_Agency_Info_System_.Entities.Class
{
    public class HREvent : BaseEntity
    {
        public HREvent(int id, DateTime eventDate, int workPlaceStreetId, TypeEvent eventType, string profession,
                       string department, string documentType, string reason, int positionId, int employeeId, string orgName)
        {
            Id = id;
            EventDate = eventDate;
            WorkPlaceStreetId = workPlaceStreetId;
            EventType = eventType;
            Profession = profession;
            Department = department;
            DocumentType = documentType;
            Reason = reason;
            PositionId = positionId;
            EmployeeId = employeeId;
        }

        private int _workPlaceStreetId;
        private string _profession;
        private string _department;
        private string _documentType;
        private string _reason;
        private int _positionId;
        private int _employeeId;
        private string _orgName;

        [Required(ErrorMessage = "Дата мероприятия обязательна")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Место работы обязательно")]
        [Range(1, int.MaxValue, ErrorMessage = "WorkPlaceStreetId должен быть положительным")]
        public int WorkPlaceStreetId
        {
            get => _workPlaceStreetId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "WorkPlaceStreetId должен быть положительным");
                _workPlaceStreetId = value;
            }
        }
        public virtual Street WorkPlace { get; set; }

        public TypeEvent EventType { get; set; }

        [MinLength(1, ErrorMessage = "Профессия не должна быть пусто")]
        public string Profession
        {
            get => _profession;
            set
            {
                if (!string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Профессия не должна быть пусто", nameof(value));
                _profession = value;
            }
        }

        [MinLength(1, ErrorMessage = "Отдел не должен быть пусто")]
        public string Department
        {
            get => _department;
            set
            {
                if (!string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Отдел не должен быть пусто", nameof(value));
                _department = value;
            }
        }

        [MinLength(1, ErrorMessage = "Имя организации не должно быть пусто")]
        public string OrgName
        {
            get => _orgName;
            set
            {
                if (!string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Имя организации не должно быть пусто", nameof(value));
                _orgName = value;
            }
        }

        [Required(ErrorMessage = "Тип документа обязателен")]
        public string DocumentType
        {
            get => _documentType;
            set => _documentType = value;
        }

        [MinLength(1, ErrorMessage = "Причина не должна быть пусто")]
        public string Reason
        {
            get => _reason;
            set
            {
                if (!string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Причина не должна быть пусто", nameof(value));
                _reason = value;
            }
        }

        [Range(1, int.MaxValue, ErrorMessage = "PositionId должен быть положительным")]
        public int PositionId
        {
            get => _positionId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "PositionId должен быть положительным");
                _positionId = value;
            }
        }
        public virtual Position Position { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "EmployeeId должен быть положительным")]
        public int EmployeeId
        {
            get => _employeeId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "EmployeeId должен быть положительным");
                _employeeId = value;
            }
        }
        public virtual Employee Employee { get; set; }
    }
}
