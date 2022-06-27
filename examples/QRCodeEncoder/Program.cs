using System.Text;
using Microsoft.Extensions.DependencyInjection;
using QRCodeEncoderLibrary;

var services = new ServiceCollection();
services.AddQRCodeEncoder();

var serviceProvider = services.BuildServiceProvider();

var qrCodeEncoder = serviceProvider.GetRequiredService<QRCodeEncoder>();

// Version: 9 (53 x 53)
// Mask Pattern: 2
// Error Correction Level : 15% Error Correction (M)
// Character Set: ISO-8859-1 (Latin 1)
const string data = "2KjZh9mG2KfYsiAgICAg2YXYs9mE2YXZiiAgICAgICAgIDE0MDEvMDMvMTE1ODI3NTQwMjIgNDUwNCAzNzEgIDE5NzMxMDc0MDM2NDYxNyA=";

qrCodeEncoder.Encode(data, Encoding.Latin1, 2, 9);
using var ms = new MemoryStream();
qrCodeEncoder.SaveQRCodeToPngFile(ms);
var bytes = ms.ToArray();
var qrCode2 = Convert.ToBase64String(bytes);
Console.WriteLine(qrCode2);