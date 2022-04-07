using System;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace ProjectDriveSafeV2.Models
{
    public class ProjectData
    {
        public float pedestrian_involved { get; set; }
        public float bicyclist_involved { get; set; }
        public float motorcycle_involved { get; set; }
        public float unrestrained { get; set; }
        public float dui { get; set; }
        public float overturn_rollover { get; set; }
        public float commercial_motor_veh_involved { get; set; }
        public float older_driver_involved { get; set; }
        public float distracted_driving { get; set; }
        public float drowsy_driving { get; set; }
        public float roadway_departure { get; set; }
        public float crash_severity_id { get; set; }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
            pedestrian_involved, bicyclist_involved, motorcycle_involved, unrestrained, dui, overturn_rollover,
            commercial_motor_veh_involved, older_driver_involved, distracted_driving, drowsy_driving, roadway_departure,
            crash_severity_id
            };
            int[] dimensions = new int[] { 1, 12 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}
