WinForms project

Resizable `UserControl` controls. Interface TBC

# Condor UDP Data Packet Format

The UDP data packet from Condor contains various telemetry parameters encoded as key-value pairs. Each parameter is followed by `=` and its value. Values are transmitted in ASCII format and use `.` as the decimal separator. The following is a reference for each parameter, its expected data type, and unit.
Same names are used in the json passed to the control 
## General Information

- **Format**: `parameter=value`
- **Data Type**: All values are floating-point (`float`).
- **Decimal Separator**: `.`

## Note
Most probable units - TBC when we got the condor

## Parameters

| Parameter          | Description                           | Data Type | Unit               |
|--------------------|---------------------------------------|-----------|--------------------|
| `time`             | Time in-game                          | `float`   | Hours (decimal)    |
| `airspeed`         | Current airspeed                      | `float`   | m/s                |
| `altitude`         | Altimeter reading                     | `float`   | Meters or feet     |
| `vario`            | Pneumatic variometer reading          | `float`   | m/s                |
| `evario`           | Electronic variometer reading         | `float`   | m/s                |
| `nettovario`       | Netto variometer value                | `float`   | m/s                |
| `integrator`       | Integrator value                      | `float`   | m/s                |
| `compass`          | Compass heading                       | `float`   | Degrees            |
| `slipball`         | Slip ball deflection angle            | `float`   | Radians            |
| `turnrate`         | Turn indicator reading                | `float`   | Radians/s          |
| `yawstringangle`   | Yaw string angle                      | `float`   | Radians            |
| `radiofrequency`   | Active radio frequency                | `float`   | MHz                |
| `yaw`              | Yaw angle                             | `float`   | Radians            |
| `pitch`            | Pitch angle                           | `float`   | Radians            |
| `bank`             | Bank angle                            | `float`   | Radians            |
| `quaternionx`      | Quaternion X component                | `float`   | Unitless           |
| `quaterniony`      | Quaternion Y component                | `float`   | Unitless           |
| `quaternionz`      | Quaternion Z component                | `float`   | Unitless           |
| `quaternionw`      | Quaternion W component                | `float`   | Unitless           |
| `ax`               | Acceleration in X                     | `float`   | m/s²               |
| `ay`               | Acceleration in Y                     | `float`   | m/s²               |
| `az`               | Acceleration in Z                     | `float`   | m/s²               |
| `vx`               | Speed vector in X                     | `float`   | m/s                |
| `vy`               | Speed vector in Y                     | `float`   | m/s                |
| `vz`               | Speed vector in Z                     | `float`   | m/s                |
| `rollrate`         | Roll rate                             | `float`   | Radians/s          |
| `pitchrate`        | Pitch rate                            | `float`   | Radians/s          |
| `yawrate`          | Yaw rate                              | `float`   | Radians/s          |
| `gforce`           | G-force factor                        | `float`   | Unitless           |
| `height`           | Height of CG above ground             | `float`   | Meters             |
| `wheelheight`      | Height of wheel above ground          | `float`   | Meters             |
| `turbulencestrength` | Turbulence strength                | `float`   | Unitless           |
| `surfaceroughness` | Surface roughness factor              | `float`   | Unitless           |
| `MC`               | MacCready setting                     | `float`   | m/s                |
| `water`            | Water ballast content                 | `float`   | Kilograms          |

## Example Message

```plaintext
time=12.000;airspeed=0.143;altitude=505.879;vario=-0.014;evario=-0.007;nettovario=-1.037;integrator=-1.18E-5;compass=0;slipball=0.001;turnrate=0.0002;yawstringangle=-0.185;radiofrequency=123.5;yaw=2.52;pitch=0.0003;bank=0.0019;quaternionx=-0.0004;quaterniony=0.001;quaternionz=0.89;quaternionw=0.457;ax=-0.413;ay=0.269;az=-1.886;vx=-0.0204;vy=0.014;vz=-0.292;rollrate=-0.0404;pitchrate=0.0143;yawrate=0.0009;gforce=0.808;height=0.598;wheelheight=-0.008;turbulencestrength=0.633;surfaceroughness=1;MC=0;water=0
```

##example JSON passed to the control callback

```JSON
{
  "time": 12.00004984575,
  "airspeed": 0.142668262124062,
  "altitude": 505.87939453125,
  "vario": -0.014398168772459,
  "evario": -0.00719908438622952,
  "nettovario": -1.03678393363953,
  "integrator": -1.18489970191149E-5,
  "compass": 0,
  "slipball": 0.00068375573027879,
  "turnrate": 0.000172436964930966,
  "yawstringangle": -0.185256719589233,
  "radiofrequency": 123.5,
  "yaw": 2.519366979599,
  "pitch": 0.000253545062150806,
  "bank": 0.00189110543578863,
  "quaternionx": -0.000370573019608855,
  "quaterniony": 0.000999429263174534,
  "quaternionz": 0.889618754386902,
  "quaternionw": 0.456702500581741,
  "ax": -0.412550836801529,
  "ay": 0.269427478313446,
  "az": -1.88640642166138,
  "vx": -0.0203692372888327,
  "vy": 0.0139364199712873,
  "vz": -0.291596084833145,
  "rollrate": -0.0404090695083141,
  "pitchrate": 0.0143251251429319,
  "yawrate": 0.000873061420861632,
  "gforce": 0.807797823720265,
  "height": 0.597808837890625,
  "wheelheight": -0.00763431470841169,
  "turbulencestrength": 0.633376657962799,
  "surfaceroughness": 1,
  "MC": 0,
  "water": 0
}
```