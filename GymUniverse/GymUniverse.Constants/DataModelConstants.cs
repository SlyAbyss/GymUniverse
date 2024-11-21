using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymUniverse.Constants
{
    /// <summary>
    ///  This class is used to store constants for the data models.
    /// </summary>  
    public static class DataModelConstants
    {
        //Constants for the Location name length
        public const int LocationNameMinLength = 3;
        public const int LocationNameMaxLength = 50;

        //Constants for the Location description length
        public const int LocationDescriptionMinLength = 3;
        public const int LocationDescriptionMaxLength = 500;

        //Constants for the Location address length
        public const int LocationAddressMinLength = 3;
        public const int LocationAddressMaxLength = 150;

        //Constants for the Room name length
        public const int RoomNameMinLength = 3;
        public const int RoomNameMaxLength = 50;

        //Constants for the Room description length
        public const int RoomDescriptionMinLength = 3;
        public const int RoomDescriptionMaxLength = 500;

        //Constants for the Trainer name length
        public const int TrainerNameMinLength = 3;
        public const int TrainerNameMaxLength = 50;

        //Constants for the Trainer age limit
        public const int TrainerAgeMinLimit = 18;
        public const int TrainerAgeMaxLimit = 60;

        //Constants for the Trainer bio length
        public const int TrainerBioMinLength = 3;
        public const int TrainerBioMaxLength = 500;

        //Constants for the Equipment name length
        public const int EquipmentNameMinLength = 3;
        public const int EquipmentNameMaxLength = 50;

        //Constants for the Equipment description length
        public const int EquipmentDescriptionMinLength = 3;
        public const int EquipmentDescriptionMaxLength = 500;

        //Constants for the Course name length
        public const int CourseNameMinLength = 3;
        public const int CourseNameMaxLength = 50;

        //Constants for the Course description length
        public const int CourseDescriptionMinLength = 3;
        public const int CourseDescriptionMaxLength = 500;

        //Constants for the Course price amount
        public const int CoursePriceMinAmount = 20;
        public const int CoursePriceMaxAmount = 150;

        //Constants for the URL length
        public const int UrlMinLength = 3;
        public const int UrlMaxLength = 2048;

        //Constant for the date format
        public const string DateFormat = "dd-MM-yyyy H:mm";
    }
}
