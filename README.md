# iXM-50/100 Camera Configuration for MAVLink

Phase One's Camera SDK application for configuring an iXM-50/100 as a MAVLink camera or as part of the P3 Payload for MAVLink.

For more information about the Camera SDK, go to https://geospatial.phaseone.com/resources-support/developer/sdk

For more information about the P3 Payload for Drones, go to https://geospatial.phaseone.com/drone-payload

# Requirements

* Windows 10/11
* iX Capture and Capture One have to be closed

# Usage

* Download the latest release from https://github.com/PhaseOnePhoto/CameraConfigForMavlink/releases
* Extract the downloaded .zip folder
* Connect the computer directly to the USB-C port on the back of the camera
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
