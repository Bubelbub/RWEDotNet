using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWE.NET.Entity
{
    public class RoomTemperatureActuatorState : LogicalDeviceState
    {
        double pointTemperature;
        string operationMode;
        bool windowReductionActive;

        public double PointTemperature
        {
            get
            { 
                return pointTemperature; 
            }
            set 
            {
                if(value != pointTemperature)
                    OnPropertyChanged(value);

                pointTemperature = value;
            }
        }

        public string OperationMode
        {
            get 
            { 
                return operationMode;
            }

            set 
            {
                if (value != operationMode)
                    OnPropertyChanged(value);
                operationMode = value;
            }
        }

        public bool WindowReductionActive
        {
            get 
            { 
                return windowReductionActive;
            }

            set
            {
                OnPropertyChanged(value);
                windowReductionActive = value; 
            }
        }



    }
}
