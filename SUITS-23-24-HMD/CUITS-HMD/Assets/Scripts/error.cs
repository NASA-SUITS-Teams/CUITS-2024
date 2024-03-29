using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Profiling;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;
using Newtonsoft.Json;

using TMPro;
using Unity.VisualScripting;
//using static TSS_Serialized.UIAData;
using System;
using System.Xml;


public class error : MonoBehaviour
{
    public TSS_DATA TSS;
    public TMP_Text display;
    public bool oxyError = true;
    public bool fanError = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // heart_rate
        if (TSS.tel.telemetry.eva1.heart_rate > 160) {
            display.text = "Detected heart rate too high: please slow down";
        }

        // suit_pressure_oxy
        if (TSS.tel.telemetry.eva1.suit_oxygen_pressure < 3.5 || TSS.tel.telemetry.eva1.suit_oxygen_pressure > 4.1) {
            display.text = "Swap to secondary oxygen tank";
        }

        // suit_pressure_co2
        if (TSS.tel.telemetry.eva1.suit_co2_pressure > 0.1) {
            display.text = "Scrubber has filled up and must be vented";
        }

        // suit_pressure_other
        if (TSS.tel.telemetry.eva1.suit_other_pressure > 0.5) {
            display.text = "Partial pressure of all gases are not zero";
        }

        // suit_pressure_total
        if (TSS.tel.telemetry.eva1.suit_total_pressure < 3.5 || TSS.tel.telemetry.eva1.suit_total_pressure > 4.5) {
            // suit_pressure_oxy
            if (TSS.tel.telemetry.eva1.suit_oxygen_pressure < 3.5 || TSS.tel.telemetry.eva1.suit_oxygen_pressure > 4.1) {
                display.text = "Swap to secondary oxygen tank";
            }
            // scrubber_a_co2_storage and scrubber_b_co2_storage
            if (TSS.tel.telemetry.eva1.scrubber_a_co2_capacity > 60 || TSS.tel.telemetry.eva1.scrubber_b_co2_capacity > 60) {
                display.text = "Vent collected carbon dioxide";
            }
        }

        // helmet_pressure_co2
        if (TSS.tel.telemetry.eva1.helmet_co2_pressure > 0.15) {
            display.text = "Swap to secondary fan";
        }

        // fan_pri_rpm and fan_sec_rpm
        if (TSS.tel.telemetry.eva1.primary_fan_rpm != 0) {
            if (TSS.tel.telemetry.eva1.primary_fan_rpm != 30000) {
                display.text = "Swap to secondary fan";
            }
        } else if (TSS.tel.telemetry.eva1.secondary_fan_rpm != 0) {
            if (TSS.tel.telemetry.eva1.secondary_fan_rpm != 30000) {
                display.text = "Swap to primary fan";
            }
        }

        // scrubber_a_co2_storage and scrubber_b_co2_storage
        if (TSS.tel.telemetry.eva1.scrubber_a_co2_capacity > 60 || TSS.tel.telemetry.eva1.scrubber_b_co2_capacity > 60) {
            display.text = "Vent collected carbon dioxide";
        }

        // temperature
        if (TSS.tel.telemetry.eva1.temperature > 90) {
            display.text = "Detected temperature too high: please slow down";
        }

    }
}
