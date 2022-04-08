using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace ProjectDriveSafeV2.Models
{
    public class ProjectData
    {
        [Required(ErrorMessage="Question Required")]
        public float pedestrian_involved { get; set; }
        [Required]
        public float bicyclist_involved { get; set; }
        [Required]
        public float motorcycle_involved { get; set; }
        [Required]
        public float unrestrained { get; set; }
        [Required]
        public float dui { get; set; }
        [Required]
        public float overturn_rollover { get; set; }
        [Required]
        public float commercial_motor_veh_involved { get; set; }
        [Required]
        public float older_driver_involved { get; set; }
        [Required]
        public float distracted_driving { get; set; }
        [Required]
        public float drowsy_driving { get; set; }
        [Required]
        public float roadway_departure { get; set; }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
            pedestrian_involved, bicyclist_involved, motorcycle_involved, unrestrained, dui, overturn_rollover,
            commercial_motor_veh_involved, older_driver_involved, distracted_driving, drowsy_driving, roadway_departure
            };
            int[] dimensions = new int[] { 1, 11 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}
