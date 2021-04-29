using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace KeyboardProjectAppSimple.Models
{
    public partial class KeyboardProject
    {
        private decimal projectPrice;

        [DisplayName("Project ID")]
        public int ProjectId { get; set; }

        [DisplayName("Project Name")]
        public string ProjectName { get; set; }

        [DisplayName("Keyboard Case")]
        public string ProjectKeyboardCase { get; set; }

        [DisplayName("Keyboard Case Price")]
        public decimal ProjectKeyboardCasePrice { get; set; }

        [DisplayName("Switchplate")]
        public string ProjectSwitchplate { get; set; }

        [DisplayName("Switchplate Price")]
        public decimal ProjectSwitchplatePrice { get; set; }

        [DisplayName("PCB")]
        public string ProjectPcb { get; set; }

        [DisplayName("PCB Price")]
        public decimal ProjectPcbPrice { get; set; }

        [DisplayName("Switch")]
        public string ProjectSwitch { get; set; }

        [DisplayName("Number of Switches")]
        public int ProjectSwitchQuant { get; set; }

        [DisplayName("Switch Price")]
        public decimal ProjectSwitchPrice { get; set; }

        [DisplayName("Keycaps")]
        public string ProjectKeycap { get; set; }

        [DisplayName("Number of Keycaps")]
        public int ProjectKeycapQuant { get; set; }

        [DisplayName("Keycap Price")]
        public decimal ProjectKeycapPrice { get; set; }

        [DisplayName("Stabilizer")]
        public string ProjectStabilizer { get; set; }

        [DisplayName("Stabilizer Price")]
        public decimal ProjectStabilizerPrice { get; set; }

        [DisplayName("Total Project Cost")]
        public decimal ProjectPrice => ProjectCost();

        public decimal ProjectCost()
        {
            decimal switchTotal = ProjectSwitchQuant * ProjectSwitchPrice;
            decimal keycapTotal = ProjectKeycapQuant * ProjectKeycapPrice;
            decimal projectCost = ProjectKeyboardCasePrice + ProjectSwitchplatePrice + ProjectPcbPrice + switchTotal + keycapTotal + ProjectStabilizerPrice;

            return projectCost;
        }

    }
}
