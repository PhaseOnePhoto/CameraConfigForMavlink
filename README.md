# iXM-50/100 Camera Configuration for MAVLink

Application of Phase One's Camera SDK for configuring an iXM-50/100 as a MAVLink camera or as part of the P3 Payload for MAVLink.

For more information about the Camera SDK, go to https://geospatial.phaseone.com/resources-support/developer/sdk

For more information about the P3 Payload for Drones, go to https://geospatial.phaseone.com/drone-payload

# Requirements

This application has to be run on a Windows computer and requires a USB-C to USB-A (or USB-C to USB-C) cable.

# Usage

* Download the latest release from https://github.com/PhaseOnePhoto/CameraConfigForMavlink/releases
* Extract the downloaded .zip folder
* Connect the computer directly to the back of the camera via USB.
* Power on the camera
* Run `CameraConfigForMavlink.exe`

# Building the code

* Install Visual Studio 2022 including .NET 6 (https://visualstudio.microsoft.com/vs/community)
* Install git (https://git-scm.com/downloads)
* Open a PowerShell terminal
* Clone this repository: `git clone https://github.com/PhaseOnePhoto/CameraConfigForMavlink.git`
* `cd` to this repository: `cd .\CameraConfigForMalvink\`
* build the code: `dotnet build`
* `cd` to the folder containing the binary executable file: `cd .\bin\Debug\net6.0\win-x64\`
* Run the application: `.\CameraConfigForMavlink.exe`

# Known limitations

* If iX Capture or Capture One has been connected before, the camera needs to be rebooted.
