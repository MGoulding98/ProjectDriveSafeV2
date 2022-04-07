using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDriveSafeV2.Models
{
    public class Crash
    {
        [Key]
        [Required]
        public int CRASH_ID { get; set; }
        [StringLength(16, ErrorMessage = "Please enter an appropriate date time following the format - MM/DD/YYYY HH:MM")]
        public string CRASH_DATETIME { get; set; }
        [StringLength(7, ErrorMessage = "Too long - Please enter an appropriate route number")]
        public string ROUTE { get; set; }
        [StringLength(12, ErrorMessage = "Too long - Please enter an appropriate milepoint")]
        public string MILEPOINT { get; set; }
        [StringLength(14, ErrorMessage = "Too long - Please enter an appropriate latitude")]
        public string LAT_UTM_Y { get; set; }
        [StringLength(14, ErrorMessage = "Too long - Please enter an appropriate longitude")]
        public string LONG_UTM_X { get; set; }
        [StringLength(75, ErrorMessage = "Too long - Please enter an appropriate road name")]
        public string MAIN_ROAD_NAME { get; set; }
        [StringLength(75, ErrorMessage = "Too long - Please enter an appropriate city name")]
        public string CITY { get; set; }
        [StringLength(30, ErrorMessage = "Too long - Please enter an appropriate county name")]
        public string COUNTY_NAME { get; set; }
        public int CRASH_SEVERITY_ID { get; set; }

        public bool WORK_ZONE_RELATED { get; set; }
        public bool PEDESTRIAN_INVOLVED { get; set; }
        public bool BICYCLIST_INVOLVED { get; set; }
        public bool MOTORCYCLE_INVOLVED { get; set; }
        public bool IMPROPER_RESTRAINT { get; set; }
        public bool UNRESTRAINED { get; set; }
        public bool DUI { get; set; }
        public bool INTERSECTION_RELATED { get; set; }
        public bool WILD_ANIMAL_RELATED { get; set; }
        public bool DOMESTIC_ANIMAL_RELATED { get; set; }
        public bool OVERTURN_ROLLOVER { get; set; }
        public bool COMMERCIAL_MOTOR_VEH_INVOLVED { get; set; }
        public bool TEENAGE_DRIVER_INVOLVED { get; set; }
        public bool OLDER_DRIVER_INVOLVED { get; set; }
        public bool NIGHT_DARK_CONDITION { get; set; }
        public bool SINGLE_VEHICLE { get; set; }
        public bool DISTRACTED_DRIVING { get; set; }
        public bool DROWSY_DRIVING { get; set; }
        public bool ROADWAY_DEPARTURE { get; set; }

    }
}
