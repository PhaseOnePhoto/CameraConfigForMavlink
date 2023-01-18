﻿

/* MIT License Copyright (c) 2022 Phase One A/S

Contributors:
 - David Wuthier (dwu@phaseone.com)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is furnished
to do so, subject to the following conditions:

The above copyright notice and this permission notice (including the next
paragraph) shall be included in all copies or substantial portions of the
Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS
OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF
OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. */


using System;
using System.Threading;
using System.Collections.Generic;
using P1.CameraSdk;


namespace CameraConfigForMavlink
{
    class Program
    {
        static void Main(string[] args)
        {
            Camera camera = null;

            ConnectCamera(ref camera);

            if (camera is not null && CheckFirmwareVersion(camera, "5.05.23"))
            {
                SetEnumProperty(camera, 260, 4);
                SetEnumProperty(camera, 256, 3);
                SetEnumProperty(camera, 142, 4);
                SetEnumProperty(camera, 1248, 0);
            }

            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }

        static void SetEnumProperty(Camera camera, uint id, uint value)
        {
            try
            {
                PropertySpec propertySpec = camera.GetPropertySpec(id);

                if (propertySpec.Value.IntValue == value)
                {
                    Console.WriteLine("{0} (property {1}) already set to {2} (index {3})",
                        propertySpec.Name,
                        id,
                        propertySpec.Value.PresentationString,
                        propertySpec.Value.IntValue);
                }
                else
                {
                    Console.WriteLine("{0} (property {1}) was set to {2} (index {3})",
                        propertySpec.Name,
                        id,
                        propertySpec.Value.PresentationString,
                        propertySpec.Value.IntValue);

                    while (propertySpec.Value.IntValue != value)
                    {
                        propertySpec.Value.IntValue = value;

                        camera.SetProperty(id, propertySpec.Value);

                        Thread.Sleep(100);

                        propertySpec = camera.GetPropertySpec(id);

                        Console.WriteLine("{0} (property {1}) now set to {2} (index {3})",
                            propertySpec.Name,
                            id,
                            propertySpec.Value.PresentationString,
                            propertySpec.Value.IntValue);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not set property {id} to {value} ({e.Message})");

                return;
            }
        }

        static bool CheckFirmwareVersion(Camera camera, string requiredFirmwareVersion)
        {
            bool success = false;

            try
            {
                PropertyValue firmwareVersion = camera.GetProperty(4);

                if (firmwareVersion.ToString() == requiredFirmwareVersion)
                {
                    Console.WriteLine($"Camera firmware version verified ({requiredFirmwareVersion})");

                    success = true;
                }
                else
                {
                    Console.WriteLine($"Please flash camera firmware {requiredFirmwareVersion}");
                }
            }
            catch
            {
                Console.WriteLine("Could not check camera firmware version.");
            }

            return success;
        }

        static void ConnectCamera(ref Camera camera)
        {
            try
            {
                camera = Camera.OpenUsbCamera();
            }
            catch
            {
                Console.WriteLine($"Could not connect to camera.");

                return;
            }

            Console.WriteLine("Camera connected");
        }

        static void ListProperties(Camera camera)
        {
            Console.WriteLine("Get a list of available properties");
            IEnumerable<uint> propertyIdList = camera.GetAllPropertyIds();
            // Iterate through list of PropertyIds
            foreach (uint propertyId in propertyIdList)
            {
                PropertySpec propertySpec = camera.GetPropertySpec(propertyId);
                PropertyValue propertyValue = camera.GetProperty(propertyId);
                Console.WriteLine("{0}|{1}|{2}|{3}",
                propertyId,
                propertySpec.Name,
                propertyValue.Type,
                propertyValue.ToString()
                );
            }
        }
    }
}
