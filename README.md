# Hash StudentID Sample
Sample code to demonstrate how to hash a StudentID into an an AlternateSSID suitable for use in de-identified student data.

There are fewer than 50 functional lines of code. This is very easy to incorporate into a larger system.

## Platform Notes
The code is written in C# and makes use of the cryptographic library in Microsoft .Net. Other platforms have equivalent libraries. For example, [here is a sample in Java](http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/AuthJavaSampleHMACSignature.html).

## Build Notes
Built using the free Microsoft Visual Studio Express 2013 for Windows Desktop.